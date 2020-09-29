using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NServiceBus.Testing;
using NUnit.Framework;
using ReportingModule.CommandHandlers;
using ReportingModule.Commands;
using ReportingModule.Common;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.Events;
using ReportingModule.Services.Impl;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.CommandHandlers
{
    [TestFixture(Category = "Integration")]
    public class CopyUnitPlanCommandHandlerIntegrationTests
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

        [TestCase(ReportingFrequency.Monthly)]
        public async Task Handle_SavesUnitReport(ReportingFrequency reportingFrequency)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, OrganizationType.Unit)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    var existing = new UnitReportBuilder()
                        .SetDescription(DataProvider.Get<string>())
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .BuildAndPersist(s);
                    var newReportYear = year + 1;
                    var cmd = new CopyUnitPlanCommand(existing.Id, organization, newReportYear, reportingTerm);
                    var description = cmd.Description;

                    var lastPeriodData = Calculator.GetLastPeriodUpdateData(existing);
                    
                    var expected = new UnitReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, newReportYear))
                        .SetReportData(existing)
                        
                        .Build();

                    expected.Update(lastPeriodData);

                    return new
                    {
                        cmd,
                        username,
                        expected
                    };
                });

            var context = await Endpoint.Act<CopyUnitPlanCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                {
                    ctx.SetUsernameOnHeader(testParams.username);
                    return h.Handle(testParams.cmd, ctx);
                });
            var evt = context.ExpectPublish<IUnitPlanCopied>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Query<UnitReport>().OrderByDescending(o => o.Id).First();
                    report.Should().NotBeNull();
                    report.Should().BeEquivalentTo(testParams.expected, e =>
                       e.Excluding(p => p.Id)
                           .Excluding(p => p.ReportingPeriod)
                           .Excluding(p => p.ReportStatus));

                    EntityReference reportRef = report;

                    var expectedEvt = Test.CreateInstance<IUnitPlanCopied>(e =>
                    {
                        e.Organization = testParams.expected.Organization;
                        e.Username = testParams.username;
                        e.UnitReport = reportRef;
                    });

                    evt.Should().BeEquivalentTo(expectedEvt, e => e.Excluding(p => p.SerializedData));
                    evt.SerializedData.Should().NotBe(null);
                });
        }

        [TestCase(ReportingFrequency.Monthly)]
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
                        .SetArgument(o => o.OrganizationType, OrganizationType.Unit)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    var copyFrom = new UnitReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year - 1))
                        .BuildAndPersist(s);

                    var duplicate = new UnitReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .BuildAndPersist(s);

                    return new
                    {
                        Cmd = new CopyUnitPlanCommand(copyFrom.Id, organization, year, reportingTerm, reportingFrequency),
                        username,
                        duplicate
                    };
                });

            var context = await Endpoint.Act<CopyUnitPlanCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                {
                    ctx.SetUsernameOnHeader(testParams.username);
                    return h.Handle(testParams.Cmd, ctx);
                });
            var evt = context.ExpectPublish<IUnitPlanCopyFailed>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Query<UnitReport>().OrderByDescending(o => o.Id).First();
                    report.Should().NotBeNull();
                    report.Should().BeEquivalentTo(testParams.duplicate);
                    evt.Errors[0].Should().Contain(testParams.duplicate.Description);
                });
        }

        [TestCase(ReportingFrequency.Monthly)]
        public async Task Handle_DoNotSavesUnitReport_WhenDifferentOrganization(ReportingFrequency reportingFrequency)
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
                        .SetArgument(o => o.OrganizationType, OrganizationType.Unit)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);
                    var organization2 = new TestObjectBuilder<Organization>()
                                            .SetArgument(o => o.OrganizationType, OrganizationType.Unit)
                                            .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                                            .BuildAndPersist(s);

                    var copyFrom = new UnitReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization2)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year - 1))
                        .BuildAndPersist(s);

                    return new
                    {
                        Cmd = new CopyUnitPlanCommand(copyFrom.Id, organization, year, reportingTerm, reportingFrequency),
                        username,
                        copyFrom
                    };
                });

            var context = await Endpoint.Act<CopyUnitPlanCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                {
                    ctx.SetUsernameOnHeader(testParams.username);
                    return h.Handle(testParams.Cmd, ctx);
                });
            var evt = context.ExpectPublish<IUnitPlanCopyFailed>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Query<UnitReport>().OrderByDescending(o => o.Id).First();
                    report.Should().NotBeNull();
                    report.Should().BeEquivalentTo(testParams.copyFrom);
                    evt.Errors[0].Should().Contain("Unable to copy plan");
                });
        }
    }
}