using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.QueryServices
{
    public interface IUnitReportQueryService
    {
        UnitReportViewModel GetUnitReportViewModel(int reportId);
        UnitPlanViewModel GetUnitPlanViewModel(int planId);

        byte[] DownloadUnitReportViewModel(int reportId, ExcelReportType excelReportType);
    }
}