namespace ReportingModule.ValueObjects
{
    public class PlanData
    {
        public PlanData(MemberPlanData memberMemberPlanData = null,
            MemberPlanData associateMemberPlanData = null,
            MemberPlanData preliminaryMemberPlanData = null,
            MemberPlanData supporterMemberPlanData = null,
            MeetingProgramPlanData workerMeetingProgramPlanData = null,
            MeetingProgramPlanData dawahMeetingProgramPlanData = null,
            MeetingProgramPlanData stateLeaderMeetingProgramPlanData = null,
            MeetingProgramPlanData stateOutingMeetingProgramPlanData = null,
            MeetingProgramPlanData iftarMeetingProgramPlanData = null,
            MeetingProgramPlanData learningMeetingProgramPlanData = null,
            MeetingProgramPlanData socialDawahMeetingProgramPlanData = null,
            MeetingProgramPlanData dawahGroupMeetingProgramPlanData = null,
            MeetingProgramPlanData nextGMeetingProgramPlanData = null,

            MeetingProgramPlanData cmsMeetingProgramPlanData = null,
            MeetingProgramPlanData smMeetingProgramPlanData = null,
            MeetingProgramPlanData memberMeetingProgramPlanData = null,
            MeetingProgramPlanData tafsirMeetingProgramPlanData = null,
            MeetingProgramPlanData unitMeetingProgramPlanData = null,
            MeetingProgramPlanData familyVisitMeetingProgramPlanData = null,
            MeetingProgramPlanData eidReunionMeetingProgramPlanData = null,
            MeetingProgramPlanData bbqMeetingProgramPlanData = null,
            MeetingProgramPlanData gatheringMeetingProgramPlanData = null,
            MeetingProgramPlanData otherMeetingProgramPlanData = null,

            FinancePlanData baitulMalFinancePlanData = null,
            FinancePlanData aDayMasjidProjectFinancePlanData = null,
            FinancePlanData masjidTableBankFinancePlanData = null,
            SocialWelfarePlanData qardeHasanaSocialWelfarePlanData = null,
            SocialWelfarePlanData patientVisitSocialWelfarePlanData = null,
            SocialWelfarePlanData socialVisitSocialWelfarePlanData = null,
            SocialWelfarePlanData transportSocialWelfarePlanData = null,
            SocialWelfarePlanData shiftingSocialWelfarePlanData = null,
            SocialWelfarePlanData shoppingSocialWelfarePlanData = null,

            SocialWelfarePlanData foodDistributionSocialWelfarePlanData = null,
            SocialWelfarePlanData cleanUpAustraliaSocialWelfarePlanData = null,
            SocialWelfarePlanData otherSocialWelfarePlanData = null,

            MaterialPlanData bookSaleMaterialPlanData = null,
            MaterialPlanData bookDistributionMaterialPlanData = null,
            LibraryStockPlanData bookLibraryStockPlanData = null,

            MaterialPlanData otherSaleMaterialPlanData = null,
            MaterialPlanData otherDistributionMaterialPlanData = null,
            LibraryStockPlanData otherLibraryStockPlanData = null,

            MaterialPlanData vhsSaleMaterialPlanData = null,
            MaterialPlanData vhsDistributionMaterialPlanData = null,
            LibraryStockPlanData vhsLibraryStockPlanData = null,

            MaterialPlanData emailDistributionMaterialPlanData = null,
            MaterialPlanData ipdcLeafletDistributionMaterialPlanData = null,
            
            
            TeachingLearningProgramPlanData groupStudyTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData studyCircleTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData practiceDarsTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData stateLearningCampTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData quranStudyTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData quranClassTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData memorizingAyatTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData stateLearningSessionTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData stateQiyamulLailTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData studyCircleForAssociateMemberTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData hadithTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData weekendIslamicSchoolTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData memorizingHadithTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData memorizingDoaTeachingLearningProgramPlanData = null,
            TeachingLearningProgramPlanData otherTeachingLearningProgramPlanData = null)
        {
            AssociateMemberPlanData = associateMemberPlanData ?? MemberData.Default();
            PreliminaryMemberPlanData = preliminaryMemberPlanData ?? MemberData.Default();
            SupporterMemberPlanData = supporterMemberPlanData ?? MemberData.Default();
            WorkerMeetingProgramPlanData = workerMeetingProgramPlanData ?? MeetingProgramData.Default();
            DawahMeetingProgramPlanData = dawahMeetingProgramPlanData ?? MeetingProgramData.Default();
            StateLeaderMeetingProgramPlanData = stateLeaderMeetingProgramPlanData ?? MeetingProgramData.Default();
            StateOutingMeetingProgramPlanData = stateOutingMeetingProgramPlanData ?? MeetingProgramData.Default();
            IftarMeetingProgramPlanData = iftarMeetingProgramPlanData ?? MeetingProgramData.Default();
            LearningMeetingProgramPlanData = learningMeetingProgramPlanData ?? MeetingProgramData.Default();
            SocialDawahMeetingProgramPlanData = socialDawahMeetingProgramPlanData ?? MeetingProgramData.Default();
            DawahGroupMeetingProgramPlanData = dawahGroupMeetingProgramPlanData ?? MeetingProgramData.Default();
            NextGMeetingProgramPlanData = nextGMeetingProgramPlanData ?? MeetingProgramData.Default();

            CmsMeetingProgramPlanData = cmsMeetingProgramPlanData ?? MeetingProgramData.Default();
            SmMeetingProgramPlanData = smMeetingProgramPlanData ?? MeetingProgramData.Default();
            MemberMeetingProgramPlanData = memberMeetingProgramPlanData ?? MeetingProgramData.Default();
            TafsirMeetingProgramPlanData = tafsirMeetingProgramPlanData ?? MeetingProgramData.Default();
            UnitMeetingProgramPlanData = unitMeetingProgramPlanData ?? MeetingProgramData.Default();
            FamilyVisitMeetingProgramPlanData = familyVisitMeetingProgramPlanData ?? MeetingProgramData.Default();
            EidReunionMeetingProgramPlanData = eidReunionMeetingProgramPlanData ?? MeetingProgramData.Default();
            BbqMeetingProgramPlanData = bbqMeetingProgramPlanData ?? MeetingProgramData.Default();
            GatheringMeetingProgramPlanData = gatheringMeetingProgramPlanData ?? MeetingProgramData.Default();
            OtherMeetingProgramPlanData = otherMeetingProgramPlanData ?? MeetingProgramData.Default();


            MemberMemberPlanData = memberMemberPlanData ?? MemberData.Default();

            BaitulMalFinancePlanData = baitulMalFinancePlanData ?? FinanceData.Default();
            ADayMasjidProjectFinancePlanData = aDayMasjidProjectFinancePlanData ?? FinanceData.Default();
            MasjidTableBankFinancePlanData = masjidTableBankFinancePlanData ?? FinanceData.Default();

            QardeHasanaSocialWelfarePlanData = qardeHasanaSocialWelfarePlanData ?? SocialWelfareData.Default();
            PatientVisitSocialWelfarePlanData = patientVisitSocialWelfarePlanData ?? SocialWelfareData.Default();
            SocialVisitSocialWelfarePlanData = socialVisitSocialWelfarePlanData ?? SocialWelfareData.Default();
            TransportSocialWelfarePlanData = transportSocialWelfarePlanData ?? SocialWelfareData.Default();
            ShiftingSocialWelfarePlanData = shiftingSocialWelfarePlanData ?? SocialWelfareData.Default();
            ShoppingSocialWelfarePlanData = shoppingSocialWelfarePlanData ?? SocialWelfareData.Default();
            FoodDistributionSocialWelfarePlanData = foodDistributionSocialWelfarePlanData ?? SocialWelfareData.Default();
            CleanUpAustraliaSocialWelfarePlanData = cleanUpAustraliaSocialWelfarePlanData ?? SocialWelfareData.Default();
            OtherSocialWelfarePlanData = otherSocialWelfarePlanData ?? SocialWelfareData.Default();

            BookSaleMaterialPlanData = bookSaleMaterialPlanData ?? MaterialData.Default();
            BookDistributionMaterialPlanData = bookDistributionMaterialPlanData ?? MaterialData.Default();
            BookLibraryStockPlanData = bookLibraryStockPlanData ?? LibraryStockData.Default();

            OtherSaleMaterialPlanData = otherSaleMaterialPlanData ?? MaterialData.Default();
            OtherDistributionMaterialPlanData = otherDistributionMaterialPlanData ?? MaterialData.Default();
            OtherLibraryStockPlanData = otherLibraryStockPlanData ?? LibraryStockData.Default();

            VhsSaleMaterialPlanData = vhsSaleMaterialPlanData ?? MaterialData.Default();
            VhsDistributionMaterialPlanData = vhsDistributionMaterialPlanData ?? MaterialData.Default();
            VhsLibraryStockPlanData = vhsLibraryStockPlanData ?? LibraryStockData.Default();
            EmailDistributionMaterialPlanData = emailDistributionMaterialPlanData ?? MaterialData.Default();
            IpdcLeafletDistributionMaterialPlanData = ipdcLeafletDistributionMaterialPlanData ?? MaterialData.Default();
            
            

            GroupStudyTeachingLearningProgramPlanData = groupStudyTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            StudyCircleTeachingLearningProgramPlanData = studyCircleTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            PracticeDarsTeachingLearningProgramPlanData = practiceDarsTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            StateLearningCampTeachingLearningProgramPlanData = stateLearningCampTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            QuranStudyTeachingLearningProgramPlanData = quranStudyTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            QuranClassTeachingLearningProgramPlanData = quranClassTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            MemorizingAyatTeachingLearningProgramPlanData = memorizingAyatTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            StateLearningSessionTeachingLearningProgramPlanData = stateLearningSessionTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            StateQiyamulLailTeachingLearningProgramPlanData = stateQiyamulLailTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();

            StudyCircleForAssociateMemberTeachingLearningProgramPlanData = studyCircleForAssociateMemberTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            HadithTeachingLearningProgramPlanData = hadithTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            WeekendIslamicSchoolTeachingLearningProgramPlanData = weekendIslamicSchoolTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            MemorizingHadithTeachingLearningProgramPlanData = memorizingHadithTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            MemorizingDoaTeachingLearningProgramPlanData = memorizingDoaTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();
            OtherTeachingLearningProgramPlanData = otherTeachingLearningProgramPlanData ?? TeachingLearningProgramData.Default();

        }
        public MemberPlanData AssociateMemberPlanData { get; private set; }
        public MemberPlanData PreliminaryMemberPlanData { get; private set; }
        public MemberPlanData SupporterMemberPlanData { get; private set; }
        public MeetingProgramPlanData WorkerMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData DawahMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData StateLeaderMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData StateOutingMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData IftarMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData LearningMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData SocialDawahMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData DawahGroupMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData NextGMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData CmsMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData SmMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData MemberMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData TafsirMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData UnitMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData FamilyVisitMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData EidReunionMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData BbqMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData GatheringMeetingProgramPlanData { get; private set; }
        public MeetingProgramPlanData OtherMeetingProgramPlanData { get; private set; }

        public MemberPlanData MemberMemberPlanData { get; private set; }

        public FinancePlanData BaitulMalFinancePlanData { get; private set; }
        public FinancePlanData ADayMasjidProjectFinancePlanData { get; private set; }
        public FinancePlanData MasjidTableBankFinancePlanData { get; private set; }

        public SocialWelfarePlanData QardeHasanaSocialWelfarePlanData { get; private set; }
        public SocialWelfarePlanData PatientVisitSocialWelfarePlanData { get; private set; }
        public SocialWelfarePlanData SocialVisitSocialWelfarePlanData { get; private set; }

        public SocialWelfarePlanData TransportSocialWelfarePlanData { get; private set; }
        public SocialWelfarePlanData ShiftingSocialWelfarePlanData { get; private set; }
        public SocialWelfarePlanData ShoppingSocialWelfarePlanData { get; private set; }

        public SocialWelfarePlanData FoodDistributionSocialWelfarePlanData { get; private set; }
        public SocialWelfarePlanData CleanUpAustraliaSocialWelfarePlanData { get; private set; }
        public SocialWelfarePlanData OtherSocialWelfarePlanData { get; private set; } 

        public MaterialPlanData BookSaleMaterialPlanData { get; private set; }
        public MaterialPlanData BookDistributionMaterialPlanData { get; private set; }
        public LibraryStockPlanData BookLibraryStockPlanData { get; private set; }

        public MaterialPlanData OtherSaleMaterialPlanData { get; private set; }
        public MaterialPlanData OtherDistributionMaterialPlanData { get; private set; }
        public LibraryStockPlanData OtherLibraryStockPlanData { get; private set; }

        public MaterialPlanData VhsSaleMaterialPlanData { get; private set; }
        public MaterialPlanData VhsDistributionMaterialPlanData { get; private set; }
        public LibraryStockPlanData VhsLibraryStockPlanData { get; private set; }
        public MaterialPlanData EmailDistributionMaterialPlanData { get; private set; }
        public MaterialPlanData IpdcLeafletDistributionMaterialPlanData { get; private set; }
        
        public TeachingLearningProgramPlanData GroupStudyTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData StudyCircleTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData PracticeDarsTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData StateLearningCampTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData QuranStudyTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData QuranClassTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData MemorizingAyatTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData StateLearningSessionTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData StateQiyamulLailTeachingLearningProgramPlanData { get; private set; }

        public TeachingLearningProgramPlanData StudyCircleForAssociateMemberTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData HadithTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData WeekendIslamicSchoolTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData MemorizingHadithTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData MemorizingDoaTeachingLearningProgramPlanData { get; private set; }
        public TeachingLearningProgramPlanData OtherTeachingLearningProgramPlanData { get; private set; }

    }
}