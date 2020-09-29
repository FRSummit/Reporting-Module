using NUnit.Framework;

namespace ReportingModule.Tests.Integration.Services
{
    [TestFixture(Category = "Integration")]
    public class StateReportFactoryIntegrationTests
    {
        //Update this section only when working with zone
        /*

        [Explicit]
        [Theory]
        public void CreateNewPlanZoneAndUnit_SavesMemberDataCorrectly(
            ReportingFrequency reportingFrequency,
            ReportingTerm reportingTerm,
            bool thisPeriodSubmitted,
            bool lastPeriod1Submitted,
            bool lastPeriod2Submitted
            )
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var now = DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var reportingTerms = ReportingPeriod.GetReportingTerms(reportingFrequency);
            if (reportingTerms.All(o => o != reportingTerm))
                return;

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(stateReportingFrequency: reportingFrequency, zoneReportingFrequency: ReportingFrequency.Quarterly);

                    var nswState = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswState).Value;
                    var nswZoneOne = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswZoneOne).Value;

                    var nswZoneTwo = new OrganizationBuilder()
                        .SetDescription("Nsw Zone Two")
                        .SetOrganizationType(OrganizationType.Zone)
                        .SetReportingFreQuency(reportingFrequency)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    var laPerouse = new OrganizationBuilder()
                        .SetDescription("La perouse")
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(ReportingFrequency.Monthly)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    var lalorPark = new OrganizationBuilder()
                        .SetDescription("Lalor park")
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(ReportingFrequency.EveryTwoMonth)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    var laneCove = new OrganizationBuilder()
                        .SetDescription("Lane cove")
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(reportingFrequency)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    new OrganizationBuilder()
                        .SetDescription("Lavender Bay")
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(reportingFrequency)
                        .SetParent(nswZoneTwo)
                        .BuildAndPersist(s);

                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    OrganizationReference organizationRef = nswState;

                    var reportingPeriod = new ReportingPeriod(reportingFrequency, reportingTerm, year);

                    var lastPeriod1 = reportingPeriod.GetReportingPeriodOfPreviousTerm();
                    var lastPeriod2 = lastPeriod1.GetReportingPeriodOfPreviousTerm();

                    var nswZoneOneThisPeriodZoneReport = BuildAndPersistZoneReport(thisPeriodSubmitted, nswZoneOne, reportingPeriod, s);
                    var nswZoneOneLastPeriod1ZoneReport = BuildAndPersistZoneReport(lastPeriod1Submitted, nswZoneOne, lastPeriod1, s);
                    var nswZoneOneLastPeriod2ZoneReport = BuildAndPersistZoneReport(lastPeriod2Submitted, nswZoneOne, lastPeriod2, s);

                    var nswZoneTwoThisPeriodZoneReport = BuildAndPersistZoneReport(thisPeriodSubmitted, nswZoneTwo, reportingPeriod, s);
                    var nswZoneTwoLastPeriod1ZoneReport = BuildAndPersistZoneReport(lastPeriod1Submitted, nswZoneTwo, lastPeriod1, s);
                    var nswZoneTwoLastPeriod2ZoneReport = BuildAndPersistZoneReport(lastPeriod2Submitted, nswZoneTwo, lastPeriod2, s);

                    var laPerouseThisPeriodUnitReport = BuildAndPersistUnitReport(thisPeriodSubmitted, laPerouse, reportingPeriod, s);
                    var laPerouseLastPeriod1UnitReport = BuildAndPersistUnitReport(lastPeriod1Submitted, laPerouse, lastPeriod1, s);
                    var laPerouseLastPeriod2UnitReport = BuildAndPersistUnitReport(lastPeriod2Submitted, laPerouse, lastPeriod2, s);

                    var lalorParkThisPeriodUnitReport = BuildAndPersistUnitReport(thisPeriodSubmitted, lalorPark, reportingPeriod, s);
                    var lalorParkLastPeriod1UnitReport = BuildAndPersistUnitReport(lastPeriod1Submitted, lalorPark, lastPeriod1, s);
                    var lalorParkLastPeriod2UnitReport = BuildAndPersistUnitReport(lastPeriod2Submitted, lalorPark, lastPeriod2, s);

                    var laneCoveThisPeriodUnitReport = BuildAndPersistUnitReport(thisPeriodSubmitted, laneCove, reportingPeriod, s);
                    var laneCoveLastPeriod1UnitReport = BuildAndPersistUnitReport(lastPeriod1Submitted, laneCove, lastPeriod1, s);
                    var laneCoveLastPeriod2UnitReport = BuildAndPersistUnitReport(lastPeriod2Submitted, laneCove, lastPeriod2, s);

                    return new
                    {
                        description,
                        reportingFrequency,
                        reportingPeriod,
                        lastPeriod1,
                        lastPeriod2,
                        organizationRef,
                        nswZoneOneThisPeriodZoneReport,
                        nswZoneOneLastPeriod1ZoneReport,
                        nswZoneOneLastPeriod2ZoneReport,
                        nswZoneTwoThisPeriodZoneReport,
                        nswZoneTwoLastPeriod1ZoneReport,
                        nswZoneTwoLastPeriod2ZoneReport,
                        laPerouseThisPeriodUnitReport,
                        laPerouseLastPeriod1UnitReport,
                        laPerouseLastPeriod2UnitReport,
                        lalorParkThisPeriodUnitReport,
                        lalorParkLastPeriod1UnitReport,
                        lalorParkLastPeriod2UnitReport,
                        laneCoveThisPeriodUnitReport,
                        laneCoveLastPeriod1UnitReport,
                        laneCoveLastPeriod2UnitReport,
                    };
                });
            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c =>
                {
                    var stateReport = c.GetInstance<IStateReportFactory>()
                        .CreateNewStatePlan(testParams.description,
                            testParams.organizationRef,
                            testParams.reportingPeriod.ReportingTerm,
                            testParams.reportingPeriod.Year);
                    return new
                    {
                        stateReport
                    };
                });
            result.stateReport.Should().NotBeNull();
            result.stateReport.Description.Should().Be(testParams.description);
            result.stateReport.ReportingPeriod.Year.Should().Be(testParams.reportingPeriod.Year);
            result.stateReport.ReportingPeriod.ReportingFrequency.Should().Be(testParams.reportingFrequency);
            result.stateReport.ReportingPeriod.ReportingTerm.Should().Be(testParams.reportingPeriod.ReportingTerm);
            result.stateReport.Organization.Should().Be(testParams.organizationRef);
            result.stateReport.Timestamp.Should().Be(now);
            result.stateReport.IsDeleted.Should().Be(false);

            if (!thisPeriodSubmitted && !lastPeriod1Submitted && !lastPeriod2Submitted)
            {
                result.stateReport.AssociateMemberData.UpgradeTarget.Should().Be(MemberData.Default().UpgradeTarget);
                result.stateReport.AssociateMemberData.LastPeriod.Should().Be(MemberData.Default().LastPeriod);
                result.stateReport.AssociateMemberData.Increased.Should().Be(MemberData.Default().Increased);
                result.stateReport.AssociateMemberData.Decreased.Should().Be(MemberData.Default().Decreased);
                result.stateReport.AssociateMemberData.ThisPeriod.Should().Be(MemberData.Default().ThisPeriod);

                result.stateReport.PreliminaryMemberData.UpgradeTarget.Should().Be(MemberData.Default().UpgradeTarget);
                result.stateReport.PreliminaryMemberData.LastPeriod.Should().Be(MemberData.Default().LastPeriod);
                result.stateReport.PreliminaryMemberData.Increased.Should().Be(MemberData.Default().Increased);
                result.stateReport.PreliminaryMemberData.Decreased.Should().Be(MemberData.Default().Decreased);
                result.stateReport.PreliminaryMemberData.ThisPeriod.Should().Be(MemberData.Default().ThisPeriod);

            }

            if (thisPeriodSubmitted == false
                && lastPeriod1Submitted
                && ValidReportPeriod(testParams.reportingPeriod, testParams.lastPeriod1)
                )
            {
                result.stateReport.AssociateMemberData.UpgradeTarget.Should().Be(
                    testParams.nswZoneOneLastPeriod1ZoneReport.AssociateMemberData.UpgradeTarget +
                    testParams.nswZoneTwoLastPeriod1ZoneReport.AssociateMemberData.UpgradeTarget +
                    testParams.laPerouseLastPeriod1UnitReport.AssociateMemberData.UpgradeTarget +
                    testParams.lalorParkLastPeriod1UnitReport.AssociateMemberData.UpgradeTarget +
                    testParams.laneCoveLastPeriod1UnitReport.AssociateMemberData.UpgradeTarget
                    );

                result.stateReport.AssociateMemberData.LastPeriod.Should().Be(
                    testParams.nswZoneOneLastPeriod1ZoneReport.AssociateMemberData.LastPeriod +
                    testParams.nswZoneTwoLastPeriod1ZoneReport.AssociateMemberData.LastPeriod +
                    testParams.laPerouseLastPeriod1UnitReport.AssociateMemberData.LastPeriod +
                    testParams.lalorParkLastPeriod1UnitReport.AssociateMemberData.LastPeriod +
                    testParams.laneCoveLastPeriod1UnitReport.AssociateMemberData.LastPeriod
                );

                result.stateReport.AssociateMemberData.ThisPeriod.Should().Be(
                    testParams.nswZoneOneLastPeriod1ZoneReport.AssociateMemberData.ThisPeriod +
                    testParams.nswZoneTwoLastPeriod1ZoneReport.AssociateMemberData.ThisPeriod +
                    testParams.laPerouseLastPeriod1UnitReport.AssociateMemberData.ThisPeriod +
                    testParams.lalorParkLastPeriod1UnitReport.AssociateMemberData.ThisPeriod +
                    testParams.laneCoveLastPeriod1UnitReport.AssociateMemberData.ThisPeriod
                );
                result.stateReport.PreliminaryMemberData.UpgradeTarget.Should().Be(
                    testParams.nswZoneOneLastPeriod1ZoneReport.PreliminaryMemberData.UpgradeTarget +
                    testParams.nswZoneTwoLastPeriod1ZoneReport.PreliminaryMemberData.UpgradeTarget +
                    testParams.laPerouseLastPeriod1UnitReport.PreliminaryMemberData.UpgradeTarget +
                    testParams.lalorParkLastPeriod1UnitReport.PreliminaryMemberData.UpgradeTarget +
                    testParams.laneCoveLastPeriod1UnitReport.PreliminaryMemberData.UpgradeTarget
                    );

                result.stateReport.PreliminaryMemberData.LastPeriod.Should().Be(
                    testParams.nswZoneOneLastPeriod1ZoneReport.PreliminaryMemberData.LastPeriod +
                    testParams.nswZoneTwoLastPeriod1ZoneReport.PreliminaryMemberData.LastPeriod +
                    testParams.laPerouseLastPeriod1UnitReport.PreliminaryMemberData.LastPeriod +
                    testParams.lalorParkLastPeriod1UnitReport.PreliminaryMemberData.LastPeriod +
                    testParams.laneCoveLastPeriod1UnitReport.PreliminaryMemberData.LastPeriod
                );

                result.stateReport.PreliminaryMemberData.ThisPeriod.Should().Be(
                    testParams.nswZoneOneLastPeriod1ZoneReport.PreliminaryMemberData.ThisPeriod +
                    testParams.nswZoneTwoLastPeriod1ZoneReport.PreliminaryMemberData.ThisPeriod +
                    testParams.laPerouseLastPeriod1UnitReport.PreliminaryMemberData.ThisPeriod +
                    testParams.lalorParkLastPeriod1UnitReport.PreliminaryMemberData.ThisPeriod +
                    testParams.laneCoveLastPeriod1UnitReport.PreliminaryMemberData.ThisPeriod
                );

            }

            if (thisPeriodSubmitted == false
                && lastPeriod1Submitted == false
                && lastPeriod2Submitted
                && ValidReportPeriod(testParams.reportingPeriod, testParams.lastPeriod2)
                )
            {
                result.stateReport.AssociateMemberData.UpgradeTarget.Should().Be(
                    testParams.nswZoneOneLastPeriod2ZoneReport.AssociateMemberData.UpgradeTarget +
                    testParams.nswZoneTwoLastPeriod2ZoneReport.AssociateMemberData.UpgradeTarget +
                    testParams.laPerouseLastPeriod2UnitReport.AssociateMemberData.UpgradeTarget +
                    testParams.lalorParkLastPeriod2UnitReport.AssociateMemberData.UpgradeTarget +
                    testParams.laneCoveLastPeriod2UnitReport.AssociateMemberData.UpgradeTarget
                    );

                result.stateReport.AssociateMemberData.LastPeriod.Should().Be(
                    testParams.nswZoneOneLastPeriod2ZoneReport.AssociateMemberData.LastPeriod +
                    testParams.nswZoneTwoLastPeriod2ZoneReport.AssociateMemberData.LastPeriod +
                    testParams.laPerouseLastPeriod2UnitReport.AssociateMemberData.LastPeriod +
                    testParams.lalorParkLastPeriod2UnitReport.AssociateMemberData.LastPeriod +
                    testParams.laneCoveLastPeriod2UnitReport.AssociateMemberData.LastPeriod
                );

                result.stateReport.AssociateMemberData.ThisPeriod.Should().Be(
                    testParams.nswZoneOneLastPeriod2ZoneReport.AssociateMemberData.ThisPeriod +
                    testParams.nswZoneTwoLastPeriod2ZoneReport.AssociateMemberData.ThisPeriod +
                    testParams.laPerouseLastPeriod2UnitReport.AssociateMemberData.ThisPeriod +
                    testParams.lalorParkLastPeriod2UnitReport.AssociateMemberData.ThisPeriod +
                    testParams.laneCoveLastPeriod2UnitReport.AssociateMemberData.ThisPeriod
                );
                result.stateReport.PreliminaryMemberData.UpgradeTarget.Should().Be(
                    testParams.nswZoneOneLastPeriod2ZoneReport.PreliminaryMemberData.UpgradeTarget +
                    testParams.nswZoneTwoLastPeriod2ZoneReport.PreliminaryMemberData.UpgradeTarget +
                    testParams.laPerouseLastPeriod2UnitReport.PreliminaryMemberData.UpgradeTarget +
                    testParams.lalorParkLastPeriod2UnitReport.PreliminaryMemberData.UpgradeTarget +
                    testParams.laneCoveLastPeriod2UnitReport.PreliminaryMemberData.UpgradeTarget
                    );

                result.stateReport.PreliminaryMemberData.LastPeriod.Should().Be(
                    testParams.nswZoneOneLastPeriod2ZoneReport.PreliminaryMemberData.LastPeriod +
                    testParams.nswZoneTwoLastPeriod2ZoneReport.PreliminaryMemberData.LastPeriod +
                    testParams.laPerouseLastPeriod2UnitReport.PreliminaryMemberData.LastPeriod +
                    testParams.lalorParkLastPeriod2UnitReport.PreliminaryMemberData.LastPeriod +
                    testParams.laneCoveLastPeriod2UnitReport.PreliminaryMemberData.LastPeriod
                );

                result.stateReport.PreliminaryMemberData.ThisPeriod.Should().Be(
                    testParams.nswZoneOneLastPeriod2ZoneReport.PreliminaryMemberData.ThisPeriod +
                    testParams.nswZoneTwoLastPeriod2ZoneReport.PreliminaryMemberData.ThisPeriod +
                    testParams.laPerouseLastPeriod2UnitReport.PreliminaryMemberData.ThisPeriod +
                    testParams.lalorParkLastPeriod2UnitReport.PreliminaryMemberData.ThisPeriod +
                    testParams.laneCoveLastPeriod2UnitReport.PreliminaryMemberData.ThisPeriod
                );
            }


        }

        [Explicit]
        [Theory]
        [TestCase(ReportingFrequency.Quarterly, ReportingTerm.One, false, true, true)]
        public void CreateNewPlanZoneAndUnit_SavesMeetingProgramDataCorrectly(
            ReportingFrequency reportingFrequency,
            ReportingTerm reportingTerm,
            bool thisPeriodSubmitted,
            bool lastPeriod1Submitted,
            bool lastPeriod2Submitted
            )
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var now = DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var reportingTerms = ReportingPeriod.GetReportingTerms(reportingFrequency);
            if (reportingTerms.All(o => o != reportingTerm))
                return;

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(stateReportingFrequency: reportingFrequency, zoneReportingFrequency: ReportingFrequency.Quarterly);

                    var nswState = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswState).Value;
                    var nswZoneOne = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswZoneOne).Value;

                    var nswZoneTwo = new OrganizationBuilder()
                        .SetDescription("Nsw Zone Two")
                        .SetOrganizationType(OrganizationType.Zone)
                        .SetReportingFreQuency(reportingFrequency)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    var laPerouse = new OrganizationBuilder()
                        .SetDescription("La perouse")
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(ReportingFrequency.Monthly)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    var lalorPark = new OrganizationBuilder()
                        .SetDescription("Lalor park")
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(ReportingFrequency.EveryTwoMonth)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    var laneCove = new OrganizationBuilder()
                        .SetDescription("Lane cove")
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(reportingFrequency)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    new OrganizationBuilder()
                        .SetDescription("Lavender Bay")
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(reportingFrequency)
                        .SetParent(nswZoneTwo)
                        .BuildAndPersist(s);

                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    OrganizationReference organizationRef = nswState;

                    var reportingPeriod = new ReportingPeriod(reportingFrequency, reportingTerm, year);

                    var lastPeriod1 = reportingPeriod.GetReportingPeriodOfPreviousTerm();
                    var lastPeriod2 = lastPeriod1.GetReportingPeriodOfPreviousTerm();

                    var nswZoneOneThisPeriodZoneReport = BuildAndPersistZoneReport(thisPeriodSubmitted, nswZoneOne, reportingPeriod, s);
                    var nswZoneOneLastPeriod1ZoneReport = BuildAndPersistZoneReport(lastPeriod1Submitted, nswZoneOne, lastPeriod1, s);
                    var nswZoneOneLastPeriod2ZoneReport = BuildAndPersistZoneReport(lastPeriod2Submitted, nswZoneOne, lastPeriod2, s);

                    var nswZoneTwoThisPeriodZoneReport = BuildAndPersistZoneReport(thisPeriodSubmitted, nswZoneTwo, reportingPeriod, s);
                    var nswZoneTwoLastPeriod1ZoneReport = BuildAndPersistZoneReport(lastPeriod1Submitted, nswZoneTwo, lastPeriod1, s);
                    var nswZoneTwoLastPeriod2ZoneReport = BuildAndPersistZoneReport(lastPeriod2Submitted, nswZoneTwo, lastPeriod2, s);

                    var laPerouseThisPeriodUnitReport = BuildAndPersistUnitReport(thisPeriodSubmitted, laPerouse, reportingPeriod, s);
                    var laPerouseLastPeriod1UnitReport = BuildAndPersistUnitReport(lastPeriod1Submitted, laPerouse, lastPeriod1, s);
                    var laPerouseLastPeriod2UnitReport = BuildAndPersistUnitReport(lastPeriod2Submitted, laPerouse, lastPeriod2, s);

                    var lalorParkThisPeriodUnitReport = BuildAndPersistUnitReport(thisPeriodSubmitted, lalorPark, reportingPeriod, s);
                    var lalorParkLastPeriod1UnitReport = BuildAndPersistUnitReport(lastPeriod1Submitted, lalorPark, lastPeriod1, s);
                    var lalorParkLastPeriod2UnitReport = BuildAndPersistUnitReport(lastPeriod2Submitted, lalorPark, lastPeriod2, s);

                    var laneCoveThisPeriodUnitReport = BuildAndPersistUnitReport(thisPeriodSubmitted, laneCove, reportingPeriod, s);
                    var laneCoveLastPeriod1UnitReport = BuildAndPersistUnitReport(lastPeriod1Submitted, laneCove, lastPeriod1, s);
                    var laneCoveLastPeriod2UnitReport = BuildAndPersistUnitReport(lastPeriod2Submitted, laneCove, lastPeriod2, s);

                    return new
                    {
                        description,
                        reportingFrequency,
                        reportingPeriod,
                        lastPeriod1,
                        lastPeriod2,
                        organizationRef,
                        nswZoneOneThisPeriodZoneReport,
                        nswZoneOneLastPeriod1ZoneReport,
                        nswZoneOneLastPeriod2ZoneReport,
                        nswZoneTwoThisPeriodZoneReport,
                        nswZoneTwoLastPeriod1ZoneReport,
                        nswZoneTwoLastPeriod2ZoneReport,
                        laPerouseThisPeriodUnitReport,
                        laPerouseLastPeriod1UnitReport,
                        laPerouseLastPeriod2UnitReport,
                        lalorParkThisPeriodUnitReport,
                        lalorParkLastPeriod1UnitReport,
                        lalorParkLastPeriod2UnitReport,
                        laneCoveThisPeriodUnitReport,
                        laneCoveLastPeriod1UnitReport,
                        laneCoveLastPeriod2UnitReport,
                    };
                });
            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c =>
                {
                    var stateReport = c.GetInstance<IStateReportFactory>()
                        .CreateNewStatePlan(testParams.description,
                            testParams.organizationRef,
                            testParams.reportingPeriod.ReportingTerm,
                            testParams.reportingPeriod.Year);
                    return new
                    {
                        stateReport
                    };
                });
            result.stateReport.Should().NotBeNull();
            result.stateReport.Description.Should().Be(testParams.description);
            result.stateReport.ReportingPeriod.Year.Should().Be(testParams.reportingPeriod.Year);
            result.stateReport.ReportingPeriod.ReportingFrequency.Should().Be(testParams.reportingFrequency);
            result.stateReport.ReportingPeriod.ReportingTerm.Should().Be(testParams.reportingPeriod.ReportingTerm);
            result.stateReport.Organization.Should().Be(testParams.organizationRef);
            result.stateReport.Timestamp.Should().Be(now);
            result.stateReport.IsDeleted.Should().Be(false);

            if (!thisPeriodSubmitted && !lastPeriod1Submitted && !lastPeriod2Submitted)
            {
                result.stateReport.WorkerMeetingProgramData.Target.Should().Be(MeetingProgramData.Default().Target);
                result.stateReport.WorkerMeetingProgramData.Actual.Should().Be(MeetingProgramData.Default().Actual);
                result.stateReport.WorkerMeetingProgramData.AverageAttendance.Should().Be(MeetingProgramData.Default().AverageAttendance);
            }

            if (thisPeriodSubmitted && lastPeriod1Submitted == false && lastPeriod2Submitted == false)
            {

                result.stateReport.WorkerMeetingProgramData.Target.Should().Be(
                    testParams.nswZoneOneThisPeriodZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoThisPeriodZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseThisPeriodUnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkThisPeriodUnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveThisPeriodUnitReport.WorkerMeetingProgramData.Target
                    );

            }

            if (thisPeriodSubmitted == false
                && lastPeriod1Submitted
                && lastPeriod2Submitted == false
                && ValidReportPeriod(testParams.reportingPeriod, testParams.lastPeriod1))
            {
                result.stateReport.WorkerMeetingProgramData.Target.Should().Be(
                    testParams.nswZoneOneLastPeriod1ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoLastPeriod1ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseLastPeriod1UnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkLastPeriod1UnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveLastPeriod1UnitReport.WorkerMeetingProgramData.Target
                );

            }

            if (thisPeriodSubmitted == false
                && lastPeriod1Submitted == false
                && lastPeriod2Submitted
                && ValidReportPeriod(testParams.reportingPeriod, testParams.lastPeriod2))
            {
                result.stateReport.WorkerMeetingProgramData.Target.Should().Be(
                    testParams.nswZoneOneThisPeriodZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneOneLastPeriod2ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseLastPeriod2UnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkLastPeriod2UnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveLastPeriod2UnitReport.WorkerMeetingProgramData.Target
                );

            }

            if (thisPeriodSubmitted
                && lastPeriod1Submitted
                && lastPeriod2Submitted == false
                && ValidReportPeriod(testParams.reportingPeriod, testParams.lastPeriod1))
            {
                result.stateReport.WorkerMeetingProgramData.Target.Should().Be(
                    testParams.nswZoneOneThisPeriodZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoThisPeriodZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseThisPeriodUnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkThisPeriodUnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveThisPeriodUnitReport.WorkerMeetingProgramData.Target +

                    testParams.nswZoneOneLastPeriod1ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoLastPeriod1ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseLastPeriod1UnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkLastPeriod1UnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveLastPeriod1UnitReport.WorkerMeetingProgramData.Target
                );

            }

            if (thisPeriodSubmitted == false
                && lastPeriod1Submitted
                && lastPeriod2Submitted
                && ValidReportPeriod(testParams.reportingPeriod, testParams.lastPeriod1)
                && ValidReportPeriod(testParams.reportingPeriod, testParams.lastPeriod2)
            )
            {
                result.stateReport.WorkerMeetingProgramData.Target.Should().Be(
                    testParams.nswZoneOneLastPeriod1ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoLastPeriod1ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseLastPeriod1UnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkLastPeriod1UnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveLastPeriod1UnitReport.WorkerMeetingProgramData.Target +

                    testParams.nswZoneOneLastPeriod2ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoLastPeriod2ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseLastPeriod2UnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkLastPeriod2UnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveLastPeriod2UnitReport.WorkerMeetingProgramData.Target
                );
            }

            if (thisPeriodSubmitted
                && lastPeriod1Submitted == false
                && lastPeriod2Submitted
                && ValidReportPeriod(testParams.reportingPeriod, testParams.lastPeriod2)
            )
            {
                result.stateReport.WorkerMeetingProgramData.Target.Should().Be(
                    testParams.nswZoneOneThisPeriodZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoThisPeriodZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseThisPeriodUnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkThisPeriodUnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveThisPeriodUnitReport.WorkerMeetingProgramData.Target +

                    testParams.nswZoneOneLastPeriod2ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoLastPeriod2ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseLastPeriod2UnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkLastPeriod2UnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveLastPeriod2UnitReport.WorkerMeetingProgramData.Target
                );
            }

            if (thisPeriodSubmitted
                && lastPeriod1Submitted
                && lastPeriod2Submitted
                && ValidReportPeriod(testParams.reportingPeriod, testParams.lastPeriod1)
                && ValidReportPeriod(testParams.reportingPeriod, testParams.lastPeriod2)
                )
            {
                result.stateReport.WorkerMeetingProgramData.Target.Should().Be(
                    testParams.nswZoneOneThisPeriodZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoThisPeriodZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseThisPeriodUnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkThisPeriodUnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveThisPeriodUnitReport.WorkerMeetingProgramData.Target +

                    testParams.nswZoneOneLastPeriod1ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoLastPeriod1ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseLastPeriod1UnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkLastPeriod1UnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveLastPeriod1UnitReport.WorkerMeetingProgramData.Target +

                    testParams.nswZoneOneLastPeriod2ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.nswZoneTwoLastPeriod2ZoneReport.WorkerMeetingProgramData.Target +
                    testParams.laPerouseLastPeriod2UnitReport.WorkerMeetingProgramData.Target +
                    testParams.lalorParkLastPeriod2UnitReport.WorkerMeetingProgramData.Target +
                    testParams.laneCoveLastPeriod2UnitReport.WorkerMeetingProgramData.Target
                );
            }
        }

        private static ZoneReport BuildAndPersistZoneReport(bool submitted, Organization organization,
            ReportingPeriod reportingPeriod, ISession s)
        {
            string description = DataProvider.Get<string>();
            var reportingData = new ReportDataBuilder().Build();
            var report =
                new ZoneReport(description, organization, reportingPeriod, reportingData);
            if (submitted)
                report.MarkStatusAsSubmitted();
            s.Save(report);
            return report;
        }

        private bool ValidReportPeriod(ReportingPeriod thisPeriod, ReportingPeriod lastPeriod)
        {
            if (thisPeriod.StartDate >= lastPeriod.StartDate && thisPeriod.EndDate <= lastPeriod.EndDate)
                return true;
            return false;
        }

        */
    }

}