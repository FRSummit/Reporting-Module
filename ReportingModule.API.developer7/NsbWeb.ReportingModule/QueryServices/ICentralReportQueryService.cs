using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ValueObjects;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices
{
    public interface ICentralReportQueryService
    {
        CentralReportViewModel GetCentralReportViewModel(int reportId);
        CentralPlanViewModel GetCentralPlanViewModel(int planId);

        byte[] DownloadCentralReportViewModel(int reportId, ExcelReportType excelReportType);
    }
}