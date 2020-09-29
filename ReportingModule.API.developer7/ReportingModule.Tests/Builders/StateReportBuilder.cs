using NHibernate;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Builders
{
    public class StateReportBuilder
    {
        private string _description = DataProvider.Get<string>();

        public StateReportBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        private OrganizationReference _organization = new TestObjectBuilder<OrganizationReference>()
            .SetArgument(o => o.OrganizationType, OrganizationType.State)
            .Build();
        public StateReportBuilder SetOrganization(OrganizationReference organization)
        {
            _organization = organization;
            return this;
        }

        private ReportingPeriod _reportingPeriod = new ReportingPeriod(ReportingFrequency.Quarterly, ReportingTerm.One, 2019);

        public StateReportBuilder SetReportingPeriod(ReportingPeriod reportingPeriod)
        {
            _reportingPeriod = reportingPeriod;
            return this;
        }

        private ReportData _reportData = new ReportDataBuilder()
            .SetMemberMemberData(MemberData.Default())
            .SetAssociateMemberData(MemberData.Default())
            .SetPreliminaryMemberData(MemberData.Default())
            .SetSupporterMemberData(MemberData.Default())

            .SetWorkerMeetingProgramData(MeetingProgramData.Default())
            .SetDawahMeetingProgramData(MeetingProgramData.Default())
            .SetStateLeaderMeetingProgramData(MeetingProgramData.Default())
            .SetStateOutingMeetingProgramData(MeetingProgramData.Default())
            .SetIftarMeetingProgramData(MeetingProgramData.Default())
            .SetLearningMeetingProgramData(MeetingProgramData.Default())
            .SetSocialDawahMeetingProgramData(MeetingProgramData.Default())
            .SetDawahGroupMeetingProgramData(MeetingProgramData.Default())
            .SetNextGMeetingProgramData(MeetingProgramData.Default())

            .SetCmsMeetingProgramData(MeetingProgramData.Default())
            .SetSmMeetingProgramData(MeetingProgramData.Default())
            .SetMemberMeetingProgramData(MeetingProgramData.Default())
            .SetTafsirMeetingProgramData(MeetingProgramData.Default())
            .SetUnitMeetingProgramData(MeetingProgramData.Default())
            .SetFamilyVisitMeetingProgramData(MeetingProgramData.Default())
            .SetEidReunionMeetingProgramData(MeetingProgramData.Default())
            .SetBbqMeetingProgramData(MeetingProgramData.Default())
            .SetGatheringMeetingProgramData(MeetingProgramData.Default())
            .SetOtherMeetingProgramData(MeetingProgramData.Default())

            .SetGroupStudyTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetStudyCircleTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetPracticeDarsTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetStateLearningCampTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetQuranStudyTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetQuranClassTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetMemorizingAyatTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetStateLearningSessionTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetStateQiyamulLailTeachingLearningProgramData(TeachingLearningProgramData.Default())

            .SetStudyCircleForAssociateMemberTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetHadithTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetWeekendIslamicSchoolTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetMemorizingHadithTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetMemorizingDoaTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetOtherTeachingLearningProgramData(TeachingLearningProgramData.Default())

            .SetBookSaleMaterialData(MaterialData.Default())
            .SetBookDistributionMaterialData(MaterialData.Default())
            .SetBookLibraryStockData(LibraryStockData.Default())

            .SetOtherSaleMaterialData(MaterialData.Default())
            .SetOtherDistributionMaterialData(MaterialData.Default())
            .SetOtherLibraryStockData(LibraryStockData.Default())

            .SetVhsSaleMaterialData(MaterialData.Default())
            .SetVhsDistributionMaterialData(MaterialData.Default())
            .SetVhsLibraryStockData(LibraryStockData.Default())
            .SetEmailDistributionMaterialData(MaterialData.Default())
            .SetIpdcLeafletDistributionMaterialData(MaterialData.Default())

            .SetBaitulMalFinanceData(FinanceData.Default())
            .SetADayMasjidProjectFinanceData(FinanceData.Default())
            .SetMasjidTableBankFinanceData(FinanceData.Default())

            .SetQardeHasanaSocialWelfareData(SocialWelfareData.Default())
            .SetPatientVisitSocialWelfareData(SocialWelfareData.Default())
            .SetSocialVisitSocialWelfareData(SocialWelfareData.Default())
            .SetTransportSocialWelfareData(SocialWelfareData.Default())
            .SetShiftingSocialWelfareData(SocialWelfareData.Default())
            .SetShoppingSocialWelfareData(SocialWelfareData.Default())

            .SetFoodDistributionSocialWelfareData(SocialWelfareData.Default())
            .SetCleanUpAustraliaSocialWelfareData(SocialWelfareData.Default())
            .SetOtherSocialWelfareData(SocialWelfareData.Default())

            .SetComment(null)
            .Build();

        public StateReportBuilder SetReportData(ReportData reportData)
        {
            _reportData = reportData;
            return this;
        }

        private ReportData _reportDataGenerated = new ReportDataBuilder()
            .SetMemberMemberData(MemberData.Default())
            .SetAssociateMemberData(MemberData.Default())
            .SetPreliminaryMemberData(MemberData.Default())
            .SetSupporterMemberData(MemberData.Default())

            .SetWorkerMeetingProgramData(MeetingProgramData.Default())
            .SetDawahMeetingProgramData(MeetingProgramData.Default())
            .SetStateLeaderMeetingProgramData(MeetingProgramData.Default())
            .SetStateOutingMeetingProgramData(MeetingProgramData.Default())
            .SetIftarMeetingProgramData(MeetingProgramData.Default())
            .SetLearningMeetingProgramData(MeetingProgramData.Default())
            .SetSocialDawahMeetingProgramData(MeetingProgramData.Default())
            .SetDawahGroupMeetingProgramData(MeetingProgramData.Default())
            .SetNextGMeetingProgramData(MeetingProgramData.Default())


            .SetCmsMeetingProgramData(MeetingProgramData.Default())
            .SetSmMeetingProgramData(MeetingProgramData.Default())
            .SetMemberMeetingProgramData(MeetingProgramData.Default())
            .SetTafsirMeetingProgramData(MeetingProgramData.Default())
            .SetUnitMeetingProgramData(MeetingProgramData.Default())
            .SetFamilyVisitMeetingProgramData(MeetingProgramData.Default())
            .SetEidReunionMeetingProgramData(MeetingProgramData.Default())
            .SetBbqMeetingProgramData(MeetingProgramData.Default())
            .SetGatheringMeetingProgramData(MeetingProgramData.Default())
            .SetOtherMeetingProgramData(MeetingProgramData.Default())


            .SetGroupStudyTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetStudyCircleTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetPracticeDarsTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetStateLearningCampTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetQuranStudyTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetQuranClassTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetMemorizingAyatTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetStateLearningSessionTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetStateQiyamulLailTeachingLearningProgramData(TeachingLearningProgramData.Default())

            .SetStudyCircleForAssociateMemberTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetHadithTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetWeekendIslamicSchoolTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetMemorizingHadithTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetMemorizingDoaTeachingLearningProgramData(TeachingLearningProgramData.Default())
            .SetOtherTeachingLearningProgramData(TeachingLearningProgramData.Default())

            .SetBookSaleMaterialData(MaterialData.Default())
            .SetBookDistributionMaterialData(MaterialData.Default())
            .SetBookLibraryStockData(LibraryStockData.Default())
            .SetOtherSaleMaterialData(MaterialData.Default())
            .SetOtherDistributionMaterialData(MaterialData.Default())
            .SetOtherLibraryStockData(LibraryStockData.Default())
            .SetVhsSaleMaterialData(MaterialData.Default())
            .SetVhsDistributionMaterialData(MaterialData.Default())
            .SetVhsLibraryStockData(LibraryStockData.Default())
            .SetEmailDistributionMaterialData(MaterialData.Default())
            .SetIpdcLeafletDistributionMaterialData(MaterialData.Default())

            .SetBaitulMalFinanceData(FinanceData.Default())
            .SetADayMasjidProjectFinanceData(FinanceData.Default())
            .SetMasjidTableBankFinanceData(FinanceData.Default())


            .SetQardeHasanaSocialWelfareData(SocialWelfareData.Default())
            .SetPatientVisitSocialWelfareData(SocialWelfareData.Default())
            .SetSocialVisitSocialWelfareData(SocialWelfareData.Default())
            .SetTransportSocialWelfareData(SocialWelfareData.Default())
            .SetShiftingSocialWelfareData(SocialWelfareData.Default())
            .SetShoppingSocialWelfareData(SocialWelfareData.Default())
            .SetFoodDistributionSocialWelfareData(SocialWelfareData.Default())
            .SetCleanUpAustraliaSocialWelfareData(SocialWelfareData.Default())
            .SetOtherSocialWelfareData(SocialWelfareData.Default())
            .Build();

        public StateReportBuilder SetReportDataGenerated(ReportData reportDataGenerated)
        {
            _reportDataGenerated = reportDataGenerated;
            return this;
        }

        public StateReport Build()
        {
            var report = new TestObjectBuilder<StateReport>()
                .SetArgument(o => o.Description, _description)
                .SetArgument(o => o.Organization, _organization)
                .SetArgument(o => o.ReportingPeriod, _reportingPeriod)
                .SetArgument("reportData", _reportData)
                .Build();
            report.UpdateGeneratedData(_reportDataGenerated);
            return report;
        }

        
        public StateReport BuildAndPersist(ISession s)
        {
            var report = Build();
            s.Save(report);
            return report;
        }
    }
}