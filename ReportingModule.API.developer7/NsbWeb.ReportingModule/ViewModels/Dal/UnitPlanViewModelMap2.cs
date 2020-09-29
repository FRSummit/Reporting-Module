using FluentNHibernate.Mapping;
using ReportingModule.Core;
using ReportingModule.Core.Fluent;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class UnitPlanViewModelMap2 : ClassMap<UnitPlanViewModel>
    {
        public UnitPlanViewModelMap2()
        {
            Not.LazyLoad();
            ReadOnly();

            Table("Report");
            Where("IsDeleted = 0 AND OrganizationOrganizationType = 1");
            Id(x => x.Id);
            Map(x => x.Description);
            this.MapComponentWithPrefix(x => x.Organization);
            this.MapComponentWithPrefix(x => x.ReportingPeriod);
            Map(x => x.ReportStatus);
            Map(x => x.ReOpenedReportStatus);
            Map(x => x.Timestamp);
            Join("UnitReportData",
           j =>
           {
               j.KeyColumn("ReportId");
               j.Optional();
               j.Map(x => x.MemberMemberPlanData).Column("MemberMemberData").JsonSerialized();
               j.Map(x => x.AssociateMemberPlanData).Column("AssociateMemberData").JsonSerialized();
               j.Map(x => x.PreliminaryMemberPlanData).Column("PreliminaryMemberData").JsonSerialized();
               j.Map(x => x.SupporterMemberPlanData).Column("SupporterMemberData").JsonSerialized();
               j.Map(x => x.WorkerMeetingProgramPlanData).Column("WorkerMeetingProgramData").JsonSerialized();
               j.Map(x => x.DawahMeetingProgramPlanData).Column("DawahMeetingProgramData").JsonSerialized();
               j.Map(x => x.StateLeaderMeetingProgramPlanData).Column("StateLeaderMeetingProgramData").JsonSerialized();
               j.Map(x => x.StateOutingMeetingProgramPlanData).Column("StateOutingMeetingProgramData").JsonSerialized();
               j.Map(x => x.IftarMeetingProgramPlanData).Column("IftarMeetingProgramData").JsonSerialized();
               j.Map(x => x.LearningMeetingProgramPlanData).Column("LearningMeetingProgramData").JsonSerialized();
               j.Map(x => x.SocialDawahMeetingProgramPlanData).Column("SocialDawahMeetingProgramData").JsonSerialized();
               j.Map(x => x.DawahGroupMeetingProgramPlanData).Column("DawahGroupMeetingProgramData").JsonSerialized();
               j.Map(x => x.NextGMeetingProgramPlanData).Column("NextGMeetingProgramData").JsonSerialized();


               j.Map(x => x.CmsMeetingProgramPlanData).Column("CmsMeetingProgramData").JsonSerialized();
               j.Map(x => x.SmMeetingProgramPlanData).Column("SmMeetingProgramData").JsonSerialized();
               j.Map(x => x.MemberMeetingProgramPlanData).Column("MemberMeetingProgramData").JsonSerialized();
               j.Map(x => x.TafsirMeetingProgramPlanData).Column("TafsirMeetingProgramData").JsonSerialized();
               j.Map(x => x.UnitMeetingProgramPlanData).Column("UnitMeetingProgramData").JsonSerialized();
               j.Map(x => x.FamilyVisitMeetingProgramPlanData).Column("FamilyVisitMeetingProgramData").JsonSerialized();
               j.Map(x => x.EidReunionMeetingProgramPlanData).Column("EidReunionMeetingProgramData").JsonSerialized();
               j.Map(x => x.BbqMeetingProgramPlanData).Column("BbqMeetingProgramData").JsonSerialized();
               j.Map(x => x.GatheringMeetingProgramPlanData).Column("GatheringMeetingProgramData").JsonSerialized();

               j.Map(x => x.OtherMeetingProgramPlanData).Column("OtherMeetingProgramData").JsonSerialized();


               j.Map(x => x.GroupStudyTeachingLearningProgramPlanData).Column("GroupStudyTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.StudyCircleTeachingLearningProgramPlanData).Column("StudyCircleTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.PracticeDarsTeachingLearningProgramPlanData).Column("PracticeDarsTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.StateLearningCampTeachingLearningProgramPlanData).Column("StateLearningCampTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.QuranStudyTeachingLearningProgramPlanData).Column("QuranStudyTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.QuranClassTeachingLearningProgramPlanData).Column("QuranClassTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.MemorizingAyatTeachingLearningProgramPlanData).Column("MemorizingAyatTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.StateLearningSessionTeachingLearningProgramPlanData).Column("StateLearningSessionTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.StateQiyamulLailTeachingLearningProgramPlanData).Column("StateQiyamulLailTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.BookSaleMaterialPlanData).Column("BookSaleMaterialData").JsonSerialized();

               j.Map(x => x.BookDistributionMaterialPlanData).Column("BookDistributionMaterialData").JsonSerialized();
               j.Map(x => x.BookLibraryStockPlanData).Column("BookLibraryStockData").JsonSerialized();
               j.Map(x => x.OtherSaleMaterialPlanData).Column("OtherSaleMaterialData").JsonSerialized();
               j.Map(x => x.OtherDistributionMaterialPlanData).Column("OtherDistributionMaterialData").JsonSerialized();
               j.Map(x => x.OtherLibraryStockPlanData).Column("OtherLibraryStockData").JsonSerialized();
               j.Map(x => x.VhsSaleMaterialPlanData).Column("VhsSaleMaterialData").JsonSerialized();

               j.Map(x => x.VhsDistributionMaterialPlanData).Column("VhsDistributionMaterialData").JsonSerialized();
               j.Map(x => x.VhsLibraryStockPlanData).Column("VhsLibraryStockData").JsonSerialized();
               j.Map(x => x.EmailDistributionMaterialPlanData).Column("EmailDistributionMaterialData").JsonSerialized();

               j.Map(x => x.IpdcLeafletDistributionMaterialPlanData).Column("IpdcLeafletDistributionMaterialData").JsonSerialized();




               j.Map(x => x.BaitulMalFinancePlanData).Column("BaitulMalFinanceData").JsonSerialized();
               j.Map(x => x.ADayMasjidProjectFinancePlanData).Column("ADayMasjidProjectFinanceData").JsonSerialized();
               j.Map(x => x.MasjidTableBankFinancePlanData).Column("MasjidTableBankFinanceData").JsonSerialized();


               j.Map(x => x.QardeHasanaSocialWelfarePlanData).Column("QardeHasanaSocialWelfareData").JsonSerialized();
               j.Map(x => x.PatientVisitSocialWelfarePlanData).Column("PatientVisitSocialWelfareData").JsonSerialized();
               j.Map(x => x.SocialVisitSocialWelfarePlanData).Column("SocialVisitSocialWelfareData").JsonSerialized();
               j.Map(x => x.TransportSocialWelfarePlanData).Column("TransportSocialWelfareData").JsonSerialized();
               j.Map(x => x.ShiftingSocialWelfarePlanData).Column("ShiftingSocialWelfareData").JsonSerialized();
               j.Map(x => x.ShoppingSocialWelfarePlanData).Column("ShoppingSocialWelfareData").JsonSerialized();
               j.Map(x => x.FoodDistributionSocialWelfarePlanData).Column("FoodDistributionSocialWelfareData").JsonSerialized();
               j.Map(x => x.CleanUpAustraliaSocialWelfarePlanData).Column("CleanUpAustraliaSocialWelfareData").JsonSerialized();
               j.Map(x => x.OtherSocialWelfarePlanData).Column("OtherSocialWelfareData").JsonSerialized();
               j.Map(x => x.StudyCircleForAssociateMemberTeachingLearningProgramPlanData).Column("StudyCircleForAssociateMemberTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.HadithTeachingLearningProgramPlanData).Column("HadithTeachingLearningProgramData").JsonSerialized();

               j.Map(x => x.WeekendIslamicSchoolTeachingLearningProgramPlanData).Column("WeekendIslamicSchoolTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.MemorizingHadithTeachingLearningProgramPlanData).Column("MemorizingHadithTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.MemorizingDoaTeachingLearningProgramPlanData).Column("MemorizingDoaTeachingLearningProgramData").JsonSerialized();
               j.Map(x => x.OtherTeachingLearningProgramPlanData).Column("OtherTeachingLearningProgramData").JsonSerialized();

           });

        }
    }
}