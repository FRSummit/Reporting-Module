using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    public interface IStateReportService
    {
        StateReport PromotePlanToStateReport(int reportId);
        StateReport GetLastSubmittedStateReport(int organizationId,
            ReportingPeriod reportingPeriod,
            int pastTermCycle = 1);

        ReportData GetGeneratedData(int organizationId, ReportingPeriod reportingPeriod);

        StateReport[] GetAllStateReports(ReportingPeriod reportingPeriod, Organization[] organizations);
        StateReport[] GetOnlyRecentStateReports(ReportingPeriod reportingPeriod, Organization[] organizations);
        StateReport[] GetStateReports(int[] reportIds);

        //ReportData GetGeneratedDataZoneAndUnit(int organizationId, ReportingPeriod reportingPeriod);
    }
}