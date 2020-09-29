namespace ReportingModule.ValueObjects
{
    public class ReportUpdateData
    {
        public ReportUpdateData(MemberReportData memberMemberReportData = null,
            MemberReportData associateMemberReportData = null,
            MemberReportData preliminaryMemberReportData = null,
            MemberReportData supporterMemberReportData = null,

            MeetingProgramReportData workerMeetingProgramReportData = null,
            MeetingProgramReportData dawahMeetingProgramReportData = null,
            MeetingProgramReportData stateLeaderMeetingProgramReportData = null,
            MeetingProgramReportData stateOutingMeetingProgramReportData = null,
            MeetingProgramReportData iftarMeetingProgramReportData = null,
            MeetingProgramReportData learningMeetingProgramReportData = null,
            MeetingProgramReportData socialDawahMeetingProgramReportData = null,
            MeetingProgramReportData dawahGroupMeetingProgramReportData = null,
            MeetingProgramReportData nextGMeetingProgramReportData = null,

            MeetingProgramReportData cmsMeetingProgramReportData = null,
            MeetingProgramReportData smMeetingProgramReportData = null,
            MeetingProgramReportData memberMeetingProgramReportData = null,
            MeetingProgramReportData tafsirMeetingProgramReportData = null,
            MeetingProgramReportData unitMeetingProgramReportData = null,
            MeetingProgramReportData familyVisitMeetingProgramReportData = null,
            MeetingProgramReportData eidReunionMeetingProgramReportData = null,
            MeetingProgramReportData bbqMeetingProgramReportData = null,
            MeetingProgramReportData gatheringMeetingProgramReportData = null,
            MeetingProgramReportData otherMeetingProgramReportData = null,

            FinanceReportData baitulMalFinanceReportData = null,
            FinanceReportData aDayMasjidProjectFinanceReportData = null,
            FinanceReportData masjidTableBankFinanceReportData = null,

            SocialWelfareReportData qardeHasanaSocialWelfareReportData = null,
            SocialWelfareReportData patientVisitSocialWelfareReportData = null,
            SocialWelfareReportData socialVisitSocialWelfareReportData = null,
            SocialWelfareReportData transportSocialWelfareReportData = null,
            SocialWelfareReportData shiftingSocialWelfareReportData = null,
            SocialWelfareReportData shoppingSocialWelfareReportData = null,

            SocialWelfareReportData foodDistributionSocialWelfareReportData = null,
            SocialWelfareReportData cleanUpAustraliaSocialWelfareReportData = null,
            SocialWelfareReportData otherSocialWelfareReportData = null,

            MaterialData bookSaleMaterialReportData = null,
            MaterialData bookDistributionMaterialReportData = null,
            LibraryStockData bookLibraryStockReportData = null,

            MaterialData otherSaleMaterialReportData = null,
            MaterialData otherDistributionMaterialReportData = null,
            LibraryStockData otherLibraryStockReportData = null,

            MaterialData vhsSaleMaterialReportData = null,
            MaterialData vhsDistributionMaterialReportData = null,
            LibraryStockData vhsLibraryStockReportData = null,

            MaterialData emailDistributionMaterialReportData = null,
            MaterialData ipdcLeafletDistributionMaterialReportData = null,
            
            
            TeachingLearningProgramData groupStudyTeachingLearningProgramReportData = null,
            TeachingLearningProgramData studyCircleTeachingLearningProgramReportData = null,
            TeachingLearningProgramData practiceDarsTeachingLearningProgramReportData = null,
            TeachingLearningProgramData stateLearningCampTeachingLearningProgramReportData = null,
            TeachingLearningProgramData quranStudyTeachingLearningProgramReportData = null,
            TeachingLearningProgramData quranClassTeachingLearningProgramReportData = null,
            TeachingLearningProgramData memorizingAyatTeachingLearningProgramReportData = null,
            TeachingLearningProgramData stateLearningSessionTeachingLearningProgramReportData = null,
            TeachingLearningProgramData stateQiyamulLailTeachingLearningProgramReportData = null,

            TeachingLearningProgramData studyCircleForAssociateMemberTeachingLearningProgramReportData = null,
            TeachingLearningProgramData hadithTeachingLearningProgramReportData = null,
            TeachingLearningProgramData weekendIslamicSchoolTeachingLearningProgramReportData = null,
            TeachingLearningProgramData memorizingHadithTeachingLearningProgramReportData = null,
            TeachingLearningProgramData memorizingDoaTeachingLearningProgramReportData = null,
            TeachingLearningProgramData otherTeachingLearningProgramReportData = null,
            string comment = null)
        {
            AssociateMemberReportData = associateMemberReportData ?? MemberData.Default();
            PreliminaryMemberReportData = preliminaryMemberReportData ?? MemberData.Default();
            SupporterMemberReportData = supporterMemberReportData ?? MemberData.Default();
            WorkerMeetingProgramReportData = workerMeetingProgramReportData ?? MeetingProgramData.Default();
            DawahMeetingProgramReportData = dawahMeetingProgramReportData ?? MeetingProgramData.Default();
            StateLeaderMeetingProgramReportData = stateLeaderMeetingProgramReportData ?? MeetingProgramData.Default();
            StateOutingMeetingProgramReportData = stateOutingMeetingProgramReportData ?? MeetingProgramData.Default();
            IftarMeetingProgramReportData = iftarMeetingProgramReportData ?? MeetingProgramData.Default();
            LearningMeetingProgramReportData = learningMeetingProgramReportData ?? MeetingProgramData.Default();
            SocialDawahMeetingProgramReportData = socialDawahMeetingProgramReportData ?? MeetingProgramData.Default();
            DawahGroupMeetingProgramReportData = dawahGroupMeetingProgramReportData ?? MeetingProgramData.Default();
            NextGMeetingProgramReportData = nextGMeetingProgramReportData ?? MeetingProgramData.Default();


            CMSMeetingProgramReportData = cmsMeetingProgramReportData ?? MeetingProgramData.Default();
            SMMeetingProgramReportData = smMeetingProgramReportData ?? MeetingProgramData.Default();
            MemberMeetingProgramReportData = memberMeetingProgramReportData ?? MeetingProgramData.Default();
            TafsirMeetingProgramReportData = tafsirMeetingProgramReportData ?? MeetingProgramData.Default();
            UnitMeetingProgramReportData = unitMeetingProgramReportData ?? MeetingProgramData.Default();
            FamilyVisitMeetingProgramReportData = familyVisitMeetingProgramReportData ?? MeetingProgramData.Default();
            EidReunionMeetingProgramReportData = eidReunionMeetingProgramReportData ?? MeetingProgramData.Default();
            BBQMeetingProgramReportData = bbqMeetingProgramReportData ?? MeetingProgramData.Default();
            GatheringMeetingProgramReportData = gatheringMeetingProgramReportData ?? MeetingProgramData.Default();

            OtherMeetingProgramReportData = otherMeetingProgramReportData ?? MeetingProgramData.Default();

            MemberMemberReportData = memberMemberReportData ?? MemberData.Default();

            BaitulMalFinanceReportData = baitulMalFinanceReportData ?? FinanceData.Default();
            ADayMasjidProjectFinanceReportData = aDayMasjidProjectFinanceReportData ?? FinanceData.Default();
            MasjidTableBankFinanceReportData = masjidTableBankFinanceReportData ?? FinanceData.Default();

            QardeHasanaSocialWelfareReportData = qardeHasanaSocialWelfareReportData ?? SocialWelfareData.Default();
            PatientVisitSocialWelfareReportData = patientVisitSocialWelfareReportData ?? SocialWelfareData.Default();
            SocialVisitSocialWelfareReportData = socialVisitSocialWelfareReportData ?? SocialWelfareData.Default();
            TransportSocialWelfareReportData = transportSocialWelfareReportData ?? SocialWelfareData.Default();
            ShiftingSocialWelfareReportData = shiftingSocialWelfareReportData ?? SocialWelfareData.Default();
            ShoppingSocialWelfareReportData = shoppingSocialWelfareReportData ?? SocialWelfareData.Default();

            FoodDistributionSocialWelfareReportData = foodDistributionSocialWelfareReportData ?? SocialWelfareData.Default();
            CleanUpAustraliaSocialWelfareReportData = cleanUpAustraliaSocialWelfareReportData ?? SocialWelfareData.Default();
            OtherSocialWelfareReportData = otherSocialWelfareReportData ?? SocialWelfareData.Default();

            BookSaleMaterialReportData = bookSaleMaterialReportData ?? MaterialData.Default();
            BookDistributionMaterialReportData = bookDistributionMaterialReportData ?? MaterialData.Default();
            BookLibraryStockReportData = bookLibraryStockReportData ?? LibraryStockData.Default();
            OtherSaleMaterialReportData = otherSaleMaterialReportData ?? MaterialData.Default();
            OtherDistributionMaterialReportData = otherDistributionMaterialReportData ?? MaterialData.Default();
            OtherLibraryStockReportData = otherLibraryStockReportData ?? LibraryStockData.Default();
            VhsSaleMaterialReportData = vhsSaleMaterialReportData ?? MaterialData.Default();
            VhsDistributionMaterialReportData = vhsDistributionMaterialReportData ?? MaterialData.Default();
            VhsLibraryStockReportData = vhsLibraryStockReportData ?? LibraryStockData.Default();
            EmailDistributionMaterialReportData = emailDistributionMaterialReportData ?? MaterialData.Default();
            IpdcLeafletDistributionMaterialReportData = ipdcLeafletDistributionMaterialReportData ?? MaterialData.Default();
            GroupStudyTeachingLearningProgramReportData = groupStudyTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            StudyCircleTeachingLearningProgramReportData = studyCircleTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            PracticeDarsTeachingLearningProgramReportData = practiceDarsTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            StateLearningCampTeachingLearningProgramReportData = stateLearningCampTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            QuranStudyTeachingLearningProgramReportData = quranStudyTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            QuranClassTeachingLearningProgramReportData = quranClassTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            MemorizingAyatTeachingLearningProgramReportData = memorizingAyatTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            StateLearningSessionTeachingLearningProgramReportData = stateLearningSessionTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            StateQiyamulLailTeachingLearningProgramReportData = stateQiyamulLailTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();

            StudyCircleForAssociateMemberTeachingLearningProgramReportData = studyCircleForAssociateMemberTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            HadithTeachingLearningProgramReportData = hadithTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            WeekendIslamicSchoolTeachingLearningProgramReportData = weekendIslamicSchoolTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            MemorizingHadithTeachingLearningProgramReportData = memorizingHadithTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            MemorizingDoaTeachingLearningProgramReportData = memorizingDoaTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            OtherTeachingLearningProgramReportData = otherTeachingLearningProgramReportData ?? TeachingLearningProgramData.Default();
            Comment = comment;
        }
        public MemberReportData AssociateMemberReportData { get; private set; }
        public MemberReportData PreliminaryMemberReportData { get; private set; }
        public MemberReportData SupporterMemberReportData { get; private set; }
        public MeetingProgramReportData WorkerMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData DawahMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData StateLeaderMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData StateOutingMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData IftarMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData LearningMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData SocialDawahMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData DawahGroupMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData NextGMeetingProgramReportData { get; private set; }

        public MeetingProgramReportData CMSMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData SMMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData MemberMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData TafsirMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData UnitMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData FamilyVisitMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData EidReunionMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData BBQMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData GatheringMeetingProgramReportData { get; private set; }
        public MeetingProgramReportData OtherMeetingProgramReportData { get; private set; }

        public MemberReportData MemberMemberReportData { get; private set; }

        public FinanceReportData BaitulMalFinanceReportData { get; private set; }
        public FinanceReportData ADayMasjidProjectFinanceReportData { get; private set; }
        public FinanceReportData MasjidTableBankFinanceReportData { get; private set; }

        public SocialWelfareReportData QardeHasanaSocialWelfareReportData { get; private set; }
        public SocialWelfareReportData PatientVisitSocialWelfareReportData { get; private set; }
        public SocialWelfareReportData SocialVisitSocialWelfareReportData { get; private set; }
        public SocialWelfareReportData TransportSocialWelfareReportData { get; private set; }
        public SocialWelfareReportData ShiftingSocialWelfareReportData { get; private set; }
        public SocialWelfareReportData ShoppingSocialWelfareReportData { get; private set; }

        public SocialWelfareReportData FoodDistributionSocialWelfareReportData { get; private set; }
        public SocialWelfareReportData CleanUpAustraliaSocialWelfareReportData { get; private set; }
        public SocialWelfareReportData OtherSocialWelfareReportData { get; private set; }

        public MaterialReportData BookSaleMaterialReportData { get; private set; }
        public MaterialReportData BookDistributionMaterialReportData { get; private set; }
        public LibraryStockReportData BookLibraryStockReportData { get; private set; }

        public MaterialReportData OtherSaleMaterialReportData { get; private set; }
        public MaterialReportData OtherDistributionMaterialReportData { get; private set; }
        public LibraryStockReportData OtherLibraryStockReportData { get; private set; }

        public MaterialReportData VhsSaleMaterialReportData { get; private set; }
        public MaterialReportData VhsDistributionMaterialReportData { get; private set; }
        public LibraryStockReportData VhsLibraryStockReportData { get; private set; }
        public MaterialReportData EmailDistributionMaterialReportData { get; private set; }
        public MaterialReportData IpdcLeafletDistributionMaterialReportData { get; private set; }

        
        

        public TeachingLearningProgramReportData GroupStudyTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData StudyCircleTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData PracticeDarsTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData StateLearningCampTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData QuranStudyTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData QuranClassTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData MemorizingAyatTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData StateLearningSessionTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData StateQiyamulLailTeachingLearningProgramReportData { get; private set; }

        public TeachingLearningProgramReportData StudyCircleForAssociateMemberTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData HadithTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData WeekendIslamicSchoolTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData MemorizingHadithTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData MemorizingDoaTeachingLearningProgramReportData { get; private set; }
        public TeachingLearningProgramReportData OtherTeachingLearningProgramReportData { get; private set; }
        public string Comment { get; private set; }
    }
}