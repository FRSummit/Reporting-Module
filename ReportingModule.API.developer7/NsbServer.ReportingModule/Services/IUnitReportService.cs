using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    public interface IUnitReportService
    {
        UnitReport PromotePlanToUnitReport(int reportId);
        UnitReport PromotePlanToUnitReportAi(int reportId);
      
        UnitReport GetSubmittedUnitReportOfPreviousTerm(int organizationId,
            ReportingPeriod reportingPeriod);
        UnitReport[] GetAllUnitReports(ReportingPeriod reportingPeriod, Organization[] organizations);
        UnitReport[] GetOnlyRecentUnitReports(ReportingPeriod reportingPeriod, Organization[] organizations);
        UnitReport[] GetUnitReports(int[] reportIds);

    }
}