using FluentNHibernate.Mapping;
using ReportingModule.Core;
using ReportingModule.Core.Fluent;
using ReportingModule.Entities;

namespace ReportingModule.Dal
{
    public class ZoneReportMap2 : ClassMap<ZoneReport>
    {
        public ZoneReportMap2()
        {
            Table("Report");
            Where("IsDeleted = 0 AND OrganizationOrganizationType = 2");
            Not.LazyLoad();
            Id(x => x.Id);
            Map(x => x.Description);
            this.MapComponentWithPrefix(x => x.Organization);
            this.MapComponentWithPrefix(x => x.ReportingPeriod);
            Map(x => x.ReportStatus);
            Map(x => x.ReopenedReportStatus);
            Map(x => x.Comment);
            Map(x => x.Timestamp);
            Map(x => x.IsDeleted);
            Join("ZoneReportData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Optional();
                    j.Map(x => x.MemberMemberData).JsonSerialized();
                    j.Map(x => x.MemberMemberGeneratedData).JsonSerialized();
                    j.Map(x => x.AssociateMemberData).JsonSerialized();
                    j.Map(x => x.AssociateMemberGeneratedData).JsonSerialized();
                    j.Map(x => x.PreliminaryMemberData).JsonSerialized();
                    j.Map(x => x.PreliminaryMemberGeneratedData).JsonSerialized();
                    j.Map(x => x.SupporterMemberData).JsonSerialized();
                    j.Map(x => x.SupporterMemberGeneratedData).JsonSerialized();
                    j.Map(x => x.WorkerMeetingProgramData).JsonSerialized();
                    j.Map(x => x.WorkerMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.DawahMeetingProgramData).JsonSerialized();
                    j.Map(x => x.DawahMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.StateLeaderMeetingProgramData).JsonSerialized();
                    j.Map(x => x.StateLeaderMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.StateOutingMeetingProgramData).JsonSerialized();
                    j.Map(x => x.StateOutingMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.IftarMeetingProgramData).JsonSerialized();
                    j.Map(x => x.IftarMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.LearningMeetingProgramData).JsonSerialized();
                    j.Map(x => x.LearningMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.SocialDawahMeetingProgramData).JsonSerialized();
                    j.Map(x => x.SocialDawahMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.DawahGroupMeetingProgramData).JsonSerialized();
                    j.Map(x => x.DawahGroupMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.NextGMeetingProgramData).JsonSerialized();
                    j.Map(x => x.NextGMeetingProgramGeneratedData).JsonSerialized();


                    j.Map(x => x.CmsMeetingProgramData).JsonSerialized();
                    j.Map(x => x.CmsMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.SmMeetingProgramData).JsonSerialized();
                    j.Map(x => x.SmMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.MemberMeetingProgramData).JsonSerialized();
                    j.Map(x => x.MemberMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.TafsirMeetingProgramData).JsonSerialized();
                    j.Map(x => x.TafsirMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.UnitMeetingProgramData).JsonSerialized();
                    j.Map(x => x.UnitMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.FamilyVisitMeetingProgramData).JsonSerialized();
                    j.Map(x => x.FamilyVisitMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.EidReunionMeetingProgramData).JsonSerialized();
                    j.Map(x => x.EidReunionMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.BbqMeetingProgramData).JsonSerialized();
                    j.Map(x => x.BbqMeetingProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.GatheringMeetingProgramData).JsonSerialized();
                    j.Map(x => x.GatheringMeetingProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.OtherMeetingProgramData).JsonSerialized();
                    j.Map(x => x.OtherMeetingProgramGeneratedData).JsonSerialized();


                    j.Map(x => x.GroupStudyTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.GroupStudyTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.StudyCircleTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.StudyCircleTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.PracticeDarsTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.PracticeDarsTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.StateLearningCampTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.StateLearningCampTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.QuranStudyTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.QuranStudyTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.QuranClassTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.QuranClassTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.MemorizingAyatTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.MemorizingAyatTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.StateLearningSessionTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.StateLearningSessionTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.StateQiyamulLailTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.StateQiyamulLailTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.BookSaleMaterialData).JsonSerialized();
                    j.Map(x => x.BookSaleMaterialGeneratedData).JsonSerialized();

                    j.Map(x => x.BookDistributionMaterialData).JsonSerialized();
                    j.Map(x => x.BookDistributionMaterialGeneratedData).JsonSerialized();
                    j.Map(x => x.BookLibraryStockData).JsonSerialized();
                    j.Map(x => x.BookLibraryStockGeneratedData).JsonSerialized();
                    j.Map(x => x.OtherSaleMaterialData).JsonSerialized();
                    j.Map(x => x.OtherSaleMaterialGeneratedData).JsonSerialized();
                    j.Map(x => x.OtherDistributionMaterialData).JsonSerialized();
                    j.Map(x => x.OtherDistributionMaterialGeneratedData).JsonSerialized();
                    j.Map(x => x.OtherLibraryStockData).JsonSerialized();
                    j.Map(x => x.OtherLibraryStockGeneratedData).JsonSerialized();
                    j.Map(x => x.VhsSaleMaterialData).JsonSerialized();
                    j.Map(x => x.VhsSaleMaterialGeneratedData).JsonSerialized();

                    j.Map(x => x.VhsDistributionMaterialData).JsonSerialized();
                    j.Map(x => x.VhsDistributionMaterialGeneratedData).JsonSerialized();
                    j.Map(x => x.VhsLibraryStockData).JsonSerialized();
                    j.Map(x => x.VhsLibraryStockGeneratedData).JsonSerialized();
                    j.Map(x => x.EmailDistributionMaterialData).JsonSerialized();
                    j.Map(x => x.EmailDistributionMaterialGeneratedData).JsonSerialized();

                    j.Map(x => x.IpdcLeafletDistributionMaterialData).JsonSerialized();
                    j.Map(x => x.IpdcLeafletDistributionMaterialGeneratedData).JsonSerialized();




                    j.Map(x => x.BaitulMalFinanceData).JsonSerialized();
                    j.Map(x => x.BaitulMalFinanceGeneratedData).JsonSerialized();
                    j.Map(x => x.ADayMasjidProjectFinanceData).JsonSerialized();
                    j.Map(x => x.ADayMasjidProjectFinanceGeneratedData).JsonSerialized();
                    j.Map(x => x.MasjidTableBankFinanceData).JsonSerialized();
                    j.Map(x => x.MasjidTableBankFinanceGeneratedData).JsonSerialized();


                    j.Map(x => x.QardeHasanaSocialWelfareData).JsonSerialized();
                    j.Map(x => x.QardeHasanaSocialWelfareGeneratedData).JsonSerialized();
                    j.Map(x => x.PatientVisitSocialWelfareData).JsonSerialized();
                    j.Map(x => x.PatientVisitSocialWelfareGeneratedData).JsonSerialized();
                    j.Map(x => x.SocialVisitSocialWelfareData).JsonSerialized();
                    j.Map(x => x.SocialVisitSocialWelfareGeneratedData).JsonSerialized();
                    j.Map(x => x.TransportSocialWelfareData).JsonSerialized();
                    j.Map(x => x.TransportSocialWelfareGeneratedData).JsonSerialized();
                    j.Map(x => x.ShiftingSocialWelfareData).JsonSerialized();
                    j.Map(x => x.ShiftingSocialWelfareGeneratedData).JsonSerialized();
                    j.Map(x => x.ShoppingSocialWelfareData).JsonSerialized();
                    j.Map(x => x.ShoppingSocialWelfareGeneratedData).JsonSerialized();
                    j.Map(x => x.FoodDistributionSocialWelfareData).JsonSerialized();
                    j.Map(x => x.FoodDistributionSocialWelfareGeneratedData).JsonSerialized();
                    j.Map(x => x.CleanUpAustraliaSocialWelfareData).JsonSerialized();
                    j.Map(x => x.CleanUpAustraliaSocialWelfareGeneratedData).JsonSerialized();
                    j.Map(x => x.OtherSocialWelfareData).JsonSerialized();
                    j.Map(x => x.OtherSocialWelfareGeneratedData).JsonSerialized();
                    j.Map(x => x.StudyCircleForAssociateMemberTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.HadithTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.HadithTeachingLearningProgramGeneratedData).JsonSerialized();

                    j.Map(x => x.WeekendIslamicSchoolTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.WeekendIslamicSchoolTeachingLearningProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.MemorizingHadithTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.MemorizingHadithTeachingLearningProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.MemorizingDoaTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.MemorizingDoaTeachingLearningProgramGeneratedData).JsonSerialized();
                    j.Map(x => x.OtherTeachingLearningProgramData).JsonSerialized();
                    j.Map(x => x.OtherTeachingLearningProgramGeneratedData).JsonSerialized();

                });
        }
    }
}