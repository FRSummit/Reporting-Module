using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ReportingModule.Core;
using ReportingModule.ValueObjects;

namespace ReportingModule.Common
{
    public class Calculator
    {
        public static ReportData GetCalculatedReportData(ReportData[] onlyRecentUnitReports,
         ReportData[] allUnitReports,
         ReportData[] onlyRecentZoneReports = null,
         ReportData[] allZoneReports = null,
         ReportData[] onlyRecentStateReports = null,
         ReportData[] allStateReports = null,
         ReportData[] onlyRecentCentralReports = null,
         ReportData[] allCentralReports = null
     )
        {
            if (onlyRecentUnitReports == null)
                onlyRecentUnitReports = new ReportData[0];
            if (onlyRecentZoneReports == null)
                onlyRecentZoneReports = new ReportData[0];
            if (onlyRecentStateReports == null)
                onlyRecentStateReports = new ReportData[0];
            if (onlyRecentCentralReports == null)
                onlyRecentCentralReports = new ReportData[0];

            if (allUnitReports == null)
                allUnitReports = new ReportData[0];
            if (allZoneReports == null)
                allZoneReports = new ReportData[0];
            if (allStateReports == null)
                allStateReports = new ReportData[0];
            if (allCentralReports == null)
                allCentralReports = new ReportData[0];


            var memberMemberData = Calculator.GetCalculatedMemberData(
                onlyRecentUnitReports.Select(o => o.MemberMemberData),
                onlyRecentZoneReports.Select(o => o.MemberMemberData),
                onlyRecentStateReports.Select(o => o.MemberMemberData),
                onlyRecentCentralReports.Select(o => o.MemberMemberData));
            var associateMemberData = Calculator.GetCalculatedMemberData(
                onlyRecentUnitReports.Select(o => o.AssociateMemberData),
                onlyRecentZoneReports.Select(o => o.AssociateMemberData),
                onlyRecentStateReports.Select(o => o.AssociateMemberData),
                onlyRecentCentralReports.Select(o => o.AssociateMemberData));
            var preliminaryMemberData = Calculator.GetCalculatedMemberData(
                onlyRecentUnitReports.Select(o => o.PreliminaryMemberData),
                onlyRecentZoneReports.Select(o => o.PreliminaryMemberData),
                onlyRecentStateReports.Select(o => o.PreliminaryMemberData),
                onlyRecentCentralReports.Select(o => o.PreliminaryMemberData));
            var supporterMemberData = Calculator.GetCalculatedMemberData(
                onlyRecentUnitReports.Select(o => o.SupporterMemberData),
                onlyRecentZoneReports.Select(o => o.SupporterMemberData),
                onlyRecentStateReports.Select(o => o.SupporterMemberData),
                onlyRecentCentralReports.Select(o => o.SupporterMemberData));

            var workerMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.WorkerMeetingProgramData),
                allZoneReports.Select(o => o.WorkerMeetingProgramData),
                allStateReports.Select(o => o.WorkerMeetingProgramData),
                allCentralReports.Select(o => o.WorkerMeetingProgramData));

            var dawahMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.DawahMeetingProgramData), allZoneReports.Select(o => o.DawahMeetingProgramData),
                allStateReports.Select(o => o.DawahMeetingProgramData),
                allCentralReports.Select(o => o.DawahMeetingProgramData));

            var stateLeaderMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.StateLeaderMeetingProgramData),
                allZoneReports.Select(o => o.StateLeaderMeetingProgramData),
                allStateReports.Select(o => o.StateLeaderMeetingProgramData),
                allCentralReports.Select(o => o.StateLeaderMeetingProgramData));
            var stateOutingMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.StateOutingMeetingProgramData),
                allZoneReports.Select(o => o.StateOutingMeetingProgramData),
                allStateReports.Select(o => o.StateOutingMeetingProgramData),
                allCentralReports.Select(o => o.StateOutingMeetingProgramData));
            var iftarMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.IftarMeetingProgramData), allZoneReports.Select(o => o.IftarMeetingProgramData),
                allStateReports.Select(o => o.IftarMeetingProgramData),
                allCentralReports.Select(o => o.IftarMeetingProgramData));
            var learningMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.LearningMeetingProgramData),
                allZoneReports.Select(o => o.LearningMeetingProgramData),
                allStateReports.Select(o => o.LearningMeetingProgramData),
                allCentralReports.Select(o => o.LearningMeetingProgramData));
            var socialDawahMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.SocialDawahMeetingProgramData),
                allZoneReports.Select(o => o.SocialDawahMeetingProgramData),
                allStateReports.Select(o => o.SocialDawahMeetingProgramData),
                allCentralReports.Select(o => o.SocialDawahMeetingProgramData));
            var dawahGroupMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.DawahGroupMeetingProgramData),
                allZoneReports.Select(o => o.DawahGroupMeetingProgramData),
                allStateReports.Select(o => o.DawahGroupMeetingProgramData),
                allCentralReports.Select(o => o.DawahGroupMeetingProgramData));
            var nextGMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.NextGMeetingProgramData), allZoneReports.Select(o => o.NextGMeetingProgramData),
                allStateReports.Select(o => o.NextGMeetingProgramData),
                allCentralReports.Select(o => o.NextGMeetingProgramData));


            var cmsMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.CmsMeetingProgramData), allZoneReports.Select(o => o.CmsMeetingProgramData),
                allStateReports.Select(o => o.CmsMeetingProgramData),
                allCentralReports.Select(o => o.CmsMeetingProgramData));
            var smMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.SmMeetingProgramData), allZoneReports.Select(o => o.SmMeetingProgramData),
                allStateReports.Select(o => o.SmMeetingProgramData),
                allCentralReports.Select(o => o.SmMeetingProgramData));
            var memberMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.MemberMeetingProgramData),
                allZoneReports.Select(o => o.MemberMeetingProgramData),
                allStateReports.Select(o => o.MemberMeetingProgramData),
                allCentralReports.Select(o => o.MemberMeetingProgramData));
            var tafsirMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.TafsirMeetingProgramData),
                allZoneReports.Select(o => o.TafsirMeetingProgramData),
                allStateReports.Select(o => o.TafsirMeetingProgramData),
                allCentralReports.Select(o => o.TafsirMeetingProgramData));
            var unitMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.UnitMeetingProgramData), allZoneReports.Select(o => o.UnitMeetingProgramData),
                allStateReports.Select(o => o.UnitMeetingProgramData),
                allCentralReports.Select(o => o.UnitMeetingProgramData));
            var familyVisitMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.FamilyVisitMeetingProgramData),
                allZoneReports.Select(o => o.FamilyVisitMeetingProgramData),
                allStateReports.Select(o => o.FamilyVisitMeetingProgramData),
                allCentralReports.Select(o => o.FamilyVisitMeetingProgramData));
            var eidReunionMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.EidReunionMeetingProgramData),
                allZoneReports.Select(o => o.EidReunionMeetingProgramData),
                allStateReports.Select(o => o.EidReunionMeetingProgramData),
                allCentralReports.Select(o => o.EidReunionMeetingProgramData));
            var bbqMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.BbqMeetingProgramData), allZoneReports.Select(o => o.BbqMeetingProgramData),
                allStateReports.Select(o => o.BbqMeetingProgramData),
                allCentralReports.Select(o => o.BbqMeetingProgramData));
            var gatheringMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.GatheringMeetingProgramData),
                allZoneReports.Select(o => o.GatheringMeetingProgramData),
                allStateReports.Select(o => o.GatheringMeetingProgramData),
                allCentralReports.Select(o => o.GatheringMeetingProgramData));
            var otherMeetingProgramData = Calculator.GetCalculatedMeetingProgramData(
                allUnitReports.Select(o => o.OtherMeetingProgramData), allZoneReports.Select(o => o.OtherMeetingProgramData),
                allStateReports.Select(o => o.OtherMeetingProgramData),
                allCentralReports.Select(o => o.OtherMeetingProgramData));


            var groupStudyTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.GroupStudyTeachingLearningProgramData),
                allZoneReports.Select(o => o.GroupStudyTeachingLearningProgramData),
                allStateReports.Select(o => o.GroupStudyTeachingLearningProgramData),
                allCentralReports.Select(o => o.GroupStudyTeachingLearningProgramData));

            var studyCircleTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.StudyCircleTeachingLearningProgramData),
                allZoneReports.Select(o => o.StudyCircleTeachingLearningProgramData),
                allStateReports.Select(o => o.StudyCircleTeachingLearningProgramData),
                allCentralReports.Select(o => o.StudyCircleTeachingLearningProgramData));

            var practiceDarsTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.PracticeDarsTeachingLearningProgramData),
                allZoneReports.Select(o => o.PracticeDarsTeachingLearningProgramData),
                allStateReports.Select(o => o.PracticeDarsTeachingLearningProgramData),
                allCentralReports.Select(o => o.PracticeDarsTeachingLearningProgramData));

            var stateLearningCampTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.StateLearningCampTeachingLearningProgramData),
                allZoneReports.Select(o => o.StateLearningCampTeachingLearningProgramData),
                allStateReports.Select(o => o.StateLearningCampTeachingLearningProgramData),
                allCentralReports.Select(o => o.StateLearningCampTeachingLearningProgramData));

            var quranStudyTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.QuranStudyTeachingLearningProgramData),
                allZoneReports.Select(o => o.QuranStudyTeachingLearningProgramData),
                allStateReports.Select(o => o.QuranStudyTeachingLearningProgramData),
                allCentralReports.Select(o => o.QuranStudyTeachingLearningProgramData));

            var quranClassTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.QuranClassTeachingLearningProgramData),
                allZoneReports.Select(o => o.QuranClassTeachingLearningProgramData),
                allStateReports.Select(o => o.QuranClassTeachingLearningProgramData),
                allCentralReports.Select(o => o.QuranClassTeachingLearningProgramData));

            var memorizingAyatTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.MemorizingAyatTeachingLearningProgramData),
                allZoneReports.Select(o => o.MemorizingAyatTeachingLearningProgramData),
                allStateReports.Select(o => o.MemorizingAyatTeachingLearningProgramData),
                allCentralReports.Select(o => o.MemorizingAyatTeachingLearningProgramData));

            var stateLearningSessionTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.StateLearningSessionTeachingLearningProgramData),
                allZoneReports.Select(o => o.StateLearningSessionTeachingLearningProgramData),
                allStateReports.Select(o => o.StateLearningSessionTeachingLearningProgramData),
                allCentralReports.Select(o => o.StateLearningSessionTeachingLearningProgramData));

            var stateQiyamulLailTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.StateQiyamulLailTeachingLearningProgramData),
                allZoneReports.Select(o => o.StateQiyamulLailTeachingLearningProgramData),
                allStateReports.Select(o => o.StateQiyamulLailTeachingLearningProgramData),
                allCentralReports.Select(o => o.StateQiyamulLailTeachingLearningProgramData));

            var studyCircleForAssociateMemberTeachingLearningProgramData =
                Calculator.GetCalculatedTeachingLearningProgramData(
                    allUnitReports.Select(o => o.StudyCircleForAssociateMemberTeachingLearningProgramData),
                    allZoneReports.Select(o => o.StudyCircleForAssociateMemberTeachingLearningProgramData),
                    allStateReports.Select(o => o.StudyCircleForAssociateMemberTeachingLearningProgramData),
                    allCentralReports.Select(o => o.StudyCircleForAssociateMemberTeachingLearningProgramData));

            var hadithTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.HadithTeachingLearningProgramData),
                allZoneReports.Select(o => o.HadithTeachingLearningProgramData),
                allStateReports.Select(o => o.HadithTeachingLearningProgramData),
                allCentralReports.Select(o => o.HadithTeachingLearningProgramData));

            var weekendIslamicSchoolTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.WeekendIslamicSchoolTeachingLearningProgramData),
                allZoneReports.Select(o => o.WeekendIslamicSchoolTeachingLearningProgramData),
                allStateReports.Select(o => o.WeekendIslamicSchoolTeachingLearningProgramData),
                allCentralReports.Select(o => o.WeekendIslamicSchoolTeachingLearningProgramData));

            var memorizingHadithTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.MemorizingHadithTeachingLearningProgramData),
                allZoneReports.Select(o => o.MemorizingHadithTeachingLearningProgramData),
                allStateReports.Select(o => o.MemorizingHadithTeachingLearningProgramData),
                allCentralReports.Select(o => o.MemorizingHadithTeachingLearningProgramData));

            var memorizingDoaTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.MemorizingDoaTeachingLearningProgramData),
                allZoneReports.Select(o => o.MemorizingDoaTeachingLearningProgramData),
                allStateReports.Select(o => o.MemorizingDoaTeachingLearningProgramData),
                allCentralReports.Select(o => o.MemorizingDoaTeachingLearningProgramData));

            var otherTeachingLearningProgramData = Calculator.GetCalculatedTeachingLearningProgramData(
                allUnitReports.Select(o => o.OtherTeachingLearningProgramData),
                allZoneReports.Select(o => o.OtherTeachingLearningProgramData),
                allStateReports.Select(o => o.OtherTeachingLearningProgramData),
                allCentralReports.Select(o => o.OtherTeachingLearningProgramData));

            var bookSaleMaterialData = Calculator.GetCalculatedMaterialData(
                allUnitReports.Select(o => o.BookSaleMaterialData), allZoneReports.Select(o => o.BookSaleMaterialData),
                allStateReports.Select(o => o.BookSaleMaterialData),
                allCentralReports.Select(o => o.BookSaleMaterialData));

            var bookDistributionMaterialData = Calculator.GetCalculatedMaterialData(
                allUnitReports.Select(o => o.BookDistributionMaterialData),
                allZoneReports.Select(o => o.BookDistributionMaterialData),
                allStateReports.Select(o => o.BookDistributionMaterialData),
                allCentralReports.Select(o => o.BookDistributionMaterialData));

            var bookLibraryStockData = Calculator.GetCalculatedLibraryStockData(
                allUnitReports.Select(o => o.BookLibraryStockData), allZoneReports.Select(o => o.BookLibraryStockData),
                allStateReports.Select(o => o.BookLibraryStockData),
                allCentralReports.Select(o => o.BookLibraryStockData));

            var otherSaleMaterialData = Calculator.GetCalculatedMaterialData(
                allUnitReports.Select(o => o.OtherSaleMaterialData), allZoneReports.Select(o => o.OtherSaleMaterialData),
                allStateReports.Select(o => o.OtherSaleMaterialData),
                allCentralReports.Select(o => o.OtherSaleMaterialData));

            var otherDistributionMaterialData = Calculator.GetCalculatedMaterialData(
                allUnitReports.Select(o => o.OtherDistributionMaterialData),
                allZoneReports.Select(o => o.OtherDistributionMaterialData),
                allStateReports.Select(o => o.OtherDistributionMaterialData),
                allCentralReports.Select(o => o.OtherDistributionMaterialData));

            var otherLibraryStockData = Calculator.GetCalculatedLibraryStockData(
                allUnitReports.Select(o => o.OtherLibraryStockData), allZoneReports.Select(o => o.OtherLibraryStockData),
                allStateReports.Select(o => o.OtherLibraryStockData),
                allCentralReports.Select(o => o.OtherLibraryStockData));

            var vhsSaleMaterialData = Calculator.GetCalculatedMaterialData(
                allUnitReports.Select(o => o.VhsSaleMaterialData), allZoneReports.Select(o => o.VhsSaleMaterialData),
                allStateReports.Select(o => o.VhsSaleMaterialData),
                allCentralReports.Select(o => o.VhsSaleMaterialData));

            var vhsDistributionMaterialData = Calculator.GetCalculatedMaterialData(
                allUnitReports.Select(o => o.VhsDistributionMaterialData),
                allZoneReports.Select(o => o.VhsDistributionMaterialData),
                allStateReports.Select(o => o.VhsDistributionMaterialData),
                allCentralReports.Select(o => o.VhsDistributionMaterialData));

            var vhsLibraryStockData = Calculator.GetCalculatedLibraryStockData(
                allUnitReports.Select(o => o.VhsLibraryStockData), allZoneReports.Select(o => o.VhsLibraryStockData),
                allStateReports.Select(o => o.VhsLibraryStockData),
                allCentralReports.Select(o => o.VhsLibraryStockData));

            var emailDistributionMaterialData = Calculator.GetCalculatedMaterialData(
                allUnitReports.Select(o => o.EmailDistributionMaterialData),
                allZoneReports.Select(o => o.EmailDistributionMaterialData),
                allStateReports.Select(o => o.EmailDistributionMaterialData),
                allCentralReports.Select(o => o.EmailDistributionMaterialData));

            var ipdcLeafletDistributionMaterialData = Calculator.GetCalculatedMaterialData(
                allUnitReports.Select(o => o.IpdcLeafletDistributionMaterialData),
                allZoneReports.Select(o => o.IpdcLeafletDistributionMaterialData),
                allStateReports.Select(o => o.IpdcLeafletDistributionMaterialData),
                allCentralReports.Select(o => o.IpdcLeafletDistributionMaterialData));


            var baitulMalFinanceData = Calculator.GetCalculatedFinanceData(
                allUnitReports.Select(o => o.BaitulMalFinanceData), allZoneReports.Select(o => o.BaitulMalFinanceData),
                allStateReports.Select(o => o.BaitulMalFinanceData),
                allCentralReports.Select(o => o.BaitulMalFinanceData));

            var aDayMasjidProjectFinanceData = Calculator.GetCalculatedFinanceData(
                allUnitReports.Select(o => o.ADayMasjidProjectFinanceData),
                allZoneReports.Select(o => o.ADayMasjidProjectFinanceData),
                allStateReports.Select(o => o.ADayMasjidProjectFinanceData),
                allCentralReports.Select(o => o.ADayMasjidProjectFinanceData));
            var masjidTableBankFinanceData = Calculator.GetCalculatedFinanceData(
                allUnitReports.Select(o => o.MasjidTableBankFinanceData),
                allZoneReports.Select(o => o.MasjidTableBankFinanceData),
                allStateReports.Select(o => o.MasjidTableBankFinanceData),
                allCentralReports.Select(o => o.MasjidTableBankFinanceData));

            var qardeHasanaSocialWelfareData = Calculator.GetCalculatedSocialWelfareData(
                allUnitReports.Select(o => o.QardeHasanaSocialWelfareData),
                allZoneReports.Select(o => o.QardeHasanaSocialWelfareData),
                allStateReports.Select(o => o.QardeHasanaSocialWelfareData),
                allCentralReports.Select(o => o.QardeHasanaSocialWelfareData));
            var patientVisitSocialWelfareData = Calculator.GetCalculatedSocialWelfareData(
                allUnitReports.Select(o => o.PatientVisitSocialWelfareData),
                allZoneReports.Select(o => o.PatientVisitSocialWelfareData),
                allStateReports.Select(o => o.PatientVisitSocialWelfareData),
                allCentralReports.Select(o => o.PatientVisitSocialWelfareData));
            var socialVisitSocialWelfareData = Calculator.GetCalculatedSocialWelfareData(
                allUnitReports.Select(o => o.SocialVisitSocialWelfareData),
                allZoneReports.Select(o => o.SocialVisitSocialWelfareData),
                allStateReports.Select(o => o.SocialVisitSocialWelfareData),
                allCentralReports.Select(o => o.SocialVisitSocialWelfareData));
            var transportSocialWelfareData = Calculator.GetCalculatedSocialWelfareData(
                allUnitReports.Select(o => o.TransportSocialWelfareData),
                allZoneReports.Select(o => o.TransportSocialWelfareData),
                allStateReports.Select(o => o.TransportSocialWelfareData),
                allCentralReports.Select(o => o.TransportSocialWelfareData));
            var shiftingSocialWelfareData = Calculator.GetCalculatedSocialWelfareData(
                allUnitReports.Select(o => o.ShiftingSocialWelfareData),
                allZoneReports.Select(o => o.ShiftingSocialWelfareData),
                allStateReports.Select(o => o.ShiftingSocialWelfareData),
                allCentralReports.Select(o => o.ShiftingSocialWelfareData));
            var shoppingSocialWelfareData = Calculator.GetCalculatedSocialWelfareData(
                allUnitReports.Select(o => o.ShoppingSocialWelfareData),
                allZoneReports.Select(o => o.ShoppingSocialWelfareData),
                allStateReports.Select(o => o.ShoppingSocialWelfareData),
                allCentralReports.Select(o => o.ShoppingSocialWelfareData));
            var foodDistributionSocialWelfareData = Calculator.GetCalculatedSocialWelfareData(
                allUnitReports.Select(o => o.FoodDistributionSocialWelfareData),
                allZoneReports.Select(o => o.FoodDistributionSocialWelfareData),
                allStateReports.Select(o => o.FoodDistributionSocialWelfareData),
                allCentralReports.Select(o => o.FoodDistributionSocialWelfareData));
            var cleanUpAustraliaSocialWelfareData = Calculator.GetCalculatedSocialWelfareData(
                allUnitReports.Select(o => o.CleanUpAustraliaSocialWelfareData),
                allZoneReports.Select(o => o.CleanUpAustraliaSocialWelfareData),
                allStateReports.Select(o => o.CleanUpAustraliaSocialWelfareData),
                allCentralReports.Select(o => o.CleanUpAustraliaSocialWelfareData));
            var otherSocialWelfareData = Calculator.GetCalculatedSocialWelfareData(
                allUnitReports.Select(o => o.OtherSocialWelfareData), allZoneReports.Select(o => o.OtherSocialWelfareData),
                allStateReports.Select(o => o.OtherSocialWelfareData),
                allCentralReports.Select(o => o.OtherSocialWelfareData));

            return new ReportData(memberMemberData: memberMemberData,
                associateMemberData: associateMemberData,
                preliminaryMemberData: preliminaryMemberData,
                supporterMemberData: supporterMemberData,
                workerMeetingProgramData: workerMeetingProgramData,
                dawahMeetingProgramData: dawahMeetingProgramData,
                stateLeaderMeetingProgramData: stateLeaderMeetingProgramData,
                stateOutingMeetingProgramData: stateOutingMeetingProgramData,
                iftarMeetingProgramData: iftarMeetingProgramData,
                learningMeetingProgramData: learningMeetingProgramData,
                socialDawahMeetingProgramData: socialDawahMeetingProgramData,
                dawahGroupMeetingProgramData: dawahGroupMeetingProgramData,
                nextGMeetingProgramData: nextGMeetingProgramData,
                cmsMeetingProgramData: cmsMeetingProgramData,
                smMeetingProgramData: smMeetingProgramData,
                memberMeetingProgramData: memberMeetingProgramData,
                tafsirMeetingProgramData: tafsirMeetingProgramData,
                unitMeetingProgramData: unitMeetingProgramData,
                familyVisitMeetingProgramData: familyVisitMeetingProgramData,
                eidReunionMeetingProgramData: eidReunionMeetingProgramData,
                bbqMeetingProgramData: bbqMeetingProgramData,
                gatheringMeetingProgramData: gatheringMeetingProgramData,
                otherMeetingProgramData: otherMeetingProgramData,
                groupStudyTeachingLearningProgramData: groupStudyTeachingLearningProgramData,
                studyCircleTeachingLearningProgramData: studyCircleTeachingLearningProgramData,
                practiceDarsTeachingLearningProgramData: practiceDarsTeachingLearningProgramData,
                stateLearningCampTeachingLearningProgramData: stateLearningCampTeachingLearningProgramData,
                quranStudyTeachingLearningProgramData: quranStudyTeachingLearningProgramData,
                quranClassTeachingLearningProgramData: quranClassTeachingLearningProgramData,
                memorizingAyatTeachingLearningProgramData: memorizingAyatTeachingLearningProgramData,
                stateLearningSessionTeachingLearningProgramData: stateLearningSessionTeachingLearningProgramData,
                stateQiyamulLailTeachingLearningProgramData: stateQiyamulLailTeachingLearningProgramData,
                studyCircleForAssociateMemberTeachingLearningProgramData:
                studyCircleForAssociateMemberTeachingLearningProgramData,
                hadithTeachingLearningProgramData: hadithTeachingLearningProgramData,
                weekendIslamicSchoolTeachingLearningProgramData: weekendIslamicSchoolTeachingLearningProgramData,
                memorizingHadithTeachingLearningProgramData: memorizingHadithTeachingLearningProgramData,
                memorizingDoaTeachingLearningProgramData: memorizingDoaTeachingLearningProgramData,
                otherTeachingLearningProgramData: otherTeachingLearningProgramData,
                bookSaleMaterialData: bookSaleMaterialData,
                bookDistributionMaterialData: bookDistributionMaterialData,
                bookLibraryStockData: bookLibraryStockData,
                otherSaleMaterialData: otherSaleMaterialData,
                otherDistributionMaterialData: otherDistributionMaterialData,
                otherLibraryStockData: otherLibraryStockData,
                vhsSaleMaterialData: vhsSaleMaterialData,
                vhsDistributionMaterialData: vhsDistributionMaterialData,
                vhsLibraryStockData: vhsLibraryStockData,
                emailDistributionMaterialData: emailDistributionMaterialData,
                ipdcLeafletDistributionMaterialData: ipdcLeafletDistributionMaterialData,
                baitulMalFinanceData: baitulMalFinanceData,
                aDayMasjidProjectFinanceData: aDayMasjidProjectFinanceData,
                masjidTableBankFinanceData: masjidTableBankFinanceData,
                qardeHasanaSocialWelfareData: qardeHasanaSocialWelfareData,
                patientVisitSocialWelfareData: patientVisitSocialWelfareData,
                socialVisitSocialWelfareData: socialVisitSocialWelfareData,
                transportSocialWelfareData: transportSocialWelfareData,
                shiftingSocialWelfareData: shiftingSocialWelfareData,
                shoppingSocialWelfareData: shoppingSocialWelfareData,
                foodDistributionSocialWelfareData: foodDistributionSocialWelfareData,
                cleanUpAustraliaSocialWelfareData: cleanUpAustraliaSocialWelfareData,
                otherSocialWelfareData: otherSocialWelfareData
            );
        }
        public static MemberData GetCalculatedMemberData(IEnumerable<MemberData> unitDatas, IEnumerable<MemberData> zoneDatas, IEnumerable<MemberData> stateDatas, IEnumerable<MemberData> centralDatas = null)
        {
            var enumerableCentralDatas = centralDatas == null ? new MemberData[0] : centralDatas.ToArray();
            var enumerableStateDatas = stateDatas == null ? new MemberData[0] : stateDatas.ToArray();
            var enumerableZoneDatas = zoneDatas == null ? new MemberData[0] : zoneDatas.ToArray();
            var enumerableUnitDatas = unitDatas == null ? new MemberData[0] : unitDatas.ToArray();

            if (!enumerableStateDatas.Any() && !enumerableZoneDatas.Any() && !enumerableUnitDatas.Any())
                return MemberData.Default();


            int lastPeriod = enumerableCentralDatas.Sum(o => o.LastPeriod) + enumerableStateDatas.Sum(o => o.LastPeriod) + enumerableZoneDatas.Sum(o => o.LastPeriod) + enumerableUnitDatas.Sum(o => o.LastPeriod);
            int upgradeTarget = enumerableCentralDatas.Sum(o => o.UpgradeTarget) + enumerableStateDatas.Sum(o => o.UpgradeTarget) + enumerableZoneDatas.Sum(o => o.UpgradeTarget) + enumerableUnitDatas.Sum(o => o.UpgradeTarget);
            int increased = enumerableCentralDatas.Sum(o => o.Increased) + enumerableStateDatas.Sum(o => o.Increased) + enumerableZoneDatas.Sum(o => o.Increased) + enumerableUnitDatas.Sum(o => o.Increased);
            int decreased = enumerableCentralDatas.Sum(o => o.Decreased) + enumerableStateDatas.Sum(o => o.Decreased) + enumerableZoneDatas.Sum(o => o.Decreased) + enumerableUnitDatas.Sum(o => o.Decreased);
            int personalContact = enumerableCentralDatas.Sum(o => o.PersonalContact) + enumerableStateDatas.Sum(o => o.PersonalContact) + enumerableZoneDatas.Sum(o => o.PersonalContact) + enumerableUnitDatas.Sum(o => o.PersonalContact);


            return new MemberData(null, null, lastPeriod, upgradeTarget, increased, decreased, null, personalContact);
        }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public static MeetingProgramData GetCalculatedMeetingProgramData(IEnumerable<MeetingProgramData> unitDatas, IEnumerable<MeetingProgramData> zoneDatas, IEnumerable<MeetingProgramData> stateDatas, IEnumerable<MeetingProgramData> centralDatas = null)
        {
            var enumerableCentralDatas = centralDatas == null ? new MeetingProgramData[0] : centralDatas.ToArray();
            var enumerableStateDatas = stateDatas == null ? new MeetingProgramData[0] : stateDatas.ToArray();
            var enumerableZoneDatas = zoneDatas == null ? new MeetingProgramData[0] : zoneDatas.ToArray();
            var enumerableUnitDatas = unitDatas == null ? new MeetingProgramData[0] : unitDatas.ToArray();

            if (!enumerableCentralDatas.Any() && !enumerableStateDatas.Any() && !enumerableZoneDatas.Any() && !enumerableUnitDatas.Any())
                return MeetingProgramData.Default();

            int target = enumerableCentralDatas.Sum(o => o.Target) + enumerableStateDatas.Sum(o => o.Target) + enumerableZoneDatas.Sum(o => o.Target) + enumerableUnitDatas.Sum(o => o.Target);
            int actual = enumerableCentralDatas.Sum(o => o.Actual) + enumerableStateDatas.Sum(o => o.Actual) + enumerableZoneDatas.Sum(o => o.Actual) + enumerableUnitDatas.Sum(o => o.Actual);

            double averageInCentral = 0;
            if (enumerableCentralDatas.Length > 0)
                averageInCentral = enumerableCentralDatas.Average(o => o.AverageAttendance);

            double averageInState = 0;
            if (enumerableStateDatas.Length > 0)
                averageInState = enumerableStateDatas.Average(o => o.AverageAttendance);

            double averageInZone = 0;
            if (enumerableZoneDatas.Length > 0)
                averageInZone = enumerableZoneDatas.Average(o => o.AverageAttendance);

            double averageInUnit = 0;
            if (enumerableUnitDatas.Length > 0)
                averageInUnit = enumerableUnitDatas.Average(o => o.AverageAttendance);

            var average = GetAverage(averageInCentral, averageInState, averageInZone, averageInUnit);

            var averageAttendance = Convert.ToInt32(average);
            return new MeetingProgramData(target, null, actual, averageAttendance, null);
        }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public static TeachingLearningProgramData GetCalculatedTeachingLearningProgramData(IEnumerable<TeachingLearningProgramData> unitDatas, IEnumerable<TeachingLearningProgramData> zoneDatas, IEnumerable<TeachingLearningProgramData> stateDatas, IEnumerable<TeachingLearningProgramData> centralDatas = null)
        {

            var enumerableCentralDatas = centralDatas == null ? new TeachingLearningProgramData[0] : centralDatas.ToArray();
            var enumerableStateDatas = stateDatas == null ? new TeachingLearningProgramData[0] : stateDatas.ToArray();
            var enumerableZoneDatas = zoneDatas == null ? new TeachingLearningProgramData[0] : zoneDatas.ToArray();
            var enumerableUnitDatas = unitDatas == null ? new TeachingLearningProgramData[0] : unitDatas.ToArray();

            if (!enumerableCentralDatas.Any() && !enumerableStateDatas.Any() && !enumerableZoneDatas.Any() && !enumerableUnitDatas.Any())
                return TeachingLearningProgramData.Default();


            int target = enumerableCentralDatas.Sum(o => o.Target) + enumerableStateDatas.Sum(o => o.Target) + enumerableZoneDatas.Sum(o => o.Target) + enumerableUnitDatas.Sum(o => o.Target);
            int actual = enumerableCentralDatas.Sum(o => o.Actual) + enumerableStateDatas.Sum(o => o.Actual) + enumerableZoneDatas.Sum(o => o.Actual) + enumerableUnitDatas.Sum(o => o.Actual);

            double averageInCentral = 0;
            if (enumerableStateDatas.Length > 0)
                averageInCentral = enumerableCentralDatas.Average(o => o.AverageAttendance);

            double averageInState = 0;
            if (enumerableStateDatas.Length > 0)
                averageInState = enumerableStateDatas.Average(o => o.AverageAttendance);

            double averageInZone = 0;
            if (enumerableZoneDatas.Length > 0)
                averageInZone = enumerableZoneDatas.Average(o => o.AverageAttendance);

            double averageInUnit = 0;
            if (enumerableUnitDatas.Length > 0)
                averageInUnit = enumerableUnitDatas.Average(o => o.AverageAttendance);

            var average = GetAverage(averageInCentral, averageInState, averageInZone, averageInUnit);

            var averageAttendance = Convert.ToInt32(average);
            return new TeachingLearningProgramData(target, null, actual, averageAttendance, null);
        }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public static MaterialData GetCalculatedMaterialData(IEnumerable<MaterialData> unitDatas, IEnumerable<MaterialData> zoneDatas, IEnumerable<MaterialData> stateDatas, IEnumerable<MaterialData> centralDatas = null)
        {
            var enumerableCentralDatas = centralDatas == null ? new MaterialData[0] : centralDatas.ToArray();
            var enumerableStateDatas = stateDatas == null ? new MaterialData[0] : stateDatas.ToArray();
            var enumerableZoneDatas = zoneDatas == null ? new MaterialData[0] : zoneDatas.ToArray();
            var enumerableUnitDatas = unitDatas == null ? new MaterialData[0] : unitDatas.ToArray();

            if (!enumerableCentralDatas.Any() && !enumerableStateDatas.Any() && !enumerableZoneDatas.Any() && !enumerableUnitDatas.Any())
                return MaterialData.Default();

            int target = enumerableCentralDatas.Sum(o => o.Target) + enumerableStateDatas.Sum(o => o.Target) + enumerableZoneDatas.Sum(o => o.Target) + enumerableUnitDatas.Sum(o => o.Target);
            int actual = enumerableCentralDatas.Sum(o => o.Actual) + enumerableStateDatas.Sum(o => o.Actual) + enumerableZoneDatas.Sum(o => o.Actual) + enumerableUnitDatas.Sum(o => o.Actual);

            return new MaterialData(target, null, actual, null);
        }

        public static LibraryStockData GetCalculatedLibraryStockData(IEnumerable<LibraryStockData> unitDatas, IEnumerable<LibraryStockData> zoneDatas, IEnumerable<LibraryStockData> stateDatas, IEnumerable<LibraryStockData> centralDatas = null)
        {

            var enumerableCentralDatas = centralDatas == null ? new LibraryStockData[0] : centralDatas.ToArray();
            var enumerableStateDatas = stateDatas == null ? new LibraryStockData[0] : stateDatas.ToArray();
            var enumerableZoneDatas = zoneDatas == null ? new LibraryStockData[0] : zoneDatas.ToArray();
            var enumerableUnitDatas = unitDatas == null ? new LibraryStockData[0] : unitDatas.ToArray();

            if (!enumerableCentralDatas.Any() && !enumerableStateDatas.Any() && !enumerableZoneDatas.Any() && !enumerableUnitDatas.Any())
                return LibraryStockData.Default();

            int lastPeriod = enumerableCentralDatas.Sum(o => o.LastPeriod) + enumerableStateDatas.Sum(o => o.LastPeriod) + enumerableZoneDatas.Sum(o => o.LastPeriod) + enumerableUnitDatas.Sum(o => o.LastPeriod);
            int increased = enumerableCentralDatas.Sum(o => o.Increased) + enumerableStateDatas.Sum(o => o.Increased) + enumerableZoneDatas.Sum(o => o.Increased) + enumerableUnitDatas.Sum(o => o.Increased);
            int decreased = enumerableCentralDatas.Sum(o => o.Decreased) + enumerableStateDatas.Sum(o => o.Decreased) + enumerableZoneDatas.Sum(o => o.Decreased) + enumerableUnitDatas.Sum(o => o.Decreased);

            return new LibraryStockData(lastPeriod, increased, decreased, null);
        }

        public static FinanceData GetCalculatedFinanceData(IEnumerable<FinanceData> unitDatas, IEnumerable<FinanceData> zoneDatas, IEnumerable<FinanceData> stateDatas, IEnumerable<FinanceData> centralDatas = null)
        {
            var enumerableCentralDatas = centralDatas == null ? new FinanceData[0] : centralDatas.ToArray();
            var enumerableStateDatas = stateDatas == null ? new FinanceData[0] : stateDatas.ToArray();
            var enumerableZoneDatas = zoneDatas == null ? new FinanceData[0] : zoneDatas.ToArray();
            var enumerableUnitDatas = unitDatas == null ? new FinanceData[0] : unitDatas.ToArray();

            if (!enumerableCentralDatas.Any() && !enumerableStateDatas.Any() && !enumerableZoneDatas.Any() && !enumerableUnitDatas.Any())
                return FinanceData.Default();

            decimal workerPromiseLastPeriod = enumerableCentralDatas.Sum(o => o.WorkerPromiseLastPeriod.Amount) + enumerableStateDatas.Sum(o => o.WorkerPromiseLastPeriod.Amount) + enumerableZoneDatas.Sum(o => o.WorkerPromiseLastPeriod.Amount) + enumerableUnitDatas.Sum(o => o.WorkerPromiseLastPeriod.Amount);
            decimal workerPromiseIncreaseTarget = enumerableCentralDatas.Sum(o => o.WorkerPromiseIncreaseTarget.Amount) + enumerableStateDatas.Sum(o => o.WorkerPromiseIncreaseTarget.Amount) + enumerableZoneDatas.Sum(o => o.WorkerPromiseIncreaseTarget.Amount) + enumerableUnitDatas.Sum(o => o.WorkerPromiseIncreaseTarget.Amount);
            decimal workerPromiseIncreased = enumerableCentralDatas.Sum(o => o.WorkerPromiseIncreased.Amount) + enumerableStateDatas.Sum(o => o.WorkerPromiseIncreased.Amount) + enumerableZoneDatas.Sum(o => o.WorkerPromiseIncreased.Amount) + enumerableUnitDatas.Sum(o => o.WorkerPromiseIncreased.Amount);
            decimal workerPromiseDecreased = enumerableCentralDatas.Sum(o => o.WorkerPromiseDecreased.Amount) + enumerableStateDatas.Sum(o => o.WorkerPromiseDecreased.Amount) + enumerableZoneDatas.Sum(o => o.WorkerPromiseDecreased.Amount) + enumerableUnitDatas.Sum(o => o.WorkerPromiseDecreased.Amount);
            decimal lastPeriod = enumerableCentralDatas.Sum(o => o.LastPeriod.Amount) + enumerableStateDatas.Sum(o => o.LastPeriod.Amount) + enumerableZoneDatas.Sum(o => o.LastPeriod.Amount) + enumerableUnitDatas.Sum(o => o.LastPeriod.Amount);
            decimal collection = enumerableCentralDatas.Sum(o => o.Collection.Amount) + enumerableStateDatas.Sum(o => o.Collection.Amount) + enumerableZoneDatas.Sum(o => o.Collection.Amount) + enumerableUnitDatas.Sum(o => o.Collection.Amount);
            decimal expenses = enumerableCentralDatas.Sum(o => o.Expense.Amount) + enumerableStateDatas.Sum(o => o.Expense.Amount) + enumerableZoneDatas.Sum(o => o.Expense.Amount) + enumerableUnitDatas.Sum(o => o.Expense.Amount);
            decimal nisabPaidToCentral = enumerableCentralDatas.Sum(o => o.NisabPaidToCentral.Amount) + enumerableStateDatas.Sum(o => o.NisabPaidToCentral.Amount) + enumerableZoneDatas.Sum(o => o.NisabPaidToCentral.Amount) + enumerableUnitDatas.Sum(o => o.NisabPaidToCentral.Amount);
            decimal otherSourceIncreaseTarget = enumerableCentralDatas.Sum(o => o.OtherSourceIncreaseTarget.Amount) + enumerableStateDatas.Sum(o => o.OtherSourceIncreaseTarget.Amount) + enumerableZoneDatas.Sum(o => o.OtherSourceIncreaseTarget.Amount) + enumerableUnitDatas.Sum(o => o.OtherSourceIncreaseTarget.Amount);

            return new FinanceData(null,
                new Money(workerPromiseIncreaseTarget),
                null,
                new Money(otherSourceIncreaseTarget),
                new Money(workerPromiseLastPeriod),
                new Money(lastPeriod),
                new Money(collection),
                new Money(expenses),
                new Money(nisabPaidToCentral),
                new Money(workerPromiseIncreased),
                new Money(workerPromiseDecreased),
                null
            );
        }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public static SocialWelfareData GetCalculatedSocialWelfareData(IEnumerable<SocialWelfareData> unitDatas, IEnumerable<SocialWelfareData> zoneDatas, IEnumerable<SocialWelfareData> stateDatas, IEnumerable<SocialWelfareData> centralDatas = null)
        {
            var enumerableCentralDatas = centralDatas == null ? new SocialWelfareData[0] : centralDatas.ToArray();
            var enumerableStateDatas = stateDatas == null ? new SocialWelfareData[0] : stateDatas.ToArray();
            var enumerableZoneDatas = zoneDatas == null ? new SocialWelfareData[0] : zoneDatas.ToArray();
            var enumerableUnitDatas = unitDatas == null ? new SocialWelfareData[0] : unitDatas.ToArray();

            if (!enumerableCentralDatas.Any() && !enumerableStateDatas.Any() && !enumerableZoneDatas.Any() && !enumerableUnitDatas.Any())
                return SocialWelfareData.Default();

            int target = enumerableCentralDatas.Sum(o => o.Target) + enumerableStateDatas.Sum(o => o.Target) + enumerableZoneDatas.Sum(o => o.Target) + enumerableUnitDatas.Sum(o => o.Target);
            int actual = enumerableCentralDatas.Sum(o => o.Actual) + enumerableStateDatas.Sum(o => o.Actual) + enumerableZoneDatas.Sum(o => o.Actual) + enumerableUnitDatas.Sum(o => o.Actual);

            return new SocialWelfareData(target, null, actual, null);
        }

        private static double GetAverage(double averageInCentral, double averageInState, double averageInZone, double averageInUnit)
        {
            var averages = new List<double>();
            if (averageInCentral > 0)
                averages.Add(averageInCentral);
            if (averageInState > 0)
                averages.Add(averageInState);
            if (averageInZone > 0)
                averages.Add(averageInZone);
            if (averageInUnit > 0)
                averages.Add(averageInUnit);

            if (averages.Count == 0)
                return 0;
            return averages.Average();
        }

        public static ReportLastPeriodUpdateData GetLastPeriodUpdateData(ReportData reportData)
        {
            var memberMemberReportData = CreateMemberReportDataFromLastPeriod(reportData.MemberMemberData);
            var associateMemberReportData = CreateMemberReportDataFromLastPeriod(reportData.AssociateMemberData);
            var preliminaryMemberReportData = CreateMemberReportDataFromLastPeriod(reportData.PreliminaryMemberData);
            var supporterMemberReportData = CreateMemberReportDataFromLastPeriod(reportData.SupporterMemberData);
            var baitulMalFinanceReportData = CreateFinanceReportDataFromLastPeriod(reportData.BaitulMalFinanceData);
            var aDayMasjidProjectFinanceReportData = CreateFinanceReportDataFromLastPeriod(reportData.ADayMasjidProjectFinanceData);
            var masjidTableBankFinanceReportData = CreateFinanceReportDataFromLastPeriod(reportData.MasjidTableBankFinanceData);
            var bookLibraryStockReportData = CreateLibraryStockReportDataFromLastPeriod(reportData.BookLibraryStockData);
            var vhsLibraryStockReportData = CreateLibraryStockReportDataFromLastPeriod(reportData.VhsLibraryStockData);
            var otherLibraryStockReportData = CreateLibraryStockReportDataFromLastPeriod(reportData.OtherLibraryStockData);

            return new ReportLastPeriodUpdateData(memberMemberReportData,
                associateMemberReportData,
                preliminaryMemberReportData,
                supporterMemberReportData,
                baitulMalFinanceReportData,
                aDayMasjidProjectFinanceReportData,
                masjidTableBankFinanceReportData,
                bookLibraryStockReportData,
                vhsLibraryStockReportData,
                otherLibraryStockReportData);
        }

        private static MemberReportData CreateMemberReportDataFromLastPeriod(MemberData lastPeriodReportData)
        {
            return new MemberReportData(lastPeriodReportData.ThisPeriod, 0, 0, lastPeriodReportData.Comment, lastPeriodReportData.PersonalContact);
        }
        private static LibraryStockReportData CreateLibraryStockReportDataFromLastPeriod(LibraryStockData lastPeriodReportData)
        {
            return new LibraryStockReportData(lastPeriodReportData.ThisPeriod, 0, 0, lastPeriodReportData.Comment);
        }

        private static FinanceReportData CreateFinanceReportDataFromLastPeriod(FinanceData lastPeriodReportData)
        {
            return new FinanceReportData(lastPeriodReportData.WorkerPromiseThisPeriod, Money.Zero(), Money.Zero(), lastPeriodReportData.Balance, lastPeriodReportData.Collection, lastPeriodReportData.Expense, lastPeriodReportData.NisabPaidToCentral, lastPeriodReportData.Comment);
        }
    }
}
