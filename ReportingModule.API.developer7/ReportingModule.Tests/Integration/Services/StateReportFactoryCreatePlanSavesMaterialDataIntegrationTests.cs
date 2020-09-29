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
    public class StateReportFactoryCreatePlanSavesMaterialDataIntegrationTests
    {
        private ReportingFrequency reportingFrequency;
        private ReportingTerm reportingTerm;

        public StateReportFactoryCreatePlanSavesMaterialDataIntegrationTests(ReportingFrequency reportingFrequency, ReportingTerm reportingTerm)
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
        public void CreateNewPlan_For_State_Unit_SavesMaterialDataCorrectly(
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

                    var expectedBookSaleMaterialData = IntegrationTestStateReportHelper.GetExpectedMaterialData(submittedReports, nameof(StateReport.BookSaleMaterialData));
                    var expectedBookSaleMaterialGeneratedData = expectedBookSaleMaterialData;

                    var expectedBookDistributionMaterialData = IntegrationTestStateReportHelper.GetExpectedMaterialData(submittedReports, nameof(StateReport.BookDistributionMaterialData));
                    var expectedBookDistributionMaterialGeneratedData = expectedBookDistributionMaterialData;

                    var expectedVhsSaleMaterialData = IntegrationTestStateReportHelper.GetExpectedMaterialData(submittedReports, nameof(StateReport.VhsSaleMaterialData));
                    var expectedVhsSaleMaterialGeneratedData = expectedVhsSaleMaterialData;

                    var expectedVhsDistributionMaterialData = IntegrationTestStateReportHelper.GetExpectedMaterialData(submittedReports, nameof(StateReport.VhsDistributionMaterialData));
                    var expectedVhsDistributionMaterialGeneratedData = expectedVhsDistributionMaterialData;

                    var expectedEmailDistributionMaterialData = IntegrationTestStateReportHelper.GetExpectedMaterialData(submittedReports, nameof(StateReport.EmailDistributionMaterialData));
                    var expectedEmailDistributionMaterialGeneratedData = expectedEmailDistributionMaterialData;

                    var expectedIpdcLeafletDistributionMaterialData = IntegrationTestStateReportHelper.GetExpectedMaterialData(submittedReports, nameof(StateReport.IpdcLeafletDistributionMaterialData));
                    var expectedIpdcLeafletDistributionMaterialGeneratedData = expectedIpdcLeafletDistributionMaterialData;


                    return new
                    {
                        description,
                        reportingPeriod,
                        organizationRef,
                        expected,
                        expectedBookSaleMaterialData,
                        expectedBookSaleMaterialGeneratedData,
                        expectedBookDistributionMaterialData,
                        expectedBookDistributionMaterialGeneratedData,
                        expectedVhsSaleMaterialData,
                        expectedVhsSaleMaterialGeneratedData,
                        expectedVhsDistributionMaterialData,
                        expectedVhsDistributionMaterialGeneratedData,
                        expectedEmailDistributionMaterialData,
                        expectedEmailDistributionMaterialGeneratedData,
                        expectedIpdcLeafletDistributionMaterialData,
                        expectedIpdcLeafletDistributionMaterialGeneratedData
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

            result.stateReport.BookSaleMaterialData.Should().BeEquivalentTo(testParams.expectedBookSaleMaterialData);
            result.stateReport.BookSaleMaterialGeneratedData.Should().BeEquivalentTo(testParams.expectedBookSaleMaterialGeneratedData);

            result.stateReport.BookDistributionMaterialData.Should().BeEquivalentTo(testParams.expectedBookDistributionMaterialData);
            result.stateReport.BookDistributionMaterialGeneratedData.Should().BeEquivalentTo(testParams.expectedBookDistributionMaterialGeneratedData);

            result.stateReport.VhsSaleMaterialData.Should().BeEquivalentTo(testParams.expectedVhsSaleMaterialData);
            result.stateReport.VhsSaleMaterialGeneratedData.Should().BeEquivalentTo(testParams.expectedVhsSaleMaterialGeneratedData);

            result.stateReport.VhsDistributionMaterialData.Should().BeEquivalentTo(testParams.expectedVhsDistributionMaterialData);
            result.stateReport.VhsDistributionMaterialGeneratedData.Should().BeEquivalentTo(testParams.expectedVhsDistributionMaterialGeneratedData);

            result.stateReport.EmailDistributionMaterialData.Should().BeEquivalentTo(testParams.expectedEmailDistributionMaterialData);
            result.stateReport.EmailDistributionMaterialGeneratedData.Should().BeEquivalentTo(testParams.expectedEmailDistributionMaterialGeneratedData);

            result.stateReport.IpdcLeafletDistributionMaterialData.Should().BeEquivalentTo(testParams.expectedIpdcLeafletDistributionMaterialData);
            result.stateReport.IpdcLeafletDistributionMaterialGeneratedData.Should().BeEquivalentTo(testParams.expectedIpdcLeafletDistributionMaterialGeneratedData);

        }


    }

}