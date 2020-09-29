using System;
using ReportingModule.Core;
using ReportingModule.Core.Domains;
using ReportingModule.Extensions;
using ReportingModule.Utility;
using ReportingModule.ValueObjects;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace ReportingModule.Entities
{
    public class StateReport : IAggregate<int>, IReport
    {
        protected StateReport()
        {
        }

        public StateReport(string description, OrganizationReference organization, ReportingPeriod reportingPeriod, ReportData reportData)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));
            if (organization == null)
                throw new ArgumentNullException(nameof(organization));
            if (organization.OrganizationType != OrganizationType.State)
                throw new ArgumentException("Invalid organization type");
            Organization = organization;
            Description = description;
            ReportingPeriod = reportingPeriod ?? throw new ArgumentNullException(nameof(reportingPeriod));
            if (reportData == null) throw new ArgumentNullException(nameof(reportData));
            MemberMemberData = reportData.MemberMemberData ?? MemberData.Default();
            AssociateMemberData = reportData.AssociateMemberData ?? MemberData.Default();
            PreliminaryMemberData = reportData.PreliminaryMemberData ?? MemberData.Default();
            SupporterMemberData = reportData.SupporterMemberData ?? MemberData.Default();


            WorkerMeetingProgramData = reportData.WorkerMeetingProgramData ?? MeetingProgramData.Default();
            DawahMeetingProgramData = reportData.DawahMeetingProgramData ?? MeetingProgramData.Default();
            StateLeaderMeetingProgramData = reportData.StateLeaderMeetingProgramData ?? MeetingProgramData.Default();
            StateOutingMeetingProgramData = reportData.StateOutingMeetingProgramData ?? MeetingProgramData.Default();
            IftarMeetingProgramData = reportData.IftarMeetingProgramData ?? MeetingProgramData.Default();
            LearningMeetingProgramData = reportData.LearningMeetingProgramData ?? MeetingProgramData.Default();
            SocialDawahMeetingProgramData = reportData.SocialDawahMeetingProgramData ?? MeetingProgramData.Default();
            DawahGroupMeetingProgramData = reportData.DawahGroupMeetingProgramData ?? MeetingProgramData.Default();
            NextGMeetingProgramData = reportData.NextGMeetingProgramData ?? MeetingProgramData.Default();

            CmsMeetingProgramData = reportData.CmsMeetingProgramData ?? MeetingProgramData.Default();
            SmMeetingProgramData = reportData.SmMeetingProgramData ?? MeetingProgramData.Default();
            MemberMeetingProgramData = reportData.MemberMeetingProgramData ?? MeetingProgramData.Default();
            TafsirMeetingProgramData = reportData.TafsirMeetingProgramData ?? MeetingProgramData.Default();
            UnitMeetingProgramData = reportData.UnitMeetingProgramData ?? MeetingProgramData.Default();
            FamilyVisitMeetingProgramData = reportData.FamilyVisitMeetingProgramData ?? MeetingProgramData.Default();
            EidReunionMeetingProgramData = reportData.EidReunionMeetingProgramData ?? MeetingProgramData.Default();
            BbqMeetingProgramData = reportData.BbqMeetingProgramData ?? MeetingProgramData.Default();
            GatheringMeetingProgramData = reportData.GatheringMeetingProgramData ?? MeetingProgramData.Default();

            OtherMeetingProgramData = reportData.OtherMeetingProgramData ?? MeetingProgramData.Default();


            GroupStudyTeachingLearningProgramData = reportData.GroupStudyTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            StudyCircleTeachingLearningProgramData = reportData.StudyCircleTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            PracticeDarsTeachingLearningProgramData = reportData.PracticeDarsTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            StateLearningCampTeachingLearningProgramData = reportData.StateLearningCampTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            QuranStudyTeachingLearningProgramData = reportData.QuranStudyTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            QuranClassTeachingLearningProgramData = reportData.QuranClassTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            MemorizingAyatTeachingLearningProgramData = reportData.MemorizingAyatTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            StateLearningSessionTeachingLearningProgramData = reportData.StateLearningSessionTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            StateQiyamulLailTeachingLearningProgramData = reportData.StateQiyamulLailTeachingLearningProgramData ?? TeachingLearningProgramData.Default();

            StudyCircleForAssociateMemberTeachingLearningProgramData = reportData.StudyCircleForAssociateMemberTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            HadithTeachingLearningProgramData = reportData.HadithTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            WeekendIslamicSchoolTeachingLearningProgramData = reportData.WeekendIslamicSchoolTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            MemorizingHadithTeachingLearningProgramData = reportData.MemorizingHadithTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            MemorizingDoaTeachingLearningProgramData = reportData.MemorizingDoaTeachingLearningProgramData ?? TeachingLearningProgramData.Default();

            OtherTeachingLearningProgramData = reportData.OtherTeachingLearningProgramData ?? TeachingLearningProgramData.Default();

            BookSaleMaterialData = reportData.BookSaleMaterialData ?? MaterialData.Default();
            BookDistributionMaterialData = reportData.BookDistributionMaterialData ?? MaterialData.Default();
            BookLibraryStockData = reportData.BookLibraryStockData ?? LibraryStockData.Default();

            OtherSaleMaterialData = reportData.OtherSaleMaterialData ?? MaterialData.Default();
            OtherDistributionMaterialData = reportData.OtherDistributionMaterialData ?? MaterialData.Default();
            OtherLibraryStockData = reportData.OtherLibraryStockData ?? LibraryStockData.Default();

            VhsSaleMaterialData = reportData.VhsSaleMaterialData ?? MaterialData.Default();
            VhsDistributionMaterialData = reportData.VhsDistributionMaterialData ?? MaterialData.Default();
            VhsLibraryStockData = reportData.VhsLibraryStockData ?? LibraryStockData.Default();
            EmailDistributionMaterialData = reportData.EmailDistributionMaterialData ?? MaterialData.Default();
            IpdcLeafletDistributionMaterialData = reportData.IpdcLeafletDistributionMaterialData ?? MaterialData.Default();


            BaitulMalFinanceData = reportData.BaitulMalFinanceData ?? FinanceData.Default();
            ADayMasjidProjectFinanceData = reportData.ADayMasjidProjectFinanceData ?? FinanceData.Default();
            MasjidTableBankFinanceData = reportData.MasjidTableBankFinanceData ?? FinanceData.Default();

            QardeHasanaSocialWelfareData = reportData.QardeHasanaSocialWelfareData ?? SocialWelfareData.Default();
            PatientVisitSocialWelfareData = reportData.PatientVisitSocialWelfareData ?? SocialWelfareData.Default();
            SocialVisitSocialWelfareData = reportData.SocialVisitSocialWelfareData ?? SocialWelfareData.Default();
            TransportSocialWelfareData = reportData.TransportSocialWelfareData ?? SocialWelfareData.Default();
            ShiftingSocialWelfareData = reportData.ShiftingSocialWelfareData ?? SocialWelfareData.Default();
            ShoppingSocialWelfareData = reportData.ShoppingSocialWelfareData ?? SocialWelfareData.Default();

            FoodDistributionSocialWelfareData = reportData.FoodDistributionSocialWelfareData ?? SocialWelfareData.Default();
            CleanUpAustraliaSocialWelfareData = reportData.CleanUpAustraliaSocialWelfareData ?? SocialWelfareData.Default();
            OtherSocialWelfareData = reportData.OtherSocialWelfareData ?? SocialWelfareData.Default();

            Comment = reportData.Comment;
            ReportStatus = ReportStatus.Draft;
            ReopenedReportStatus = ReopenedReportStatus.None;
            Timestamp = ZaphodTime.UtcNow;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public OrganizationReference Organization { get; private set; }
        public ReportingPeriod ReportingPeriod { get; private set; }
        public string Comment { get; private set; }
        public ReportStatus ReportStatus { get; private set; }
        public ReopenedReportStatus ReopenedReportStatus { get; private set; }
        public MemberData MemberMemberData { get; private set; }
        public MemberData MemberMemberGeneratedData { get; private set; }
        public MemberData AssociateMemberData { get; private set; }
        public MemberData AssociateMemberGeneratedData { get; private set; }
        public MemberData PreliminaryMemberData { get; private set; }
        public MemberData PreliminaryMemberGeneratedData { get; private set; }
        public MemberData SupporterMemberData { get; private set; }
        public MemberData SupporterMemberGeneratedData { get; private set; }
        public MeetingProgramData WorkerMeetingProgramData { get; private set; }
        public MeetingProgramData WorkerMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData DawahMeetingProgramData { get; private set; }
        public MeetingProgramData DawahMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData StateLeaderMeetingProgramData { get; private set; }
        public MeetingProgramData StateLeaderMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData StateOutingMeetingProgramData { get; private set; }
        public MeetingProgramData StateOutingMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData IftarMeetingProgramData { get; private set; }
        public MeetingProgramData IftarMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData LearningMeetingProgramData { get; private set; }
        public MeetingProgramData LearningMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData SocialDawahMeetingProgramData { get; private set; }
        public MeetingProgramData SocialDawahMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData DawahGroupMeetingProgramData { get; private set; }
        public MeetingProgramData DawahGroupMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData NextGMeetingProgramData { get; private set; }
        public MeetingProgramData NextGMeetingProgramGeneratedData { get; private set; }


        public MeetingProgramData CmsMeetingProgramData { get; private set; }
        public MeetingProgramData CmsMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData SmMeetingProgramData { get; private set; }
        public MeetingProgramData SmMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData MemberMeetingProgramData { get; private set; }
        public MeetingProgramData MemberMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData TafsirMeetingProgramData { get; private set; }
        public MeetingProgramData TafsirMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData UnitMeetingProgramData { get; private set; }
        public MeetingProgramData UnitMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData FamilyVisitMeetingProgramData { get; private set; }
        public MeetingProgramData FamilyVisitMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData EidReunionMeetingProgramData { get; private set; }
        public MeetingProgramData EidReunionMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData BbqMeetingProgramData { get; private set; }
        public MeetingProgramData BbqMeetingProgramGeneratedData { get; private set; }
        public MeetingProgramData GatheringMeetingProgramData { get; private set; }
        public MeetingProgramData GatheringMeetingProgramGeneratedData { get; private set; }

        public MeetingProgramData OtherMeetingProgramData { get; private set; }
        public MeetingProgramData OtherMeetingProgramGeneratedData { get; private set; }

        public TeachingLearningProgramData GroupStudyTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData StudyCircleTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData PracticeDarsTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData StateLearningCampTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData QuranStudyTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData QuranClassTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData MemorizingAyatTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData StateLearningSessionTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData StateQiyamulLailTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData GroupStudyTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData StudyCircleTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData PracticeDarsTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData StateLearningCampTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData QuranStudyTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData QuranClassTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData MemorizingAyatTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData StateLearningSessionTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData StateQiyamulLailTeachingLearningProgramGeneratedData { get; private set; }

        public TeachingLearningProgramData StudyCircleForAssociateMemberTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData HadithTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData HadithTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData WeekendIslamicSchoolTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData WeekendIslamicSchoolTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData MemorizingHadithTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData MemorizingHadithTeachingLearningProgramGeneratedData { get; private set; }
        public TeachingLearningProgramData MemorizingDoaTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData MemorizingDoaTeachingLearningProgramGeneratedData { get; private set; }

        public TeachingLearningProgramData OtherTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData OtherTeachingLearningProgramGeneratedData { get; private set; }

        public MaterialData BookSaleMaterialData { get; private set; }
        public MaterialData BookSaleMaterialGeneratedData { get; private set; }
        public MaterialData BookDistributionMaterialData { get; private set; }
        public MaterialData BookDistributionMaterialGeneratedData { get; private set; }
        public LibraryStockData BookLibraryStockData { get; private set; }
        public LibraryStockData BookLibraryStockGeneratedData { get; private set; }

        public MaterialData OtherSaleMaterialData { get; private set; }
        public MaterialData OtherSaleMaterialGeneratedData { get; private set; }
        public MaterialData OtherDistributionMaterialData { get; private set; }
        public MaterialData OtherDistributionMaterialGeneratedData { get; private set; }
        public LibraryStockData OtherLibraryStockData { get; private set; }
        public LibraryStockData OtherLibraryStockGeneratedData { get; private set; }

        public MaterialData VhsSaleMaterialData { get; private set; }
        public MaterialData VhsSaleMaterialGeneratedData { get; private set; }
        public MaterialData VhsDistributionMaterialData { get; private set; }
        public MaterialData VhsDistributionMaterialGeneratedData { get; private set; }
        public LibraryStockData VhsLibraryStockData { get; private set; }
        public LibraryStockData VhsLibraryStockGeneratedData { get; private set; }
        public MaterialData EmailDistributionMaterialData { get; private set; }
        public MaterialData EmailDistributionMaterialGeneratedData { get; private set; }
        public MaterialData IpdcLeafletDistributionMaterialData { get; private set; }
        public MaterialData IpdcLeafletDistributionMaterialGeneratedData { get; private set; }






        public FinanceData BaitulMalFinanceData { get; private set; }
        public FinanceData BaitulMalFinanceGeneratedData { get; private set; }
        public FinanceData ADayMasjidProjectFinanceData { get; private set; }
        public FinanceData ADayMasjidProjectFinanceGeneratedData { get; private set; }
        public FinanceData MasjidTableBankFinanceData { get; private set; }
        public FinanceData MasjidTableBankFinanceGeneratedData { get; private set; }

        public SocialWelfareData QardeHasanaSocialWelfareData { get; private set; }
        public SocialWelfareData QardeHasanaSocialWelfareGeneratedData { get; private set; }
        public SocialWelfareData PatientVisitSocialWelfareData { get; private set; }
        public SocialWelfareData PatientVisitSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData SocialVisitSocialWelfareData { get; private set; }
        public SocialWelfareData SocialVisitSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData TransportSocialWelfareData { get; private set; }
        public SocialWelfareData TransportSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData ShiftingSocialWelfareData { get; private set; }
        public SocialWelfareData ShiftingSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData ShoppingSocialWelfareData { get; private set; }
        public SocialWelfareData ShoppingSocialWelfareGeneratedData { get; set; }

        public SocialWelfareData FoodDistributionSocialWelfareData { get; private set; }
        public SocialWelfareData FoodDistributionSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData CleanUpAustraliaSocialWelfareData { get; private set; }
        public SocialWelfareData CleanUpAustraliaSocialWelfareGeneratedData { get; set; }
        public SocialWelfareData OtherSocialWelfareData { get; private set; }
        public SocialWelfareData OtherSocialWelfareGeneratedData { get; set; }

        public DateTime Timestamp { get; private set; }
        public bool IsDeleted { get; private set; }

        public void MarkAsDelete()
        {
            IsDeleted = true;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void MarkStatusAsPlanPromoted()
        {
            ReportStatus = ReportStatus.PlanPromoted;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void MarkStatusAsSubmitted()
        {
            ReportStatus = ReportStatus.Submitted;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void MarkStatusAsReopenedPlan()
        {
            ReopenedReportStatus = ReopenedReportStatus.PlanReopened;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void MarkStatusAsReopenedPlanPromoted()
        {
            ReopenedReportStatus = ReopenedReportStatus.ReopenedPlanPromoted;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void MarkStatusAsReopenedReport()
        {
            ReopenedReportStatus = ReopenedReportStatus.ReportReopened;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void MarkStatusAsReopenedReportSubmitted()
        {
            ReopenedReportStatus = ReopenedReportStatus.ReopenedReportSubmitted;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void UpdatePlan(PlanData planData)
        {
            MemberMemberData = MemberMemberData?.ToMemberData(planData.MemberMemberPlanData ?? throw new ArgumentNullException(nameof(planData.MemberMemberPlanData)));
            AssociateMemberData = AssociateMemberData?.ToMemberData(planData.AssociateMemberPlanData ?? throw new ArgumentNullException(nameof(planData.AssociateMemberPlanData)));
            PreliminaryMemberData = PreliminaryMemberData?.ToMemberData(planData.PreliminaryMemberPlanData ?? throw new ArgumentNullException(nameof(planData.PreliminaryMemberPlanData)));
            SupporterMemberData = SupporterMemberData?.ToMemberData(planData.SupporterMemberPlanData ?? throw new ArgumentNullException(nameof(planData.SupporterMemberPlanData)));

            WorkerMeetingProgramData = WorkerMeetingProgramData?.ToMeetingProgramData(planData.WorkerMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.WorkerMeetingProgramPlanData)));
            DawahMeetingProgramData = DawahMeetingProgramData?.ToMeetingProgramData(planData.DawahMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.DawahMeetingProgramPlanData)));
            StateLeaderMeetingProgramData = StateLeaderMeetingProgramData?.ToMeetingProgramData(planData.StateLeaderMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.StateLeaderMeetingProgramPlanData)));
            StateOutingMeetingProgramData = StateOutingMeetingProgramData?.ToMeetingProgramData(planData.StateOutingMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.StateOutingMeetingProgramPlanData)));
            IftarMeetingProgramData = IftarMeetingProgramData?.ToMeetingProgramData(planData.IftarMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.IftarMeetingProgramPlanData)));
            LearningMeetingProgramData = LearningMeetingProgramData?.ToMeetingProgramData(planData.LearningMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.LearningMeetingProgramPlanData)));
            SocialDawahMeetingProgramData = SocialDawahMeetingProgramData?.ToMeetingProgramData(planData.SocialDawahMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.SocialDawahMeetingProgramPlanData)));
            DawahGroupMeetingProgramData = DawahGroupMeetingProgramData?.ToMeetingProgramData(planData.DawahGroupMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.DawahGroupMeetingProgramPlanData)));
            NextGMeetingProgramData = NextGMeetingProgramData?.ToMeetingProgramData(planData.NextGMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.NextGMeetingProgramPlanData)));


            CmsMeetingProgramData = CmsMeetingProgramData?.ToMeetingProgramData(planData.CmsMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.CmsMeetingProgramPlanData)));
            SmMeetingProgramData = SmMeetingProgramData?.ToMeetingProgramData(planData.SmMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.SmMeetingProgramPlanData)));
            MemberMeetingProgramData = MemberMeetingProgramData?.ToMeetingProgramData(planData.MemberMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.MemberMeetingProgramPlanData)));
            TafsirMeetingProgramData = TafsirMeetingProgramData?.ToMeetingProgramData(planData.TafsirMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.TafsirMeetingProgramPlanData)));
            UnitMeetingProgramData = UnitMeetingProgramData?.ToMeetingProgramData(planData.UnitMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.UnitMeetingProgramPlanData)));
            FamilyVisitMeetingProgramData = FamilyVisitMeetingProgramData?.ToMeetingProgramData(planData.FamilyVisitMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.FamilyVisitMeetingProgramPlanData)));
            EidReunionMeetingProgramData = EidReunionMeetingProgramData?.ToMeetingProgramData(planData.EidReunionMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.EidReunionMeetingProgramPlanData)));
            BbqMeetingProgramData = BbqMeetingProgramData?.ToMeetingProgramData(planData.BbqMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.BbqMeetingProgramPlanData)));
            GatheringMeetingProgramData = GatheringMeetingProgramData?.ToMeetingProgramData(planData.GatheringMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.GatheringMeetingProgramPlanData)));

            OtherMeetingProgramData = OtherMeetingProgramData?.ToMeetingProgramData(planData.OtherMeetingProgramPlanData ?? throw new ArgumentNullException(nameof(planData.OtherMeetingProgramPlanData)));

            GroupStudyTeachingLearningProgramData = GroupStudyTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.GroupStudyTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.GroupStudyTeachingLearningProgramPlanData)));
            StudyCircleTeachingLearningProgramData = StudyCircleTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.StudyCircleTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.StudyCircleTeachingLearningProgramPlanData)));
            PracticeDarsTeachingLearningProgramData = PracticeDarsTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.PracticeDarsTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.PracticeDarsTeachingLearningProgramPlanData)));
            StateLearningCampTeachingLearningProgramData = StateLearningCampTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.StateLearningCampTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.StateLearningCampTeachingLearningProgramPlanData)));
            QuranStudyTeachingLearningProgramData = QuranStudyTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.QuranStudyTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.QuranStudyTeachingLearningProgramPlanData)));
            QuranClassTeachingLearningProgramData = QuranClassTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.QuranClassTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.QuranClassTeachingLearningProgramPlanData)));
            MemorizingAyatTeachingLearningProgramData = MemorizingAyatTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.MemorizingAyatTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.MemorizingAyatTeachingLearningProgramPlanData)));
            StateLearningSessionTeachingLearningProgramData = StateLearningSessionTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.StateLearningSessionTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.StateLearningSessionTeachingLearningProgramPlanData)));
            StateQiyamulLailTeachingLearningProgramData = StateQiyamulLailTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.StateQiyamulLailTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.StateQiyamulLailTeachingLearningProgramPlanData)));

            BookSaleMaterialData = BookSaleMaterialData?.ToMaterialData(planData.BookSaleMaterialPlanData ?? throw new ArgumentNullException(nameof(planData.BookSaleMaterialPlanData)));
            BookDistributionMaterialData = BookDistributionMaterialData?.ToMaterialData(planData.BookDistributionMaterialPlanData ?? throw new ArgumentNullException(nameof(planData.BookDistributionMaterialPlanData)));
            BookLibraryStockData = BookLibraryStockData?.ToLibraryStockData(planData.BookLibraryStockPlanData ?? throw new ArgumentNullException(nameof(planData.BookLibraryStockPlanData)));

            OtherSaleMaterialData = OtherSaleMaterialData?.ToMaterialData(planData.OtherSaleMaterialPlanData ?? throw new ArgumentNullException(nameof(planData.OtherSaleMaterialPlanData)));
            OtherDistributionMaterialData = OtherDistributionMaterialData?.ToMaterialData(planData.OtherDistributionMaterialPlanData ?? throw new ArgumentNullException(nameof(planData.OtherDistributionMaterialPlanData)));
            OtherLibraryStockData = OtherLibraryStockData?.ToLibraryStockData(planData.OtherLibraryStockPlanData ?? throw new ArgumentNullException(nameof(planData.OtherLibraryStockPlanData)));

            VhsSaleMaterialData = VhsSaleMaterialData?.ToMaterialData(planData.VhsSaleMaterialPlanData ?? throw new ArgumentNullException(nameof(planData.VhsSaleMaterialPlanData)));
            VhsDistributionMaterialData = VhsDistributionMaterialData?.ToMaterialData(planData.VhsDistributionMaterialPlanData ?? throw new ArgumentNullException(nameof(planData.VhsDistributionMaterialPlanData)));
            VhsLibraryStockData = VhsLibraryStockData?.ToLibraryStockData(planData.VhsLibraryStockPlanData ?? throw new ArgumentNullException(nameof(planData.VhsLibraryStockPlanData)));
            EmailDistributionMaterialData = EmailDistributionMaterialData?.ToMaterialData(planData.EmailDistributionMaterialPlanData ?? throw new ArgumentNullException(nameof(planData.EmailDistributionMaterialPlanData)));
            IpdcLeafletDistributionMaterialData = IpdcLeafletDistributionMaterialData?.ToMaterialData(planData.IpdcLeafletDistributionMaterialPlanData ?? throw new ArgumentNullException(nameof(planData.IpdcLeafletDistributionMaterialPlanData)));

            BaitulMalFinanceData = BaitulMalFinanceData?.ToFinanceData(planData.BaitulMalFinancePlanData ?? throw new ArgumentNullException(nameof(planData.BaitulMalFinancePlanData)));
            ADayMasjidProjectFinanceData = ADayMasjidProjectFinanceData?.ToFinanceData(planData.ADayMasjidProjectFinancePlanData ?? throw new ArgumentNullException(nameof(planData.ADayMasjidProjectFinancePlanData)));
            MasjidTableBankFinanceData = MasjidTableBankFinanceData?.ToFinanceData(planData.MasjidTableBankFinancePlanData ?? throw new ArgumentNullException(nameof(planData.MasjidTableBankFinancePlanData)));

            QardeHasanaSocialWelfareData = QardeHasanaSocialWelfareData?.ToSocialWelfareData(planData.QardeHasanaSocialWelfarePlanData ?? throw new ArgumentNullException(nameof(planData.QardeHasanaSocialWelfarePlanData)));
            PatientVisitSocialWelfareData = PatientVisitSocialWelfareData?.ToSocialWelfareData(planData.PatientVisitSocialWelfarePlanData ?? throw new ArgumentNullException(nameof(planData.PatientVisitSocialWelfarePlanData)));
            SocialVisitSocialWelfareData = SocialVisitSocialWelfareData?.ToSocialWelfareData(planData.SocialVisitSocialWelfarePlanData ?? throw new ArgumentNullException(nameof(planData.SocialVisitSocialWelfarePlanData)));
            TransportSocialWelfareData = TransportSocialWelfareData?.ToSocialWelfareData(planData.TransportSocialWelfarePlanData ?? throw new ArgumentNullException(nameof(planData.TransportSocialWelfarePlanData)));
            ShiftingSocialWelfareData = ShiftingSocialWelfareData?.ToSocialWelfareData(planData.ShiftingSocialWelfarePlanData ?? throw new ArgumentNullException(nameof(planData.ShiftingSocialWelfarePlanData)));
            ShoppingSocialWelfareData = ShoppingSocialWelfareData?.ToSocialWelfareData(planData.ShoppingSocialWelfarePlanData ?? throw new ArgumentNullException(nameof(planData.ShoppingSocialWelfarePlanData)));

            FoodDistributionSocialWelfareData = FoodDistributionSocialWelfareData?.ToSocialWelfareData(planData.FoodDistributionSocialWelfarePlanData ?? throw new ArgumentNullException(nameof(planData.FoodDistributionSocialWelfarePlanData)));
            CleanUpAustraliaSocialWelfareData = CleanUpAustraliaSocialWelfareData?.ToSocialWelfareData(planData.CleanUpAustraliaSocialWelfarePlanData ?? throw new ArgumentNullException(nameof(planData.CleanUpAustraliaSocialWelfarePlanData)));
            OtherSocialWelfareData = OtherSocialWelfareData?.ToSocialWelfareData(planData.OtherSocialWelfarePlanData ?? throw new ArgumentNullException(nameof(planData.OtherSocialWelfarePlanData)));

            StudyCircleForAssociateMemberTeachingLearningProgramData = StudyCircleForAssociateMemberTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.StudyCircleForAssociateMemberTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.StudyCircleForAssociateMemberTeachingLearningProgramPlanData)));
            HadithTeachingLearningProgramData = HadithTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.HadithTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.HadithTeachingLearningProgramPlanData)));
            WeekendIslamicSchoolTeachingLearningProgramData = WeekendIslamicSchoolTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.WeekendIslamicSchoolTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.WeekendIslamicSchoolTeachingLearningProgramPlanData)));
            MemorizingHadithTeachingLearningProgramData = MemorizingHadithTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.MemorizingHadithTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.MemorizingHadithTeachingLearningProgramPlanData)));
            MemorizingDoaTeachingLearningProgramData = MemorizingDoaTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.MemorizingDoaTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.MemorizingDoaTeachingLearningProgramPlanData)));

            OtherTeachingLearningProgramData = OtherTeachingLearningProgramData?.ToTeachingLearningProgramData(planData.OtherTeachingLearningProgramPlanData ?? throw new ArgumentNullException(nameof(planData.OtherTeachingLearningProgramPlanData)));

            Timestamp = ZaphodTime.UtcNow;
        }

        public void Update(ReportUpdateData reportUpdateData)
        {
            MemberMemberData = MemberMemberData?.ToMemberData(reportUpdateData.MemberMemberReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.MemberMemberReportData)));
            AssociateMemberData = AssociateMemberData?.ToMemberData(reportUpdateData.AssociateMemberReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.AssociateMemberReportData)));
            PreliminaryMemberData = PreliminaryMemberData?.ToMemberData(reportUpdateData.PreliminaryMemberReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.PreliminaryMemberReportData)));
            SupporterMemberData = SupporterMemberData?.ToMemberData(reportUpdateData.SupporterMemberReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.SupporterMemberReportData)));

            WorkerMeetingProgramData = WorkerMeetingProgramData?.ToMeetingProgramData(reportUpdateData.WorkerMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.WorkerMeetingProgramReportData)));
            DawahMeetingProgramData = DawahMeetingProgramData?.ToMeetingProgramData(reportUpdateData.DawahMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.DawahMeetingProgramReportData)));
            StateLeaderMeetingProgramData = StateLeaderMeetingProgramData?.ToMeetingProgramData(reportUpdateData.StateLeaderMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.StateLeaderMeetingProgramReportData)));
            StateOutingMeetingProgramData = StateOutingMeetingProgramData?.ToMeetingProgramData(reportUpdateData.StateOutingMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.StateOutingMeetingProgramReportData)));
            IftarMeetingProgramData = IftarMeetingProgramData?.ToMeetingProgramData(reportUpdateData.IftarMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.IftarMeetingProgramReportData)));
            LearningMeetingProgramData = LearningMeetingProgramData?.ToMeetingProgramData(reportUpdateData.LearningMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.LearningMeetingProgramReportData)));
            SocialDawahMeetingProgramData = SocialDawahMeetingProgramData?.ToMeetingProgramData(reportUpdateData.SocialDawahMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.SocialDawahMeetingProgramReportData)));
            DawahGroupMeetingProgramData = DawahGroupMeetingProgramData?.ToMeetingProgramData(reportUpdateData.DawahGroupMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.DawahGroupMeetingProgramReportData)));
            NextGMeetingProgramData = NextGMeetingProgramData?.ToMeetingProgramData(reportUpdateData.NextGMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.NextGMeetingProgramReportData)));


            CmsMeetingProgramData = CmsMeetingProgramData?.ToMeetingProgramData(reportUpdateData.CMSMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.CMSMeetingProgramReportData)));
            SmMeetingProgramData = SmMeetingProgramData?.ToMeetingProgramData(reportUpdateData.SMMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.SMMeetingProgramReportData)));
            MemberMeetingProgramData = MemberMeetingProgramData?.ToMeetingProgramData(reportUpdateData.MemberMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.MemberMeetingProgramReportData)));
            TafsirMeetingProgramData = TafsirMeetingProgramData?.ToMeetingProgramData(reportUpdateData.TafsirMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.TafsirMeetingProgramReportData)));
            UnitMeetingProgramData = UnitMeetingProgramData?.ToMeetingProgramData(reportUpdateData.UnitMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.UnitMeetingProgramReportData)));
            FamilyVisitMeetingProgramData = FamilyVisitMeetingProgramData?.ToMeetingProgramData(reportUpdateData.FamilyVisitMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.FamilyVisitMeetingProgramReportData)));
            EidReunionMeetingProgramData = EidReunionMeetingProgramData?.ToMeetingProgramData(reportUpdateData.EidReunionMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.EidReunionMeetingProgramReportData)));
            BbqMeetingProgramData = BbqMeetingProgramData?.ToMeetingProgramData(reportUpdateData.BBQMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.BBQMeetingProgramReportData)));
            GatheringMeetingProgramData = GatheringMeetingProgramData?.ToMeetingProgramData(reportUpdateData.GatheringMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.GatheringMeetingProgramReportData)));

            OtherMeetingProgramData = OtherMeetingProgramData?.ToMeetingProgramData(reportUpdateData.OtherMeetingProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.OtherMeetingProgramReportData)));

            GroupStudyTeachingLearningProgramData = GroupStudyTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.GroupStudyTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.GroupStudyTeachingLearningProgramReportData)));
            StudyCircleTeachingLearningProgramData = StudyCircleTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.StudyCircleTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.StudyCircleTeachingLearningProgramReportData)));
            PracticeDarsTeachingLearningProgramData = PracticeDarsTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.PracticeDarsTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.PracticeDarsTeachingLearningProgramReportData)));
            StateLearningCampTeachingLearningProgramData = StateLearningCampTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.StateLearningCampTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.StateLearningCampTeachingLearningProgramReportData)));
            QuranStudyTeachingLearningProgramData = QuranStudyTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.QuranStudyTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.QuranStudyTeachingLearningProgramReportData)));
            QuranClassTeachingLearningProgramData = QuranClassTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.QuranClassTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.QuranClassTeachingLearningProgramReportData)));
            MemorizingAyatTeachingLearningProgramData = MemorizingAyatTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.MemorizingAyatTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.MemorizingAyatTeachingLearningProgramReportData)));
            StateLearningSessionTeachingLearningProgramData = StateLearningSessionTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.StateLearningSessionTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.StateLearningSessionTeachingLearningProgramReportData)));
            StateQiyamulLailTeachingLearningProgramData = StateQiyamulLailTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.StateQiyamulLailTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.StateQiyamulLailTeachingLearningProgramReportData)));

            BookSaleMaterialData = BookSaleMaterialData?.ToMaterialData(reportUpdateData.BookSaleMaterialReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.BookSaleMaterialReportData)));
            BookDistributionMaterialData = BookDistributionMaterialData?.ToMaterialData(reportUpdateData.BookDistributionMaterialReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.BookDistributionMaterialReportData)));
            BookLibraryStockData = BookLibraryStockData?.ToLibraryStockData(reportUpdateData.BookLibraryStockReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.BookLibraryStockReportData)));

            OtherSaleMaterialData = OtherSaleMaterialData?.ToMaterialData(reportUpdateData.OtherSaleMaterialReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.OtherSaleMaterialReportData)));
            OtherDistributionMaterialData = OtherDistributionMaterialData?.ToMaterialData(reportUpdateData.OtherDistributionMaterialReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.OtherDistributionMaterialReportData)));
            OtherLibraryStockData = OtherLibraryStockData?.ToLibraryStockData(reportUpdateData.OtherLibraryStockReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.OtherLibraryStockReportData)));


            VhsSaleMaterialData = VhsSaleMaterialData?.ToMaterialData(reportUpdateData.VhsSaleMaterialReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.VhsSaleMaterialReportData)));
            VhsDistributionMaterialData = VhsDistributionMaterialData?.ToMaterialData(reportUpdateData.VhsDistributionMaterialReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.VhsDistributionMaterialReportData)));
            VhsLibraryStockData = VhsLibraryStockData?.ToLibraryStockData(reportUpdateData.VhsLibraryStockReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.VhsLibraryStockReportData)));
            EmailDistributionMaterialData = EmailDistributionMaterialData?.ToMaterialData(reportUpdateData.EmailDistributionMaterialReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.EmailDistributionMaterialReportData)));
            IpdcLeafletDistributionMaterialData = IpdcLeafletDistributionMaterialData?.ToMaterialData(reportUpdateData.IpdcLeafletDistributionMaterialReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.IpdcLeafletDistributionMaterialReportData)));


            BaitulMalFinanceData = BaitulMalFinanceData?.ToFinanceData(reportUpdateData.BaitulMalFinanceReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.BaitulMalFinanceReportData)));
            ADayMasjidProjectFinanceData = ADayMasjidProjectFinanceData?.ToFinanceData(reportUpdateData.ADayMasjidProjectFinanceReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.ADayMasjidProjectFinanceReportData)));
            MasjidTableBankFinanceData = MasjidTableBankFinanceData?.ToFinanceData(reportUpdateData.MasjidTableBankFinanceReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.MasjidTableBankFinanceReportData)));

            QardeHasanaSocialWelfareData = QardeHasanaSocialWelfareData?.ToSocialWelfareData(reportUpdateData.QardeHasanaSocialWelfareReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.QardeHasanaSocialWelfareReportData)));
            PatientVisitSocialWelfareData = PatientVisitSocialWelfareData?.ToSocialWelfareData(reportUpdateData.PatientVisitSocialWelfareReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.PatientVisitSocialWelfareReportData)));
            SocialVisitSocialWelfareData = SocialVisitSocialWelfareData?.ToSocialWelfareData(reportUpdateData.SocialVisitSocialWelfareReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.SocialVisitSocialWelfareReportData)));
            TransportSocialWelfareData = TransportSocialWelfareData?.ToSocialWelfareData(reportUpdateData.TransportSocialWelfareReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.TransportSocialWelfareReportData)));
            ShiftingSocialWelfareData = ShiftingSocialWelfareData?.ToSocialWelfareData(reportUpdateData.ShiftingSocialWelfareReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.ShiftingSocialWelfareReportData)));
            ShoppingSocialWelfareData = ShoppingSocialWelfareData?.ToSocialWelfareData(reportUpdateData.ShoppingSocialWelfareReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.ShoppingSocialWelfareReportData)));

            FoodDistributionSocialWelfareData = FoodDistributionSocialWelfareData?.ToSocialWelfareData(reportUpdateData.FoodDistributionSocialWelfareReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.FoodDistributionSocialWelfareReportData)));
            CleanUpAustraliaSocialWelfareData = CleanUpAustraliaSocialWelfareData?.ToSocialWelfareData(reportUpdateData.CleanUpAustraliaSocialWelfareReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.CleanUpAustraliaSocialWelfareReportData)));
            OtherSocialWelfareData = OtherSocialWelfareData?.ToSocialWelfareData(reportUpdateData.OtherSocialWelfareReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.OtherSocialWelfareReportData)));

            StudyCircleForAssociateMemberTeachingLearningProgramData = StudyCircleForAssociateMemberTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.StudyCircleForAssociateMemberTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.StudyCircleForAssociateMemberTeachingLearningProgramReportData)));
            HadithTeachingLearningProgramData = HadithTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.HadithTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.HadithTeachingLearningProgramReportData)));
            WeekendIslamicSchoolTeachingLearningProgramData = WeekendIslamicSchoolTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.WeekendIslamicSchoolTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.WeekendIslamicSchoolTeachingLearningProgramReportData)));
            MemorizingHadithTeachingLearningProgramData = MemorizingHadithTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.MemorizingHadithTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.MemorizingHadithTeachingLearningProgramReportData)));
            MemorizingDoaTeachingLearningProgramData = MemorizingDoaTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.MemorizingDoaTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.MemorizingDoaTeachingLearningProgramReportData)));

            OtherTeachingLearningProgramData = OtherTeachingLearningProgramData?.ToTeachingLearningProgramData(reportUpdateData.OtherTeachingLearningProgramReportData ?? throw new ArgumentNullException(nameof(reportUpdateData.OtherTeachingLearningProgramReportData)));

            Comment = reportUpdateData.Comment;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void UpdateGeneratedData(ReportData reportDataGenerated)
        {
            MemberMemberGeneratedData = reportDataGenerated.MemberMemberData ?? throw new ArgumentNullException(nameof(reportDataGenerated.MemberMemberData));
            AssociateMemberGeneratedData = reportDataGenerated.AssociateMemberData ?? throw new ArgumentNullException(nameof(reportDataGenerated.AssociateMemberData));
            PreliminaryMemberGeneratedData = reportDataGenerated.PreliminaryMemberData ?? throw new ArgumentNullException(nameof(reportDataGenerated.PreliminaryMemberData));
            SupporterMemberGeneratedData = reportDataGenerated.SupporterMemberData ?? throw new ArgumentNullException(nameof(reportDataGenerated.SupporterMemberData));

            WorkerMeetingProgramGeneratedData = reportDataGenerated.WorkerMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.WorkerMeetingProgramData));
            DawahMeetingProgramGeneratedData = reportDataGenerated.DawahMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.DawahMeetingProgramData));
            StateLeaderMeetingProgramGeneratedData = reportDataGenerated.StateLeaderMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.StateLeaderMeetingProgramData));
            StateOutingMeetingProgramGeneratedData = reportDataGenerated.StateOutingMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.StateOutingMeetingProgramData));
            IftarMeetingProgramGeneratedData = reportDataGenerated.IftarMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.IftarMeetingProgramData));
            LearningMeetingProgramGeneratedData = reportDataGenerated.LearningMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.LearningMeetingProgramData));
            SocialDawahMeetingProgramGeneratedData = reportDataGenerated.SocialDawahMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.SocialDawahMeetingProgramData));
            DawahGroupMeetingProgramGeneratedData = reportDataGenerated.DawahGroupMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.DawahGroupMeetingProgramData));
            NextGMeetingProgramGeneratedData = reportDataGenerated.NextGMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.NextGMeetingProgramData));


            CmsMeetingProgramGeneratedData = reportDataGenerated.CmsMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.CmsMeetingProgramData));
            SmMeetingProgramGeneratedData = reportDataGenerated.SmMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.SmMeetingProgramData));
            MemberMeetingProgramGeneratedData = reportDataGenerated.MemberMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.MemberMeetingProgramData));
            TafsirMeetingProgramGeneratedData = reportDataGenerated.TafsirMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.TafsirMeetingProgramData));
            UnitMeetingProgramGeneratedData = reportDataGenerated.UnitMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.UnitMeetingProgramData));
            FamilyVisitMeetingProgramGeneratedData = reportDataGenerated.FamilyVisitMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.FamilyVisitMeetingProgramData));
            EidReunionMeetingProgramGeneratedData = reportDataGenerated.EidReunionMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.EidReunionMeetingProgramData));
            BbqMeetingProgramGeneratedData = reportDataGenerated.BbqMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.BbqMeetingProgramData));
            GatheringMeetingProgramGeneratedData = reportDataGenerated.GatheringMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.GatheringMeetingProgramData));

            OtherMeetingProgramGeneratedData = reportDataGenerated.OtherMeetingProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.OtherMeetingProgramData));

            GroupStudyTeachingLearningProgramGeneratedData = reportDataGenerated.GroupStudyTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.GroupStudyTeachingLearningProgramData));
            StudyCircleTeachingLearningProgramGeneratedData = reportDataGenerated.StudyCircleTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.StudyCircleTeachingLearningProgramData));
            PracticeDarsTeachingLearningProgramGeneratedData = reportDataGenerated.PracticeDarsTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.PracticeDarsTeachingLearningProgramData));
            StateLearningCampTeachingLearningProgramGeneratedData = reportDataGenerated.StateLearningCampTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.StateLearningCampTeachingLearningProgramData));
            QuranStudyTeachingLearningProgramGeneratedData = reportDataGenerated.QuranStudyTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.QuranStudyTeachingLearningProgramData));
            QuranClassTeachingLearningProgramGeneratedData = reportDataGenerated.QuranClassTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.QuranClassTeachingLearningProgramData));
            MemorizingAyatTeachingLearningProgramGeneratedData = reportDataGenerated.MemorizingAyatTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.MemorizingAyatTeachingLearningProgramData));
            StateLearningSessionTeachingLearningProgramGeneratedData = reportDataGenerated.StateLearningSessionTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.StateLearningSessionTeachingLearningProgramData));
            StateQiyamulLailTeachingLearningProgramGeneratedData = reportDataGenerated.StateQiyamulLailTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.StateQiyamulLailTeachingLearningProgramData));

            BookSaleMaterialGeneratedData = reportDataGenerated.BookSaleMaterialData ?? throw new ArgumentNullException(nameof(reportDataGenerated.BookSaleMaterialData));
            BookDistributionMaterialGeneratedData = reportDataGenerated.BookDistributionMaterialData ?? throw new ArgumentNullException(nameof(reportDataGenerated.BookDistributionMaterialData));
            BookLibraryStockGeneratedData = reportDataGenerated.BookLibraryStockData ?? throw new ArgumentNullException(nameof(reportDataGenerated.BookLibraryStockData));

            OtherSaleMaterialGeneratedData = reportDataGenerated.OtherSaleMaterialData ?? throw new ArgumentNullException(nameof(reportDataGenerated.OtherSaleMaterialData));
            OtherDistributionMaterialGeneratedData = reportDataGenerated.OtherDistributionMaterialData ?? throw new ArgumentNullException(nameof(reportDataGenerated.OtherDistributionMaterialData));
            OtherLibraryStockGeneratedData = reportDataGenerated.OtherLibraryStockData ?? throw new ArgumentNullException(nameof(reportDataGenerated.OtherLibraryStockData));

            VhsSaleMaterialGeneratedData = reportDataGenerated.VhsSaleMaterialData ?? throw new ArgumentNullException(nameof(reportDataGenerated.VhsSaleMaterialData));
            VhsDistributionMaterialGeneratedData = reportDataGenerated.VhsDistributionMaterialData ?? throw new ArgumentNullException(nameof(reportDataGenerated.VhsDistributionMaterialData));
            VhsLibraryStockGeneratedData = reportDataGenerated.VhsLibraryStockData ?? throw new ArgumentNullException(nameof(reportDataGenerated.VhsLibraryStockData));
            EmailDistributionMaterialGeneratedData = reportDataGenerated.EmailDistributionMaterialData ?? throw new ArgumentNullException(nameof(reportDataGenerated.EmailDistributionMaterialData));
            IpdcLeafletDistributionMaterialGeneratedData = reportDataGenerated.IpdcLeafletDistributionMaterialData ?? throw new ArgumentNullException(nameof(reportDataGenerated.IpdcLeafletDistributionMaterialData));

            BaitulMalFinanceGeneratedData = reportDataGenerated.BaitulMalFinanceData ?? throw new ArgumentNullException(nameof(reportDataGenerated.BaitulMalFinanceData));
            ADayMasjidProjectFinanceGeneratedData = reportDataGenerated.ADayMasjidProjectFinanceData ?? throw new ArgumentNullException(nameof(reportDataGenerated.ADayMasjidProjectFinanceData));
            MasjidTableBankFinanceGeneratedData = reportDataGenerated.MasjidTableBankFinanceData ?? throw new ArgumentNullException(nameof(reportDataGenerated.MasjidTableBankFinanceData));


            QardeHasanaSocialWelfareGeneratedData = reportDataGenerated.QardeHasanaSocialWelfareData ?? throw new ArgumentNullException(nameof(reportDataGenerated.QardeHasanaSocialWelfareData));
            PatientVisitSocialWelfareGeneratedData = reportDataGenerated.PatientVisitSocialWelfareData ?? throw new ArgumentNullException(nameof(reportDataGenerated.PatientVisitSocialWelfareData));
            SocialVisitSocialWelfareGeneratedData = reportDataGenerated.SocialVisitSocialWelfareData ?? throw new ArgumentNullException(nameof(reportDataGenerated.SocialVisitSocialWelfareData));
            TransportSocialWelfareGeneratedData = reportDataGenerated.TransportSocialWelfareData ?? throw new ArgumentNullException(nameof(reportDataGenerated.TransportSocialWelfareData));
            ShiftingSocialWelfareGeneratedData = reportDataGenerated.ShiftingSocialWelfareData ?? throw new ArgumentNullException(nameof(reportDataGenerated.ShiftingSocialWelfareData));
            ShoppingSocialWelfareGeneratedData = reportDataGenerated.ShoppingSocialWelfareData ?? throw new ArgumentNullException(nameof(reportDataGenerated.ShoppingSocialWelfareData));

            FoodDistributionSocialWelfareGeneratedData = reportDataGenerated.FoodDistributionSocialWelfareData ?? throw new ArgumentNullException(nameof(reportDataGenerated.FoodDistributionSocialWelfareData));
            CleanUpAustraliaSocialWelfareGeneratedData = reportDataGenerated.CleanUpAustraliaSocialWelfareData ?? throw new ArgumentNullException(nameof(reportDataGenerated.CleanUpAustraliaSocialWelfareData));
            OtherSocialWelfareGeneratedData = reportDataGenerated.OtherSocialWelfareData ?? throw new ArgumentNullException(nameof(reportDataGenerated.OtherSocialWelfareData));

            StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData = reportDataGenerated.StudyCircleForAssociateMemberTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.StudyCircleForAssociateMemberTeachingLearningProgramData));
            HadithTeachingLearningProgramGeneratedData = reportDataGenerated.HadithTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.HadithTeachingLearningProgramData));
            WeekendIslamicSchoolTeachingLearningProgramGeneratedData = reportDataGenerated.WeekendIslamicSchoolTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.WeekendIslamicSchoolTeachingLearningProgramData));
            MemorizingHadithTeachingLearningProgramGeneratedData = reportDataGenerated.MemorizingHadithTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.MemorizingHadithTeachingLearningProgramData));
            MemorizingDoaTeachingLearningProgramGeneratedData = reportDataGenerated.MemorizingDoaTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.MemorizingDoaTeachingLearningProgramData));

            OtherTeachingLearningProgramGeneratedData = reportDataGenerated.OtherTeachingLearningProgramData ?? throw new ArgumentNullException(nameof(reportDataGenerated.OtherTeachingLearningProgramData));


            Timestamp = ZaphodTime.UtcNow;
        }

        public void Update(ReportLastPeriodUpdateData reportLastPeriodUpdateData)
        {
            AssociateMemberData = AssociateMemberData?.ToMemberData(reportLastPeriodUpdateData.AssociateMemberReportData ?? throw new ArgumentNullException(nameof(reportLastPeriodUpdateData.AssociateMemberReportData)));
            PreliminaryMemberData = PreliminaryMemberData?.ToMemberData(reportLastPeriodUpdateData.PreliminaryMemberReportData ?? throw new ArgumentNullException(nameof(reportLastPeriodUpdateData.PreliminaryMemberReportData)));
            SupporterMemberData = SupporterMemberData?.ToMemberData(reportLastPeriodUpdateData.SupporterMemberReportData ?? throw new ArgumentNullException(nameof(reportLastPeriodUpdateData.SupporterMemberReportData)));
            MemberMemberData = MemberMemberData?.ToMemberData(reportLastPeriodUpdateData.MemberMemberReportData ?? throw new ArgumentNullException(nameof(reportLastPeriodUpdateData.MemberMemberReportData)));

            BaitulMalFinanceData = BaitulMalFinanceData?.ToFinanceData(reportLastPeriodUpdateData.BaitulMalFinanceReportData ?? throw new ArgumentNullException(nameof(reportLastPeriodUpdateData.BaitulMalFinanceReportData)));
            ADayMasjidProjectFinanceData = ADayMasjidProjectFinanceData?.ToFinanceData(reportLastPeriodUpdateData.ADayMasjidProjectFinanceReportData ?? throw new ArgumentNullException(nameof(reportLastPeriodUpdateData.ADayMasjidProjectFinanceReportData)));
            MasjidTableBankFinanceData = MasjidTableBankFinanceData?.ToFinanceData(reportLastPeriodUpdateData.MasjidTableBankFinanceReportData ?? throw new ArgumentNullException(nameof(reportLastPeriodUpdateData.MasjidTableBankFinanceReportData)));

            BookLibraryStockData = BookLibraryStockData?.ToLibraryStockData(reportLastPeriodUpdateData.BookLibraryStockReportData ?? throw new ArgumentNullException(nameof(reportLastPeriodUpdateData.BookLibraryStockReportData)));
            VhsLibraryStockData = VhsLibraryStockData?.ToLibraryStockData(reportLastPeriodUpdateData.VhsLibraryStockReportData ?? throw new ArgumentNullException(nameof(reportLastPeriodUpdateData.VhsLibraryStockReportData)));
            OtherLibraryStockData = OtherLibraryStockData?.ToLibraryStockData(reportLastPeriodUpdateData.OtherLibraryStockReportData ?? throw new ArgumentNullException(nameof(reportLastPeriodUpdateData.OtherLibraryStockReportData)));

            Timestamp = ZaphodTime.UtcNow;
        }


        public static implicit operator EntityReference(StateReport report)
        {
            return new EntityReference(report.Id, report.Description);
        }

        public static implicit operator ReportData(StateReport report)
        {
            return new ReportData(report.MemberMemberData,
                report.AssociateMemberData,
                report.PreliminaryMemberData,
                report.SupporterMemberData,

                report.WorkerMeetingProgramData,
                report.DawahMeetingProgramData,
                report.StateLeaderMeetingProgramData,
                report.StateOutingMeetingProgramData,
                report.IftarMeetingProgramData,
                report.LearningMeetingProgramData,
                report.SocialDawahMeetingProgramData,
                report.DawahGroupMeetingProgramData,
                report.NextGMeetingProgramData,

                cmsMeetingProgramData: report.CmsMeetingProgramData,
                smMeetingProgramData: report.SmMeetingProgramData,
                memberMeetingProgramData: report.MemberMeetingProgramData,
                tafsirMeetingProgramData: report.TafsirMeetingProgramData,
                unitMeetingProgramData: report.UnitMeetingProgramData,
                familyVisitMeetingProgramData: report.FamilyVisitMeetingProgramData,
                eidReunionMeetingProgramData: report.EidReunionMeetingProgramData,
                bbqMeetingProgramData: report.BbqMeetingProgramData,
                gatheringMeetingProgramData: report.GatheringMeetingProgramData,
                otherMeetingProgramData: report.OtherMeetingProgramData,

                groupStudyTeachingLearningProgramData: report.GroupStudyTeachingLearningProgramData,
                studyCircleTeachingLearningProgramData: report.StudyCircleTeachingLearningProgramData,
                practiceDarsTeachingLearningProgramData: report.PracticeDarsTeachingLearningProgramData,
                stateLearningCampTeachingLearningProgramData: report.StateLearningCampTeachingLearningProgramData,
                quranStudyTeachingLearningProgramData: report.QuranStudyTeachingLearningProgramData,
                quranClassTeachingLearningProgramData: report.QuranClassTeachingLearningProgramData,
                memorizingAyatTeachingLearningProgramData: report.MemorizingAyatTeachingLearningProgramData,
                stateLearningSessionTeachingLearningProgramData: report.StateLearningSessionTeachingLearningProgramData,
                stateQiyamulLailTeachingLearningProgramData: report.StateQiyamulLailTeachingLearningProgramData,

                studyCircleForAssociateMemberTeachingLearningProgramData: report.StudyCircleForAssociateMemberTeachingLearningProgramData,
                hadithTeachingLearningProgramData: report.HadithTeachingLearningProgramData,
                weekendIslamicSchoolTeachingLearningProgramData: report.WeekendIslamicSchoolTeachingLearningProgramData,
                memorizingHadithTeachingLearningProgramData: report.MemorizingHadithTeachingLearningProgramData,
                memorizingDoaTeachingLearningProgramData: report.MemorizingDoaTeachingLearningProgramData,

                otherTeachingLearningProgramData: report.OtherTeachingLearningProgramData,


                bookSaleMaterialData: report.BookSaleMaterialData,
                bookDistributionMaterialData: report.BookDistributionMaterialData,
                bookLibraryStockData: report.BookLibraryStockData,

                otherSaleMaterialData: report.OtherSaleMaterialData,
                otherDistributionMaterialData: report.OtherDistributionMaterialData,
                otherLibraryStockData: report.OtherLibraryStockData,

                vhsSaleMaterialData: report.VhsSaleMaterialData,
                vhsDistributionMaterialData: report.VhsDistributionMaterialData,
                emailDistributionMaterialData: report.EmailDistributionMaterialData,
                ipdcLeafletDistributionMaterialData: report.IpdcLeafletDistributionMaterialData,



                vhsLibraryStockData: report.VhsLibraryStockData,

                baitulMalFinanceData: report.BaitulMalFinanceData,
                aDayMasjidProjectFinanceData: report.ADayMasjidProjectFinanceData,
                masjidTableBankFinanceData: report.MasjidTableBankFinanceData,

                qardeHasanaSocialWelfareData: report.QardeHasanaSocialWelfareData,
                patientVisitSocialWelfareData: report.PatientVisitSocialWelfareData,
                socialVisitSocialWelfareData: report.SocialVisitSocialWelfareData,
                transportSocialWelfareData: report.TransportSocialWelfareData,
                shiftingSocialWelfareData: report.ShiftingSocialWelfareData,
                shoppingSocialWelfareData: report.ShoppingSocialWelfareData,

                foodDistributionSocialWelfareData: report.FoodDistributionSocialWelfareData,
                cleanUpAustraliaSocialWelfareData: report.CleanUpAustraliaSocialWelfareData,
                otherSocialWelfareData: report.OtherSocialWelfareData,

                comment: report.Comment);
        }

        public static implicit operator ReportLastPeriodUpdateData(StateReport report)
        {
            return new ReportLastPeriodUpdateData(report.MemberMemberData,
                report.AssociateMemberData,
                report.PreliminaryMemberData,
                report.SupporterMemberData,

                report.BaitulMalFinanceData,
                report.ADayMasjidProjectFinanceData,
                report.MasjidTableBankFinanceData,

                report.BookLibraryStockData,
                report.VhsLibraryStockData,
                report.OtherLibraryStockData
            );
        }

    }
}