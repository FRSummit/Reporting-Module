﻿using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using ReportingModule.Entities;
using ReportingModule.Services;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.Tests.Integration.Helpers;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.Services
{
    [TestFixture(Category = "Integration")]
    [TestFixtureSource(typeof(CreatePlanFixtureData), "FixtureParams")]
    public class StateReportFactoryCreateNewPlanSavesFinanceDataIntegrationTests
    {
        private ReportingFrequency reportingFrequency;
        private ReportingTerm reportingTerm;
        public StateReportFactoryCreateNewPlanSavesFinanceDataIntegrationTests(ReportingFrequency reportingFrequency, ReportingTerm reportingTerm)
        {
            this.reportingFrequency = reportingFrequency;
            this.reportingTerm = reportingTerm;
        }

        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                //DomainDatabase.ClearAllTables(s);

                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [Theory]
        public void CreateNewPlan_For_State_Unit_SavesFinanceDataCorrectly(
            bool thisPeriodSubmitted,
            bool lastPeriod1Submitted,
            bool lastPeriod2Submitted
        )
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var reportingTerms = ReportingPeriod.GetReportingTerms(reportingFrequency);
            if (reportingTerms.All(o => o != reportingTerm))
                return;

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);

                    var nswState = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswState).Value;
                    var laPerouse = new OrganizationBuilder()
                        .SetDescription("La perouse")
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(ReportingFrequency.Monthly)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    var lalorPark = new OrganizationBuilder()
                        .SetDescription("Lalor park")
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(ReportingFrequency.Monthly)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    OrganizationReference organizationRef = nswState;

                    var reportingPeriod = new ReportingPeriod(reportingFrequency, reportingTerm, year);
                    var expected = new StateReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organizationRef)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingPeriod.ReportingTerm,
                            reportingPeriod.Year))
                        .Build();


                    var lastPeriod1 = reportingPeriod.GetReportingPeriodOfPreviousTerm();
                    var lastPeriod2 = lastPeriod1.GetReportingPeriodOfPreviousTerm();

                    var laPerouseThisPeriodUnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(thisPeriodSubmitted, laPerouse,
                            reportingPeriod, s);
                    var laPerouseLastPeriod1UnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(lastPeriod1Submitted, laPerouse,
                            lastPeriod1, s);
                    var laPerouseLastPeriod2UnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(lastPeriod2Submitted, laPerouse,
                            lastPeriod2, s);

                    var lalorParkThisPeriodUnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(thisPeriodSubmitted, lalorPark,
                            reportingPeriod, s);
                    var lalorParkLastPeriod1UnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(lastPeriod1Submitted, lalorPark,
                            lastPeriod1, s);
                    var lalorParkLastPeriod2UnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(lastPeriod2Submitted, lalorPark,
                            lastPeriod2, s);

                    var laPerouseUnitReports = new[]
                    {
                        laPerouseThisPeriodUnitReport,
                        laPerouseLastPeriod1UnitReport,
                        laPerouseLastPeriod2UnitReport,
                    };

                    var lalorParkeUnitReports = new[]
                    {
                        lalorParkThisPeriodUnitReport,
                        lalorParkLastPeriod1UnitReport,
                        lalorParkLastPeriod2UnitReport,
                    };

                    var lastSubmittedLapeRouseReport =
                        IntegrationTestStateReportHelper.GetLastSubmittedReport(laPerouseUnitReports, reportingPeriod);
                    var lastSubmittedLalorParkReport =
                        IntegrationTestStateReportHelper.GetLastSubmittedReport(lalorParkeUnitReports, reportingPeriod);

                    var submittedReports = new[] {lastSubmittedLapeRouseReport, lastSubmittedLalorParkReport}
                        .Where(o => o != null).ToArray();

                    var expectedBaitulMalFinancekData =
                        IntegrationTestStateReportHelper.GetExpectedFinanceData(submittedReports,
                            nameof(StateReport.BaitulMalFinanceData));
                    var expectedBaitulMalFinancekGeneratedData = expectedBaitulMalFinancekData;

                    var expectedADayMasjidProjectFinanceData =
                        IntegrationTestStateReportHelper.GetExpectedFinanceData(submittedReports,
                            nameof(StateReport.ADayMasjidProjectFinanceData));
                    var expectedADayMasjidProjectFinanceGeneratedData = expectedADayMasjidProjectFinanceData;

                    var expectedMasjidTableBankFinanceData =
                        IntegrationTestStateReportHelper.GetExpectedFinanceData(submittedReports,
                            nameof(StateReport.MasjidTableBankFinanceData));
                    var expectedMasjidTableBankFinanceGeneratedData = expectedMasjidTableBankFinanceData;

                    return new
                    {
                        description,
                        reportingPeriod,
                        organizationRef,
                        expected,
                        expectedBaitulMalFinancekData,
                        expectedBaitulMalFinancekGeneratedData,
                        expectedADayMasjidProjectFinanceData,
                        expectedADayMasjidProjectFinanceGeneratedData,
                        expectedMasjidTableBankFinanceData,
                        expectedMasjidTableBankFinanceGeneratedData,
                    };
                });
            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c =>
                {
                    var stateReport = c.GetInstance<IStateReportFactory>()
                        .CreateNewStatePlan(testParams.description,
                            testParams.organizationRef,
                            testParams.reportingPeriod.ReportingTerm,
                            testParams.reportingPeriod.Year,
                            reportingFrequency);
                    return new
                    {
                        stateReport
                    };
                });
            result.stateReport.Should().NotBeNull();



            result.stateReport.BaitulMalFinanceData.Should().BeEquivalentTo(testParams.expectedBaitulMalFinancekData);
            result.stateReport.BaitulMalFinanceGeneratedData.Should()
                .BeEquivalentTo(testParams.expectedBaitulMalFinancekGeneratedData);

            result.stateReport.ADayMasjidProjectFinanceData.Should()
                .BeEquivalentTo(testParams.expectedADayMasjidProjectFinanceData);
            result.stateReport.ADayMasjidProjectFinanceGeneratedData.Should()
                .BeEquivalentTo(testParams.expectedADayMasjidProjectFinanceGeneratedData);

            result.stateReport.MasjidTableBankFinanceData.Should()
                .BeEquivalentTo(testParams.expectedMasjidTableBankFinanceData);
            result.stateReport.MasjidTableBankFinanceGeneratedData.Should()
                .BeEquivalentTo(testParams.expectedMasjidTableBankFinanceGeneratedData);


        }
    }
}