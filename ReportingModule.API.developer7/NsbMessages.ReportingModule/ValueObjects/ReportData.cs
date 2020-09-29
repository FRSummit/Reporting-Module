
namespace ReportingModule.ValueObjects
{
    public class ReportData
    {
        public ReportData(MemberData memberMemberData = null,
            MemberData associateMemberData = null,
            MemberData preliminaryMemberData = null,
            MemberData supporterMemberData = null,

            MeetingProgramData workerMeetingProgramData = null,
            MeetingProgramData dawahMeetingProgramData = null,
            MeetingProgramData stateLeaderMeetingProgramData = null,
            MeetingProgramData stateOutingMeetingProgramData = null,
            MeetingProgramData iftarMeetingProgramData = null,
            MeetingProgramData learningMeetingProgramData = null,
            MeetingProgramData socialDawahMeetingProgramData = null,
            MeetingProgramData dawahGroupMeetingProgramData = null,
            MeetingProgramData nextGMeetingProgramData = null,

            MeetingProgramData cmsMeetingProgramData = null,
            MeetingProgramData smMeetingProgramData = null,
            MeetingProgramData memberMeetingProgramData = null,
            MeetingProgramData tafsirMeetingProgramData = null,
            MeetingProgramData unitMeetingProgramData = null,
            MeetingProgramData familyVisitMeetingProgramData = null,
            MeetingProgramData eidReunionMeetingProgramData = null,
            MeetingProgramData bbqMeetingProgramData = null,
            MeetingProgramData gatheringMeetingProgramData = null,

            MeetingProgramData otherMeetingProgramData = null,

            FinanceData baitulMalFinanceData = null,
            FinanceData aDayMasjidProjectFinanceData = null,
            FinanceData masjidTableBankFinanceData = null,

            SocialWelfareData qardeHasanaSocialWelfareData = null,
            SocialWelfareData patientVisitSocialWelfareData = null,
            SocialWelfareData socialVisitSocialWelfareData = null,
            SocialWelfareData transportSocialWelfareData = null,
            SocialWelfareData shiftingSocialWelfareData = null,
            SocialWelfareData shoppingSocialWelfareData = null,

            SocialWelfareData foodDistributionSocialWelfareData = null,
            SocialWelfareData cleanUpAustraliaSocialWelfareData = null,
            SocialWelfareData otherSocialWelfareData = null,

            MaterialData bookSaleMaterialData = null,
            MaterialData bookDistributionMaterialData = null,
            LibraryStockData bookLibraryStockData = null,

            MaterialData otherSaleMaterialData = null,
            MaterialData otherDistributionMaterialData = null,
            LibraryStockData otherLibraryStockData = null,

            MaterialData vhsSaleMaterialData = null,
            MaterialData vhsDistributionMaterialData = null,
            LibraryStockData vhsLibraryStockData = null,

            MaterialData emailDistributionMaterialData = null,
            MaterialData ipdcLeafletDistributionMaterialData = null,

            TeachingLearningProgramData groupStudyTeachingLearningProgramData = null,
            TeachingLearningProgramData studyCircleTeachingLearningProgramData = null,
            TeachingLearningProgramData practiceDarsTeachingLearningProgramData = null,
            TeachingLearningProgramData stateLearningCampTeachingLearningProgramData = null,
            TeachingLearningProgramData quranStudyTeachingLearningProgramData = null,
            TeachingLearningProgramData quranClassTeachingLearningProgramData = null,
            TeachingLearningProgramData memorizingAyatTeachingLearningProgramData = null,
            TeachingLearningProgramData stateLearningSessionTeachingLearningProgramData = null,
            TeachingLearningProgramData stateQiyamulLailTeachingLearningProgramData = null,
            TeachingLearningProgramData studyCircleForAssociateMemberTeachingLearningProgramData = null,
            TeachingLearningProgramData hadithTeachingLearningProgramData = null,
            TeachingLearningProgramData weekendIslamicSchoolTeachingLearningProgramData = null,
            TeachingLearningProgramData memorizingHadithTeachingLearningProgramData = null,
            TeachingLearningProgramData memorizingDoaTeachingLearningProgramData = null,
            TeachingLearningProgramData otherTeachingLearningProgramData = null,
            string comment = null)
        {
            AssociateMemberData = associateMemberData ?? MemberData.Default();
            PreliminaryMemberData = preliminaryMemberData ?? MemberData.Default();
            SupporterMemberData = supporterMemberData ?? MemberData.Default();
            WorkerMeetingProgramData = workerMeetingProgramData ?? MeetingProgramData.Default();
            DawahMeetingProgramData = dawahMeetingProgramData ?? MeetingProgramData.Default();
            StateLeaderMeetingProgramData = stateLeaderMeetingProgramData ?? MeetingProgramData.Default();
            StateOutingMeetingProgramData = stateOutingMeetingProgramData ?? MeetingProgramData.Default();
            IftarMeetingProgramData = iftarMeetingProgramData ?? MeetingProgramData.Default();
            LearningMeetingProgramData = learningMeetingProgramData ?? MeetingProgramData.Default();
            SocialDawahMeetingProgramData = socialDawahMeetingProgramData ?? MeetingProgramData.Default();
            DawahGroupMeetingProgramData = dawahGroupMeetingProgramData ?? MeetingProgramData.Default();
            NextGMeetingProgramData = nextGMeetingProgramData ?? MeetingProgramData.Default();

            CmsMeetingProgramData = cmsMeetingProgramData ?? MeetingProgramData.Default();
            SmMeetingProgramData = smMeetingProgramData ?? MeetingProgramData.Default();
            MemberMeetingProgramData = memberMeetingProgramData ?? MeetingProgramData.Default();
            TafsirMeetingProgramData = tafsirMeetingProgramData ?? MeetingProgramData.Default();
            UnitMeetingProgramData = unitMeetingProgramData ?? MeetingProgramData.Default();
            FamilyVisitMeetingProgramData = familyVisitMeetingProgramData ?? MeetingProgramData.Default();
            EidReunionMeetingProgramData = eidReunionMeetingProgramData ?? MeetingProgramData.Default();
            BbqMeetingProgramData = bbqMeetingProgramData ?? MeetingProgramData.Default();
            GatheringMeetingProgramData = gatheringMeetingProgramData ?? MeetingProgramData.Default();

            OtherMeetingProgramData = otherMeetingProgramData ?? MeetingProgramData.Default();

            MemberMemberData = memberMemberData ?? MemberData.Default();

            BaitulMalFinanceData = baitulMalFinanceData ?? FinanceData.Default();
            ADayMasjidProjectFinanceData = aDayMasjidProjectFinanceData ?? FinanceData.Default();
            MasjidTableBankFinanceData = masjidTableBankFinanceData ?? FinanceData.Default();

            QardeHasanaSocialWelfareData = qardeHasanaSocialWelfareData ?? SocialWelfareData.Default();
            PatientVisitSocialWelfareData = patientVisitSocialWelfareData ?? SocialWelfareData.Default();
            SocialVisitSocialWelfareData = socialVisitSocialWelfareData ?? SocialWelfareData.Default();
            TransportSocialWelfareData = transportSocialWelfareData ?? SocialWelfareData.Default();
            ShiftingSocialWelfareData = shiftingSocialWelfareData ?? SocialWelfareData.Default();
            ShoppingSocialWelfareData = shoppingSocialWelfareData ?? SocialWelfareData.Default();

            FoodDistributionSocialWelfareData = foodDistributionSocialWelfareData ?? SocialWelfareData.Default();
            CleanUpAustraliaSocialWelfareData = cleanUpAustraliaSocialWelfareData ?? SocialWelfareData.Default();
            OtherSocialWelfareData = otherSocialWelfareData ?? SocialWelfareData.Default();

            BookSaleMaterialData = bookSaleMaterialData ?? MaterialData.Default();
            BookDistributionMaterialData = bookDistributionMaterialData ?? MaterialData.Default();
            BookLibraryStockData = bookLibraryStockData ?? LibraryStockData.Default();

            OtherSaleMaterialData = otherSaleMaterialData ?? MaterialData.Default();
            OtherDistributionMaterialData = otherDistributionMaterialData ?? MaterialData.Default();
            OtherLibraryStockData = otherLibraryStockData ?? LibraryStockData.Default();

            VhsSaleMaterialData = vhsSaleMaterialData ?? MaterialData.Default();
            VhsDistributionMaterialData = vhsDistributionMaterialData ?? MaterialData.Default();
            VhsLibraryStockData = vhsLibraryStockData ?? LibraryStockData.Default();

            EmailDistributionMaterialData = emailDistributionMaterialData ?? MaterialData.Default();
            IpdcLeafletDistributionMaterialData = ipdcLeafletDistributionMaterialData ?? MaterialData.Default();



            GroupStudyTeachingLearningProgramData = groupStudyTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            StudyCircleTeachingLearningProgramData = studyCircleTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            PracticeDarsTeachingLearningProgramData = practiceDarsTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            StateLearningCampTeachingLearningProgramData = stateLearningCampTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            QuranStudyTeachingLearningProgramData = quranStudyTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            QuranClassTeachingLearningProgramData = quranClassTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            MemorizingAyatTeachingLearningProgramData = memorizingAyatTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            StateLearningSessionTeachingLearningProgramData = stateLearningSessionTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            StateQiyamulLailTeachingLearningProgramData = stateQiyamulLailTeachingLearningProgramData ?? TeachingLearningProgramData.Default();

            StudyCircleForAssociateMemberTeachingLearningProgramData = studyCircleForAssociateMemberTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            HadithTeachingLearningProgramData = hadithTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            WeekendIslamicSchoolTeachingLearningProgramData = weekendIslamicSchoolTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            MemorizingHadithTeachingLearningProgramData = memorizingHadithTeachingLearningProgramData ?? TeachingLearningProgramData.Default();
            MemorizingDoaTeachingLearningProgramData = memorizingDoaTeachingLearningProgramData ?? TeachingLearningProgramData.Default();

            OtherTeachingLearningProgramData = otherTeachingLearningProgramData ?? TeachingLearningProgramData.Default();

            Comment = comment;
        }
        public MemberData AssociateMemberData { get; private set; }
        public MemberData PreliminaryMemberData { get; private set; }
        public MemberData SupporterMemberData { get; private set; }
        public MeetingProgramData WorkerMeetingProgramData { get; private set; }
        public MeetingProgramData DawahMeetingProgramData { get; private set; }
        public MeetingProgramData StateLeaderMeetingProgramData { get; private set; }
        public MeetingProgramData StateOutingMeetingProgramData { get; private set; }
        public MeetingProgramData IftarMeetingProgramData { get; private set; }
        public MeetingProgramData LearningMeetingProgramData { get; private set; }
        public MeetingProgramData SocialDawahMeetingProgramData { get; private set; }
        public MeetingProgramData DawahGroupMeetingProgramData { get; private set; }
        public MeetingProgramData NextGMeetingProgramData { get; private set; }

        public MeetingProgramData CmsMeetingProgramData { get; private set; }
        public MeetingProgramData SmMeetingProgramData { get; private set; }
        public MeetingProgramData MemberMeetingProgramData { get; private set; }
        public MeetingProgramData TafsirMeetingProgramData { get; private set; }
        public MeetingProgramData UnitMeetingProgramData { get; private set; }
        public MeetingProgramData FamilyVisitMeetingProgramData { get; private set; }
        public MeetingProgramData EidReunionMeetingProgramData { get; private set; }
        public MeetingProgramData BbqMeetingProgramData { get; private set; }
        public MeetingProgramData GatheringMeetingProgramData { get; private set; }

        public MeetingProgramData OtherMeetingProgramData { get; private set; }

        public MemberData MemberMemberData { get; private set; }

        public FinanceData BaitulMalFinanceData { get; private set; }
        public FinanceData ADayMasjidProjectFinanceData { get; private set; }
        public FinanceData MasjidTableBankFinanceData { get; private set; }

        public SocialWelfareData QardeHasanaSocialWelfareData { get; private set; }
        public SocialWelfareData PatientVisitSocialWelfareData { get; private set; }
        public SocialWelfareData SocialVisitSocialWelfareData { get; private set; }

        public SocialWelfareData TransportSocialWelfareData { get; private set; }
        public SocialWelfareData ShiftingSocialWelfareData { get; private set; }
        public SocialWelfareData ShoppingSocialWelfareData { get; private set; }

        public SocialWelfareData FoodDistributionSocialWelfareData { get; private set; }
        public SocialWelfareData CleanUpAustraliaSocialWelfareData { get; private set; }
        public SocialWelfareData OtherSocialWelfareData { get; private set; }

        public MaterialData BookSaleMaterialData { get; private set; }
        public MaterialData BookDistributionMaterialData { get; private set; }
        public LibraryStockData BookLibraryStockData { get; private set; }

        public MaterialData OtherSaleMaterialData { get; private set; }
        public MaterialData OtherDistributionMaterialData { get; private set; }
        public LibraryStockData OtherLibraryStockData { get; private set; }

        public MaterialData VhsSaleMaterialData { get; private set; }
        public MaterialData VhsDistributionMaterialData { get; private set; }
        public LibraryStockData VhsLibraryStockData { get; private set; }

        public MaterialData EmailDistributionMaterialData { get; private set; }
        public MaterialData IpdcLeafletDistributionMaterialData { get; private set; }




        public TeachingLearningProgramData GroupStudyTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData StudyCircleTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData PracticeDarsTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData StateLearningCampTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData QuranStudyTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData QuranClassTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData MemorizingAyatTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData StateLearningSessionTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData StateQiyamulLailTeachingLearningProgramData { get; private set; }

        public TeachingLearningProgramData StudyCircleForAssociateMemberTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData HadithTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData WeekendIslamicSchoolTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData MemorizingHadithTeachingLearningProgramData { get; private set; }
        public TeachingLearningProgramData MemorizingDoaTeachingLearningProgramData { get; private set; }

        public TeachingLearningProgramData OtherTeachingLearningProgramData { get; private set; }

        public string Comment { get; private set; }

        public static ReportData Default() => new ReportData();

        public static implicit operator PlanData(ReportData reportData)
        {
            return new PlanData(memberMemberPlanData: reportData.MemberMemberData,
                associateMemberPlanData: reportData.AssociateMemberData,
                preliminaryMemberPlanData: reportData.PreliminaryMemberData,
                supporterMemberPlanData: reportData.SupporterMemberData,

                workerMeetingProgramPlanData: reportData.WorkerMeetingProgramData,
                dawahMeetingProgramPlanData: reportData.DawahMeetingProgramData,
                stateLeaderMeetingProgramPlanData: reportData.StateLeaderMeetingProgramData,
                stateOutingMeetingProgramPlanData: reportData.StateOutingMeetingProgramData,
                iftarMeetingProgramPlanData: reportData.IftarMeetingProgramData,
                learningMeetingProgramPlanData: reportData.LearningMeetingProgramData,
                socialDawahMeetingProgramPlanData: reportData.SocialDawahMeetingProgramData,
                dawahGroupMeetingProgramPlanData: reportData.DawahGroupMeetingProgramData,
                nextGMeetingProgramPlanData: reportData.NextGMeetingProgramData,

                cmsMeetingProgramPlanData: reportData.CmsMeetingProgramData,
                smMeetingProgramPlanData: reportData.SmMeetingProgramData,
                memberMeetingProgramPlanData: reportData.MemberMeetingProgramData,
                tafsirMeetingProgramPlanData: reportData.TafsirMeetingProgramData,
                unitMeetingProgramPlanData: reportData.UnitMeetingProgramData,
                familyVisitMeetingProgramPlanData: reportData.FamilyVisitMeetingProgramData,
                eidReunionMeetingProgramPlanData: reportData.EidReunionMeetingProgramData,
                bbqMeetingProgramPlanData: reportData.BbqMeetingProgramData,
                gatheringMeetingProgramPlanData: reportData.GatheringMeetingProgramData,
                otherMeetingProgramPlanData: reportData.OtherMeetingProgramData,

                baitulMalFinancePlanData: reportData.BaitulMalFinanceData,
                aDayMasjidProjectFinancePlanData: reportData.ADayMasjidProjectFinanceData,
                masjidTableBankFinancePlanData: reportData.MasjidTableBankFinanceData,

                qardeHasanaSocialWelfarePlanData: reportData.QardeHasanaSocialWelfareData,
                patientVisitSocialWelfarePlanData: reportData.PatientVisitSocialWelfareData,
                socialVisitSocialWelfarePlanData: reportData.SocialVisitSocialWelfareData,
                transportSocialWelfarePlanData: reportData.TransportSocialWelfareData,
                shiftingSocialWelfarePlanData: reportData.ShiftingSocialWelfareData,
                shoppingSocialWelfarePlanData: reportData.ShoppingSocialWelfareData,

                foodDistributionSocialWelfarePlanData: reportData.FoodDistributionSocialWelfareData,
                cleanUpAustraliaSocialWelfarePlanData: reportData.CleanUpAustraliaSocialWelfareData,
                otherSocialWelfarePlanData: reportData.OtherSocialWelfareData,

                bookSaleMaterialPlanData: reportData.BookSaleMaterialData,
                bookDistributionMaterialPlanData: reportData.BookDistributionMaterialData,
                bookLibraryStockPlanData: reportData.BookLibraryStockData,

                otherSaleMaterialPlanData: reportData.OtherSaleMaterialData,
                otherDistributionMaterialPlanData: reportData.OtherDistributionMaterialData,
                otherLibraryStockPlanData: reportData.OtherLibraryStockData,

                vhsSaleMaterialPlanData: reportData.VhsSaleMaterialData,
                vhsDistributionMaterialPlanData: reportData.VhsDistributionMaterialData,
                vhsLibraryStockPlanData: reportData.VhsLibraryStockData,
                emailDistributionMaterialPlanData: reportData.EmailDistributionMaterialData,
                ipdcLeafletDistributionMaterialPlanData: reportData.IpdcLeafletDistributionMaterialData,
                groupStudyTeachingLearningProgramPlanData: reportData.GroupStudyTeachingLearningProgramData,
                studyCircleTeachingLearningProgramPlanData: reportData.StudyCircleTeachingLearningProgramData,
                practiceDarsTeachingLearningProgramPlanData: reportData.PracticeDarsTeachingLearningProgramData,
                stateLearningCampTeachingLearningProgramPlanData: reportData.StateLearningCampTeachingLearningProgramData,
                quranStudyTeachingLearningProgramPlanData: reportData.QuranStudyTeachingLearningProgramData,
                quranClassTeachingLearningProgramPlanData: reportData.QuranClassTeachingLearningProgramData,
                memorizingAyatTeachingLearningProgramPlanData: reportData.MemorizingAyatTeachingLearningProgramData,
                stateLearningSessionTeachingLearningProgramPlanData: reportData.StateLearningSessionTeachingLearningProgramData,
                stateQiyamulLailTeachingLearningProgramPlanData: reportData.StateQiyamulLailTeachingLearningProgramData,
                studyCircleForAssociateMemberTeachingLearningProgramPlanData: reportData.StudyCircleForAssociateMemberTeachingLearningProgramData,
                hadithTeachingLearningProgramPlanData: reportData.HadithTeachingLearningProgramData,
                weekendIslamicSchoolTeachingLearningProgramPlanData: reportData.WeekendIslamicSchoolTeachingLearningProgramData,
                memorizingHadithTeachingLearningProgramPlanData: reportData.MemorizingHadithTeachingLearningProgramData,
                memorizingDoaTeachingLearningProgramPlanData: reportData.MemorizingDoaTeachingLearningProgramData,
                otherTeachingLearningProgramPlanData: reportData.OtherTeachingLearningProgramData);
        }

        public static implicit operator ReportUpdateData(ReportData reportData)
        {
            return new ReportUpdateData(memberMemberReportData: reportData.MemberMemberData,
                associateMemberReportData: reportData.AssociateMemberData,
                preliminaryMemberReportData: reportData.PreliminaryMemberData,
                supporterMemberReportData: reportData.SupporterMemberData,

                workerMeetingProgramReportData: reportData.WorkerMeetingProgramData,
                dawahMeetingProgramReportData: reportData.DawahMeetingProgramData,
                stateLeaderMeetingProgramReportData: reportData.StateLeaderMeetingProgramData,
                stateOutingMeetingProgramReportData: reportData.StateOutingMeetingProgramData,
                iftarMeetingProgramReportData: reportData.IftarMeetingProgramData,
                learningMeetingProgramReportData: reportData.LearningMeetingProgramData,
                socialDawahMeetingProgramReportData: reportData.SocialDawahMeetingProgramData,
                dawahGroupMeetingProgramReportData: reportData.DawahGroupMeetingProgramData,
                nextGMeetingProgramReportData: reportData.NextGMeetingProgramData,

                cmsMeetingProgramReportData: reportData.CmsMeetingProgramData,
                smMeetingProgramReportData: reportData.SmMeetingProgramData,
                memberMeetingProgramReportData: reportData.MemberMeetingProgramData,
                tafsirMeetingProgramReportData: reportData.TafsirMeetingProgramData,
                unitMeetingProgramReportData: reportData.UnitMeetingProgramData,
                familyVisitMeetingProgramReportData: reportData.FamilyVisitMeetingProgramData,
                eidReunionMeetingProgramReportData: reportData.EidReunionMeetingProgramData,
                bbqMeetingProgramReportData: reportData.BbqMeetingProgramData,
                gatheringMeetingProgramReportData: reportData.GatheringMeetingProgramData,
                otherMeetingProgramReportData: reportData.OtherMeetingProgramData,

                baitulMalFinanceReportData: reportData.BaitulMalFinanceData,
                aDayMasjidProjectFinanceReportData: reportData.ADayMasjidProjectFinanceData,
                masjidTableBankFinanceReportData: reportData.MasjidTableBankFinanceData,

                qardeHasanaSocialWelfareReportData: reportData.QardeHasanaSocialWelfareData,
                patientVisitSocialWelfareReportData: reportData.PatientVisitSocialWelfareData,
                socialVisitSocialWelfareReportData: reportData.SocialVisitSocialWelfareData,
                transportSocialWelfareReportData: reportData.TransportSocialWelfareData,
                shiftingSocialWelfareReportData: reportData.ShiftingSocialWelfareData,
                shoppingSocialWelfareReportData: reportData.ShoppingSocialWelfareData,

                foodDistributionSocialWelfareReportData: reportData.FoodDistributionSocialWelfareData,
                cleanUpAustraliaSocialWelfareReportData: reportData.CleanUpAustraliaSocialWelfareData,
                otherSocialWelfareReportData: reportData.OtherSocialWelfareData,

                bookSaleMaterialReportData: reportData.BookSaleMaterialData,
                bookDistributionMaterialReportData: reportData.BookDistributionMaterialData,
                bookLibraryStockReportData: reportData.BookLibraryStockData,

                otherSaleMaterialReportData: reportData.OtherSaleMaterialData,
                otherDistributionMaterialReportData: reportData.OtherDistributionMaterialData,
                otherLibraryStockReportData: reportData.OtherLibraryStockData,

                vhsSaleMaterialReportData: reportData.VhsSaleMaterialData,
                vhsDistributionMaterialReportData: reportData.VhsDistributionMaterialData,
                vhsLibraryStockReportData: reportData.VhsLibraryStockData,
                emailDistributionMaterialReportData: reportData.EmailDistributionMaterialData,
                ipdcLeafletDistributionMaterialReportData: reportData.IpdcLeafletDistributionMaterialData,
                groupStudyTeachingLearningProgramReportData: reportData.GroupStudyTeachingLearningProgramData,
                studyCircleTeachingLearningProgramReportData: reportData.StudyCircleTeachingLearningProgramData,
                practiceDarsTeachingLearningProgramReportData: reportData.PracticeDarsTeachingLearningProgramData,
                stateLearningCampTeachingLearningProgramReportData: reportData.StateLearningCampTeachingLearningProgramData,
                quranStudyTeachingLearningProgramReportData: reportData.QuranStudyTeachingLearningProgramData,
                quranClassTeachingLearningProgramReportData: reportData.QuranClassTeachingLearningProgramData,
                memorizingAyatTeachingLearningProgramReportData: reportData.MemorizingAyatTeachingLearningProgramData,
                stateLearningSessionTeachingLearningProgramReportData: reportData.StateLearningSessionTeachingLearningProgramData,
                stateQiyamulLailTeachingLearningProgramReportData: reportData.StateQiyamulLailTeachingLearningProgramData,
                studyCircleForAssociateMemberTeachingLearningProgramReportData: reportData.StudyCircleForAssociateMemberTeachingLearningProgramData,
                hadithTeachingLearningProgramReportData: reportData.HadithTeachingLearningProgramData,
                weekendIslamicSchoolTeachingLearningProgramReportData: reportData.WeekendIslamicSchoolTeachingLearningProgramData,
                memorizingHadithTeachingLearningProgramReportData: reportData.MemorizingHadithTeachingLearningProgramData,
                memorizingDoaTeachingLearningProgramReportData: reportData.MemorizingDoaTeachingLearningProgramData,
                otherTeachingLearningProgramReportData: reportData.OtherTeachingLearningProgramData,
                comment: reportData.Comment);
        }

    }
}