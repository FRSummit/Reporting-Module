using System.Linq;
using NHibernate;
using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class ZoneReportService : IZoneReportService
    {
        private readonly ISession _session;
        private readonly IOrganizationService _organizationService;
        private readonly IUnitReportService _unitReportService;

        public ZoneReportService(ISession session, IOrganizationService organizationService, IUnitReportService unitReportService)
        {
            _session = session;
            _organizationService = organizationService;
            _unitReportService = unitReportService;
        }

      
        public ReportData GetGeneratedData(int organizationId, ReportingPeriod reportingPeriod)
        {
            var managedOrganizations = _organizationService.GetManagedOrganizations(organizationId);
            var organizations = managedOrganizations as Organization[] ?? managedOrganizations.ToArray();

            var onlyRecentStateReports = new StateReport[0];
            var allStateReports = new StateReport[0];

            var onlyRecentZoneReports = new ZoneReport[0];
            var allZoneReports = new ZoneReport[0];

            var onlyRecentUnitReports = _unitReportService.GetOnlyRecentUnitReports(reportingPeriod, organizations);
            var allUnitReports = _unitReportService.GetAllUnitReports(reportingPeriod, organizations);

            return ReportDataCalculator.GetCalculatedReportData(onlyRecentUnitReports, allUnitReports, onlyRecentZoneReports, allZoneReports, onlyRecentStateReports, allStateReports);

        }

        public ZoneReport[] GetAllZoneReports(ReportingPeriod reportingPeriod, Organization[] organizations)
        {
            var orgIds = organizations
                .Where(managedOrganization => managedOrganization.OrganizationType == OrganizationType.Zone)
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
            return _session.Query<ZoneReport>()
                .Where(r => reportIds.Contains(r.Id)).ToArray();
        }


        public ZoneReport[] GetOnlyRecentZoneReports(ReportingPeriod reportingPeriod, Organization[] organizations)
        {
            var reportIds = organizations
                .Where(managedOrganization => managedOrganization.OrganizationType == OrganizationType.Zone)
                .Select(managedOrganization =>
                    GetSubmittedZoneReportInReportingPeriod(managedOrganization.Id, reportingPeriod))
                .ToArray()
                .Where(o => o != null)
                .Select(o=>o.Id)
                .ToArray();
            return _session.Query<ZoneReport>()
                .Where(r => reportIds.Contains(r.Id)).ToArray();
        }

        private Report GetSubmittedZoneReportInReportingPeriod(int organizationId,
            ReportingPeriod reportingPeriod)
        {
            return _session.Query<Report>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.Zone &&
                            o.Organization.Id == organizationId &&
                            o.ReportStatus == ReportStatus.Submitted &&
                            o.ReportingPeriod.EndDate <= reportingPeriod.EndDate &&
                            o.ReportingPeriod.StartDate >=
                            reportingPeriod.StartDate)
                .OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o)
                .FirstOrDefault();
        }

        public ZoneReport PromotePlanToZoneReport(int reportId)
        {
            var report = _session.Query<ZoneReport>().Single(o => o.Id == reportId);
            report.MarkStatusAsPlanPromoted();
            _session.Save(report);
            return report;
        }

        public ZoneReport GetLastSubmittedZoneReport(int organizationId,
            ReportingPeriod reportingPeriod,
            int pastTermCycle = 1)
        {
            var reportingPeriodOfPreviousTerm1 = reportingPeriod.GetReportingPeriodOfPreviousTerm();

            var reportIds = _session.Query<Report>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.Zone &&
                            o.Organization.Id == organizationId &&
                            o.ReportStatus == ReportStatus.Submitted &&
                            o.ReportingPeriod.EndDate < reportingPeriod.StartDate &&
                            o.ReportingPeriod.StartDate >=
                            reportingPeriodOfPreviousTerm1.StartDate)
                .OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o.Id)
                .ToArray();

            var zoneReports = _session.Query<ZoneReport>()
                .Where(r => reportIds.Contains(r.Id)).ToArray();

            if (zoneReports.Length == 0 && pastTermCycle <= 3)
                return GetLastSubmittedZoneReport(organizationId,
                    reportingPeriodOfPreviousTerm1, pastTermCycle + 1);
            return zoneReports.FirstOrDefault();
        }

        public ZoneReport[] GetZoneReports(int[] reportIds)
        {
            if (reportIds == null)
                reportIds = new int[0];
            return _session.Query<ZoneReport>().Where(r => reportIds.Contains(r.Id)).ToArray();
        }

    }
}
