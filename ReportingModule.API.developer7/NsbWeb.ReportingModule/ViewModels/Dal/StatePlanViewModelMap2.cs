using FluentNHibernate.Mapping;
using ReportingModule.Core;
using ReportingModule.Core.Fluent;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class StatePlanViewModelMap2 : ClassMap<StatePlanViewModel>
    {
        public StatePlanViewModelMap2()
        {
            Not.LazyLoad();
            ReadOnly();

            Table("Report");
            Where("IsDeleted = 0 AND OrganizationOrganizationType = 3");
            Id(x => x.Id);
            Map(x => x.Description);
            this.MapComponentWithPrefix(x => x.Organization);
            this.MapComponentWithPrefix(x => x.ReportingPeriod);
            Map(x => x.ReportStatus);
            Map(x => x.ReOpenedReportStatus);
            Map(x => x.Timestamp);

            Join("StateReportData",
           j =>
           {
               j.KeyColumn("ReportId");
               j.Optional();
               j.Map(x => x.MemberMemberPlanData).Column("MemberMemberData").JsonSerialized();
               j.Map(x => x.MemberMemberPlanGeneratedData).Column("MemberMemberGeneratedData").JsonSerialized();
               j.Map(x => x.AssociateMemberPlanData).Column("AssociateMemberData").JsonSerialized();
               j.Map(x => x.AssociateMemberPlanGeneratedData).Column("AssociateMemberGeneratedData").JsonSerialized();
               j.Map(x => x.PreliminaryMemberPlanData).Column("PreliminaryMemberData").JsonSerialized();
               j.Map(x => x.PreliminaryMemberPlanGeneratedData).Column("PreliminaryMemberGeneratedData").JsonSerialized();
               j.Map(x => x.SupporterMemberPlanData).Column("SupporterMemberData").JsonSerialized();
               j.Map(x => x.SupporterMemberPlanGeneratedData).Column("SupporterMemberGeneratedData").JsonSerialized();
               j.Map(x => x.WorkerMeetingProgramPlanData).Column("WorkerMeetingProgramData").JsonSerialized();
               j.Map(x => x.WorkerMeetingProgramPlanGeneratedData).Column("WorkerMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.DawahMeetingProgramPlanData).Column("DawahMeetingProgramData").JsonSerialized();
               j.Map(x => x.DawahMeetingProgramPlanGeneratedData).Column("DawahMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.StateLeaderMeetingProgramPlanData).Column("StateLeaderMeetingProgramData").JsonSerialized();
               j.Map(x => x.StateLeaderMeetingProgramPlanGeneratedData).Column("StateLeaderMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.StateOutingMeetingProgramPlanData).Column("StateOutingMeetingProgramData").JsonSerialized();
               j.Map(x => x.StateOutingMeetingProgramPlanGeneratedData).Column("StateOutingMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.IftarMeetingProgramPlanData).Column("IftarMeetingProgramData").JsonSerialized();
               j.Map(x => x.IftarMeetingProgramPlanGeneratedData).Column("IftarMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.LearningMeetingProgramPlanData).Column("LearningMeetingProgramData").JsonSerialized();
               j.Map(x => x.LearningMeetingProgramPlanGeneratedData).Column("LearningMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.SocialDawahMeetingProgramPlanData).Column("SocialDawahMeetingProgramData").JsonSerialized();
               j.Map(x => x.SocialDawahMeetingProgramPlanGeneratedData).Column("SocialDawahMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.DawahGroupMeetingProgramPlanData).Column("DawahGroupMeetingProgramData").JsonSerialized();
               j.Map(x => x.DawahGroupMeetingProgramPlanGeneratedData).Column("DawahGroupMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.NextGMeetingProgramPlanData).Column("NextGMeetingProgramData").JsonSerialized();
               j.Map(x => x.NextGMeetingProgramPlanGeneratedData).Column("NextGMeetingProgramGeneratedData").JsonSerialized();


               j.Map(x => x.CmsMeetingProgramPlanData).Column("CmsMeetingProgramData").JsonSerialized();
               j.Map(x => x.CmsMeetingProgramPlanGeneratedData).Column("CmsMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.SmMeetingProgramPlanData).Column("SmMeetingProgramData").JsonSerialized();
               j.Map(x => x.SmMeetingProgramPlanGeneratedData).Column("SmMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.MemberMeetingProgramPlanData).Column("MemberMeetingProgramData").JsonSerialized();
               j.Map(x => x.MemberMeetingProgramPlanGeneratedData).Column("MemberMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.TafsirMeetingProgramPlanData).Column("TafsirMeetingProgramData").JsonSerialized();
               j.Map(x => x.TafsirMeetingProgramPlanGeneratedData).Column("TafsirMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.UnitMeetingProgramPlanData).Column("UnitMeetingProgramData").JsonSerialized();
               j.Map(x => x.UnitMeetingProgramPlanGeneratedData).Column("UnitMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.FamilyVisitMeetingProgramPlanData).Column("FamilyVisitMeetingProgramData").JsonSerialized();
               j.Map(x => x.FamilyVisitMeetingProgramPlanGeneratedData).Column("FamilyVisitMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.EidReunionMeetingProgramPlanData).Column("EidReunionMeetingProgramData").JsonSerialized();
               j.Map(x => x.EidReunionMeetingProgramPlanGeneratedData).Column("EidReunionMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.BbqMeetingProgramPlanData).Column("BbqMeetingProgramData").JsonSerialized();
               j.Map(x => x.BbqMeetingProgramPlanGeneratedData).Column("BbqMeetingProgramGeneratedData").JsonSerialized();
               j.Map(x => x.GatheringMeetingProgramPlanData).Column("GatheringMeetingProgramData").JsonSerialized();
               j.Map(x => x.GatheringMeetingProgramPlanGeneratedData).Column("GatheringMeetingProgramGeneratedData").JsonSerialized();

               j.Map(x => x.OtherMeetingProgramPlanData).Column("OtherMeetingProgramData").JsonSerialized();
               j.Map(x => x.OtherMeetingProgramPlanGeneratedData).Column("OtherMeetingProgramGeneratedData").JsonSerialized();


               j.Map(x => x.GroupStudyTeachingLearningProgramPlanData).Column("GroupStudyTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.GroupStudyTeachingLearningProgramPlanGeneratedData).Column("GroupStudyTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.StudyCircleTeachingLearningProgramPlanData).Column("StudyCircleTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.StudyCircleTeachingLearningProgramPlanGeneratedData).Column("StudyCircleTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.PracticeDarsTeachingLearningProgramPlanData).Column("PracticeDarsTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.PracticeDarsTeachingLearningProgramPlanGeneratedData).Column("PracticeDarsTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.StateLearningCampTeachingLearningProgramPlanData).Column("StateLearningCampTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.StateLearningCampTeachingLearningProgramPlanGeneratedData).Column("StateLearningCampTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.QuranStudyTeachingLearningProgramPlanData).Column("QuranStudyTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.QuranStudyTeachingLearningProgramPlanGeneratedData).Column("QuranStudyTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.QuranClassTeachingLearningProgramPlanData).Column("QuranClassTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.QuranClassTeachingLearningProgramPlanGeneratedData).Column("QuranClassTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.MemorizingAyatTeachingLearningProgramPlanData).Column("MemorizingAyatTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.MemorizingAyatTeachingLearningProgramPlanGeneratedData).Column("MemorizingAyatTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.StateLearningSessionTeachingLearningProgramPlanData).Column("StateLearningSessionTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.StateLearningSessionTeachingLearningProgramPlanGeneratedData).Column("StateLearningSessionTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.StateQiyamulLailTeachingLearningProgramPlanData).Column("StateQiyamulLailTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.StateQiyamulLailTeachingLearningProgramPlanGeneratedData).Column("StateQiyamulLailTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.BookSaleMaterialPlanData).Column("BookSaleMaterialData").JsonSerialized();
               j.Map(x => x.BookSaleMaterialPlanGeneratedData).Column("BookSaleMaterialGeneratedData").JsonSerialized();

               j.Map(x => x.BookDistributionMaterialPlanData).Column("BookDistributionMaterialData").JsonSerialized();
               j.Map(x => x.BookDistributionMaterialPlanGeneratedData).Column("BookDistributionMaterialGeneratedData").JsonSerialized();
               j.Map(x => x.BookLibraryStockPlanData).Column("BookLibraryStockData").JsonSerialized();
               j.Map(x => x.BookLibraryStockPlanGeneratedData).Column("BookLibraryStockGeneratedData").JsonSerialized();
               j.Map(x => x.OtherSaleMaterialPlanData).Column("OtherSaleMaterialData").JsonSerialized();
               j.Map(x => x.OtherSaleMaterialPlanGeneratedData).Column("OtherSaleMaterialGeneratedData").JsonSerialized();
               j.Map(x => x.OtherDistributionMaterialPlanData).Column("OtherDistributionMaterialData").JsonSerialized();
               j.Map(x => x.OtherDistributionMaterialPlanGeneratedData).Column("OtherDistributionMaterialGeneratedData").JsonSerialized();
               j.Map(x => x.OtherLibraryStockPlanData).Column("OtherLibraryStockData").JsonSerialized();
               j.Map(x => x.OtherLibraryStockPlanGeneratedData).Column("OtherLibraryStockGeneratedData").JsonSerialized();
               j.Map(x => x.VhsSaleMaterialPlanData).Column("VhsSaleMaterialData").JsonSerialized();
               j.Map(x => x.VhsSaleMaterialPlanGeneratedData).Column("VhsSaleMaterialGeneratedData").JsonSerialized();

               j.Map(x => x.VhsDistributionMaterialPlanData).Column("VhsDistributionMaterialData").JsonSerialized();
               j.Map(x => x.VhsDistributionMaterialPlanGeneratedData).Column("VhsDistributionMaterialGeneratedData").JsonSerialized();
               j.Map(x => x.VhsLibraryStockPlanData).Column("VhsLibraryStockData").JsonSerialized();
               j.Map(x => x.VhsLibraryStockPlanGeneratedData).Column("VhsLibraryStockGeneratedData").JsonSerialized();
               j.Map(x => x.EmailDistributionMaterialPlanData).Column("EmailDistributionMaterialData").JsonSerialized();
               j.Map(x => x.EmailDistributionMaterialPlanGeneratedData).Column("EmailDistributionMaterialGeneratedData").JsonSerialized();

               j.Map(x => x.IpdcLeafletDistributionMaterialPlanData).Column("IpdcLeafletDistributionMaterialData").JsonSerialized();
               j.Map(x => x.IpdcLeafletDistributionMaterialPlanGeneratedData).Column("IpdcLeafletDistributionMaterialGeneratedData").JsonSerialized();




               j.Map(x => x.BaitulMalFinancePlanData).Column("BaitulMalFinanceData").JsonSerialized();
               j.Map(x => x.BaitulMalFinancePlanGeneratedData).Column("BaitulMalFinanceGeneratedData").JsonSerialized();
               j.Map(x => x.ADayMasjidProjectFinancePlanData).Column("ADayMasjidProjectFinanceData").JsonSerialized();
               j.Map(x => x.ADayMasjidProjectFinancePlanGeneratedData).Column("ADayMasjidProjectFinanceGeneratedData").JsonSerialized();
               j.Map(x => x.MasjidTableBankFinancePlanData).Column("MasjidTableBankFinanceData").JsonSerialized();
               j.Map(x => x.MasjidTableBankFinancePlanGeneratedData).Column("MasjidTableBankFinanceGeneratedData").JsonSerialized();


               j.Map(x => x.QardeHasanaSocialWelfarePlanData).Column("QardeHasanaSocialWelfareData").JsonSerialized();
               j.Map(x => x.QardeHasanaSocialWelfarePlanGeneratedData).Column("QardeHasanaSocialWelfareGeneratedData").JsonSerialized();
               j.Map(x => x.PatientVisitSocialWelfarePlanData).Column("PatientVisitSocialWelfareData").JsonSerialized();
               j.Map(x => x.PatientVisitSocialWelfarePlanGeneratedData).Column("PatientVisitSocialWelfareGeneratedData").JsonSerialized();
               j.Map(x => x.SocialVisitSocialWelfarePlanData).Column("SocialVisitSocialWelfareData").JsonSerialized();
               j.Map(x => x.SocialVisitSocialWelfarePlanGeneratedData).Column("SocialVisitSocialWelfareGeneratedData").JsonSerialized();
               j.Map(x => x.TransportSocialWelfarePlanData).Column("TransportSocialWelfareData").JsonSerialized();
               j.Map(x => x.TransportSocialWelfarePlanGeneratedData).Column("TransportSocialWelfareGeneratedData").JsonSerialized();
               j.Map(x => x.ShiftingSocialWelfarePlanData).Column("ShiftingSocialWelfareData").JsonSerialized();
               j.Map(x => x.ShiftingSocialWelfarePlanGeneratedData).Column("ShiftingSocialWelfareGeneratedData").JsonSerialized();
               j.Map(x => x.ShoppingSocialWelfarePlanData).Column("ShoppingSocialWelfareData").JsonSerialized();
               j.Map(x => x.ShoppingSocialWelfarePlanGeneratedData).Column("ShoppingSocialWelfareGeneratedData").JsonSerialized();
               j.Map(x => x.FoodDistributionSocialWelfarePlanData).Column("FoodDistributionSocialWelfareData").JsonSerialized();
               j.Map(x => x.FoodDistributionSocialWelfarePlanGeneratedData).Column("FoodDistributionSocialWelfareGeneratedData").JsonSerialized();
               j.Map(x => x.CleanUpAustraliaSocialWelfarePlanData).Column("CleanUpAustraliaSocialWelfareData").JsonSerialized();
               j.Map(x => x.CleanUpAustraliaSocialWelfarePlanGeneratedData).Column("CleanUpAustraliaSocialWelfareGeneratedData").JsonSerialized();
               j.Map(x => x.OtherSocialWelfarePlanData).Column("OtherSocialWelfareData").JsonSerialized();
               j.Map(x => x.OtherSocialWelfarePlanGeneratedData).Column("OtherSocialWelfareGeneratedData").JsonSerialized();
               j.Map(x => x.StudyCircleForAssociateMemberTeachingLearningProgramPlanData).Column("StudyCircleForAssociateMemberTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.StudyCircleForAssociateMemberTeachingLearningProgramPlanGeneratedData).Column("StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.HadithTeachingLearningProgramPlanData).Column("HadithTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.HadithTeachingLearningProgramPlanGeneratedData).Column("HadithTeachingLearningProgramGeneratedData").JsonSerialized();

               j.Map(x => x.WeekendIslamicSchoolTeachingLearningProgramPlanData).Column("WeekendIslamicSchoolTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.WeekendIslamicSchoolTeachingLearningProgramPlanGeneratedData).Column("WeekendIslamicSchoolTeachingLearningProgramGeneratedData").JsonSerialized();
               j.Map(x => x.MemorizingHadithTeachingLearningProgramPlanData).Column("MemorizingHadithTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.MemorizingHadithTeachingLearningProgramPlanGeneratedData).Column("MemorizingHadithTeachingLearningProgramGeneratedData").JsonSerialized();
               j.Map(x => x.MemorizingDoaTeachingLearningProgramPlanData).Column("MemorizingDoaTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.MemorizingDoaTeachingLearningProgramPlanGeneratedData).Column("MemorizingDoaTeachingLearningProgramGeneratedData").JsonSerialized();
               j.Map(x => x.OtherTeachingLearningProgramPlanData).Column("OtherTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.OtherTeachingLearningProgramPlanGeneratedData).Column("OtherTeachingLearningProgramGeneratedData").JsonSerialized();

           });

        }
    }
}