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
    public class StateReportFactoryCreateNewPlanSavesMemberDataIntegrationTests
    {
        private ReportingFrequency reportingFrequency;
        private ReportingTerm reportingTerm;

        public StateReportFactoryCreateNewPlanSavesMemberDataIntegrationTests(ReportingFrequency reportingFrequency, ReportingTerm reportingTerm)
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
        public void CreateNewPlan_For_State_Unit_SavesMemberDataCorrectly(
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

                    var lastSubmittedLapeRouseReport = IntegrationTestStateReportHelper.GetLastSubmittedReport(laPerouseUnitReports, reportingPeriod);
                    var lastSubmittedLalorParkReport = IntegrationTestStateReportHelper.GetLastSubmittedReport(lalorParkeUnitReports, reportingPeriod);

                    var submittedReports = new[] { lastSubmittedLapeRouseReport, lastSubmittedLalorParkReport }.Where(o => o != null).ToArray();

                    var expectedMemberMemberData = IntegrationTestStateReportHelper.GetExpectedMemberData(submittedReports, nameof(StateReport.MemberMemberData));
                    var expectedMemberMemberGeneratedData = expectedMemberMemberData;
                    var expectedAssociateMemberData = IntegrationTestStateReportHelper.GetExpectedMemberData(submittedReports, nameof(StateReport.AssociateMemberData));
                    var expectedAssociateMemberGeneratedData = expectedAssociateMemberData;
                    var expectedPreliminaryMemberData = IntegrationTestStateReportHelper.GetExpectedMemberData(submittedReports, nameof(StateReport.PreliminaryMemberData));
                    var expectedPreliminaryMemberGeneratedData = expectedPreliminaryMemberData;
                    var expectedSupporterMemberData = IntegrationTestStateReportHelper.GetExpectedMemberData(submittedReports, nameof(StateReport.SupporterMemberData));
                    var expectedSupporterMemberGeneratedData = expectedSupporterMemberData;

                    return new
                    {
                        description,
                        reportingPeriod,
                        organizationRef,
                        expected,
                        expectedMemberMemberData,
                        expectedMemberMemberGeneratedData,
                        expectedAssociateMemberData,
                        expectedAssociateMemberGeneratedData,
                        expectedPreliminaryMemberData,
                        expectedPreliminaryMemberGeneratedData,
                        expectedSupporterMemberData,
                        expectedSupporterMemberGeneratedData,
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

            //no need to repeat this section for the other field types
            result.stateReport.Should().BeEquivalentTo(testParams.expected, e =>
                    e.Excluding(p => p.Id)
                    .Excluding(p => p.MemberMemberData)
                    .Excluding(p => p.MemberMemberGeneratedData)
                    .Excluding(p => p.AssociateMemberData)
                    .Excluding(p => p.AssociateMemberGeneratedData)
                    .Excluding(p => p.PreliminaryMemberData)
                    .Excluding(p => p.PreliminaryMemberGeneratedData)
                    .Excluding(p => p.SupporterMemberData)
                    .Excluding(p => p.SupporterMemberGeneratedData)

                    .Excluding(p => p.WorkerMeetingProgramData)
                    .Excluding(p => p.WorkerMeetingProgramGeneratedData)
                    .Excluding(p => p.DawahMeetingProgramData)
                    .Excluding(p => p.DawahMeetingProgramGeneratedData)
                    .Excluding(p => p.StateLeaderMeetingProgramData)
                    .Excluding(p => p.StateLeaderMeetingProgramGeneratedData)
                    .Excluding(p => p.StateOutingMeetingProgramData)
                    .Excluding(p => p.StateOutingMeetingProgramGeneratedData)
                    .Excluding(p => p.IftarMeetingProgramData)
                    .Excluding(p => p.IftarMeetingProgramGeneratedData)
                    .Excluding(p => p.LearningMeetingProgramData)
                    .Excluding(p => p.LearningMeetingProgramGeneratedData)
                    .Excluding(p => p.SocialDawahMeetingProgramData)
                    .Excluding(p => p.SocialDawahMeetingProgramGeneratedData)
                    .Excluding(p => p.DawahGroupMeetingProgramData)
                    .Excluding(p => p.DawahGroupMeetingProgramGeneratedData)
                    .Excluding(p => p.NextGMeetingProgramData)
                    .Excluding(p => p.NextGMeetingProgramGeneratedData)

                    .Excluding(p => p.CmsMeetingProgramData)
                    .Excluding(p => p.CmsMeetingProgramGeneratedData)
                    .Excluding(p => p.SmMeetingProgramData)
                    .Excluding(p => p.SmMeetingProgramGeneratedData)
                    .Excluding(p => p.MemberMeetingProgramData)
                    .Excluding(p => p.MemberMeetingProgramGeneratedData)
                    .Excluding(p => p.TafsirMeetingProgramData)
                    .Excluding(p => p.TafsirMeetingProgramGeneratedData)
                    .Excluding(p => p.UnitMeetingProgramData)
                    .Excluding(p => p.UnitMeetingProgramGeneratedData)
                    .Excluding(p => p.FamilyVisitMeetingProgramData)
                    .Excluding(p => p.FamilyVisitMeetingProgramGeneratedData)
                    .Excluding(p => p.EidReunionMeetingProgramData)
                    .Excluding(p => p.EidReunionMeetingProgramGeneratedData)
                    .Excluding(p => p.BbqMeetingProgramData)
                    .Excluding(p => p.BbqMeetingProgramGeneratedData)
                    .Excluding(p => p.GatheringMeetingProgramData)
                    .Excluding(p => p.GatheringMeetingProgramGeneratedData)
                    .Excluding(p => p.OtherMeetingProgramData)
                    .Excluding(p => p.OtherMeetingProgramGeneratedData)

                    .Excluding(p => p.GroupStudyTeachingLearningProgramData)
                    .Excluding(p => p.GroupStudyTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.StudyCircleTeachingLearningProgramData)
                    .Excluding(p => p.StudyCircleTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.PracticeDarsTeachingLearningProgramData)
                    .Excluding(p => p.PracticeDarsTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.StateLearningCampTeachingLearningProgramData)
                    .Excluding(p => p.StateLearningCampTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.QuranStudyTeachingLearningProgramData)
                    .Excluding(p => p.QuranStudyTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.QuranClassTeachingLearningProgramData)
                    .Excluding(p => p.QuranClassTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.MemorizingAyatTeachingLearningProgramData)
                    .Excluding(p => p.MemorizingAyatTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.StateLearningSessionTeachingLearningProgramData)
                    .Excluding(p => p.StateLearningSessionTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.StateQiyamulLailTeachingLearningProgramData)
                    .Excluding(p => p.StateQiyamulLailTeachingLearningProgramGeneratedData)

                    .Excluding(p => p.StudyCircleForAssociateMemberTeachingLearningProgramData)
                    .Excluding(p => p.StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.HadithTeachingLearningProgramData)
                    .Excluding(p => p.HadithTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.WeekendIslamicSchoolTeachingLearningProgramData)
                    .Excluding(p => p.WeekendIslamicSchoolTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.MemorizingHadithTeachingLearningProgramData)
                    .Excluding(p => p.MemorizingHadithTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.MemorizingDoaTeachingLearningProgramData)
                    .Excluding(p => p.MemorizingDoaTeachingLearningProgramGeneratedData)
                    .Excluding(p => p.OtherTeachingLearningProgramData)
                    .Excluding(p => p.OtherTeachingLearningProgramGeneratedData)

                    .Excluding(p => p.BookSaleMaterialData)
                    .Excluding(p => p.BookSaleMaterialGeneratedData)
                    .Excluding(p => p.BookDistributionMaterialData)
                    .Excluding(p => p.BookDistributionMaterialGeneratedData)
                    .Excluding(p => p.BookLibraryStockData)
                    .Excluding(p => p.BookLibraryStockGeneratedData)
                    .Excluding(p => p.OtherSaleMaterialData)
                    .Excluding(p => p.OtherSaleMaterialGeneratedData)
                    .Excluding(p => p.OtherDistributionMaterialData)
                    .Excluding(p => p.OtherDistributionMaterialGeneratedData)
                    .Excluding(p => p.OtherLibraryStockData)
                    .Excluding(p => p.OtherLibraryStockGeneratedData)
                    .Excluding(p => p.VhsSaleMaterialData)
                    .Excluding(p => p.VhsSaleMaterialGeneratedData)
                    .Excluding(p => p.VhsDistributionMaterialData)
                    .Excluding(p => p.VhsDistributionMaterialGeneratedData)
                    .Excluding(p => p.VhsLibraryStockData)
                    .Excluding(p => p.VhsLibraryStockGeneratedData)
                    .Excluding(p => p.EmailDistributionMaterialData)
                    .Excluding(p => p.EmailDistributionMaterialGeneratedData)
                    .Excluding(p => p.IpdcLeafletDistributionMaterialData)
                    .Excluding(p => p.IpdcLeafletDistributionMaterialGeneratedData)
                    .Excluding(p => p.BaitulMalFinanceData)
                    .Excluding(p => p.BaitulMalFinanceGeneratedData)
                    .Excluding(p => p.ADayMasjidProjectFinanceData)
                    .Excluding(p => p.ADayMasjidProjectFinanceGeneratedData)
                    .Excluding(p => p.MasjidTableBankFinanceData)
                    .Excluding(p => p.MasjidTableBankFinanceGeneratedData)


                    .Excluding(p => p.QardeHasanaSocialWelfareData)
                    .Excluding(p => p.QardeHasanaSocialWelfareGeneratedData)
                    .Excluding(p => p.PatientVisitSocialWelfareData)
                    .Excluding(p => p.PatientVisitSocialWelfareGeneratedData)
                    .Excluding(p => p.SocialVisitSocialWelfareData)
                    .Excluding(p => p.SocialVisitSocialWelfareGeneratedData)
                    .Excluding(p => p.TransportSocialWelfareData)
                    .Excluding(p => p.TransportSocialWelfareGeneratedData)
                    .Excluding(p => p.ShiftingSocialWelfareData)
                    .Excluding(p => p.ShiftingSocialWelfareGeneratedData)
                    .Excluding(p => p.ShoppingSocialWelfareData)
                    .Excluding(p => p.ShoppingSocialWelfareGeneratedData)
                    .Excluding(p => p.FoodDistributionSocialWelfareData)
                    .Excluding(p => p.FoodDistributionSocialWelfareGeneratedData)
                    .Excluding(p => p.CleanUpAustraliaSocialWelfareData)
                    .Excluding(p => p.CleanUpAustraliaSocialWelfareGeneratedData)
                    .Excluding(p => p.OtherSocialWelfareData)
                    .Excluding(p => p.OtherSocialWelfareGeneratedData)

            );

            result.stateReport.MemberMemberData.Should().BeEquivalentTo(testParams.expectedMemberMemberData);
            result.stateReport.MemberMemberGeneratedData.Should().BeEquivalentTo(testParams.expectedMemberMemberGeneratedData);

            result.stateReport.AssociateMemberData.Should().BeEquivalentTo(testParams.expectedAssociateMemberData);
            result.stateReport.AssociateMemberGeneratedData.Should().BeEquivalentTo(testParams.expectedAssociateMemberGeneratedData);

            result.stateReport.PreliminaryMemberData.Should().BeEquivalentTo(testParams.expectedPreliminaryMemberData);
            result.stateReport.PreliminaryMemberGeneratedData.Should().BeEquivalentTo(testParams.expectedPreliminaryMemberGeneratedData);

            result.stateReport.SupporterMemberData.Should().BeEquivalentTo(testParams.expectedSupporterMemberData);
            result.stateReport.SupporterMemberGeneratedData.Should().BeEquivalentTo(testParams.expectedSupporterMemberGeneratedData);
        }
    }
}