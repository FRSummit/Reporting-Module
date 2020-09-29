using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using ReportingModule.CommandHandlers;
using ReportingModule.Commands;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;

namespace ReportingModule.Tests.Integration.CommandHandlers
{
    [TestFixture(Category = "Integration")]
    public class DeleteOrganizationCommandHandlerIntegrationTests
    {
        [Test]
        public async Task Handle_DeletesOrganization()
        {
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();

                    var organization = new OrganizationBuilder().BuildAndPersist(s);
                    return new
                    {
                        username,
                        cmd = new DeleteOrganizationCommand(organization.Id)
                    };
                });

            await Endpoint.Act<DeleteOrganizationCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                {
                    ctx.SetUsernameOnHeader(testParams.username);
                    return h.Handle(testParams.cmd, ctx);
                });

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organization = s.Get<Organization>(testParams.cmd.OrganizationId);
                    organization.Should().BeNull();
                });
        }
    }
}