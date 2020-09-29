using System.Linq;
using NHibernate;
using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class CentralReportService : ICentralReportService
    {
        private readonly ISession _session;
        private readonly IOrganizationService _organizationService;
        private readonly IUnitReportService _unitReportService;
        private readonly IZoneReportService _zoneReportService;
        private readonly IStateReportService _stateReportService;

        public CentralReportService(ISession session, IOrganizationService organizationService, IUnitReportService unitReportService, IZoneReportService zoneReportService, IStateReportService stateReportService)
        {
            _session = session;
            _organizationService = organizationService;
            _unitReportService = unitReportService;
            _zoneReportService = zoneReportService;
            _stateReportService = stateReportService;
        }

        public ReportData GetGeneratedData(int organizationId, ReportingPeriod reportingPeriod)
        {
            var managedOrganizations = _organizationService.GetManagedOrganizations(organizationId);
            var organizations = managedOrganizations as Organization[] ?? managedOrganizations.ToArray();

            var onlyRecentStateReports = _stateReportService.GetOnlyRecentStateReports(reportingPeriod, organizations);
            var allStateReports = _stateReportService.GetAllStateReports(reportingPeriod, organizations);

            var onlyRecentZoneReports = _zoneReportService.GetOnlyRecentZoneReports(reportingPeriod, organizations); ;
            var allZoneReports = _zoneReportService.GetAllZoneReports(reportingPeriod, organizations);

            var onlyRecentUnitReports = _unitReportService.GetOnlyRecentUnitReports(reportingPeriod, organizations);
            var allUnitReports = _unitReportService.GetAllUnitReports(reportingPeriod, organizations);

            return ReportDataCalculator.GetCalculatedReportData(onlyRecentUnitReports, allUnitReports, onlyRecentZoneReports, allZoneReports, onlyRecentStateReports, allStateReports );
        }

        public CentralReport PromotePlanToCentralReport(int reportId)
        {
            var report = _session.Query<CentralReport>().Single(o => o.Id == reportId);
            report.MarkStatusAsPlanPromoted();
            _session.Save(report);
            return report;
        }
        public CentralReport GetLastSubmittedCentralReport(int organizationId,
            ReportingPeriod reportingPeriod,
            int pastTermCycle = 1)
        {
            var reportingPeriodOfPreviousTerm1 = reportingPeriod.GetReportingPeriodOfPreviousTerm();

            var reportIds = _session.Query<Report>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.State &&
                            o.Organization.Id == organizationId &&
                            o.ReportStatus == ReportStatus.Submitted &&
                            o.ReportingPeriod.EndDate < reportingPeriod.StartDate &&
                            o.ReportingPeriod.StartDate >=
                            reportingPeriodOfPreviousTerm1.StartDate)
                .OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o.Id)
                .ToArray();

            var centralReports = _session.Query<CentralReport>()
                .Where(r => reportIds.Contains(r.Id)).ToArray();

            if (centralReports.Length == 0 && pastTermCycle <= 3)
                return GetLastSubmittedCentralReport(organizationId,
                    reportingPeriodOfPreviousTerm1, pastTermCycle + 1);
            return centralReports.FirstOrDefault();
        }

        public CentralReport[] GetCentralReports(int[] reportIds)
        {
            if (reportIds == null)
                reportIds = new int[0];
            return _session.Query<CentralReport>().Where(r => reportIds.Contains(r.Id)).ToArray();
        }


    }
}