using System;
using System.Diagnostics.CodeAnalysis;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class UnitReportViewModel : IReportSearchTermsFilter
    {
        public UnitReportViewModel() { }

        public int Id { get; set; }
        public string Description { get; set; }
        public OrganizationReference Organization { get; set; }
        public ReportingPeriod ReportingPeriod { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string ReportStatusDescription => ReportStatus.ToString();
        public ReopenedReportStatus ReOpenedReportStatus { get; set; }
        public string ReOpenedReportStatusDescription => ReOpenedReportStatus.ToString();
        public MemberData AssociateMemberData { get; set; }
        public MemberData PreliminaryMemberData { get; set; }
        public MemberData SupporterMemberData { get; set; }
        public MeetingProgramData WorkerMeetingProgramData { get; set; }
        public MeetingProgramData DawahMeetingProgramData { get; set; }
        public MeetingProgramData StateLeaderMeetingProgramData { get; set; }
        public MeetingProgramData StateOutingMeetingProgramData { get; set; }
        public MeetingProgramData IftarMeetingProgramData { get; set; }
        public MeetingProgramData LearningMeetingProgramData { get; set; }
        public MeetingProgramData SocialDawahMeetingProgramData { get; set; }
        public MeetingProgramData DawahGroupMeetingProgramData { get; set; }
        public MeetingProgramData NextGMeetingProgramData { get; set; }

        public MeetingProgramData CmsMeetingProgramData { get; set; }
        public MeetingProgramData SmMeetingProgramData { get; set; }
        public MeetingProgramData MemberMeetingProgramData { get; set; }
        public MeetingProgramData TafsirMeetingProgramData { get; set; }
        public MeetingProgramData UnitMeetingProgramData { get; set; }
        public MeetingProgramData FamilyVisitMeetingProgramData { get; set; }
        public MeetingProgramData EidReunionMeetingProgramData { get; set; }
        public MeetingProgramData BbqMeetingProgramData { get; set; }
        public MeetingProgramData GatheringMeetingProgramData { get; set; }
        public MeetingProgramData OtherMeetingProgramData { get; set; }

        public MemberData MemberMemberData { get; set; }

        public FinanceData BaitulMalFinanceData { get; set; }
        public FinanceData ADayMasjidProjectFinanceData { get;  set; }
        public FinanceData MasjidTableBankFinanceData { get;  set; }


        public SocialWelfareData QardeHasanaSocialWelfareData { get; set; }
        public SocialWelfareData PatientVisitSocialWelfareData { get; set; }
        public SocialWelfareData SocialVisitSocialWelfareData { get; set; }
        public SocialWelfareData TransportSocialWelfareData { get; set; }
        public SocialWelfareData ShiftingSocialWelfareData { get; set; }
        public SocialWelfareData ShoppingSocialWelfareData { get; set; }

        public SocialWelfareData FoodDistributionSocialWelfareData { get; set; }
        public SocialWelfareData CleanUpAustraliaSocialWelfareData { get; set; }
        public SocialWelfareData OtherSocialWelfareData { get; set; }

        public MaterialData BookSaleMaterialData { get; set; }
        public MaterialData BookDistributionMaterialData { get; set; }
        public LibraryStockData BookLibraryStockData { get; set; }
        public MaterialData OtherSaleMaterialData { get; set; }
        public MaterialData OtherDistributionMaterialData { get; set; }
        public LibraryStockData OtherLibraryStockData { get; set; }
        public MaterialData VhsSaleMaterialData { get; set; }
        public MaterialData VhsDistributionMaterialData { get; set; }
        public LibraryStockData VhsLibraryStockData { get; set; }
        public MaterialData EmailDistributionMaterialData { get; set; }
        public MaterialData IpdcLeafletDistributionMaterialData { get; set; }

        
        
        public TeachingLearningProgramData GroupStudyTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData StudyCircleTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData PracticeDarsTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData StateLearningCampTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData QuranStudyTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData QuranClassTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData MemorizingAyatTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData StateLearningSessionTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData StateQiyamulLailTeachingLearningProgramData { get; set; }

        public TeachingLearningProgramData StudyCircleForAssociateMemberTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData HadithTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData WeekendIslamicSchoolTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData MemorizingHadithTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData MemorizingDoaTeachingLearningProgramData { get; set; }
        public TeachingLearningProgramData OtherTeachingLearningProgramData { get; set; }

        public string Comment { get; set; }
        public DateTime Timestamp { get; set; }
    }
}