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
    public class UpdateUnitPlanCommandHandlerIntegrationTests
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
        public async Task Handle_SavesPlan(ReportingFrequency reportingFrequency )
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new OrganizationBuilder()
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(reportingFrequency)
                        .BuildAndPersist(s);

                    var report = new UnitReportBuilder()
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .BuildAndPersist(s);

                    var associateMemberData = new TestObjectBuilder<MemberData>()
                        .Build();

                    var preliminaryMemberData = new TestObjectBuilder<MemberData>()
                        .Build();

                    var workerMeetingProgramData = new TestObjectBuilder<MeetingProgramData>()
                        .Build();

                    var supporterMemberData = new TestObjectBuilder<MemberData>()
                        .Build();

                    var memberMemberData = new TestObjectBuilder<MemberData>()
                        .Build();

                    PlanData planData = new ReportDataBuilder()
                        .SetAssociateMemberData(associateMemberData)
                        .SetPreliminaryMemberData(preliminaryMemberData)
                        .SetWorkerMeetingProgramData(workerMeetingProgramData)
                        .SetSupporterMemberData(supporterMemberData)
                        .SetMemberMemberData(memberMemberData)
                        .Build();

                    EntityReference reportRef = report;
                    var expectedEvt = Test.CreateInstance<IUnitPlanUpdated>(e =>
                    {
                        e.Organization = organization;
                        e.Username = username;
                        e.UnitReport = reportRef;
                    });


                    return new
                    {
                        Cmd = new UpdateUnitPlanCommand(report.Id,
                            planData),
                        Organization = organization,
                        Report = report,
                        username,
                        expectedEvt
                    };
                });

            var context = await Endpoint.Act<UpdateUnitPlanCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<IUnitPlanUpdated>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                   var unitReport = s.Get<UnitReport>(testParams.Cmd.ReportId);
                    unitReport.Should().NotBeNull();
                    unitReport.Should().BeEquivalentTo(testParams.Report, e => 
                        e.Excluding(p => p.AssociateMemberData)
                            .Excluding(p => p.PreliminaryMemberData)
                            .Excluding(p => p.SupporterMemberData)
                            .Excluding(p => p.WorkerMeetingProgramData)
                            .Excluding(p => p.DawahMeetingProgramData)
                            .Excluding(p => p.StateLeaderMeetingProgramData)
                            .Excluding(p => p.StateOutingMeetingProgramData)
                            .Excluding(p => p.IftarMeetingProgramData)
                            .Excluding(p => p.LearningMeetingProgramData)
                            .Excluding(p => p.SocialDawahMeetingProgramData)
                            .Excluding(p => p.DawahGroupMeetingProgramData)
                            .Excluding(p => p.NextGMeetingProgramData)
                            .Excluding(p => p.CmsMeetingProgramData)
                            .Excluding(p => p.SmMeetingProgramData)
                            .Excluding(p => p.MemberMeetingProgramData)
                            .Excluding(p => p.TafsirMeetingProgramData)
                            .Excluding(p => p.UnitMeetingProgramData)
                            .Excluding(p => p.FamilyVisitMeetingProgramData)
                            .Excluding(p => p.EidReunionMeetingProgramData)
                            .Excluding(p => p.BbqMeetingProgramData)
                            .Excluding(p => p.GatheringMeetingProgramData)
                            .Excluding(p => p.OtherMeetingProgramData)
                            .Excluding(p => p.MemberMemberData)
                            .Excluding(p => p.BaitulMalFinanceData)
                            .Excluding(p => p.ADayMasjidProjectFinanceData)
                            .Excluding(p => p.MasjidTableBankFinanceData)
                            .Excluding(p => p.QardeHasanaSocialWelfareData)
                            .Excluding(p => p.PatientVisitSocialWelfareData)
                            .Excluding(p => p.SocialVisitSocialWelfareData)
                            .Excluding(p => p.TransportSocialWelfareData)
                            .Excluding(p => p.ShiftingSocialWelfareData)
                            .Excluding(p => p.ShoppingSocialWelfareData)
                            .Excluding(p => p.FoodDistributionSocialWelfareData)
                            .Excluding(p => p.CleanUpAustraliaSocialWelfareData)
                            .Excluding(p => p.OtherSocialWelfareData)
                            .Excluding(p => p.BookSaleMaterialData)
                            .Excluding(p => p.BookDistributionMaterialData)
                            .Excluding(p => p.BookLibraryStockData)

                            .Excluding(p => p.OtherSaleMaterialData)
                            .Excluding(p => p.OtherDistributionMaterialData)
                            .Excluding(p => p.OtherLibraryStockData)

                            .Excluding(p => p.VhsSaleMaterialData)
                            .Excluding(p => p.VhsDistributionMaterialData)
                            .Excluding(p => p.VhsLibraryStockData)
                            .Excluding(p => p.EmailDistributionMaterialData)
                            .Excluding(p => p.IpdcLeafletDistributionMaterialData)
                            
                            .Excluding(p => p.GroupStudyTeachingLearningProgramData)
                            .Excluding(p => p.StudyCircleTeachingLearningProgramData)
                            .Excluding(p => p.PracticeDarsTeachingLearningProgramData)
                            .Excluding(p => p.StateLearningCampTeachingLearningProgramData)
                            .Excluding(p => p.QuranStudyTeachingLearningProgramData)
                            .Excluding(p => p.QuranClassTeachingLearningProgramData)
                            .Excluding(p => p.MemorizingAyatTeachingLearningProgramData)
                            .Excluding(p => p.StateLearningSessionTeachingLearningProgramData)
                            .Excluding(p => p.StateQiyamulLailTeachingLearningProgramData)
                            //
                            .Excluding(p => p.StudyCircleForAssociateMemberTeachingLearningProgramData)
                            .Excluding(p => p.HadithTeachingLearningProgramData)
                            .Excluding(p => p.WeekendIslamicSchoolTeachingLearningProgramData)
                            .Excluding(p => p.MemorizingHadithTeachingLearningProgramData)
                            .Excluding(p => p.MemorizingDoaTeachingLearningProgramData)
                            .Excluding(p => p.OtherTeachingLearningProgramData)
                        );

                    ReportData reportData = unitReport;
                    PlanData planData = reportData;
                    planData.Should().BeEquivalentTo(testParams.Cmd.PlanData);

                    evt.Should().BeEquivalentTo(testParams.expectedEvt, e => e.Excluding(p => p.SerializedData));
                    evt.SerializedData.Should().NotBe(null);

                });
        }
    }
}