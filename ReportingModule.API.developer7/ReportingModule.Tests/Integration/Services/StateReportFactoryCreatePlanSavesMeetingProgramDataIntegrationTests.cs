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
    public class StateReportFactoryCreatePlanSavesMeetingProgramDataIntegrationTests
    {
        private ReportingFrequency reportingFrequency;
        private ReportingTerm reportingTerm;

        public StateReportFactoryCreatePlanSavesMeetingProgramDataIntegrationTests(ReportingFrequency reportingFrequency, ReportingTerm reportingTerm)
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
        public void CreateNewPlan_For_State_Unit_SavesMeetingProgramDataCorrectly(
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

                    var allUnitReports = new[]
                    {
                        laPerouseThisPeriodUnitReport,
                        laPerouseLastPeriod1UnitReport,
                        laPerouseLastPeriod2UnitReport,
                        lalorParkThisPeriodUnitReport,
                        lalorParkLastPeriod1UnitReport,
                        lalorParkLastPeriod2UnitReport,
                    };

                    var submittedReports =
                        IntegrationTestStateReportHelper.GetSubmittedReports(allUnitReports, reportingPeriod);

                    var expectedWorkerMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.WorkerMeetingProgramData));
                    var expectedWorkerMeetingProgramGeneratedData = expectedWorkerMeetingProgramData;

                    var expectedDawahMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.DawahMeetingProgramData));
                    var expectedDawahMeetingProgramGeneratedData = expectedDawahMeetingProgramData;

                    var expectedStateLeaderMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.StateLeaderMeetingProgramData));
                    var expectedStateLeaderMeetingProgramGeneratedData = expectedStateLeaderMeetingProgramData;

                    var expectedStateOutingMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.StateOutingMeetingProgramData));
                    var expectedStateOutingMeetingProgramGeneratedData = expectedStateOutingMeetingProgramData;

                    var expectedIftarMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.IftarMeetingProgramData));
                    var expectedIftarMeetingProgramGeneratedData = expectedIftarMeetingProgramData;

                    var expectedLearningMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.LearningMeetingProgramData));
                    var expectedLearningMeetingProgramGeneratedData = expectedLearningMeetingProgramData;

                    var expectedSocialDawahMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.SocialDawahMeetingProgramData));
                    var expectedSocialDawahMeetingProgramGeneratedData = expectedSocialDawahMeetingProgramData;

                    var expectedDawahGroupMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.DawahGroupMeetingProgramData));
                    var expectedDawahGroupMeetingProgramGeneratedData = expectedDawahGroupMeetingProgramData;

                    var expectedNextGMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.NextGMeetingProgramData));
                    var expectedNextGMeetingProgramGeneratedData = expectedNextGMeetingProgramData;

                    var expectedCmsMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.CmsMeetingProgramData));
                    var expectedCMSMeetingProgramGeneratedData = expectedCmsMeetingProgramData;

                    var expectedSmMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.SmMeetingProgramData));
                    var expectedSmMeetingProgramGeneratedData = expectedSmMeetingProgramData;

                    var expectedMemberMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.MemberMeetingProgramData));
                    var expectedMemberMeetingProgramGeneratedData = expectedMemberMeetingProgramData;

                    var expectedTafsirMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.TafsirMeetingProgramData));
                    var expectedTafsirMeetingProgramGeneratedData = expectedTafsirMeetingProgramData;

                    var expectedUnitMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.UnitMeetingProgramData));
                    var expectedUnitMeetingProgramGeneratedData = expectedUnitMeetingProgramData;

                    var expectedFamilyVisitMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.FamilyVisitMeetingProgramData));
                    var expectedFamilyVisitMeetingProgramGeneratedData = expectedFamilyVisitMeetingProgramData;

                    var expectedEidReunionMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.EidReunionMeetingProgramData));
                    var expectedEidReunionMeetingProgramGeneratedData = expectedEidReunionMeetingProgramData;

                    var expectedBbqMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.BbqMeetingProgramData));
                    var expectedBbqMeetingProgramGeneratedData = expectedBbqMeetingProgramData;

                    var expectedGatheringMeetingProgramData = IntegrationTestStateReportHelper.GetExpectedMeetingProgramData(submittedReports, nameof(StateReport.GatheringMeetingProgramData));
                    var expectedGatheringMeetingProgramGeneratedData = expectedGatheringMeetingProgramData;

                    return new
                    {
                        description,
                        reportingPeriod,
                        organizationRef,
                        expected,

                        expectedWorkerMeetingProgramData,
                        expectedWorkerMeetingProgramGeneratedData,
                        expectedDawahMeetingProgramData,
                        expectedDawahMeetingProgramGeneratedData,
                        expectedStateLeaderMeetingProgramData,
                        expectedStateLeaderMeetingProgramGeneratedData,
                        expectedStateOutingMeetingProgramData,
                        expectedStateOutingMeetingProgramGeneratedData,
                        expectedIftarMeetingProgramData,
                        expectedIftarMeetingProgramGeneratedData,
                        expectedLearningMeetingProgramData,
                        expectedLearningMeetingProgramGeneratedData,
                        expectedSocialDawahMeetingProgramData,
                        expectedSocialDawahMeetingProgramGeneratedData,
                        expectedDawahGroupMeetingProgramData,
                        expectedDawahGroupMeetingProgramGeneratedData,
                        expectedNextGMeetingProgramData,
                        expectedNextGMeetingProgramGeneratedData,

                        expectedCmsMeetingProgramData,
                        expectedCMSMeetingProgramGeneratedData,
                        expectedSmMeetingProgramData,
                        expectedSmMeetingProgramGeneratedData,
                        expectedMemberMeetingProgramData,
                        expectedMemberMeetingProgramGeneratedData,
                        expectedTafsirMeetingProgramData,
                        expectedTafsirMeetingProgramGeneratedData,
                        expectedUnitMeetingProgramData,
                        expectedUnitMeetingProgramGeneratedData,
                        expectedFamilyVisitMeetingProgramData,
                        expectedFamilyVisitMeetingProgramGeneratedData,
                        expectedEidReunionMeetingProgramData,
                        expectedEidReunionMeetingProgramGeneratedData,
                        expectedBbqMeetingProgramData,
                        expectedBbqMeetingProgramGeneratedData,
                        expectedGatheringMeetingProgramData,
                        expectedGatheringMeetingProgramGeneratedData,

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

            result.stateReport.WorkerMeetingProgramData.Should().BeEquivalentTo(testParams.expectedWorkerMeetingProgramData);
            result.stateReport.WorkerMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedWorkerMeetingProgramGeneratedData);

            result.stateReport.DawahMeetingProgramData.Should().BeEquivalentTo(testParams.expectedDawahMeetingProgramData);
            result.stateReport.DawahMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedDawahMeetingProgramGeneratedData);

            result.stateReport.StateLeaderMeetingProgramData.Should().BeEquivalentTo(testParams.expectedStateLeaderMeetingProgramData);
            result.stateReport.StateLeaderMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedStateLeaderMeetingProgramGeneratedData);

            result.stateReport.StateOutingMeetingProgramData.Should().BeEquivalentTo(testParams.expectedStateOutingMeetingProgramData);
            result.stateReport.StateOutingMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedStateOutingMeetingProgramGeneratedData);

            result.stateReport.IftarMeetingProgramData.Should().BeEquivalentTo(testParams.expectedIftarMeetingProgramData);
            result.stateReport.IftarMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedIftarMeetingProgramGeneratedData);

            result.stateReport.LearningMeetingProgramData.Should().BeEquivalentTo(testParams.expectedLearningMeetingProgramData);
            result.stateReport.LearningMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedLearningMeetingProgramGeneratedData);

            result.stateReport.SocialDawahMeetingProgramData.Should().BeEquivalentTo(testParams.expectedSocialDawahMeetingProgramData);
            result.stateReport.SocialDawahMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedSocialDawahMeetingProgramGeneratedData);

            result.stateReport.DawahGroupMeetingProgramData.Should().BeEquivalentTo(testParams.expectedDawahGroupMeetingProgramData);
            result.stateReport.DawahGroupMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedDawahGroupMeetingProgramGeneratedData);

            result.stateReport.NextGMeetingProgramData.Should().BeEquivalentTo(testParams.expectedNextGMeetingProgramData);
            result.stateReport.NextGMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedNextGMeetingProgramGeneratedData);

            result.stateReport.CmsMeetingProgramData.Should().BeEquivalentTo(expectation: testParams.expectedCmsMeetingProgramData);
            result.stateReport.CmsMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedCMSMeetingProgramGeneratedData);

            result.stateReport.SmMeetingProgramData.Should().BeEquivalentTo(expectation: testParams.expectedSmMeetingProgramData);
            result.stateReport.SmMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedSmMeetingProgramGeneratedData);

            result.stateReport.MemberMeetingProgramData.Should().BeEquivalentTo(testParams.expectedMemberMeetingProgramData);
            result.stateReport.MemberMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedMemberMeetingProgramGeneratedData);

            result.stateReport.TafsirMeetingProgramData.Should().BeEquivalentTo(testParams.expectedTafsirMeetingProgramData);
            result.stateReport.TafsirMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedTafsirMeetingProgramGeneratedData);

            result.stateReport.UnitMeetingProgramData.Should().BeEquivalentTo(testParams.expectedUnitMeetingProgramData);
            result.stateReport.UnitMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedUnitMeetingProgramGeneratedData);

            result.stateReport.FamilyVisitMeetingProgramData.Should().BeEquivalentTo(testParams.expectedFamilyVisitMeetingProgramData);
            result.stateReport.FamilyVisitMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedFamilyVisitMeetingProgramGeneratedData);

            result.stateReport.EidReunionMeetingProgramData.Should().BeEquivalentTo(testParams.expectedEidReunionMeetingProgramData);
            result.stateReport.EidReunionMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedEidReunionMeetingProgramGeneratedData);

            result.stateReport.BbqMeetingProgramData.Should().BeEquivalentTo(testParams.expectedBbqMeetingProgramData);
            result.stateReport.BbqMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedBbqMeetingProgramGeneratedData);

            result.stateReport.GatheringMeetingProgramData.Should().BeEquivalentTo(testParams.expectedGatheringMeetingProgramData);
            result.stateReport.GatheringMeetingProgramGeneratedData.Should().BeEquivalentTo(testParams.expectedGatheringMeetingProgramGeneratedData);
        }
    }
}