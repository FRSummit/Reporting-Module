﻿using System.Threading.Tasks;
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
    public class UpdateCentralReportCommandHandlerIntegrationTests
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

        [TestCase(ReportingFrequency.Yearly)]
        [TestCase(ReportingFrequency.Quarterly)]
        public async Task Handle_SavesReport(ReportingFrequency reportingFrequency)
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new OrganizationBuilder()
                        .SetOrganizationType(OrganizationType.Central)
                        .SetReportingFreQuency(reportingFrequency)
                        .BuildAndPersist(s);

                    var report = new CentralReportBuilder()
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .Build();
                    report.MarkStatusAsPlanPromoted();
                    s.Save(report);
                    var memberMemberData = new TestObjectBuilder<MemberData>()
                        .Build();
                    var associateMemberData = new TestObjectBuilder<MemberData>()
                        .Build();

                    var preliminaryMemberData = new TestObjectBuilder<MemberData>()
                        .Build();

                    //Todo pass random data once supporterMember is added to the CentralReport
                    var supporterMemberData = new TestObjectBuilder<MemberData>()
                        .Build();

                    var workerMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var dawahMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var stateLeaderMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var stateOutingMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var iftarMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var learningMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var socialDawahMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var dawahGroupMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var nextGMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

                    var cmsMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var smMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var memberMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var tafsirMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var unitMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var familyVisitMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var eidReunionMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var bbqMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var gatheringMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
                    var otherMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

                    var groupStudyTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var studyCircleTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var practiceDarsTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var stateLearningCampTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var quranStudyTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var quranClassTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var memorizingAyatTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var stateLearningSessionTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var stateQiyamulLailTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var studyCircleForAssociateMemberTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var hadithTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var weekendIslamicSchoolTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var memorizingHadithTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var memorizingDoaTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
                    var otherTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();


                    var baitulMalFinanceData = FinanceData.Default();
                    var aDayMasjidProjectFinanceData = FinanceData.Default();
                    var masjidTableBankFinanceData = FinanceData.Default();

                    var qardeHasanaSocialWelfareData = SocialWelfareData.Default();
                    var patientVisitSocialWelfareData = SocialWelfareData.Default();
                    var socialVisitSocialWelfareData = SocialWelfareData.Default();

                    var transportSocialWelfareData = SocialWelfareData.Default();
                    var shiftingSocialWelfareData = SocialWelfareData.Default();
                    var shoppingSocialWelfareData = SocialWelfareData.Default();
                    var foodDistributionSocialWelfareData = SocialWelfareData.Default();
                    var cleanUpAustraliaSocialWelfareData = SocialWelfareData.Default();
                    var otherSocialWelfareData = SocialWelfareData.Default();

                    var bookSaleMaterialData = MaterialData.Default();
                    var bookDistributionMaterialData = MaterialData.Default();
                    var bookLibraryStockData = LibraryStockData.Default();
                    var otherSaleMaterialData = MaterialData.Default();
                    var otherDistributionMaterialData = MaterialData.Default();
                    var otherLibraryStockData = LibraryStockData.Default();
                    var vhsSaleMaterialData = MaterialData.Default();
                    var vhsDistributionMaterialData = MaterialData.Default();
                    var vhsLibraryStockData = LibraryStockData.Default();
                    var emailDistributionMaterialData = MaterialData.Default();
                    var ipdcLeafletDistributionMaterialData = MaterialData.Default();

                    //var bookLibraryStockData = LibraryStockData.Default();
                    //var vhsLibraryStockData = LibraryStockData.Default();

                    var comment = DataProvider.Get<string>();


                    ReportUpdateData centralReportUpdateData = new ReportDataBuilder()
                        .SetMemberMemberData(memberMemberData)
                        .SetAssociateMemberData(associateMemberData)
                        .SetPreliminaryMemberData(preliminaryMemberData)
                        .SetSupporterMemberData(supporterMemberData)

                        .SetWorkerMeetingProgramData(workerMeetingProgramData)
                        .SetDawahMeetingProgramData(dawahMeetingProgramData)
                        .SetStateLeaderMeetingProgramData(stateLeaderMeetingProgramData)
                        .SetStateOutingMeetingProgramData(stateOutingMeetingProgramData)
                        .SetIftarMeetingProgramData(iftarMeetingProgramData)
                        .SetLearningMeetingProgramData(learningMeetingProgramData)
                        .SetSocialDawahMeetingProgramData(socialDawahMeetingProgramData)
                        .SetDawahGroupMeetingProgramData(dawahGroupMeetingProgramData)
                        .SetNextGMeetingProgramData(nextGMeetingProgramData)

                        .SetCmsMeetingProgramData(cmsMeetingProgramData)
                        .SetSmMeetingProgramData(smMeetingProgramData)
                        .SetMemberMeetingProgramData(memberMeetingProgramData)
                        .SetTafsirMeetingProgramData(tafsirMeetingProgramData)
                        .SetUnitMeetingProgramData(unitMeetingProgramData)
                        .SetFamilyVisitMeetingProgramData(familyVisitMeetingProgramData)
                        .SetEidReunionMeetingProgramData(eidReunionMeetingProgramData)
                        .SetBbqMeetingProgramData(bbqMeetingProgramData)
                        .SetGatheringMeetingProgramData(gatheringMeetingProgramData)
                        .SetOtherMeetingProgramData(otherMeetingProgramData)

                        .SetGroupStudyTeachingLearningProgramData(groupStudyTeachingLearningProgramData)
                        .SetStudyCircleTeachingLearningProgramData(studyCircleTeachingLearningProgramData)
                        .SetPracticeDarsTeachingLearningProgramData(practiceDarsTeachingLearningProgramData)
                        .SetStateLearningCampTeachingLearningProgramData(stateLearningCampTeachingLearningProgramData)
                        .SetQuranStudyTeachingLearningProgramData(quranStudyTeachingLearningProgramData)
                        .SetQuranClassTeachingLearningProgramData(quranClassTeachingLearningProgramData)
                        .SetMemorizingAyatTeachingLearningProgramData(memorizingAyatTeachingLearningProgramData)
                        .SetStateLearningSessionTeachingLearningProgramData(stateLearningSessionTeachingLearningProgramData)
                        .SetStateQiyamulLailTeachingLearningProgramData(stateQiyamulLailTeachingLearningProgramData)

                        .SetBaitulMalFinanceData(baitulMalFinanceData)
                        .SetADayMasjidProjectFinanceData(aDayMasjidProjectFinanceData)
                        .SetMasjidTableBankFinanceData(masjidTableBankFinanceData)

                        .SetQardeHasanaSocialWelfareData(qardeHasanaSocialWelfareData)
                        .SetPatientVisitSocialWelfareData(patientVisitSocialWelfareData)
                        .SetSocialVisitSocialWelfareData(socialVisitSocialWelfareData)
                        .SetTransportSocialWelfareData(transportSocialWelfareData)
                        .SetShiftingSocialWelfareData(shiftingSocialWelfareData)
                        .SetShoppingSocialWelfareData(shoppingSocialWelfareData)

                        .SetFoodDistributionSocialWelfareData(foodDistributionSocialWelfareData)
                        .SetCleanUpAustraliaSocialWelfareData(cleanUpAustraliaSocialWelfareData)
                        .SetOtherSocialWelfareData(otherSocialWelfareData)

                        .SetBookSaleMaterialData(bookSaleMaterialData)
                        .SetBookDistributionMaterialData(bookDistributionMaterialData)
                        .SetBookLibraryStockData(bookLibraryStockData)

                        .SetOtherSaleMaterialData(otherSaleMaterialData)
                        .SetOtherDistributionMaterialData(otherDistributionMaterialData)
                        .SetOtherLibraryStockData(otherLibraryStockData)

                        .SetVhsSaleMaterialData(vhsSaleMaterialData)
                        .SetVhsDistributionMaterialData(vhsDistributionMaterialData)
                        .SetVhsLibraryStockData(vhsLibraryStockData)

                        .SetEmailDistributionMaterialData(emailDistributionMaterialData)
                        .SetIpdcLeafletDistributionMaterialData(ipdcLeafletDistributionMaterialData)

                        .SetGroupStudyTeachingLearningProgramData(groupStudyTeachingLearningProgramData)
                        .SetStudyCircleTeachingLearningProgramData(studyCircleTeachingLearningProgramData)
                        .SetPracticeDarsTeachingLearningProgramData(practiceDarsTeachingLearningProgramData)
                        .SetStateLearningCampTeachingLearningProgramData(stateLearningCampTeachingLearningProgramData)
                        .SetQuranStudyTeachingLearningProgramData(quranStudyTeachingLearningProgramData)
                        .SetQuranClassTeachingLearningProgramData(quranClassTeachingLearningProgramData)
                        .SetMemorizingAyatTeachingLearningProgramData(memorizingAyatTeachingLearningProgramData)
                        .SetStateLearningSessionTeachingLearningProgramData(stateLearningSessionTeachingLearningProgramData)
                        .SetStateQiyamulLailTeachingLearningProgramData(stateQiyamulLailTeachingLearningProgramData)

                        .SetStudyCircleForAssociateMemberTeachingLearningProgramData(studyCircleForAssociateMemberTeachingLearningProgramData)
                        .SetHadithTeachingLearningProgramData(hadithTeachingLearningProgramData)
                        .SetWeekendIslamicSchoolTeachingLearningProgramData(weekendIslamicSchoolTeachingLearningProgramData)
                        .SetMemorizingHadithTeachingLearningProgramData(memorizingHadithTeachingLearningProgramData)
                        .SetMemorizingDoaTeachingLearningProgramData(memorizingDoaTeachingLearningProgramData)
                        .SetOtherTeachingLearningProgramData(otherTeachingLearningProgramData)

                        .SetComment(comment)

                        .Build();

                    EntityReference reportRef = report;
                    var expectedEvt = Test.CreateInstance<ICentralReportUpdated>(e =>
                    {
                        e.Organization = organization;
                        e.Username = username;
                        e.CentralReport = reportRef;
                    });

                    return new
                    {
                        Cmd = new UpdateCentralReportCommand(report.Id,
                            centralReportUpdateData),
                        Report = report,
                        username,
                        expectedEvt
                    };
                });

            var context = await Endpoint.Act<UpdateCentralReportCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<ICentralReportUpdated>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var centralReport = s.Get<CentralReport>(testParams.Cmd.ReportId);
                    centralReport.Should().NotBeNull();

                    centralReport.Should().BeEquivalentTo(testParams.Report, e =>
                        e.Excluding(p => p.MemberMemberData)
                            .Excluding(p => p.AssociateMemberData)
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

                            .Excluding(p => p.GroupStudyTeachingLearningProgramData)
                            .Excluding(p => p.StudyCircleTeachingLearningProgramData)
                            .Excluding(p => p.PracticeDarsTeachingLearningProgramData)
                            .Excluding(p => p.StateLearningCampTeachingLearningProgramData)
                            .Excluding(p => p.QuranStudyTeachingLearningProgramData)
                            .Excluding(p => p.QuranClassTeachingLearningProgramData)
                            .Excluding(p => p.MemorizingAyatTeachingLearningProgramData)
                            .Excluding(p => p.StateLearningSessionTeachingLearningProgramData)
                            .Excluding(p => p.StateQiyamulLailTeachingLearningProgramData)

                            .Excluding(p => p.StudyCircleForAssociateMemberTeachingLearningProgramData)
                            .Excluding(p => p.HadithTeachingLearningProgramData)
                            .Excluding(p => p.WeekendIslamicSchoolTeachingLearningProgramData)
                            .Excluding(p => p.MemorizingHadithTeachingLearningProgramData)
                            .Excluding(p => p.MemorizingDoaTeachingLearningProgramData)
                            .Excluding(p => p.OtherTeachingLearningProgramData)

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
                            .Excluding(p => p.Comment)
                    );

                    ReportData reportData = centralReport;
                    ReportUpdateData reportUpdateData = reportData;
                    reportUpdateData.Should().BeEquivalentTo(testParams.Cmd.ReportUpdateData);

                    evt.Should().BeEquivalentTo(testParams.expectedEvt, e => e.Excluding(p => p.SerializedData));
                    evt.SerializedData.Should().NotBe(null);
                });
        }
    }
}