using FluentNHibernate.Mapping;
using ReportingModule.Core;
using ReportingModule.Core.Fluent;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class UnitReportViewModelMap2 : ClassMap<UnitReportViewModel>
    {
        public UnitReportViewModelMap2()
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
            Join("UnitReportData",
               j =>
               {
                   j.KeyColumn("ReportId");
                   j.Optional();
                   j.Map(x => x.MemberMemberData).JsonSerialized();
                   j.Map(x => x.AssociateMemberData).JsonSerialized();
                   j.Map(x => x.PreliminaryMemberData).JsonSerialized();
                   j.Map(x => x.SupporterMemberData).JsonSerialized();

                   j.Map(x => x.WorkerMeetingProgramData).JsonSerialized();
                   j.Map(x => x.DawahMeetingProgramData).JsonSerialized();
                   j.Map(x => x.StateLeaderMeetingProgramData).JsonSerialized();
                   j.Map(x => x.StateOutingMeetingProgramData).JsonSerialized();
                   j.Map(x => x.IftarMeetingProgramData).JsonSerialized();
                   j.Map(x => x.LearningMeetingProgramData).JsonSerialized();
                   j.Map(x => x.SocialDawahMeetingProgramData).JsonSerialized();
                   j.Map(x => x.DawahGroupMeetingProgramData).JsonSerialized();
                   j.Map(x => x.NextGMeetingProgramData).JsonSerialized();


                   j.Map(x => x.CmsMeetingProgramData).JsonSerialized();
                   j.Map(x => x.SmMeetingProgramData).JsonSerialized();
                   j.Map(x => x.MemberMeetingProgramData).JsonSerialized();
                   j.Map(x => x.TafsirMeetingProgramData).JsonSerialized();
                   j.Map(x => x.UnitMeetingProgramData).JsonSerialized();
                   j.Map(x => x.FamilyVisitMeetingProgramData).JsonSerialized();
                   j.Map(x => x.EidReunionMeetingProgramData).JsonSerialized();
                   j.Map(x => x.BbqMeetingProgramData).JsonSerialized();
                   j.Map(x => x.GatheringMeetingProgramData).JsonSerialized();
                   j.Map(x => x.OtherMeetingProgramData).JsonSerialized();


                   j.Map(x => x.BaitulMalFinanceData).JsonSerialized();
                   j.Map(x => x.ADayMasjidProjectFinanceData).JsonSerialized();
                   j.Map(x => x.MasjidTableBankFinanceData).JsonSerialized();
                   j.Map(x => x.QardeHasanaSocialWelfareData).JsonSerialized();
                   j.Map(x => x.PatientVisitSocialWelfareData).JsonSerialized();
                   j.Map(x => x.SocialVisitSocialWelfareData).JsonSerialized();
                   j.Map(x => x.TransportSocialWelfareData).JsonSerialized();
                   j.Map(x => x.ShiftingSocialWelfareData).JsonSerialized();
                   j.Map(x => x.ShoppingSocialWelfareData).JsonSerialized();
                   j.Map(x => x.FoodDistributionSocialWelfareData).JsonSerialized();
                   j.Map(x => x.CleanUpAustraliaSocialWelfareData).JsonSerialized();
                   j.Map(x => x.OtherSocialWelfareData).JsonSerialized();
                   j.Map(x => x.BookSaleMaterialData).JsonSerialized();
                   j.Map(x => x.BookDistributionMaterialData).JsonSerialized();
                   j.Map(x => x.BookLibraryStockData).JsonSerialized();
                   j.Map(x => x.OtherSaleMaterialData).JsonSerialized();
                   j.Map(x => x.OtherDistributionMaterialData).JsonSerialized();
                   j.Map(x => x.OtherLibraryStockData).JsonSerialized();
                   j.Map(x => x.VhsSaleMaterialData).JsonSerialized();
                   j.Map(x => x.VhsDistributionMaterialData).JsonSerialized();
                   j.Map(x => x.EmailDistributionMaterialData).JsonSerialized();
                   j.Map(x => x.IpdcLeafletDistributionMaterialData).JsonSerialized();

                   j.Map(x => x.VhsLibraryStockData).JsonSerialized();
                   j.Map(x => x.GroupStudyTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.StudyCircleTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.PracticeDarsTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.StateLearningCampTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.QuranStudyTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.QuranClassTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.MemorizingAyatTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.StateLearningSessionTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.StateQiyamulLailTeachingLearningProgramData).JsonSerialized();

                   j.Map(x => x.StudyCircleForAssociateMemberTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.HadithTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.WeekendIslamicSchoolTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.MemorizingHadithTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.MemorizingDoaTeachingLearningProgramData).JsonSerialized();
                   j.Map(x => x.OtherTeachingLearningProgramData).JsonSerialized();

               });


        }
    }
}