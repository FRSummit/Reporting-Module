/*using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class UnitPlanViewModelMap : ClassMap<UnitPlanViewModel>
    {
        public UnitPlanViewModelMap()
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
            Join("AssociateMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.AssociateMemberPlanData);
                    j.Optional();
                });
            Join("PreliminaryMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PreliminaryMemberPlanData);
                    j.Optional();
                });
            Join("SupporterMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SupporterMemberPlanData);
                    j.Optional();
                });
            Join("WorkerMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WorkerMeetingProgramPlanData);
                    j.Optional();
                });
            Join("DawahMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.DawahMeetingProgramPlanData);
                    j.Optional();
                });
            Join("StateLeaderMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateLeaderMeetingProgramPlanData);
                    j.Optional();
                });
            Join("StateOutingMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateOutingMeetingProgramPlanData);
                    j.Optional();
                });
            Join("MemberMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMemberPlanData);
                    j.Optional();
                });

            Join("IftarMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.IftarMeetingProgramPlanData);
                    j.Optional();
                });
            Join("LearningMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.LearningMeetingProgramPlanData);
                    j.Optional();
                });
            Join("SocialDawahMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SocialDawahMeetingProgramPlanData);
                    j.Optional();
                });

            Join("DawahGroupMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.DawahGroupMeetingProgramPlanData);
                    j.Optional();
                });

            Join("NextGMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.NextGMeetingProgramPlanData);
                    j.Optional();
                });


            Join("CMSMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CmsMeetingProgramPlanData);
                    j.Optional();
                });
            Join("SMMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SmMeetingProgramPlanData);
                    j.Optional();
                });
            Join("MemberMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMeetingProgramPlanData);
                    j.Optional();
                });
            Join("TafsirMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TafsirMeetingProgramPlanData);
                    j.Optional();
                });
            Join("UnitMeetingData",
                 j =>
                 {
                     j.KeyColumn("ReportId");
                     j.Component(x => x.UnitMeetingProgramPlanData);
                     j.Optional();
                 });
            Join("FamilyVisitMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FamilyVisitMeetingProgramPlanData);
                    j.Optional();
                });
            Join("EidReunionMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EidReunionMeetingProgramPlanData);
                    j.Optional();
                });
            Join("BbqMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BbqMeetingProgramPlanData);
                    j.Optional();
                });
            Join("GatheringMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.GatheringMeetingProgramPlanData);
                    j.Optional();
                });
            Join("OtherMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherMeetingProgramPlanData);
                    j.Optional();
                });


            Join("BaitulMalFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BaitulMalFinancePlanData);
                    j.Optional();
                });
            Join("ADayMasjidProjectFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ADayMasjidProjectFinancePlanData);
                    j.Optional();
                });
            Join("MasjidTableBankFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MasjidTableBankFinancePlanData);
                    j.Optional();
                });
            Join("QardeHasanaSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.QardeHasanaSocialWelfarePlanData);
                    j.Optional();
                });
            Join("PatientVisitSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PatientVisitSocialWelfarePlanData);
                    j.Optional();
                });
            Join("SocialVisitSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SocialVisitSocialWelfarePlanData);
                    j.Optional();
                });
            Join("TransportSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TransportSocialWelfarePlanData);
                    j.Optional();
                });
            Join("ShiftingSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShiftingSocialWelfarePlanData);
                    j.Optional();
                });
            Join("ShoppingSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShoppingSocialWelfarePlanData);
                    j.Optional();
                });
            Join("FoodDistributionSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FoodDistributionSocialWelfarePlanData);
                    j.Optional();
                });
            Join("CleanUpAustraliaSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CleanUpAustraliaSocialWelfarePlanData);
                    j.Optional();
                });
            Join("OtherSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSocialWelfarePlanData);
                    j.Optional();
                });
            Join("BookSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookSaleMaterialPlanData);
                    j.Optional();
                });
            Join("BookDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookDistributionMaterialPlanData);
                    j.Optional();
                });
            Join("BookLibraryStockData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookLibraryStockPlanData);
                    j.Optional();
                });
            Join("OtherSaleMaterialData",
               j =>
               {
                   j.KeyColumn("ReportId");
                   j.Component(x => x.OtherSaleMaterialPlanData);
                   j.Optional();
               });
            Join("OtherDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherDistributionMaterialPlanData);
                    j.Optional();
                });
            Join("OtherLibraryStockData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherLibraryStockPlanData);
                    j.Optional();
                });
            Join("VhsSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsSaleMaterialPlanData);
                    j.Optional();
                });
            Join("VhsDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsDistributionMaterialPlanData);
                    j.Optional();
                });
            Join("VhsLibraryStockData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsLibraryStockPlanData);
                    j.Optional();
                });
            Join("EmailDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EmailDistributionMaterialPlanData);
                    j.Optional();
                });
            Join("IpdcLeafletDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.IpdcLeafletDistributionMaterialPlanData);
                    j.Optional();
                });
            
            
            
            Join("GroupStudyTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.GroupStudyTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("StudyCircleTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StudyCircleTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("PracticeDarsTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PracticeDarsTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("StateLearningCampTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateLearningCampTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("QuranStudyTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.QuranStudyTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("QuranClassTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.QuranClassTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("MemorizingAyatTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingAyatTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("StateLearningSessionTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateLearningSessionTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("StateQiyamulLailTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateQiyamulLailTeachingLearningProgramPlanData);
                    j.Optional();
                });

            Join("StudyCircleForAssociateMemberTeachingLearningProgramData",
               j =>
               {
                   j.KeyColumn("ReportId");
                   j.Component(x => x.StudyCircleForAssociateMemberTeachingLearningProgramPlanData);
                   j.Optional();
               });

            Join("HadithTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.HadithTeachingLearningProgramPlanData);
                    j.Optional();
                });

            Join("WeekendIslamicSchoolTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WeekendIslamicSchoolTeachingLearningProgramPlanData);
                    j.Optional();
                });

            Join("MemorizingHadithTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingHadithTeachingLearningProgramPlanData);
                    j.Optional();
                });

            Join("MemorizingDoaTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingDoaTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("OtherTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherTeachingLearningProgramPlanData);
                    j.Optional();
                });
        }
    }
}*/