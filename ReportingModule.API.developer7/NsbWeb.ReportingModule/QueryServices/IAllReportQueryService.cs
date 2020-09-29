using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices
{
    public interface IAllReportQueryService
    {
        SearchResult<ReportViewModel> Search(AllReportSearchTerms searchTerms);
        SearchResult<ReportViewModel> SearchPlan(AllReportSearchTerms searchTerms);
        SearchResult<ReportViewModel> SearchReport(AllReportSearchTerms searchTerms);
        SearchResult<ReportQueryViewModel> Query(AllReportSearchTerms searchTerms);


        byte[] Download(AllReportSearchTerms searchTerms);
        byte[] DownloadPlan(AllReportSearchTerms searchTerms);
        byte[] DownloadReport(AllReportSearchTerms searchTerms);
        
    }
}

