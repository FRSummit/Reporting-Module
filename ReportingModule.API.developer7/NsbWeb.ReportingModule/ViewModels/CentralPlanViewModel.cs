using System;
using System.Diagnostics.CodeAnalysis;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class CentralPlanViewModel : IReportSearchTermsFilter
    {
        public CentralPlanViewModel() { }

        public int Id { get; set; }
        public string Description { get; set; }
        public OrganizationReference Organization { get; set; }
        public ReportingPeriod ReportingPeriod { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string ReportStatusDescription => ReportStatus.ToString();
        public ReopenedReportStatus ReOpenedReportStatus { get; set; }
        public string ReOpenedReportStatusDescription => ReOpenedReportStatus.ToString();
        public MemberPlanData MemberMemberPlanData { get; set; }
        public MemberPlanData MemberMemberPlanGeneratedData { get; set; }
        public MemberPlanData AssociateMemberPlanData { get; set; }
        public MemberPlanData AssociateMemberPlanGeneratedData { get; set; }
        public MemberPlanData PreliminaryMemberPlanData { get; set; }
        public MemberPlanData PreliminaryMemberPlanGeneratedData { get; set; }
        public MemberPlanData SupporterMemberPlanData { get; set; }
        public MemberPlanData SupporterMemberPlanGeneratedData { get; set; }
        public MeetingProgramPlanData WorkerMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData WorkerMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData DawahMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData DawahMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData StateLeaderMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData StateLeaderMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData StateOutingMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData StateOutingMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData IftarMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData IftarMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData LearningMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData LearningMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData SocialDawahMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData SocialDawahMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData DawahGroupMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData DawahGroupMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData NextGMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData NextGMeetingProgramPlanGeneratedData { get; set; }

        public MeetingProgramPlanData CmsMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData CmsMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData SmMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData SmMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData MemberMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData MemberMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData TafsirMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData TafsirMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData UnitMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData UnitMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData FamilyVisitMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData FamilyVisitMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData EidReunionMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData EidReunionMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData BbqMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData BbqMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData GatheringMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData GatheringMeetingProgramPlanGeneratedData { get; set; }
        public MeetingProgramPlanData OtherMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData OtherMeetingProgramPlanGeneratedData { get; set; }

        public TeachingLearningProgramPlanData GroupStudyTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData GroupStudyTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData StudyCircleTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData StudyCircleTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData PracticeDarsTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData PracticeDarsTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData StateLearningCampTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData StateLearningCampTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData QuranStudyTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData QuranStudyTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData QuranClassTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData QuranClassTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData MemorizingAyatTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData MemorizingAyatTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData StateLearningSessionTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData StateLearningSessionTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData StateQiyamulLailTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData StateQiyamulLailTeachingLearningProgramPlanGeneratedData { get; set; }

        public TeachingLearningProgramPlanData StudyCircleForAssociateMemberTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData HadithTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData WeekendIslamicSchoolTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData MemorizingHadithTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData MemorizingDoaTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData OtherTeachingLearningProgramPlanData { get; set; }


        public TeachingLearningProgramPlanData StudyCircleForAssociateMemberTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData HadithTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData WeekendIslamicSchoolTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData MemorizingHadithTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData MemorizingDoaTeachingLearningProgramPlanGeneratedData { get; set; }
        public TeachingLearningProgramPlanData OtherTeachingLearningProgramPlanGeneratedData { get; set; }


        public MaterialPlanData BookSaleMaterialPlanData { get; set; }
        public MaterialPlanData BookSaleMaterialPlanGeneratedData { get; set; }
        public MaterialPlanData BookDistributionMaterialPlanData { get; set; }
        public MaterialPlanData BookDistributionMaterialPlanGeneratedData { get; set; }
        public LibraryStockData BookLibraryStockPlanData { get; set; }
        public LibraryStockData BookLibraryStockPlanGeneratedData { get; set; }


        public MaterialPlanData OtherSaleMaterialPlanData { get; set; }
        public MaterialPlanData OtherSaleMaterialPlanGeneratedData { get; set; }
        public MaterialPlanData OtherDistributionMaterialPlanData { get; set; }
        public MaterialPlanData OtherDistributionMaterialPlanGeneratedData { get; set; }
        public LibraryStockData OtherLibraryStockPlanData { get; set; }
        public LibraryStockData OtherLibraryStockPlanGeneratedData { get; set; }

        public MaterialPlanData VhsSaleMaterialPlanData { get; set; }
        public MaterialPlanData VhsSaleMaterialPlanGeneratedData { get; set; }
        public MaterialPlanData VhsDistributionMaterialPlanData { get; set; }
        public MaterialPlanData VhsDistributionMaterialPlanGeneratedData { get; set; }
        public LibraryStockData VhsLibraryStockPlanData { get; set; }
        public LibraryStockData VhsLibraryStockPlanGeneratedData { get; set; }
        public MaterialPlanData EmailDistributionMaterialPlanData { get; set; }
        public MaterialPlanData EmailDistributionMaterialPlanGeneratedData { get; set; }
        public MaterialPlanData IpdcLeafletDistributionMaterialPlanData { get; set; }
        public MaterialPlanData IpdcLeafletDistributionMaterialPlanGeneratedData { get; set; }

        public FinancePlanData BaitulMalFinancePlanData { get; set; }
        public FinancePlanData BaitulMalFinancePlanGeneratedData { get; set; }
        public FinancePlanData ADayMasjidProjectFinancePlanData { get; set; }
        public FinancePlanData ADayMasjidProjectFinancePlanGeneratedData { get; set; }
        public FinancePlanData MasjidTableBankFinancePlanData { get; set; }
        public FinancePlanData MasjidTableBankFinancePlanGeneratedData { get; set; }

        public SocialWelfarePlanData QardeHasanaSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData QardeHasanaSocialWelfarePlanGeneratedData { get; set; }
        public SocialWelfarePlanData PatientVisitSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData PatientVisitSocialWelfarePlanGeneratedData { get; set; }
        public SocialWelfarePlanData SocialVisitSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData SocialVisitSocialWelfarePlanGeneratedData { get; set; }
        public SocialWelfarePlanData TransportSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData TransportSocialWelfarePlanGeneratedData { get; set; }
        public SocialWelfarePlanData ShiftingSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData ShiftingSocialWelfarePlanGeneratedData { get; set; }
        public SocialWelfarePlanData ShoppingSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData ShoppingSocialWelfarePlanGeneratedData { get; set; }
        public SocialWelfarePlanData FoodDistributionSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData FoodDistributionSocialWelfarePlanGeneratedData { get; set; }
        public SocialWelfarePlanData CleanUpAustraliaSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData CleanUpAustraliaSocialWelfarePlanGeneratedData { get; set; }
        public SocialWelfarePlanData OtherSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData OtherSocialWelfarePlanGeneratedData { get; set; }
        public DateTime Timestamp { get; set; }

    }
}