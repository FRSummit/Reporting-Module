using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public interface IExcelReportFactory
    {
        byte[] CreateExcelReport(SearchResult<UnitReportViewModel> data);
        byte[] CreateExcelReport(UnitReportViewModel data);
        byte[] CreateExcelReport(SearchResult<ZoneReportViewModel> data);
        byte[] CreateExcelReport(ZoneReportViewModel data);
        byte[] CreateExcelReport(SearchResult<StateReportViewModel> data);
        byte[] CreateExcelReport(StateReportViewModel data);
        byte[] CreateExcelReport(SearchResult<CentralReportViewModel> data);
        byte[] CreateExcelReport(CentralReportViewModel data);
        byte[] CreateExcelReport(SearchResult<ExcelReportData> data);
    }
}