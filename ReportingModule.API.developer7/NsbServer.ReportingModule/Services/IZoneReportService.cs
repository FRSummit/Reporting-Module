using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    public interface IZoneReportService
    {
        ZoneReport PromotePlanToZoneReport(int reportId);
        ZoneReport GetLastSubmittedZoneReport(int organizationId,
            ReportingPeriod reportingPeriod,
            int pastTermCycle = 1);

        ReportData GetGeneratedData(int organizationId, ReportingPeriod reportingPeriod);
        ZoneReport[] GetAllZoneReports(ReportingPeriod reportingPeriod, Organization[] organizations);
        ZoneReport[] GetOnlyRecentZoneReports(ReportingPeriod reportingPeriod, Organization[] organizations);
        ZoneReport[] GetZoneReports(int[] reportIds);
    }
}