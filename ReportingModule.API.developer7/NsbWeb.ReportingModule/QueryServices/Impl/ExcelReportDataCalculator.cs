using System.Linq;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.Common;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public class ExcelReportDataCalculator
    {
        public static ExcelReportData GetCalculatedExcelReportData(ExcelReportData[] onlyRecentUnitReports,
            ExcelReportData[] allUnitReports,
            ExcelReportData[] onlyRecentZoneReports = null,
            ExcelReportData[] allZoneReports = null,
            ExcelReportData[] onlyRecentStateReports = null,
            ExcelReportData[] allStateReports = null,
            ExcelReportData[] onlyRecentCentralReports = null,
            ExcelReportData[] allCentralReports = null

     )
        {
            if (onlyRecentUnitReports == null)
                onlyRecentUnitReports = new ExcelReportData[0];
            if (onlyRecentZoneReports == null)
                onlyRecentZoneReports = new ExcelReportData[0];
            if (onlyRecentStateReports == null)
                onlyRecentStateReports = new ExcelReportData[0];
            if (onlyRecentCentralReports == null)
                onlyRecentCentralReports = new ExcelReportData[0];

            if (allUnitReports == null)
                allUnitReports = new ExcelReportData[0];
            if (allZoneReports == null)
                allZoneReports = new ExcelReportData[0];
            if (allStateReports == null)
                allStateReports = new ExcelReportData[0];
            if (allCentralReports == null)
                allCentralReports = new ExcelReportData[0];

            var memberMemberData = Calculator.GetCalculatedMemberData(
                onlyRecentUnitReports.Select(o => o.MemberMemberData),
                onlyRecentZoneReports.Select(o => o.MemberMemberData),
                onlyRecentStateReports.Select(o => o.MemberMemberData),
                onlyRecentCentralReports.Select(o => o.MemberMemberData)
                );
            var associateMemberData = Calculator.GetCalculatedMemberData(
                onlyRecentUnitReports.Select(o => o.AssociateMemberData),
                onlyRecentZoneReports.Select(o => o.AssociateMemberData),
                onlyRecentStateReports.Select(o => o.AssociateMemberData),
                onlyRecentCentralReports.Select(o => o.AssociateMemberData)
                );
            var preliminaryMemberData = Calculator.GetCalculatedMemberData(
                onlyRecentUnitReports.Select(o => o.PreliminaryMemberData),
                onlyRecentZoneReports.Select(o => o.PreliminaryMemberData),
                onlyRecentStateReports.Select(o => o.PreliminaryMemberData),
                onlyRecentCentralReports.Select(o => o.PreliminaryMemberData)
                );
            var supporterMemberData = Calculator.GetCalculatedMemberData(
                onlyRecentUnitReports.Select(o => o.SupporterMemberData),
                onlyRecentZoneReports.Select(o => o.SupporterMemberData),
                onlyRecentStateReports.Select(o => o.SupporterMemberData),
                onlyRecentCentralReports.Select(o => o.SupporterMemberData)
                );


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

            return new ExcelReportData()
            {
                MemberMemberData = memberMemberData,
                AssociateMemberData = associateMemberData,
                PreliminaryMemberData = preliminaryMemberData,
                WorkerMeetingProgramData = workerMeetingProgramData,
                SupporterMemberData = supporterMemberData,
                DawahMeetingProgramData = dawahMeetingProgramData,
                StateLeaderMeetingProgramData = stateLeaderMeetingProgramData,
                StateOutingMeetingProgramData = stateOutingMeetingProgramData,
                IftarMeetingProgramData = iftarMeetingProgramData,
                LearningMeetingProgramData = learningMeetingProgramData,
                SocialDawahMeetingProgramData = socialDawahMeetingProgramData,
                DawahGroupMeetingProgramData = dawahGroupMeetingProgramData,
                NextGMeetingProgramData = nextGMeetingProgramData,

                CmsMeetingProgramData = cmsMeetingProgramData,
                SmMeetingProgramData = smMeetingProgramData,
                MemberMeetingProgramData = memberMeetingProgramData,
                TafsirMeetingProgramData = tafsirMeetingProgramData,
                UnitMeetingProgramData = unitMeetingProgramData,
                FamilyVisitMeetingProgramData = familyVisitMeetingProgramData,
                EidReunionMeetingProgramData = eidReunionMeetingProgramData,
                BbqMeetingProgramData = bbqMeetingProgramData,
                GatheringMeetingProgramData = gatheringMeetingProgramData,
                OtherMeetingProgramData = otherMeetingProgramData,

                BaitulMalFinanceData = baitulMalFinanceData,
                ADayMasjidProjectFinanceData = aDayMasjidProjectFinanceData,
                MasjidTableBankFinanceData = masjidTableBankFinanceData,
                QardeHasanaSocialWelfareData = qardeHasanaSocialWelfareData,
                PatientVisitSocialWelfareData = patientVisitSocialWelfareData,
                SocialVisitSocialWelfareData = socialVisitSocialWelfareData,
                TransportSocialWelfareData = transportSocialWelfareData,
                ShiftingSocialWelfareData = shiftingSocialWelfareData,
                ShoppingSocialWelfareData = shoppingSocialWelfareData,
                FoodDistributionSocialWelfareData = foodDistributionSocialWelfareData,
                CleanUpAustraliaSocialWelfareData = cleanUpAustraliaSocialWelfareData,
                OtherSocialWelfareData = otherSocialWelfareData,
                BookSaleMaterialData = bookSaleMaterialData,
                BookDistributionMaterialData = bookDistributionMaterialData,
                BookLibraryStockData = bookLibraryStockData,
                OtherSaleMaterialData = otherSaleMaterialData,
                OtherDistributionMaterialData = otherDistributionMaterialData,
                OtherLibraryStockData = otherLibraryStockData,
                VhsSaleMaterialData = vhsSaleMaterialData,
                VhsDistributionMaterialData = vhsDistributionMaterialData,
                VhsLibraryStockData = vhsLibraryStockData,
                EmailDistributionMaterialData = emailDistributionMaterialData,
                IpdcLeafletDistributionMaterialData = ipdcLeafletDistributionMaterialData,
                GroupStudyTeachingLearningProgramData = groupStudyTeachingLearningProgramData,
                StudyCircleTeachingLearningProgramData = studyCircleTeachingLearningProgramData,
                PracticeDarsTeachingLearningProgramData = practiceDarsTeachingLearningProgramData,
                StateLearningCampTeachingLearningProgramData =
                stateLearningCampTeachingLearningProgramData,
                QuranStudyTeachingLearningProgramData = quranStudyTeachingLearningProgramData,
                QuranClassTeachingLearningProgramData = quranClassTeachingLearningProgramData,
                MemorizingAyatTeachingLearningProgramData =
                memorizingAyatTeachingLearningProgramData,
                StateLearningSessionTeachingLearningProgramData =
                stateLearningSessionTeachingLearningProgramData,
                StateQiyamulLailTeachingLearningProgramData =
                stateQiyamulLailTeachingLearningProgramData,
                StudyCircleForAssociateMemberTeachingLearningProgramData =
                studyCircleForAssociateMemberTeachingLearningProgramData,
                HadithTeachingLearningProgramData = hadithTeachingLearningProgramData,
                WeekendIslamicSchoolTeachingLearningProgramData =
                weekendIslamicSchoolTeachingLearningProgramData,
                MemorizingHadithTeachingLearningProgramData =
                memorizingHadithTeachingLearningProgramData,
                MemorizingDoaTeachingLearningProgramData = memorizingDoaTeachingLearningProgramData,
                OtherTeachingLearningProgramData = otherTeachingLearningProgramData,

                //Comment = comment,
            };

        }

    }
}
