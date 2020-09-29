using NsbWeb.ReportingModule.ViewModels;

namespace NsbWeb.ReportingModule.QueryServices
{
    public interface IReportingPeriodQueryService
    {
        ReportingPeriodViewModel GetNextReportingPeriod(int reportId);
        ReportingPeriodViewModel[] GetReportingPeriods(int organizationId);
    }
}