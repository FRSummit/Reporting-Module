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
    public class DeleteOrganizationUserCommandHandlerIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [Test]
        public async Task Handle_DeletesOrganizationUser()
        {
            var deletedByusername = DataProvider.Get<string>();
            var username = DataProvider.Get<string>();
            var role = DataProvider.Get<string>();
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var org = new OrganizationBuilder().BuildAndPersist(s);
                    var organizationUser = new TestObjectBuilder<OrganizationUser>()
                        .SetArgument(o => o.Username, username)
                        .SetArgument(o => o.Role, role)
                        .SetArgument(o => o.Organization, org)
                        .BuildAndPersist(s);
                    return new
                    {
                        deletedByusername,
                        cmd = new DeleteOrganizationUserCommand(organizationUser.Id)
                    };
                });


            await Endpoint.Act<DeleteOrganizationUserCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                {

                    ctx.SetUsernameOnHeader(testParams.deletedByusername);
                    return h.Handle(testParams.cmd, ctx);
                });

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Get<OrganizationUser>(testParams.cmd.OrganizationUserId);
                    report.Should().BeNull();
                });
        }
    }
}