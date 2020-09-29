using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    public interface ICentralReportService
    {
        CentralReport PromotePlanToCentralReport(int reportId);
        CentralReport GetLastSubmittedCentralReport(int organizationId,
            ReportingPeriod reportingPeriod,
            int pastTermCycle = 1);

        ReportData GetGeneratedData(int organizationId, ReportingPeriod reportingPeriod);
        CentralReport[] GetCentralReports(int[] reportIds);
        //ReportData GetGeneratedDataZoneAndUnit(int organizationId, ReportingPeriod reportingPeriod);
    }
}