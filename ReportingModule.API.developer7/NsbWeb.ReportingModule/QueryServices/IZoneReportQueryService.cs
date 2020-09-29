using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.QueryServices
{
    public interface IZoneReportQueryService
    {
        ZoneReportViewModel GetZoneReportViewModel(int reportId);
        ZonePlanViewModel GetZonePlanViewModel(int planId);

        byte[] DownloadZoneReportViewModel(int reportId, ExcelReportType excelReportType);
    }

    
}