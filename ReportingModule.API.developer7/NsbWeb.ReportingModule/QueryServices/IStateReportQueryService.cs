using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.QueryServices
{
    public interface IStateReportQueryService
    {
        StateReportViewModel GetStateReportViewModel(int reportId);
        StatePlanViewModel GetStatePlanViewModel(int planId);
        byte[] DownloadStateReportViewModel(int reportId, ExcelReportType excelReportType);

    }
}