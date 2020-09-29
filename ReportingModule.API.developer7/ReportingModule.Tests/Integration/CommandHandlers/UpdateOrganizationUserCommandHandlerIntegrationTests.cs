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
    public class UpdateOrganizationCommandHandlerIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                //DomainDatabase.ClearAllTables(s);

                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [TestCase(OrganizationType.Central, ReportingFrequency.Yearly)]
        [TestCase(OrganizationType.Central, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.State, ReportingFrequency.Yearly)]
        [TestCase(OrganizationType.State, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.Zone, ReportingFrequency.Yearly)]
        [TestCase(OrganizationType.Zone, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.Unit, ReportingFrequency.Monthly)]
        public async Task Handle_SavesRecord(OrganizationType newOrganizationType, ReportingFrequency newReportingFrequency)
        {
            var now = DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();


            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var org = new OrganizationBuilder().BuildAndPersist(s);

                    EntityReference parent;
                    switch (newOrganizationType)
                    {
                        case OrganizationType.State:
                            parent = new OrganizationBuilder().SetOrganizationType(OrganizationType.Central).BuildAndPersist(s);
                            break;
                        case OrganizationType.Zone:
                        case OrganizationType.Unit:
                            parent = new OrganizationBuilder().SetOrganizationType(OrganizationType.State).BuildAndPersist(s);
                            break;
                        default:
                            parent = new OrganizationBuilder().SetOrganizationType(OrganizationType.Central).BuildAndPersist(s);
                            break;
                    }

                    var newDescription = DataProvider.Get<string>();
                    var newDetails = DataProvider.Get<string>();

                    var expectedEvt = Test.CreateInstance<IOrganizationUpdated>(e =>
                    {
                        e.Organization = new OrganizationReference(org.Id, newOrganizationType, newDescription, newDetails, newReportingFrequency);
                        e.Username = username;
                    });

                    return new
                    {
                        username,
                        expectedEvt,
                        Cmd = new UpdateOrganizationCommand(org.Id, newDescription, newDetails, newOrganizationType, newReportingFrequency, parent)
                    };
                });

            var context = await Endpoint.Act<UpdateOrganizationCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<IOrganizationUpdated>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organization = s.Query<Organization>().Single(x=>x.Id == testParams.Cmd.OrganizationId);
                    organization.Should().NotBeNull();
                    organization.OrganizationType.Should().Be(testParams.Cmd.OrganizationType);
                    organization.ReportingFrequency.Should().Be(testParams.Cmd.ReportingFrequency);
                    organization.Description.Should().Be(testParams.Cmd.Description);
                    organization.Details.Should().Be(testParams.Cmd.Details);
                    organization.Parent.Should().Be(testParams.Cmd.Parent);
                    organization.Timestamp.Should().Be(now);
                    organization.IsDeleted.Should().Be(false);

                });

            evt.Should().BeEquivalentTo(testParams.expectedEvt, e => e.Excluding(p => p.SerializedData));
            evt.SerializedData.Should().NotBe(null);
        }


        [TestCase(OrganizationType.Central, ReportingFrequency.Yearly)]
        [TestCase(OrganizationType.Central, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.State, ReportingFrequency.Yearly)]
        [TestCase(OrganizationType.State, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.Zone, ReportingFrequency.Yearly)]
        [TestCase(OrganizationType.Zone, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.Unit, ReportingFrequency.Monthly)]
        public async Task Handle_RaisesFailedEvent_WhenParentIsSameOrganization(OrganizationType newOrganizationType, ReportingFrequency newReportingFrequency)
        {
            var now = DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();


            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var org = new OrganizationBuilder().BuildAndPersist(s);

                    EntityReference parent = org;
                    var newDescription = DataProvider.Get<string>();
                    var newDetails = DataProvider.Get<string>();

                    var expectedEvt = Test.CreateInstance<IOrganizationUpdateFailed>(e =>
                    {
                        e.Errors = new string[]{ $"unable to add same organization as Parent organization" };
                    });

                    return new
                    {
                        username,
                        expectedEvt,
                        Cmd = new UpdateOrganizationCommand(org.Id, newDescription, newDetails, newOrganizationType, newReportingFrequency, parent),
                        org
                    };
                });

            var context = await Endpoint.Act<UpdateOrganizationCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<IOrganizationUpdateFailed>();


            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organization = s.Query<Organization>().SingleOrDefault();
                    organization.Should().NotBeNull();
                    organization.Should().BeEquivalentTo(testParams.org);
                });

            evt.Should().BeEquivalentTo(testParams.expectedEvt);

        }

    }
}