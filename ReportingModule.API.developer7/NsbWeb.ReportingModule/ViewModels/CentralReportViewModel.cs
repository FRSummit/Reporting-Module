using System;
using System.Diagnostics.CodeAnalysis;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels
{

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class CentralReportViewModel : IReportSearchTermsFilter
    {
        public CentralReportViewModel() { }

        public int Id { get; set; }
        public string Description { get; set; }
        public OrganizationReference Organization { get; set; }
        public ReportingPeriod ReportingPeriod { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string ReportStatusDescription => ReportStatus.ToString();
        public ReopenedReportStatus ReOpenedReportStatus { get; set; }
        public string ReOpenedReportStatusDescription => ReOpenedReportStatus.ToString();
        public MemberData MemberMemberData { get; set; }
        public MemberData MemberMemberGeneratedData { get; set; }
        public MemberData AssociateMemberData { get; set; }
        public MemberData AssociateMemberGeneratedData { get; set; }
        public MemberData PreliminaryMemberData { get; set; }
        public MemberData PreliminaryMemberGeneratedData { get; set; }
        public MemberData SupporterMemberData { get; set; }
        public MemberData SupporterMemberGeneratedData { get; set; }
        public MeetingProgramData WorkerMeetingProgramData { get; set; }
        public MeetingProgramData WorkerMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData DawahMeetingProgramData { get; set; }
        public MeetingProgramData DawahMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData StateLeaderMeetingProgramData { get; set; }
        public MeetingProgramData StateLeaderMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData StateOutingMeetingProgramData { get; set; }
        public MeetingProgramData StateOutingMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData IftarMeetingProgramData { get; set; }
        public MeetingProgramData IftarMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData LearningMeetingProgramData { get; set; }
        public MeetingProgramData LearningMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData SocialDawahMeetingProgramData { get; set; }
        public MeetingProgramData SocialDawahMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData DawahGroupMeetingProgramData { get; set; }
        public MeetingProgramData DawahGroupMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData NextGMeetingProgramData { get; set; }
        public MeetingProgramData NextGMeetingProgramGeneratedData { get; set; }

        public MeetingProgramData CmsMeetingProgramData { get; set; }
        public MeetingProgramData CmsMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData SmMeetingProgramData { get; set; }
        public MeetingProgramData SmMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData MemberMeetingProgramData { get; set; }
        public MeetingProgramData MemberMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData TafsirMeetingProgramData { get; set; }
        public MeetingProgramData TafsirMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData UnitMeetingProgramData { get; set; }
        public MeetingProgramData UnitMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData FamilyVisitMeetingProgramData { get; set; }
        public MeetingProgramData FamilyVisitMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData EidReunionMeetingProgramData { get; set; }
        public MeetingProgramData EidReunionMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData BbqMeetingProgramData { get; set; }
        public MeetingProgramData BbqMeetingProgramGeneratedData { get; set; }
        public MeetingProgramData GatheringMeetingProgramData { get; set; }
        public MeetingProgramData GatheringMeetingProgramGeneratedData { get; set; }

        public MeetingProgramData OtherMeetingProgramData { get; set; }
        public MeetingProgramData OtherMeetingProgramGeneratedData { get; set; }

        public TeachingLearningProgramData GroupStudyTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData GroupStudyTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData StudyCircleTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData StudyCircleTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData PracticeDarsTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData PracticeDarsTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData StateLearningCampTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData StateLearningCampTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData QuranStudyTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData QuranStudyTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData QuranClassTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData QuranClassTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData MemorizingAyatTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData MemorizingAyatTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData StateLearningSessionTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData StateLearningSessionTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData StateQiyamulLailTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData StateQiyamulLailTeachingLearningProgramGeneratedData { get; set; }

        public TeachingLearningProgramData StudyCircleForAssociateMemberTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData HadithTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData WeekendIslamicSchoolTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData MemorizingHadithTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData MemorizingDoaTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData OtherTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData HadithTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData WeekendIslamicSchoolTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData MemorizingHadithTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData MemorizingDoaTeachingLearningProgramGeneratedData { get; set; }
        public TeachingLearningProgramData OtherTeachingLearningProgramGeneratedData { get; set; }

        public MaterialData BookSaleMaterialData { get; set; }
        public MaterialData BookSaleMaterialGeneratedData { get; set; }
        public MaterialData BookDistributionMaterialData { get; set; }
        public MaterialData BookDistributionMaterialGeneratedData { get; set; }
        public LibraryStockData BookLibraryStockData { get; set; }
        public LibraryStockData BookLibraryStockGeneratedData { get; set; }

        public MaterialData OtherSaleMaterialData { get; set; }
        public MaterialData OtherSaleMaterialGeneratedData { get; set; }
        public MaterialData OtherDistributionMaterialData { get; set; }
        public MaterialData OtherDistributionMaterialGeneratedData { get; set; }
        public LibraryStockData OtherLibraryStockData { get; set; }
        public LibraryStockData OtherLibraryStockGeneratedData { get; set; }

        public MaterialData VhsSaleMaterialData { get; set; }
        public MaterialData VhsSaleMaterialGeneratedData { get; set; }
        public MaterialData VhsDistributionMaterialData { get; set; }
        public MaterialData VhsDistributionMaterialGeneratedData { get; set; }
        public LibraryStockData VhsLibraryStockData { get; set; }
        public LibraryStockData VhsLibraryStockGeneratedData { get; set; }
        public MaterialData EmailDistributionMaterialData { get; set; }
        public MaterialData EmailDistributionMaterialGeneratedData { get; set; }
        public MaterialData IpdcLeafletDistributionMaterialData { get; set; }
        public MaterialData IpdcLeafletDistributionMaterialGeneratedData { get; set; }


        public FinanceData BaitulMalFinanceData { get; set; }
        public FinanceData BaitulMalFinanceGeneratedData { get; set; }

        public FinanceData ADayMasjidProjectFinanceData { get; set; }
        public FinanceData ADayMasjidProjectFinanceGeneratedData { get; set; }
        public FinanceData MasjidTableBankFinanceData { get; set; }
        public FinanceData MasjidTableBankFinanceGeneratedData { get; set; }


        public SocialWelfareData QardeHasanaSocialWelfareData { get; set; }
        public SocialWelfareData QardeHasanaSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData PatientVisitSocialWelfareData { get; set; }
        public SocialWelfareData PatientVisitSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData SocialVisitSocialWelfareData { get; set; }
        public SocialWelfareData SocialVisitSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData TransportSocialWelfareData { get; set; }
        public SocialWelfareData TransportSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData ShiftingSocialWelfareData { get; set; }
        public SocialWelfareData ShiftingSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData ShoppingSocialWelfareData { get; set; }
        public SocialWelfareData ShoppingSocialWelfareGeneratedData { get; set; }

        public SocialWelfareData FoodDistributionSocialWelfareData { get; set; }
        public SocialWelfareData FoodDistributionSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData CleanUpAustraliaSocialWelfareData { get; set; }
        public SocialWelfareData CleanUpAustraliaSocialWelfareGeneratedData { get; set; }

        public SocialWelfareData OtherSocialWelfareData { get; set; }
        public SocialWelfareData OtherSocialWelfareGeneratedData { get; set; }



        public string Comment { get; set; }
        public DateTime Timestamp { get; set; }

    }
}