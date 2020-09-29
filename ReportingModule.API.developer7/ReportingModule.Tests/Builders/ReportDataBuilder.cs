using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Builders
{
    public class ReportDataBuilder
    {
        private MemberData _associateMemberData = new TestObjectBuilder<MemberData>().Build();

        public ReportDataBuilder SetAssociateMemberData(MemberData associateMemberData)
        {
            _associateMemberData = associateMemberData;
            return this;
        }

        private MemberData _preliminaryMemberData = new TestObjectBuilder<MemberData>().Build();

        public ReportDataBuilder SetPreliminaryMemberData(MemberData preliminaryMemberData)
        {
            _preliminaryMemberData = preliminaryMemberData;
            return this;
        }

        private MeetingProgramData _workerMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetWorkerMeetingProgramData(MeetingProgramData workerMeetingData)
        {
            _workerMeetingProgramData = workerMeetingData;
            return this;
        }

        private MemberData _supporterMemberData = new TestObjectBuilder<MemberData>().Build();
        public ReportDataBuilder SetSupporterMemberData(MemberData supporterMemberData)
        {
            _supporterMemberData = supporterMemberData;
            return this;
        }

        private MeetingProgramData _dawahMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
        public ReportDataBuilder SetDawahMeetingProgramData(MeetingProgramData dawahMeetingData)
        {
            _dawahMeetingProgramData = dawahMeetingData;
            return this;
        }

        private MeetingProgramData _stateLeaderMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetStateLeaderMeetingProgramData(MeetingProgramData stateLeaderMeetingData)
        {
            _stateLeaderMeetingProgramData = stateLeaderMeetingData;
            return this;
        }


        private MeetingProgramData _stateOutingMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetStateOutingMeetingProgramData(MeetingProgramData stateOutingMeetingData)
        {
            _stateOutingMeetingProgramData = stateOutingMeetingData;
            return this;
        }

        private MeetingProgramData _iftarMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetIftarMeetingProgramData(MeetingProgramData iftarMeetingData)
        {
            _iftarMeetingProgramData = iftarMeetingData;
            return this;
        }


        private MeetingProgramData _learningMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
        public ReportDataBuilder SetLearningMeetingProgramData(MeetingProgramData learningMeetingData)
        {
            _learningMeetingProgramData = learningMeetingData;
            return this;
        }

        private MeetingProgramData _socialDawahMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
        public ReportDataBuilder SetSocialDawahMeetingProgramData(MeetingProgramData socialDawahMeetingData)
        {
            _socialDawahMeetingProgramData = socialDawahMeetingData;
            return this;
        }

        private MeetingProgramData _dawahGroupMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
        public ReportDataBuilder SetDawahGroupMeetingProgramData(MeetingProgramData dawahGroupMeetingData)
        {
            _dawahGroupMeetingProgramData = dawahGroupMeetingData;
            return this;
        }

        private MeetingProgramData _nextGMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();
        public ReportDataBuilder SetNextGMeetingProgramData(MeetingProgramData nextGMeetingData)
        {
            _nextGMeetingProgramData = nextGMeetingData;
            return this;
        }


        private MeetingProgramData _cmsMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetCmsMeetingProgramData(MeetingProgramData cmsMeetingData)
        {
            _cmsMeetingProgramData = cmsMeetingData;
            return this;
        }
        private MeetingProgramData _smMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetSmMeetingProgramData(MeetingProgramData smMeetingData)
        {
            _smMeetingProgramData = smMeetingData;
            return this;
        }
        private MeetingProgramData _memberMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetMemberMeetingProgramData(MeetingProgramData memberMeetingData)
        {
            _memberMeetingProgramData = memberMeetingData;
            return this;
        }
        private MeetingProgramData _tafsirMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetTafsirMeetingProgramData(MeetingProgramData tafsirMeetingData)
        {
            _tafsirMeetingProgramData = tafsirMeetingData;
            return this;
        }
        private MeetingProgramData _unitMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetUnitMeetingProgramData(MeetingProgramData unitMeetingData)
        {
            _unitMeetingProgramData = unitMeetingData;
            return this;
        }
        private MeetingProgramData _familyVisitMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetFamilyVisitMeetingProgramData(MeetingProgramData familyVisitMeetingData)
        {
            _familyVisitMeetingProgramData = familyVisitMeetingData;
            return this;
        }
        private MeetingProgramData _eidReunionMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetEidReunionMeetingProgramData(MeetingProgramData eidReunionMeetingData)
        {
            _eidReunionMeetingProgramData = eidReunionMeetingData;
            return this;
        }
        private MeetingProgramData _bbqMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetBbqMeetingProgramData(MeetingProgramData bbqMeetingData)
        {
            _bbqMeetingProgramData = bbqMeetingData;
            return this;
        }
        private MeetingProgramData _gatheringMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetGatheringMeetingProgramData(MeetingProgramData gatheringMeetingData)
        {
            _gatheringMeetingProgramData = gatheringMeetingData;
            return this;
        }


        private MeetingProgramData _otherMeetingProgramData = new TestObjectBuilder<MeetingProgramData>().Build();

        public ReportDataBuilder SetOtherMeetingProgramData(MeetingProgramData otherMeetingData)
        {
            _otherMeetingProgramData = otherMeetingData;
            return this;
        }

        private MemberData _memberMemberData = new TestObjectBuilder<MemberData>().Build();

        public ReportDataBuilder SetMemberMemberData(MemberData memberMemberData)
        {
            _memberMemberData = memberMemberData;
            return this;
        }


        private FinanceData _baitulMalFinanceData = new FinanceDataBuilder().Build();
        public ReportDataBuilder SetBaitulMalFinanceData(FinanceData baitulMalFinanceData)
        {
            _baitulMalFinanceData = baitulMalFinanceData;
            return this;
        }

        private FinanceData _aDayMasjidProjectFinanceData = new FinanceDataBuilder().Build();
        public ReportDataBuilder SetADayMasjidProjectFinanceData(FinanceData aDayMasjidProjectFinanceData)
        {
            _aDayMasjidProjectFinanceData = aDayMasjidProjectFinanceData;
            return this;
        }

        private FinanceData _masjidTableBankFinanceData = new FinanceDataBuilder().Build();
        public ReportDataBuilder SetMasjidTableBankFinanceData(FinanceData masjidTableBankFinanceData)
        {
            _masjidTableBankFinanceData = masjidTableBankFinanceData;
            return this;
        }

        private SocialWelfareData _qardeHasanaSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ReportDataBuilder SetQardeHasanaSocialWelfareData(SocialWelfareData qardeHasanaSocialWelfareData)
        {
            _qardeHasanaSocialWelfareData = qardeHasanaSocialWelfareData;
            return this;
        }

        private SocialWelfareData _patientVisitSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ReportDataBuilder SetPatientVisitSocialWelfareData(SocialWelfareData patientVisitSocialWelfareData)
        {
            _patientVisitSocialWelfareData = patientVisitSocialWelfareData;
            return this;
        }

        private SocialWelfareData _socialVisitSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ReportDataBuilder SetSocialVisitSocialWelfareData(SocialWelfareData socialVisitSocialWelfareData)
        {
            _socialVisitSocialWelfareData = socialVisitSocialWelfareData;
            return this;
        }

        private SocialWelfareData _transportSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ReportDataBuilder SetTransportSocialWelfareData(SocialWelfareData transportSocialWelfareData)
        {
            _transportSocialWelfareData = transportSocialWelfareData;
            return this;
        }

        private SocialWelfareData _shiftingSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ReportDataBuilder SetShiftingSocialWelfareData(SocialWelfareData shiftingSocialWelfareData)
        {
            _shiftingSocialWelfareData = shiftingSocialWelfareData;
            return this;
        }

        private SocialWelfareData _shoppingSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ReportDataBuilder SetShoppingSocialWelfareData(SocialWelfareData shoppingSocialWelfareData)
        {
            _shoppingSocialWelfareData = shoppingSocialWelfareData;
            return this;
        }

        private SocialWelfareData _foodDistributionSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ReportDataBuilder SetFoodDistributionSocialWelfareData(SocialWelfareData foodDistributionSocialWelfareData)
        {
            _foodDistributionSocialWelfareData = foodDistributionSocialWelfareData;
            return this;
        }

        private SocialWelfareData _cleanUpAustraliaSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ReportDataBuilder SetCleanUpAustraliaSocialWelfareData(SocialWelfareData cleanUpAustraliaSocialWelfareData)
        {
            _cleanUpAustraliaSocialWelfareData = cleanUpAustraliaSocialWelfareData;
            return this;
        }

        private SocialWelfareData _otherSocialWelfareData = new TestObjectBuilder<SocialWelfareData>().Build();
        public ReportDataBuilder SetOtherSocialWelfareData(SocialWelfareData otherSocialWelfareData)
        {
            _otherSocialWelfareData = otherSocialWelfareData;
            return this;
        }

        private MaterialData _bookSaleMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ReportDataBuilder SetBookSaleMaterialData(MaterialData bookSaleMaterialData)
        {
            _bookSaleMaterialData = bookSaleMaterialData;
            return this;
        }

        private MaterialData _bookDistributionMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ReportDataBuilder SetBookDistributionMaterialData(MaterialData bookDistributionMaterialData)
        {
            _bookDistributionMaterialData = bookDistributionMaterialData;
            return this;
        }

        private LibraryStockData _bookLibraryStockData = new TestObjectBuilder<LibraryStockData>().Build();
        public ReportDataBuilder SetBookLibraryStockData(LibraryStockData bookLibraryStockData)
        {
            _bookLibraryStockData = bookLibraryStockData;
            return this;
        }

        private MaterialData _otherSaleMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ReportDataBuilder SetOtherSaleMaterialData(MaterialData otherSaleMaterialData)
        {
            _otherSaleMaterialData = otherSaleMaterialData;
            return this;
        }

        private MaterialData _otherDistributionMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ReportDataBuilder SetOtherDistributionMaterialData(MaterialData otherDistributionMaterialData)
        {
            _otherDistributionMaterialData = otherDistributionMaterialData;
            return this;
        }

        private LibraryStockData _otherLibraryStockData = new TestObjectBuilder<LibraryStockData>().Build();
        public ReportDataBuilder SetOtherLibraryStockData(LibraryStockData otherLibraryStockData)
        {
            _otherLibraryStockData = otherLibraryStockData;
            return this;
        }

        private MaterialData _vhsSaleMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ReportDataBuilder SetVhsSaleMaterialData(MaterialData vhsSaleMaterialData)
        {
            _vhsSaleMaterialData = vhsSaleMaterialData;
            return this;
        }

        private MaterialData _vhsDistributionMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ReportDataBuilder SetVhsDistributionMaterialData(MaterialData vhsDistributionMaterialData)
        {
            _vhsDistributionMaterialData = vhsDistributionMaterialData;
            return this;
        }

        private LibraryStockData _vhsLibraryStockData = new TestObjectBuilder<LibraryStockData>().Build();
        public ReportDataBuilder SetVhsLibraryStockData(LibraryStockData vhsLibraryStockData)
        {
            _vhsLibraryStockData = vhsLibraryStockData;
            return this;
        }

        private MaterialData _emailDistributionMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ReportDataBuilder SetEmailDistributionMaterialData(MaterialData emailDistributionMaterialData)
        {
            _emailDistributionMaterialData = emailDistributionMaterialData;
            return this;
        }

        private MaterialData _ipdcLeafletDistributionMaterialData = new TestObjectBuilder<MaterialData>().Build();
        public ReportDataBuilder SetIpdcLeafletDistributionMaterialData(MaterialData ipdcLeafletDistributionMaterialData)
        {
            _ipdcLeafletDistributionMaterialData = ipdcLeafletDistributionMaterialData;
            return this;
        }





        private TeachingLearningProgramData _groupStudyTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetGroupStudyTeachingLearningProgramData(TeachingLearningProgramData groupStudyTeachingLearningProgramData)
        {
            _groupStudyTeachingLearningProgramData = groupStudyTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _studyCircleTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetStudyCircleTeachingLearningProgramData(TeachingLearningProgramData studyCircleTeachingLearningProgramData)
        {
            _studyCircleTeachingLearningProgramData = studyCircleTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _practiceDarsTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetPracticeDarsTeachingLearningProgramData(TeachingLearningProgramData practiceDarsTeachingLearningProgramData)
        {
            _practiceDarsTeachingLearningProgramData = practiceDarsTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _stateLearningCampTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetStateLearningCampTeachingLearningProgramData(TeachingLearningProgramData stateLearningCampTeachingLearningProgramData)
        {
            _stateLearningCampTeachingLearningProgramData = stateLearningCampTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _quranStudyTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetQuranStudyTeachingLearningProgramData(TeachingLearningProgramData quranStudyTeachingLearningProgramData)
        {
            _quranStudyTeachingLearningProgramData = quranStudyTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _quranClassTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetQuranClassTeachingLearningProgramData(TeachingLearningProgramData quranClassTeachingLearningProgramData)
        {
            _quranClassTeachingLearningProgramData = quranClassTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _memorizingAyatTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetMemorizingAyatTeachingLearningProgramData(TeachingLearningProgramData memorizingAyatTeachingLearningProgramData)
        {
            _memorizingAyatTeachingLearningProgramData = memorizingAyatTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _stateLearningSessionTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetStateLearningSessionTeachingLearningProgramData(TeachingLearningProgramData stateLearningSessionTeachingLearningProgramData)
        {
            _stateLearningSessionTeachingLearningProgramData = stateLearningSessionTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _stateQiyamulLailTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetStateQiyamulLailTeachingLearningProgramData(TeachingLearningProgramData stateQiyamulLailTeachingLearningProgramData)
        {
            _stateQiyamulLailTeachingLearningProgramData = stateQiyamulLailTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _studyCircleForAssociateMemberTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetStudyCircleForAssociateMemberTeachingLearningProgramData(TeachingLearningProgramData studyCircleForAssociateMemberTeachingLearningProgramData)
        {
            _studyCircleForAssociateMemberTeachingLearningProgramData = studyCircleForAssociateMemberTeachingLearningProgramData;
            return this;
        }
        private TeachingLearningProgramData _hadithTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetHadithTeachingLearningProgramData(TeachingLearningProgramData hadithTeachingLearningProgramData)
        {
            _hadithTeachingLearningProgramData = hadithTeachingLearningProgramData;
            return this;
        }
        private TeachingLearningProgramData _weekendIslamicSchoolTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetWeekendIslamicSchoolTeachingLearningProgramData(TeachingLearningProgramData weekendIslamicSchoolTeachingLearningProgramData)
        {
            _weekendIslamicSchoolTeachingLearningProgramData = weekendIslamicSchoolTeachingLearningProgramData;
            return this;
        }
        private TeachingLearningProgramData _memorizingHadithTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetMemorizingHadithTeachingLearningProgramData(TeachingLearningProgramData memorizingHadithTeachingLearningProgramData)
        {
            _memorizingHadithTeachingLearningProgramData = memorizingHadithTeachingLearningProgramData;
            return this;
        }
        private TeachingLearningProgramData _memorizingDoaTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetMemorizingDoaTeachingLearningProgramData(TeachingLearningProgramData memorizingDoaTeachingLearningProgramData)
        {
            _memorizingDoaTeachingLearningProgramData = memorizingDoaTeachingLearningProgramData;
            return this;
        }

        private TeachingLearningProgramData _otherTeachingLearningProgramData = new TestObjectBuilder<TeachingLearningProgramData>().Build();
        public ReportDataBuilder SetOtherTeachingLearningProgramData(TeachingLearningProgramData otherTeachingLearningProgramData)
        {
            _otherTeachingLearningProgramData = otherTeachingLearningProgramData;
            return this;
        }

        private string _comment = DataProvider.Get<string>();
        public ReportDataBuilder SetComment(string comment)
        {
            _comment = comment;
            return this;
        }

        public ReportData Build()
        {
            var reportData = new TestObjectBuilder<ReportData>()
                .SetArgument(o => o.MemberMemberData, _memberMemberData)
                .SetArgument(o => o.AssociateMemberData, _associateMemberData)
                .SetArgument(o => o.PreliminaryMemberData, _preliminaryMemberData)
                .SetArgument(o => o.WorkerMeetingProgramData, _workerMeetingProgramData)
                .SetArgument(o => o.SupporterMemberData, _supporterMemberData)
                .SetArgument(o => o.DawahMeetingProgramData, _dawahMeetingProgramData)
                .SetArgument(o => o.StateLeaderMeetingProgramData, _stateLeaderMeetingProgramData)
                .SetArgument(o => o.StateOutingMeetingProgramData, _stateOutingMeetingProgramData)
                .SetArgument(o => o.IftarMeetingProgramData, _iftarMeetingProgramData)
                .SetArgument(o => o.LearningMeetingProgramData, _learningMeetingProgramData)
                .SetArgument(o => o.SocialDawahMeetingProgramData, _socialDawahMeetingProgramData)
                .SetArgument(o => o.DawahGroupMeetingProgramData, _dawahGroupMeetingProgramData)
                .SetArgument(o => o.NextGMeetingProgramData, _nextGMeetingProgramData)

                .SetArgument(o => o.CmsMeetingProgramData, _cmsMeetingProgramData)
                .SetArgument(o => o.SmMeetingProgramData, _smMeetingProgramData)
                .SetArgument(o => o.MemberMeetingProgramData, _memberMeetingProgramData)
                .SetArgument(o => o.TafsirMeetingProgramData, _tafsirMeetingProgramData)
                .SetArgument(o => o.UnitMeetingProgramData, _unitMeetingProgramData)
                .SetArgument(o => o.FamilyVisitMeetingProgramData, _familyVisitMeetingProgramData)
                .SetArgument(o => o.EidReunionMeetingProgramData, _eidReunionMeetingProgramData)
                .SetArgument(o => o.BbqMeetingProgramData, _bbqMeetingProgramData)
                .SetArgument(o => o.GatheringMeetingProgramData, _gatheringMeetingProgramData)
                .SetArgument(o => o.OtherMeetingProgramData, _otherMeetingProgramData)


                .SetArgument(o => o.BaitulMalFinanceData, _baitulMalFinanceData)
                .SetArgument(o => o.ADayMasjidProjectFinanceData, _aDayMasjidProjectFinanceData)
                .SetArgument(o => o.MasjidTableBankFinanceData, _masjidTableBankFinanceData)
                .SetArgument(o => o.QardeHasanaSocialWelfareData, _qardeHasanaSocialWelfareData)
                .SetArgument(o => o.PatientVisitSocialWelfareData, _patientVisitSocialWelfareData)
                .SetArgument(o => o.SocialVisitSocialWelfareData, _socialVisitSocialWelfareData)
                .SetArgument(o => o.TransportSocialWelfareData, _transportSocialWelfareData)
                .SetArgument(o => o.ShiftingSocialWelfareData, _shiftingSocialWelfareData)
                .SetArgument(o => o.ShoppingSocialWelfareData, _shoppingSocialWelfareData)
                .SetArgument(o => o.FoodDistributionSocialWelfareData, _foodDistributionSocialWelfareData)
                .SetArgument(o => o.CleanUpAustraliaSocialWelfareData, _cleanUpAustraliaSocialWelfareData)
                .SetArgument(o => o.OtherSocialWelfareData, _otherSocialWelfareData)
                .SetArgument(o => o.BookSaleMaterialData, _bookSaleMaterialData)
                .SetArgument(o => o.BookDistributionMaterialData, _bookDistributionMaterialData)
                .SetArgument(o => o.BookLibraryStockData, _bookLibraryStockData)
                .SetArgument(o => o.OtherSaleMaterialData, _otherSaleMaterialData)
                .SetArgument(o => o.OtherDistributionMaterialData, _otherDistributionMaterialData)
                .SetArgument(o => o.OtherLibraryStockData, _otherLibraryStockData)
                .SetArgument(o => o.VhsSaleMaterialData, _vhsSaleMaterialData)
                .SetArgument(o => o.VhsDistributionMaterialData, _vhsDistributionMaterialData)
                .SetArgument(o => o.VhsLibraryStockData, _vhsLibraryStockData)
                .SetArgument(o => o.EmailDistributionMaterialData, _emailDistributionMaterialData)
                .SetArgument(o => o.IpdcLeafletDistributionMaterialData, _ipdcLeafletDistributionMaterialData)
                .SetArgument(o => o.GroupStudyTeachingLearningProgramData, _groupStudyTeachingLearningProgramData)
                .SetArgument(o => o.StudyCircleTeachingLearningProgramData, _studyCircleTeachingLearningProgramData)
                .SetArgument(o => o.PracticeDarsTeachingLearningProgramData, _practiceDarsTeachingLearningProgramData)
                .SetArgument(o => o.StateLearningCampTeachingLearningProgramData, _stateLearningCampTeachingLearningProgramData)
                .SetArgument(o => o.QuranStudyTeachingLearningProgramData, _quranStudyTeachingLearningProgramData)
                .SetArgument(o => o.QuranClassTeachingLearningProgramData, _quranClassTeachingLearningProgramData)
                .SetArgument(o => o.MemorizingAyatTeachingLearningProgramData, _memorizingAyatTeachingLearningProgramData)
                .SetArgument(o => o.StateLearningSessionTeachingLearningProgramData, _stateLearningSessionTeachingLearningProgramData)
                .SetArgument(o => o.StateQiyamulLailTeachingLearningProgramData, _stateQiyamulLailTeachingLearningProgramData)
                .SetArgument(o => o.StudyCircleForAssociateMemberTeachingLearningProgramData, _studyCircleForAssociateMemberTeachingLearningProgramData)
                .SetArgument(o => o.HadithTeachingLearningProgramData, _hadithTeachingLearningProgramData)
                .SetArgument(o => o.WeekendIslamicSchoolTeachingLearningProgramData, _weekendIslamicSchoolTeachingLearningProgramData)
                .SetArgument(o => o.MemorizingHadithTeachingLearningProgramData, _memorizingHadithTeachingLearningProgramData)
                .SetArgument(o => o.MemorizingDoaTeachingLearningProgramData, _memorizingDoaTeachingLearningProgramData)
                .SetArgument(o => o.OtherTeachingLearningProgramData, _otherTeachingLearningProgramData)

                .SetArgument(o => o.Comment, _comment)
                .Build();
            return reportData;
        }
    }
}