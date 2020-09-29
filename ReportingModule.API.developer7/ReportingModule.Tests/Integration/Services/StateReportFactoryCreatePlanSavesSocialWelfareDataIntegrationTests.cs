using System.Linq;
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
    public class StateReportFactoryCreatePlanSavesSocialWelfareDataIntegrationTests
    {
        private ReportingFrequency reportingFrequency;
        private ReportingTerm reportingTerm;

        public StateReportFactoryCreatePlanSavesSocialWelfareDataIntegrationTests(ReportingFrequency reportingFrequency, ReportingTerm reportingTerm)
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
        public void CreateNewPlan_For_State_Unit_SavesSocialWelfareDataCorrectly(
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
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(thisPeriodSubmitted, laPerouse, reportingPeriod, s);
                    var laPerouseLastPeriod1UnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(lastPeriod1Submitted, laPerouse, lastPeriod1, s);
                    var laPerouseLastPeriod2UnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(lastPeriod2Submitted, laPerouse, lastPeriod2, s);

                    var lalorParkThisPeriodUnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(thisPeriodSubmitted, lalorPark, reportingPeriod, s);
                    var lalorParkLastPeriod1UnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(lastPeriod1Submitted, lalorPark, lastPeriod1, s);
                    var lalorParkLastPeriod2UnitReport =
                        IntegrationTestStateReportHelper.BuildAndPersistUnitReport(lastPeriod2Submitted, lalorPark, lastPeriod2, s);

                    var allUnitReports = new[]
                    {
                        laPerouseThisPeriodUnitReport,
                        laPerouseLastPeriod1UnitReport,
                        laPerouseLastPeriod2UnitReport,
                        lalorParkThisPeriodUnitReport,
                        lalorParkLastPeriod1UnitReport,
                        lalorParkLastPeriod2UnitReport,
                    };

                    var submittedReports = IntegrationTestStateReportHelper.GetSubmittedReports(allUnitReports, reportingPeriod);

                    var expectedQardeHasanaSocialWelfareData = IntegrationTestStateReportHelper.GetExpectedSocialWelfareData(submittedReports, nameof(StateReport.QardeHasanaSocialWelfareData));
                    var expectedQardeHasanaSocialWelfareGeneratedData = expectedQardeHasanaSocialWelfareData;

                    var expectedPatientVisitSocialWelfareData = IntegrationTestStateReportHelper.GetExpectedSocialWelfareData(submittedReports, nameof(StateReport.PatientVisitSocialWelfareData));
                    var expectedPatientVisitSocialWelfareGeneratedData = expectedPatientVisitSocialWelfareData;

                    var expectedSocialVisitSocialWelfareData = IntegrationTestStateReportHelper.GetExpectedSocialWelfareData(submittedReports, nameof(StateReport.SocialVisitSocialWelfareData));
                    var expectedSocialVisitSocialWelfareGeneratedData = expectedSocialVisitSocialWelfareData;

                    var expectedTransportSocialWelfareData = IntegrationTestStateReportHelper.GetExpectedSocialWelfareData(submittedReports, nameof(StateReport.TransportSocialWelfareData));
                    var expectedTransportSocialWelfareGeneratedData = expectedTransportSocialWelfareData;

                    var expectedShiftingSocialWelfareData = IntegrationTestStateReportHelper.GetExpectedSocialWelfareData(submittedReports, nameof(StateReport.ShiftingSocialWelfareData));
                    var expectedShiftingSocialWelfareGeneratedData = expectedShiftingSocialWelfareData;

                    var expectedShoppingSocialWelfareData = IntegrationTestStateReportHelper.GetExpectedSocialWelfareData(submittedReports, nameof(StateReport.ShoppingSocialWelfareData));
                    var expectedShoppingSocialWelfareGeneratedData = expectedShoppingSocialWelfareData;



                    return new
                    {
                        description,
                        reportingPeriod,
                        organizationRef,
                        expected,
                        expectedQardeHasanaSocialWelfareData,
                        expectedQardeHasanaSocialWelfareGeneratedData,
                        expectedPatientVisitSocialWelfareData,
                        expectedPatientVisitSocialWelfareGeneratedData,
                        expectedTransportSocialWelfareData,
                        expectedTransportSocialWelfareGeneratedData,
                        expectedShiftingSocialWelfareData,
                        expectedShiftingSocialWelfareGeneratedData,
                        expectedShoppingSocialWelfareData,
                        expectedShoppingSocialWelfareGeneratedData,
                        expectedSocialVisitSocialWelfareData,
                        expectedSocialVisitSocialWelfareGeneratedData
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

            result.stateReport.QardeHasanaSocialWelfareData.Should().BeEquivalentTo(testParams.expectedQardeHasanaSocialWelfareData);
            result.stateReport.QardeHasanaSocialWelfareGeneratedData.Should().BeEquivalentTo(testParams.expectedQardeHasanaSocialWelfareGeneratedData);

            result.stateReport.PatientVisitSocialWelfareData.Should().BeEquivalentTo(testParams.expectedPatientVisitSocialWelfareData);
            result.stateReport.PatientVisitSocialWelfareGeneratedData.Should().BeEquivalentTo(testParams.expectedPatientVisitSocialWelfareGeneratedData);

            result.stateReport.TransportSocialWelfareData.Should().BeEquivalentTo(testParams.expectedTransportSocialWelfareData);
            result.stateReport.TransportSocialWelfareGeneratedData.Should().BeEquivalentTo(testParams.expectedTransportSocialWelfareGeneratedData);

            result.stateReport.ShiftingSocialWelfareData.Should().BeEquivalentTo(testParams.expectedShiftingSocialWelfareData);
            result.stateReport.ShiftingSocialWelfareGeneratedData.Should().BeEquivalentTo(testParams.expectedShiftingSocialWelfareGeneratedData);

            result.stateReport.ShoppingSocialWelfareData.Should().BeEquivalentTo(testParams.expectedShoppingSocialWelfareData);
            result.stateReport.ShoppingSocialWelfareGeneratedData.Should().BeEquivalentTo(testParams.expectedShoppingSocialWelfareGeneratedData);
        }


    }

}