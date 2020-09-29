﻿using System.Linq;
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
    public class CreateStatePlanCommandHandlerIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [TestCase(ReportingFrequency.Yearly)]
        [TestCase(ReportingFrequency.Quarterly)]
        public async Task Handle_SavesStateReport(ReportingFrequency reportingFrequency)
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, OrganizationType.State)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    var cmd = new CreateStatePlanCommand(organization, year, reportingTerm, reportingFrequency);
                    var description = cmd.Description;
                    var expected = new StateReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .Build();

                    return new
                    {
                        Cmd = cmd,
                        Organization = organization,
                        username,
                        expected
                    };
                });

            var context = await Endpoint.Act<CreateStatePlanCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<IStatePlanCreated>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Query<StateReport>().Single();
                    report.Should().NotBeNull();
                    report.Should().BeEquivalentTo(testParams.expected, e => e.Excluding(p => p.Id));
                    report.ReportingPeriod.Should().BeEquivalentTo(testParams.expected.ReportingPeriod);

                    EntityReference reportRef = report;

                    var expectedEvt = Test.CreateInstance<IStatePlanCreated>(e =>
                    {
                        e.Organization = testParams.expected.Organization;
                        e.Username = testParams.username;
                        e.StateReport = reportRef;
                    });

                    evt.Should().BeEquivalentTo(expectedEvt, e => e.Excluding(p => p.SerializedData));
                    evt.SerializedData.Should().NotBe(null);
                });
        }

        [TestCase(ReportingFrequency.Yearly)]
        [TestCase(ReportingFrequency.Quarterly)]
        public async Task Handle_DoNotSavesUnitReport_WhenDuplicate(ReportingFrequency reportingFrequency)
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, OrganizationType.State)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    var duplicate = new StateReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .BuildAndPersist(s);
                    return new
                    {
                        Cmd = new CreateStatePlanCommand(organization, year, reportingTerm, reportingFrequency),
                        username,
                        duplicate
                    };
                });

            var context = await Endpoint.Act<CreateStatePlanCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<IStatePlanCreateFailed>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Query<StateReport>().Single();
                    report.Should().NotBeNull();
                    report.Should().BeEquivalentTo(testParams.duplicate);
                    evt.Errors[0].Should().Contain(testParams.duplicate.Description);
                });
        }
    }
}