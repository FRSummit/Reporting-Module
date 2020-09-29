/*using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class UnitReportViewModelMap : ClassMap<UnitReportViewModel>
    {
        public UnitReportViewModelMap()
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
            Map(x => x.Comment);
            Map(x => x.Timestamp);
            Join("AssociateMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.AssociateMemberData);
                    j.Optional();
                });
            Join("PreliminaryMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PreliminaryMemberData);
                    j.Optional();
                });
            Join("SupporterMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SupporterMemberData);
                    j.Optional();
                });
            Join("WorkerMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WorkerMeetingProgramData);
                    j.Optional();
                });
            Join("DawahMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.DawahMeetingProgramData);
                    j.Optional();
                });
            Join("StateLeaderMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateLeaderMeetingProgramData);
                    j.Optional();
                });
            Join("IftarMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.IftarMeetingProgramData);
                    j.Optional();
                });

            Join("StateOutingMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateOutingMeetingProgramData);
                    j.Optional();
                });
            Join("LearningMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.LearningMeetingProgramData);
                    j.Optional();
                });

            Join("SocialDawahMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SocialDawahMeetingProgramData);
                    j.Optional();
                });

            Join("DawahGroupMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.DawahGroupMeetingProgramData);
                    j.Optional();
                });
            Join("MemberMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMemberData);
                    j.Optional();
                });

            Join("NextGMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.NextGMeetingProgramData);
                    j.Optional();
                });


            Join("CmsMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CmsMeetingProgramData);
                    j.Optional();
                });
            Join("SmMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SmMeetingProgramData);
                    j.Optional();
                });
            Join("MemberMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMeetingProgramData);
                    j.Optional();
                });
            Join("TafsirMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TafsirMeetingProgramData);
                    j.Optional();
                });
            Join("UnitMeetingData",
                 j =>
                 {
                     j.KeyColumn("ReportId");
                     j.Component(x => x.UnitMeetingProgramData);
                     j.Optional();
                 });
            Join("FamilyVisitMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FamilyVisitMeetingProgramData);
                    j.Optional();
                });
            Join("EidReunionMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EidReunionMeetingProgramData);
                    j.Optional();
                });
            Join("BbqMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BbqMeetingProgramData);
                    j.Optional();
                });
            Join("GatheringMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.GatheringMeetingProgramData);
                    j.Optional();
                });
            Join("OtherMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherMeetingProgramData);
                    j.Optional();
                });


            Join("BaitulMalFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BaitulMalFinanceData);
                    j.Optional();
                });
            Join("ADayMasjidProjectFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ADayMasjidProjectFinanceData);
                    j.Optional();
                });
            Join("MasjidTableBankFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MasjidTableBankFinanceData);
                    j.Optional();
                });
            Join("QardeHasanaSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.QardeHasanaSocialWelfareData);
                    j.Optional();
                });
            Join("PatientVisitSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PatientVisitSocialWelfareData);
                    j.Optional();
                });
            Join("SocialVisitSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SocialVisitSocialWelfareData);
                    j.Optional();
                });
            Join("TransportSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TransportSocialWelfareData);
                    j.Optional();
                });
            Join("ShiftingSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShiftingSocialWelfareData);
                    j.Optional();
                });
            Join("ShoppingSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShoppingSocialWelfareData);
                    j.Optional();
                });
            Join("FoodDistributionSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FoodDistributionSocialWelfareData);
                    j.Optional();
                });
            Join("CleanUpAustraliaSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CleanUpAustraliaSocialWelfareData);
                    j.Optional();
                });
            Join("OtherSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSocialWelfareData);
                    j.Optional();
                });
            Join("BookSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookSaleMaterialData);
                    j.Optional();
                });
            Join("BookDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookDistributionMaterialData);
                    j.Optional();
                });
            Join("OtherSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSaleMaterialData);
                    j.Optional();
                });
            Join("OtherDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherDistributionMaterialData);
                    j.Optional();
                });
            Join("OtherLibraryStockData",
               j =>
               {
                   j.KeyColumn("ReportId");
                   j.Component(x => x.OtherLibraryStockData);
                   j.Optional();
               });
            Join("VhsSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsSaleMaterialData);
                    j.Optional();
                });
            Join("VhsDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsDistributionMaterialData);
                    j.Optional();
                });
            Join("EmailDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EmailDistributionMaterialData);
                    j.Optional();
                });
            Join("IpdcLeafletDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.IpdcLeafletDistributionMaterialData);
                    j.Optional();
                });
            Join("BookLibraryStockData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookLibraryStockData);
                    j.Optional();
                });
            Join("VhsLibraryStockData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsLibraryStockData);
                    j.Optional();
                });
            Join("GroupStudyTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.GroupStudyTeachingLearningProgramData);
                    j.Optional();
                });
            Join("StudyCircleTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StudyCircleTeachingLearningProgramData);
                    j.Optional();
                });
            Join("PracticeDarsTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PracticeDarsTeachingLearningProgramData);
                    j.Optional();
                });
            Join("StateLearningCampTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateLearningCampTeachingLearningProgramData);
                    j.Optional();
                });
            Join("QuranStudyTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.QuranStudyTeachingLearningProgramData);
                    j.Optional();
                });
            Join("QuranClassTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.QuranClassTeachingLearningProgramData);
                    j.Optional();
                });
            Join("MemorizingAyatTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingAyatTeachingLearningProgramData);
                    j.Optional();
                });
            Join("StateLearningSessionTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateLearningSessionTeachingLearningProgramData);
                    j.Optional();
                });
            Join("StateQiyamulLailTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateQiyamulLailTeachingLearningProgramData);
                    j.Optional();
                });

            Join("StudyCircleForAssociateMemberTeachingLearningProgramData",
    j =>
    {
        j.KeyColumn("ReportId");
        j.Component(x => x.StudyCircleForAssociateMemberTeachingLearningProgramData);
        j.Optional();
    });

            Join("HadithTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.HadithTeachingLearningProgramData);
                    j.Optional();
                });

            Join("WeekendIslamicSchoolTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WeekendIslamicSchoolTeachingLearningProgramData);
                    j.Optional();
                });

            Join("MemorizingHadithTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingHadithTeachingLearningProgramData);
                    j.Optional();
                });

            Join("MemorizingDoaTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingDoaTeachingLearningProgramData);
                    j.Optional();
                });
            Join("OtherTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherTeachingLearningProgramData);
                    j.Optional();
                });
        }
    }
}*/