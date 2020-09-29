using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Builders
{
    public class ExcelReportDataBuilder
    {
        private MemberData _associateMemberData = new TestObjectBuilder<MemberData>().Build();

        public ExcelReportDataBuilder SetAssociateMemberData(MemberData associateMemberData)
        {
            _associateMemberData = associateMemberData;
            return this;
        }

        private MemberData _preliminaryMemberData = new TestObjectBuilder<MemberData>().Build();

        public ExcelReportDataBuilder SetPreliminaryMemberData(MemberData preliminaryMemberData)
        {
            _preliminaryMemberData = preliminaryMemberData;
            return this;
        }

        private MeetingProgramData _workerMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetWorkerMeetingProgramData(MeetingProgramData workerMeetingData)
        {
            _workerMeetingProgramData = workerMeetingData;
            return this;
        }

        private MemberData _supporterMemberData = new TestObjectBuilder<MemberData>().Build();
        public ExcelReportDataBuilder SetSupporterMemberData(MemberData supporterMemberData)
        {
            _supporterMemberData = supporterMemberData;
            return this;
        }

        private MeetingProgramData _dawahMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
        public ExcelReportDataBuilder SetDawahMeetingProgramData(MeetingProgramData dawahMeetingData)
        {
            _dawahMeetingProgramData = dawahMeetingData;
            return this;
        }

        private MeetingProgramData _stateLeaderMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetStateLeaderMeetingProgramData(MeetingProgramData stateLeaderMeetingData)
        {
            _stateLeaderMeetingProgramData = stateLeaderMeetingData;
            return this;
        }


        private MeetingProgramData _stateOutingMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetStateOutingMeetingProgramData(MeetingProgramData stateOutingMeetingData)
        {
            _stateOutingMeetingProgramData = stateOutingMeetingData;
            return this;
        }

        private MeetingProgramData _iftarMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetIftarMeetingProgramData(MeetingProgramData iftarMeetingData)
        {
            _iftarMeetingProgramData = iftarMeetingData;
            return this;
        }


        private MeetingProgramData _learningMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
        public ExcelReportDataBuilder SetLearningMeetingProgramData(MeetingProgramData learningMeetingData)
        {
            _learningMeetingProgramData = learningMeetingData;
            return this;
        }

        private MeetingProgramData _socialDawahMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
        public ExcelReportDataBuilder SetSocialDawahMeetingProgramData(MeetingProgramData socialDawahMeetingData)
        {
            _socialDawahMeetingProgramData = socialDawahMeetingData;
            return this;
        }

        private MeetingProgramData _dawahGroupMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
        public ExcelReportDataBuilder SetDawahGroupMeetingProgramData(MeetingProgramData dawahGroupMeetingData)
        {
            _dawahGroupMeetingProgramData = dawahGroupMeetingData;
            return this;
        }

        private MeetingProgramData _nextGMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
        public ExcelReportDataBuilder SetNextGMeetingProgramData(MeetingProgramData nextGMeetingData)
        {
            _nextGMeetingProgramData = nextGMeetingData;
            return this;
        }


        private MeetingProgramData _cmsMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetCmsMeetingProgramData(MeetingProgramData cmsMeetingData)
        {
            _cmsMeetingProgramData = cmsMeetingData;
            return this;
        }
        private MeetingProgramData _smMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetSmMeetingProgramData(MeetingProgramData smMeetingData)
        {
            _smMeetingProgramData = smMeetingData;
            return this;
        }
        private MeetingProgramData _memberMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetMemberMeetingProgramData(MeetingProgramData memberMeetingData)
        {
            _memberMeetingProgramData = memberMeetingData;
            return this;
        }
        private MeetingProgramData _tafsirMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetTafsirMeetingProgramData(MeetingProgramData tafsirMeetingData)
        {
            _tafsirMeetingProgramData = tafsirMeetingData;
            return this;
        }
        private MeetingProgramData _unitMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetUnitMeetingProgramData(MeetingProgramData unitMeetingData)
        {
            _unitMeetingProgramData = unitMeetingData;
            return this;
        }
        private MeetingProgramData _familyVisitMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetFamilyVisitMeetingProgramData(MeetingProgramData familyVisitMeetingData)
        {
            _familyVisitMeetingProgramData = familyVisitMeetingData;
            return this;
        }
        private MeetingProgramData _eidReunionMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetEidReunionMeetingProgramData(MeetingProgramData eidReunionMeetingData)
        {
            _eidReunionMeetingProgramData = eidReunionMeetingData;
            return this;
        }
        private MeetingProgramData _bbqMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetBbqMeetingProgramData(MeetingProgramData bbqMeetingData)
        {
            _bbqMeetingProgramData = bbqMeetingData;
            return this;
        }
        private MeetingProgramData _gatheringMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetGatheringMeetingProgramData(MeetingProgramData gatheringMeetingData)
        {
            _gatheringMeetingProgramData = gatheringMeetingData;
            return this;
        }


        private MeetingProgramData _otherMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ExcelReportDataBuilder SetOtherMeetingProgramData(MeetingProgramData otherMeetingData)
        {
            _otherMeetingProgramData = otherMeetingData;
            return this;
        }

        private MemberData _memberMemberData = new TestObjectBuilder<MemberData>().Build();

        public ExcelReportDataBuilder SetMemberMemberData(MemberData memberMemberData)
        {
            _memberMemberData = memberMemberData;
            return this;
        }


        private FinanceData _baitulMalFinanceData = new FinanceDataBuilder().Build();
        public ExcelReportDataBuilder SetBaitulMalFinanceData(FinanceData baitulMalFinanceData)
        {
            _baitulMalFinanceData = baitulMalFinanceData;
            return this;
        }

        private FinanceData _aDayMasjidProjectFinanceData = new FinanceDataBuilder().Build();
        public ExcelReportDataBuilder SetADayMasjidProjectFinanceData(FinanceData aDayMasjidProjectFinanceData)
        {
            _aDayMasjidProjectFinanceData = aDayMasjidProjectFinanceData;
            return this;
        }

        private FinanceData _masjidTableBankFinanceData = new FinanceDataBuilder().Build();
        public ExcelReportDataBuilder SetMasjidTableBankFinanceData(FinanceData masjidTableBankFinanceData)
        {
            _masjidTableBankFinanceData = masjidTableBankFinanceData;
            return this;
        }

        private SocialWelfareData _qardeHasanaSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ExcelReportDataBuilder SetQardeHasanaSocialWelfareData(SocialWelfareData qardeHasanaSocialWelfareData)
        {
            _qardeHasanaSocialWelfareData = qardeHasanaSocialWelfareData;
            return this;
        }

        private SocialWelfareData _patientVisitSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ExcelReportDataBuilder SetPatientVisitSocialWelfareData(SocialWelfareData patientVisitSocialWelfareData)
        {
            _patientVisitSocialWelfareData = patientVisitSocialWelfareData;
            return this;
        }

        private SocialWelfareData _socialVisitSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ExcelReportDataBuilder SetSocialVisitSocialWelfareData(SocialWelfareData socialVisitSocialWelfareData)
        {
            _socialVisitSocialWelfareData = socialVisitSocialWelfareData;
            return this;
        }

        private SocialWelfareData _transportSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ExcelReportDataBuilder SetTransportSocialWelfareData(SocialWelfareData transportSocialWelfareData)
        {
            _transportSocialWelfareData = transportSocialWelfareData;
            return this;
        }

        private SocialWelfareData _shiftingSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ExcelReportDataBuilder SetShiftingSocialWelfareData(SocialWelfareData shiftingSocialWelfareData)
        {
            _shiftingSocialWelfareData = shiftingSocialWelfareData;
            return this;
        }

        private SocialWelfareData _shoppingSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ExcelReportDataBuilder SetShoppingSocialWelfareData(SocialWelfareData shoppingSocialWelfareData)
        {
            _shoppingSocialWelfareData = shoppingSocialWelfareData;
            return this;
        }

        private SocialWelfareData _foodDistributionSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ExcelReportDataBuilder SetFoodDistributionSocialWelfareData(SocialWelfareData foodDistributionSocialWelfareData)
        {
            _foodDistributionSocialWelfareData = foodDistributionSocialWelfareData;
            return this;
        }

        private SocialWelfareData _cleanUpAustraliaSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ExcelReportDataBuilder SetCleanUpAustraliaSocialWelfareData(SocialWelfareData cleanUpAustraliaSocialWelfareData)
        {
            _cleanUpAustraliaSocialWelfareData = cleanUpAustraliaSocialWelfareData;
            return this;
        }

        private SocialWelfareData _otherSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ExcelReportDataBuilder SetOtherSocialWelfareData(SocialWelfareData otherSocialWelfareData)
        {
            _otherSocialWelfareData = otherSocialWelfareData;
            return this;
        }

        private MaterialData _bookSaleMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ExcelReportDataBuilder SetBookSaleMaterialData(MaterialData bookSaleMaterialData)
        {
            _bookSaleMaterialData = bookSaleMaterialData;
            return this;
        }

        private MaterialData _bookDistributionMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ExcelReportDataBuilder SetBookDistributionMaterialData(MaterialData bookDistributionMaterialData)
        {
            _bookDistributionMaterialData = bookDistributionMaterialData;
            return this;
        }

        private LibraryStockData _bookLibraryStockData = new TestObjectBuilder<LibraryStockData>().Build();
        public ExcelReportDataBuilder SetBookLibraryStockData(LibraryStockData bookLibraryStockData)
        {
            _bookLibraryStockData = bookLibraryStockData;
            return this;
        }

        private MaterialData _otherSaleMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ExcelReportDataBuilder SetOtherSaleMaterialData(MaterialData otherSaleMaterialData)
        {
            _otherSaleMaterialData = otherSaleMaterialData;
            return this;
        }

        private MaterialData _otherDistributionMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ExcelReportDataBuilder SetOtherDistributionMaterialData(MaterialData otherDistributionMaterialData)
        {
            _otherDistributionMaterialData = otherDistributionMaterialData;
            return this;
        }

        private LibraryStockData _otherLibraryStockData = new TestObjectBuilder<LibraryStockData>().Build();
        public ExcelReportDataBuilder SetOtherLibraryStockData(LibraryStockData otherLibraryStockData)
        {
            _otherLibraryStockData = otherLibraryStockData;
            return this;
        }

        private MaterialData _vhsSaleMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ExcelReportDataBuilder SetVhsSaleMaterialData(MaterialData vhsSaleMaterialData)
        {
            _vhsSaleMaterialData = vhsSaleMaterialData;
            return this;
        }

        private MaterialData _vhsDistributionMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ExcelReportDataBuilder SetVhsDistributionMaterialData(MaterialData vhsDistributionMaterialData)
        {
            _vhsDistributionMaterialData = vhsDistributionMaterialData;
            return this;
        }

        private LibraryStockData _vhsLibraryStockData = new TestObjectBuilder<LibraryStockData>().Build();
        public ExcelReportDataBuilder SetVhsLibraryStockData(LibraryStockData vhsLibraryStockData)
        {
            _vhsLibraryStockData = vhsLibraryStockData;
            return this;
        }

        private MaterialData _emailDistributionMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ExcelReportDataBuilder SetEmailDistributionMaterialData(MaterialData emailDistributionMaterialData)
        {
            _emailDistributionMaterialData = emailDistributionMaterialData;
            return this;
        }

        private MaterialData _ipdcLeafletDistributionMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ExcelReportDataBuilder SetIpdcLeafletDistributionMaterialData(MaterialData ipdcLeafletDistributionMaterialData)
        {
            _ipdcLeafletDistributionMaterialData = ipdcLeafletDistributionMaterialData;
            return this;
        }





        private TeachingLearningProgramData _groupStudyTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetGroupStudyTeachingLearningProgramData(TeachingLearningProgramData groupStudyTeachingLearningProgramData)
        {
            _groupStudyTeachingLearningProgramData = groupStudyTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _studyCircleTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetStudyCircleTeachingLearningProgramData(TeachingLearningProgramData studyCircleTeachingLearningProgramData)
        {
            _studyCircleTeachingLearningProgramData = studyCircleTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _practiceDarsTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetPracticeDarsTeachingLearningProgramData(TeachingLearningProgramData practiceDarsTeachingLearningProgramData)
        {
            _practiceDarsTeachingLearningProgramData = practiceDarsTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _stateLearningCampTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetStateLearningCampTeachingLearningProgramData(TeachingLearningProgramData stateLearningCampTeachingLearningProgramData)
        {
            _stateLearningCampTeachingLearningProgramData = stateLearningCampTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _quranStudyTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetQuranStudyTeachingLearningProgramData(TeachingLearningProgramData quranStudyTeachingLearningProgramData)
        {
            _quranStudyTeachingLearningProgramData = quranStudyTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _quranClassTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetQuranClassTeachingLearningProgramData(TeachingLearningProgramData quranClassTeachingLearningProgramData)
        {
            _quranClassTeachingLearningProgramData = quranClassTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _memorizingAyatTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetMemorizingAyatTeachingLearningProgramData(TeachingLearningProgramData memorizingAyatTeachingLearningProgramData)
        {
            _memorizingAyatTeachingLearningProgramData = memorizingAyatTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _stateLearningSessionTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetStateLearningSessionTeachingLearningProgramData(TeachingLearningProgramData stateLearningSessionTeachingLearningProgramData)
        {
            _stateLearningSessionTeachingLearningProgramData = stateLearningSessionTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _stateQiyamulLailTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetStateQiyamulLailTeachingLearningProgramData(TeachingLearningProgramData stateQiyamulLailTeachingLearningProgramData)
        {
            _stateQiyamulLailTeachingLearningProgramData = stateQiyamulLailTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _studyCircleForAssociateMemberTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetStudyCircleForAssociateMemberTeachingLearningProgramData(TeachingLearningProgramData studyCircleForAssociateMemberTeachingLearningProgramData)
        {
            _studyCircleForAssociateMemberTeachingLearningProgramData = studyCircleForAssociateMemberTeachingLearningProgramData;
            return this;
        }
        private TeachingLearningProgramData _hadithTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetHadithTeachingLearningProgramData(TeachingLearningProgramData hadithTeachingLearningProgramData)
        {
            _hadithTeachingLearningProgramData = hadithTeachingLearningProgramData;
            return this;
        }
        private TeachingLearningProgramData _weekendIslamicSchoolTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetWeekendIslamicSchoolTeachingLearningProgramData(TeachingLearningProgramData weekendIslamicSchoolTeachingLearningProgramData)
        {
            _weekendIslamicSchoolTeachingLearningProgramData = weekendIslamicSchoolTeachingLearningProgramData;
            return this;
        }
        private TeachingLearningProgramData _memorizingHadithTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetMemorizingHadithTeachingLearningProgramData(TeachingLearningProgramData memorizingHadithTeachingLearningProgramData)
        {
            _memorizingHadithTeachingLearningProgramData = memorizingHadithTeachingLearningProgramData;
            return this;
        }
        private TeachingLearningProgramData _memorizingDoaTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetMemorizingDoaTeachingLearningProgramData(TeachingLearningProgramData memorizingDoaTeachingLearningProgramData)
        {
            _memorizingDoaTeachingLearningProgramData = memorizingDoaTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _otherTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ExcelReportDataBuilder SetOtherTeachingLearningProgramData(TeachingLearningProgramData otherTeachingLearningProgramData)
        {
            _otherTeachingLearningProgramData = otherTeachingLearningProgramData;
            return this;
        }

        private string _comment = DataProvider.Get<string>();
        public ExcelReportDataBuilder SetComment(string comment)
        {
            _comment = comment;
            return this;
        }

        public ExcelReportData Build()
        {
            var reportData = new ExcelReportData()
            {
                MemberMemberData = _memberMemberData,
                AssociateMemberData = _associateMemberData,
                PreliminaryMemberData = _preliminaryMemberData,
                WorkerMeetingProgramData = _workerMeetingProgramData,
                SupporterMemberData = _supporterMemberData,
                DawahMeetingProgramData = _dawahMeetingProgramData,
                StateLeaderMeetingProgramData = _stateLeaderMeetingProgramData,
                StateOutingMeetingProgramData = _stateOutingMeetingProgramData,
                IftarMeetingProgramData = _iftarMeetingProgramData,
                LearningMeetingProgramData = _learningMeetingProgramData,
                SocialDawahMeetingProgramData = _socialDawahMeetingProgramData,
                DawahGroupMeetingProgramData = _dawahGroupMeetingProgramData,
                NextGMeetingProgramData = _nextGMeetingProgramData,

                CmsMeetingProgramData = _cmsMeetingProgramData,
                SmMeetingProgramData = _smMeetingProgramData,
                MemberMeetingProgramData = _memberMeetingProgramData,
                TafsirMeetingProgramData = _tafsirMeetingProgramData,
                UnitMeetingProgramData = _unitMeetingProgramData,
                FamilyVisitMeetingProgramData = _familyVisitMeetingProgramData,
                EidReunionMeetingProgramData = _eidReunionMeetingProgramData,
                BbqMeetingProgramData = _bbqMeetingProgramData,
                GatheringMeetingProgramData = _gatheringMeetingProgramData,
                OtherMeetingProgramData = _otherMeetingProgramData,

                BaitulMalFinanceData = _baitulMalFinanceData,
                ADayMasjidProjectFinanceData = _aDayMasjidProjectFinanceData,
                MasjidTableBankFinanceData = _masjidTableBankFinanceData,
                QardeHasanaSocialWelfareData = _qardeHasanaSocialWelfareData,
                PatientVisitSocialWelfareData = _patientVisitSocialWelfareData,
                SocialVisitSocialWelfareData = _socialVisitSocialWelfareData,
                TransportSocialWelfareData = _transportSocialWelfareData,
                ShiftingSocialWelfareData = _shiftingSocialWelfareData,
                ShoppingSocialWelfareData = _shoppingSocialWelfareData,
                FoodDistributionSocialWelfareData = _foodDistributionSocialWelfareData,
                CleanUpAustraliaSocialWelfareData = _cleanUpAustraliaSocialWelfareData,
                OtherSocialWelfareData = _otherSocialWelfareData,
                BookSaleMaterialData = _bookSaleMaterialData,
                BookDistributionMaterialData = _bookDistributionMaterialData,
                BookLibraryStockData = _bookLibraryStockData,
                OtherSaleMaterialData = _otherSaleMaterialData,
                OtherDistributionMaterialData = _otherDistributionMaterialData,
                OtherLibraryStockData = _otherLibraryStockData,
                VhsSaleMaterialData = _vhsSaleMaterialData,
                VhsDistributionMaterialData = _vhsDistributionMaterialData,
                VhsLibraryStockData = _vhsLibraryStockData,
                EmailDistributionMaterialData = _emailDistributionMaterialData,
                IpdcLeafletDistributionMaterialData = _ipdcLeafletDistributionMaterialData,
                GroupStudyTeachingLearningProgramData = _groupStudyTeachingLearningProgramData,
                StudyCircleTeachingLearningProgramData = _studyCircleTeachingLearningProgramData,
                PracticeDarsTeachingLearningProgramData = _practiceDarsTeachingLearningProgramData,
                StateLearningCampTeachingLearningProgramData =
                _stateLearningCampTeachingLearningProgramData,
                QuranStudyTeachingLearningProgramData = _quranStudyTeachingLearningProgramData,
                QuranClassTeachingLearningProgramData = _quranClassTeachingLearningProgramData,
                MemorizingAyatTeachingLearningProgramData =
                _memorizingAyatTeachingLearningProgramData,
                StateLearningSessionTeachingLearningProgramData =
                _stateLearningSessionTeachingLearningProgramData,
                StateQiyamulLailTeachingLearningProgramData =
                _stateQiyamulLailTeachingLearningProgramData,
                StudyCircleForAssociateMemberTeachingLearningProgramData =
                _studyCircleForAssociateMemberTeachingLearningProgramData,
                HadithTeachingLearningProgramData = _hadithTeachingLearningProgramData,
                WeekendIslamicSchoolTeachingLearningProgramData =
                _weekendIslamicSchoolTeachingLearningProgramData,
                MemorizingHadithTeachingLearningProgramData =
                _memorizingHadithTeachingLearningProgramData,
                MemorizingDoaTeachingLearningProgramData = _memorizingDoaTeachingLearningProgramData,
                OtherTeachingLearningProgramData = _otherTeachingLearningProgramData,

                Comment = _comment,
            };
            return reportData;
        }
    }
}