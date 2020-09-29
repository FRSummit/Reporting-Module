using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NServiceBus.Testing;
using NUnit.Framework;
using ReportingModule.CommandHandlers;
using ReportingModule.Commands;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.Events;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.CommandHandlers
{
    [TestFixture(Category = "Integration")]
    public class CreateOrganizationCommandHandlerIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [Theory]
        public async Task Handle_SavesRecord(OrganizationType organizationType, ReportingFrequency reportingFrequency)
        {
            var username = DataProvider.Get<string>();

            var description = DataProvider.Get<string>();
            var details = DataProvider.Get<string>();
            var parent = DataProvider.Get<EntityReference>();
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var expected = new OrganizationBuilder()
                .SetDescription(description)
                .SetDetails(details)
                .SetParent(parent)
                .SetOrganizationType(organizationType)
                .SetReportingFreQuency(reportingFrequency)
                .Build();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s => new
                {
                    Cmd = new CreateOrganizationCommand(description, details, organizationType, reportingFrequency, parent),
                    username,
                    expected
                });

            var context = await Endpoint.Act<CreateOrganizationCommandHandler>(
                AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                {
                    ctx.SetUsernameOnHeader(testParams.username);
                    return h.Handle(testParams.Cmd, ctx);
                });
            var evt = context.ExpectPublish<IOrganizationCreated>();
            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var org = s.Query<Organization>().Single();
                    org.Should().NotBeNull();
                    org.Should().BeEquivalentTo(testParams.expected, e => e.Excluding(p => p.Id));

                    OrganizationReference orgRef = org;
                    var expectedEvt = Test.CreateInstance<IOrganizationCreated>(e =>
                    {
                        e.Organization = orgRef;
                        e.Username = testParams.username;
                    });

                    evt.Should().BeEquivalentTo(expectedEvt, e => e.Excluding(p => p.SerializedData));
                    evt.SerializedData.Should().NotBe(null);
                });
        }

    }
}