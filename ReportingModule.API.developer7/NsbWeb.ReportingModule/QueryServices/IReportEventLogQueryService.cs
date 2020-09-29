using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices
{
    public interface IReportEventLogQueryService
    {
        SearchResult<ReportEventLogViewModel> SearchReportEventLog(ReportEventLogSearchTerms searchTerms);
    }
}