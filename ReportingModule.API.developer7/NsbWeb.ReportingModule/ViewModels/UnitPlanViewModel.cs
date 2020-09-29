using System;
using System.Diagnostics.CodeAnalysis;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class UnitPlanViewModel : IReportSearchTermsFilter
    {
        public UnitPlanViewModel() { }
        public int Id { get; set; }
        public string Description { get; set; }
        public OrganizationReference Organization { get; set; }
        public ReportingPeriod ReportingPeriod { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string ReportStatusDescription => ReportStatus.ToString();
        public ReopenedReportStatus ReOpenedReportStatus { get; set; }
        public string ReOpenedReportStatusDescription => ReOpenedReportStatus.ToString();
        public MemberPlanData AssociateMemberPlanData { get; set; }
        public MemberPlanData PreliminaryMemberPlanData { get; set; }
        public MemberPlanData SupporterMemberPlanData { get; set; }
        public MeetingProgramPlanData WorkerMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData DawahMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData StateLeaderMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData StateOutingMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData IftarMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData LearningMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData SocialDawahMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData DawahGroupMeetingProgramPlanData { get; set; }
        public MeetingProgramPlanData NextGMeetingProgramPlanData { get; set; }

        public MeetingProgramPlanData CmsMeetingProgramPlanData { get;  set; }
        public MeetingProgramPlanData SmMeetingProgramPlanData { get;  set; }
        public MeetingProgramPlanData MemberMeetingProgramPlanData { get;  set; }
        public MeetingProgramPlanData TafsirMeetingProgramPlanData { get;  set; }
        public MeetingProgramPlanData UnitMeetingProgramPlanData { get;  set; }
        public MeetingProgramPlanData FamilyVisitMeetingProgramPlanData { get;  set; }
        public MeetingProgramPlanData EidReunionMeetingProgramPlanData { get;  set; }
        public MeetingProgramPlanData BbqMeetingProgramPlanData { get;  set; }
        public MeetingProgramPlanData GatheringMeetingProgramPlanData { get;  set; }
        public MeetingProgramPlanData OtherMeetingProgramPlanData { get; set; }

        public MemberPlanData MemberMemberPlanData { get; set; }

        public FinancePlanData BaitulMalFinancePlanData { get; set; }
        public FinancePlanData ADayMasjidProjectFinancePlanData { get; set; }
        public FinancePlanData MasjidTableBankFinancePlanData { get; set; }

        public SocialWelfarePlanData QardeHasanaSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData PatientVisitSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData SocialVisitSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData TransportSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData ShiftingSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData ShoppingSocialWelfarePlanData { get; set; }

        public SocialWelfarePlanData FoodDistributionSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData CleanUpAustraliaSocialWelfarePlanData { get; set; }
        public SocialWelfarePlanData OtherSocialWelfarePlanData { get; set; }

        public MaterialPlanData BookSaleMaterialPlanData { get; set; }
        public MaterialPlanData BookDistributionMaterialPlanData { get; set; }
        public LibraryStockPlanData BookLibraryStockPlanData { get; set; }
        public MaterialPlanData OtherSaleMaterialPlanData { get; set; }
        public MaterialPlanData OtherDistributionMaterialPlanData { get; set; }
        public LibraryStockPlanData OtherLibraryStockPlanData { get; set; }

        public MaterialPlanData VhsSaleMaterialPlanData { get; set; }
        public MaterialPlanData VhsDistributionMaterialPlanData { get; set; }
        public LibraryStockPlanData VhsLibraryStockPlanData { get; set; }
        public MaterialPlanData EmailDistributionMaterialPlanData { get; set; }
        public MaterialPlanData IpdcLeafletDistributionMaterialPlanData { get; set; }

        public TeachingLearningProgramPlanData GroupStudyTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData StudyCircleTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData PracticeDarsTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData StateLearningCampTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData QuranStudyTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData QuranClassTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData MemorizingAyatTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData StateLearningSessionTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData StateQiyamulLailTeachingLearningProgramPlanData { get; set; }

        public TeachingLearningProgramPlanData StudyCircleForAssociateMemberTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData HadithTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData WeekendIslamicSchoolTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData MemorizingHadithTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData MemorizingDoaTeachingLearningProgramPlanData { get; set; }
        public TeachingLearningProgramPlanData OtherTeachingLearningProgramPlanData { get; set; }

        public DateTime Timestamp { get; set; }

    }
}