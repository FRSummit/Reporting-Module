using NHibernate;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Builders
{
    public class UnitReportBuilder
    {
        private string _description = DataProvider.Get<string>();

        public UnitReportBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        private OrganizationReference _organization = new TestObjectBuilder<OrganizationReference>()
            .SetArgument(o=>o.OrganizationType, OrganizationType.Unit)
            .Build();

        public UnitReportBuilder SetOrganization(OrganizationReference organization)
        {
            _organization = organization;
            return this;
        }

        private ReportingPeriod _reportingPeriod = new ReportingPeriod(ReportingFrequency.Quarterly, ReportingTerm.One, 2019);

        public UnitReportBuilder SetReportingPeriod(ReportingPeriod reportingPeriod)
        {
            _reportingPeriod = reportingPeriod;
            return this;
        }

        private ReportData _reportData = new ReportDataBuilder()
            .SetAssociateMemberData(MemberData.Default())
            .SetPreliminaryMemberData(MemberData.Default())
            .SetWorkerMeetingProgramData(MeetingProgramData.Default())
            .SetSupporterMemberData(MemberData.Default())
            
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

            .SetMemberMemberData(MemberData.Default())

            .SetBaitulMalFinanceData(FinanceData.Default())
            .SetADayMasjidProjectFinanceData(FinanceData.Default())
            .SetMasjidTableBankFinanceData(FinanceData.Default())

            .SetQardeHasanaSocialWelfareData(SocialWelfareData.Default())
            .SetPatientVisitSocialWelfareData(SocialWelfareData.Default())
            .SetSocialVisitSocialWelfareData(SocialWelfareData.Default())
            .SetTransportSocialWelfareData(SocialWelfareData.Default())
            .SetShiftingSocialWelfareData(SocialWelfareData.Default())
            .SetShoppingSocialWelfareData(SocialWelfareData.Default())

            .SetBookSaleMaterialData(MaterialData.Default())
            .SetBookDistributionMaterialData(MaterialData.Default())
            .SetVhsSaleMaterialData(MaterialData.Default())
            .SetVhsDistributionMaterialData(MaterialData.Default())
            .SetEmailDistributionMaterialData(MaterialData.Default())
            .SetIpdcLeafletDistributionMaterialData(MaterialData.Default())
            .SetBookLibraryStockData(LibraryStockData.Default())
            .SetVhsLibraryStockData(LibraryStockData.Default())

            .SetComment(null)
            .Build();

        public UnitReportBuilder SetReportData(ReportData reportData)
        {
            _reportData = reportData;
            return this;
        }

        public UnitReport Build()
        {
            var report = new TestObjectBuilder<UnitReport>()
                .SetArgument(o => o.Description, _description)
                .SetArgument(o => o.Organization, _organization)
                .SetArgument(o => o.ReportingPeriod, _reportingPeriod)
                .SetArgument("reportData", _reportData)
                .Build();
            return report;
        }

        
        public UnitReport BuildAndPersist(ISession s)
        {
            var report = Build();
            s.Save(report);
            return report;
        }
    }
}