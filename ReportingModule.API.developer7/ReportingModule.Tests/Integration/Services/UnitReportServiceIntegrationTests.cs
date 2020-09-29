using FluentAssertions;
using NUnit.Framework;
using ReportingModule.Entities;
using ReportingModule.Services.Impl;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.Services
{
    [TestFixture(Category = "Integration")]
    public class UnitReportServiceIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [TestCase(ReportingFrequency.Monthly)]
        public void PromotePlanToUnitReport_SavesCorrectlyWhenLastYearSubmitted(ReportingFrequency reportingFrequency)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizationType = OrganizationType.Unit;

                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, organizationType)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    var period1 = new ReportingPeriod(reportingFrequency, reportingTerm, year);
                    var period1ReportingData = new ReportDataBuilder().Build();
                    var period1UnitReport =
                        new UnitReport(description, organization, period1, period1ReportingData);
                    s.Save(period1UnitReport);

                 
                    return new
                    {
                        period1UnitReport,
                    };
                });
            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c =>
                {
                    var unitReport = c.GetInstance<UnitReportService>()
                        .PromotePlanToUnitReport(testParams.period1UnitReport.Id);
                    return new
                    {
                        unitReport
                    };
                });
            result.unitReport.Should().NotBeNull();
            result.unitReport.Should().BeEquivalentTo(testParams.period1UnitReport, e =>
                e.Excluding(p => p.ReportStatus));
            result.unitReport.ReportStatus.Should().Be(ReportStatus.PlanPromoted);
        }

        [Explicit]
        [Theory]
        public void PromotePlanToUnitReportAi_SavesCorrectlyWhenLastYearSubmitted(ReportingFrequency reportingFrequency)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizationType = OrganizationType.Unit;

                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, organizationType)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    var period1 = new ReportingPeriod(reportingFrequency, reportingTerm, year);
                    var period1ReportingData = new ReportDataBuilder().Build();
                    var period1UnitReport =
                        new UnitReport(description, organization, period1, period1ReportingData);
                    s.Save(period1UnitReport);

                    var lastPeriod2 = period1.GetReportingPeriodOfPreviousTerm();
                    var lastPeriod2ReportingData = new ReportDataBuilder().Build();
                    var lastPeriod2UnitReport =
                        new UnitReport(description, organization, lastPeriod2, lastPeriod2ReportingData);
                    lastPeriod2UnitReport.MarkStatusAsSubmitted();
                    s.Save(lastPeriod2UnitReport);

                    return new
                    {
                        period1UnitReport,
                        lastPeriod2UnitReport
                    };
                });
            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c =>
                {
                    var unitReport = c.GetInstance<UnitReportService>()
                        .PromotePlanToUnitReportAi(testParams.period1UnitReport.Id);
                    return new
                    {
                        unitReport
                    };
                });
            result.unitReport.Should().NotBeNull();
            result.unitReport.Should().BeEquivalentTo(testParams.period1UnitReport, e =>
                e.Excluding(p => p.ReportStatus)
                    .Excluding(p => p.AssociateMemberData)
                    .Excluding(p => p.PreliminaryMemberData)
                    .Excluding(p => p.WorkerMeetingProgramData));

            result.unitReport.ReportStatus.Should().Be(ReportStatus.PlanPromoted);

            result.unitReport.AssociateMemberData.UpgradeTarget.Should()
                .Be(testParams.period1UnitReport.AssociateMemberData.UpgradeTarget);
            result.unitReport.AssociateMemberData.LastPeriod.Should()
                .Be(testParams.period1UnitReport.AssociateMemberData.LastPeriod);
            result.unitReport.AssociateMemberData.ThisPeriod.Should()
                .Be(testParams.lastPeriod2UnitReport.AssociateMemberData.ThisPeriod);

            result.unitReport.PreliminaryMemberData.UpgradeTarget.Should()
                .Be(testParams.period1UnitReport.PreliminaryMemberData.UpgradeTarget);
            result.unitReport.PreliminaryMemberData.LastPeriod.Should()
                .Be(testParams.period1UnitReport.PreliminaryMemberData.LastPeriod);
            result.unitReport.PreliminaryMemberData.ThisPeriod.Should()
                .Be(testParams.lastPeriod2UnitReport.PreliminaryMemberData.ThisPeriod);
           
            //Worker meeting values should be initial values. Should not set last period values (as that will be irrelevant)
            result.unitReport.WorkerMeetingProgramData.Target.Should()
                .Be(testParams.period1UnitReport.WorkerMeetingProgramData.Target);
            result.unitReport.WorkerMeetingProgramData.Actual.Should()
                .Be(testParams.period1UnitReport.WorkerMeetingProgramData.Actual);
            result.unitReport.WorkerMeetingProgramData.AverageAttendance.Should()
                .Be(testParams.period1UnitReport.WorkerMeetingProgramData.AverageAttendance);
            
        }
    }
}