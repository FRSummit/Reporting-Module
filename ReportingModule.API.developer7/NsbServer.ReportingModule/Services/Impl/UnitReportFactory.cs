using System;
using System.Linq;
using NHibernate;
using ReportingModule.Common;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class UnitReportFactory : IUnitReportFactory
    {
        private readonly ISession _session;
        private readonly IUnitReportService _unitReportService;

        public UnitReportFactory(ISession session, IUnitReportService unitReportService)
        {
            _session = session;
            _unitReportService = unitReportService;
        }

        public UnitReport CreateNewUnitPlan(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year, ReportingFrequency reportingFrequency)
        {
            return CreateNew(description, organizationRef, reportingTerm, year, reportingFrequency);
        }

        public UnitReport CreateNewUnitPlanAi(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year, ReportingFrequency reportingFrequency)
        {
            return CreateNew(description, organizationRef, reportingTerm, year, reportingFrequency, true);
        }

        private UnitReport CreateNew(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm,
                int year, ReportingFrequency reportingFrequency, bool isAi = false)
        {
            var organization = _session.Query<Organization>().Single(o => o.Id == organizationRef.Id);
            if (organization.OrganizationType != OrganizationType.Unit)
                throw new ArgumentException("Invalid Organization Type");
            if (reportingFrequency != organization.ReportingFrequency)
                throw new ArgumentException("Invalid Reporting Frequency");

            var reportingPeriod =
                new ReportingPeriod(reportingFrequency, reportingTerm, year);

            var reportData = isAi ? GetReportDataAi(organization, reportingPeriod) : ReportData.Default();

            var report = new UnitReport(description, organization, reportingPeriod, reportData);
            _session.Save(report);
            return report;
        }

        protected ReportData GetReportDataAi(Organization organization, ReportingPeriod reportingPeriod)
        {
            var lastSubmittedUnitReport =
                _unitReportService.GetSubmittedUnitReportOfPreviousTerm(organization.Id, reportingPeriod);

            var reportData = ReportData.Default();
            if (lastSubmittedUnitReport != null)
            {
                var unitMemberMemberData = CreateMemberData(lastSubmittedUnitReport.MemberMemberData);
                var unitAssociateMemberData = CreateMemberData(lastSubmittedUnitReport.AssociateMemberData);
                var unitPreliminaryMemberData = CreateMemberData(lastSubmittedUnitReport.PreliminaryMemberData);
                var unitSupporterMemberData = CreateMemberData(lastSubmittedUnitReport.SupporterMemberData);

                var unitWorkerMeetingData = CreateMeetingProgramData(lastSubmittedUnitReport.WorkerMeetingProgramData);
                var unitDawahMeetingData = CreateMeetingProgramData(lastSubmittedUnitReport.DawahMeetingProgramData);
                var unitStateLeaderMeetingData = CreateMeetingProgramData(lastSubmittedUnitReport.StateLeaderMeetingProgramData);
                var unitStateOutingMeetingData = CreateMeetingProgramData(lastSubmittedUnitReport.StateOutingMeetingProgramData);
                var unitIftarMeetingData = CreateMeetingProgramData(lastSubmittedUnitReport.IftarMeetingProgramData);
                var unitLearningMeetingData = CreateMeetingProgramData(lastSubmittedUnitReport.LearningMeetingProgramData);
                var unitSocialDawahMeetingData = CreateMeetingProgramData(lastSubmittedUnitReport.SocialDawahMeetingProgramData);
                var unitDawahGroupMeetingData = CreateMeetingProgramData(lastSubmittedUnitReport.DawahGroupMeetingProgramData);
                var unitNextGMeetingData = CreateMeetingProgramData(lastSubmittedUnitReport.NextGMeetingProgramData);

                var baitulMalFinanceData = CreateFinanceData(lastSubmittedUnitReport.BaitulMalFinanceData);
                var aDayMasjidProjectFinanceData = CreateFinanceData(lastSubmittedUnitReport.ADayMasjidProjectFinanceData);
                var masjidTableBankFinanceData = CreateFinanceData(lastSubmittedUnitReport.MasjidTableBankFinanceData);

                reportData = new ReportData(unitMemberMemberData,
                    unitAssociateMemberData,
                    unitPreliminaryMemberData,
                    unitSupporterMemberData,

                    unitWorkerMeetingData,
                    unitDawahMeetingData,
                    unitStateLeaderMeetingData,
                    unitStateOutingMeetingData,
                    unitIftarMeetingData,
                    unitLearningMeetingData,
                    unitSocialDawahMeetingData,
                    unitDawahGroupMeetingData,
                    unitNextGMeetingData,

                    baitulMalFinanceData: baitulMalFinanceData,
                    aDayMasjidProjectFinanceData: aDayMasjidProjectFinanceData,
                    masjidTableBankFinanceData: masjidTableBankFinanceData);
            }

            return reportData;
        }

        public UnitReport CopyUnitPlan(string description, int copyFromReportId, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year)
        {
            if (organizationRef.OrganizationType != OrganizationType.Unit)
                throw new ArgumentException("Invalid Organization Type");
     
            var copyFromReport = _session.Get<UnitReport>(copyFromReportId);
            if (copyFromReport.ReportingPeriod.ReportingFrequency != organizationRef.ReportingFrequency)
                throw new ArgumentException("Invalid Reporting Frequency");

            ReportData reportData = copyFromReport;
            var lastPeriodUpdateData = Calculator.GetLastPeriodUpdateData(reportData);

            var newReport = CreateNew(description, copyFromReport.Organization, reportingTerm, year, copyFromReport.ReportingPeriod.ReportingFrequency);
            newReport.UpdatePlan(reportData);
            newReport.Update(reportData);
            newReport.Update(lastPeriodUpdateData);
            _session.Save(newReport);

            return newReport;
        }

        private FinanceReportData CreateFinanceReportDataFromLastPeriod(FinanceData lastPeriodReportData)
        {
            return new FinanceReportData(lastPeriodReportData.WorkerPromiseThisPeriod, Money.Zero(), Money.Zero(), lastPeriodReportData.Balance, lastPeriodReportData.Collection, lastPeriodReportData.Expense, lastPeriodReportData.NisabPaidToCentral, lastPeriodReportData.Comment);
        }


        private MemberData CreateMemberData(MemberData lastPeriodAssociateMemberData)
        {
            return new MemberData(
                null,
                null,
                lastPeriodAssociateMemberData.ThisPeriod,
                lastPeriodAssociateMemberData.UpgradeTarget,
                0,
                0,
                null,
                0);
        }

        private MeetingProgramData CreateMeetingProgramData(MeetingProgramData lastPeriodWorkerMeetingData)
        {
            return new MeetingProgramData(
                lastPeriodWorkerMeetingData.Target,
                null,
                0,
                0,
                null);
        }

        private FinanceData CreateFinanceData(FinanceData lastPeriodBaitulMalFinanceData)
        {
            return new FinanceData(
                null,
                Money.Zero(),
                null,
                Money.Zero(),
                lastPeriodBaitulMalFinanceData.WorkerPromiseThisPeriod,
                lastPeriodBaitulMalFinanceData.Balance,
                Money.Zero(),
                Money.Zero(),
                Money.Zero(),
                Money.Zero(),
                Money.Zero(),
                null);
        }
    }
}