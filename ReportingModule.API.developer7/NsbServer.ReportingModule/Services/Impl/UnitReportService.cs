using System.Linq;
using NHibernate;
using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class UnitReportService : IUnitReportService
    {
        private readonly ISession _session;

        public UnitReportService(ISession session)
        {
            _session = session;
        }

        public UnitReport PromotePlanToUnitReport(int reportId)
        {
            var report = _session.Query<UnitReport>().Single(o => o.Id == reportId);
            report.MarkStatusAsPlanPromoted();
            _session.Save(report);
            return report;
        }

        public UnitReport PromotePlanToUnitReportAi(int reportId)
        {
            var report = _session.Query<UnitReport>().Single(o => o.Id == reportId);
            var previousSubmittedReport = GetSubmittedUnitReportInLastThreeTerm(report.Organization.Id, report.ReportingPeriod);
            if (previousSubmittedReport != null)
            {
                report.AssociateMemberData.SetThisPeriod(previousSubmittedReport.AssociateMemberData.ThisPeriod);
                report.PreliminaryMemberData.SetThisPeriod(previousSubmittedReport.PreliminaryMemberData.ThisPeriod);

                //Worker meeting values should be initial values. Should not set last period values (as that will be irrelevant)

            }
            report.MarkStatusAsPlanPromoted();
            _session.Save(report);
            return report;
        }

        public UnitReport GetSubmittedUnitReportOfPreviousTerm(int organizationId,
            ReportingPeriod reportingPeriod)
        {
            var reportingPeriodOfPreviousTerm1 = reportingPeriod.GetReportingPeriodOfPreviousTerm();

            var report = _session.Query<Report>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.Unit &&
                            o.Organization.Id == organizationId &&
                            o.ReportStatus == ReportStatus.Submitted &&
                            o.ReportingPeriod.EndDate < reportingPeriod.StartDate &&
                            o.ReportingPeriod.StartDate >=
                            reportingPeriodOfPreviousTerm1.StartDate)
                .OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o)
                .FirstOrDefault();

            return report == null ? null : _session.Query<UnitReport>().Single(o => o.Id == report.Id);

        }

        public UnitReport[] GetAllUnitReports(ReportingPeriod reportingPeriod, Organization[] organizations)
        {
            var orgIds = organizations
                .Where(managedOrganization => managedOrganization.OrganizationType == OrganizationType.Unit)
                .Select(managedOrganization => managedOrganization.Id)
                .ToArray();

            var reportIds = _session.Query<Report>()
                .Where(o => orgIds.Contains(o.Organization.Id) &&
                            o.ReportStatus == ReportStatus.Submitted &&
                            o.ReportingPeriod.EndDate <= reportingPeriod.EndDate &&
                            o.ReportingPeriod.StartDate >=
                            reportingPeriod.StartDate)
                .OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o.Id)
                .ToArray();

            return _session.Query<UnitReport>()
                .Where(r => reportIds.Contains(r.Id)).ToArray();

        }

        public UnitReport[] GetOnlyRecentUnitReports(ReportingPeriod reportingPeriod, Organization[] organizations)
        {
            var reportIds = organizations
                .Where(managedOrganization => managedOrganization.OrganizationType == OrganizationType.Unit)
                .Select(managedOrganization =>
                    GetSubmittedUnitReportInReportingPeriod(managedOrganization.Id, reportingPeriod))
                .ToArray()
                .Where(o => o != null)
                .Select(o=>o.Id)
                .ToArray();
            return _session.Query<UnitReport>()
                .Where(r => reportIds.Contains(r.Id)).ToArray();
        }

        private Report GetSubmittedUnitReportInReportingPeriod(int organizationId,
            ReportingPeriod reportingPeriod)
        {
            return _session.Query<Report>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.Unit &&
                            o.Organization.Id == organizationId &&
                            o.ReportStatus == ReportStatus.Submitted &&
                            o.ReportingPeriod.EndDate <= reportingPeriod.EndDate &&
                            o.ReportingPeriod.StartDate >=
                            reportingPeriod.StartDate)
                .OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o)
                .FirstOrDefault();
        }

        private UnitReport GetSubmittedUnitReportInLastThreeTerm(int organizationId,
            ReportingPeriod reportingPeriod,
            int pastTermCycle = 1)
        {
            var reportingPeriodOfPreviousTerm1 = reportingPeriod.GetReportingPeriodOfPreviousTerm();

            var reportIds = _session.Query<Report>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.Unit &&
                            o.Organization.Id == organizationId &&
                            o.ReportStatus == ReportStatus.Submitted &&
                            o.ReportingPeriod.EndDate < reportingPeriod.StartDate &&
                            o.ReportingPeriod.StartDate >=
                            reportingPeriodOfPreviousTerm1.StartDate)
                .OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o.Id)
                .ToArray();

            var unitReports = _session.Query<UnitReport>()
                .Where(r => reportIds.Contains(r.Id)).ToArray();

            if (unitReports.Length == 0 && pastTermCycle <= 3)
                return GetSubmittedUnitReportInLastThreeTerm(organizationId,
                    reportingPeriodOfPreviousTerm1, pastTermCycle + 1);
            return unitReports.FirstOrDefault();
        }

        public UnitReport[] GetUnitReports(int[] reportIds)
        {
            if (reportIds == null)
                reportIds = new int[0];
            return _session.Query<UnitReport>().Where(r => reportIds.Contains(r.Id)).ToArray();
        }
    }
}