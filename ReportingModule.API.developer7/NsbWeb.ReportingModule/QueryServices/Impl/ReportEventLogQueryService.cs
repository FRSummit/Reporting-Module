using NHibernate;
using NsbWeb.Core;
using NsbWeb.ReportingModule.Configuration;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ViewModels.Extensions;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public class ReportEventLogQueryService : IReportEventLogQueryService
    {
        private const int DefaultPageSize = 10;

        private readonly ISession _session;
        private readonly IUserContext _userContext;

        public ReportEventLogQueryService(IReportingModuleSession customerReportingInterfaceSession,
            IUserContext userContext)
        {
            _userContext = userContext;
            _session = customerReportingInterfaceSession.Session;
        }

        public SearchResult<ReportEventLogViewModel> SearchReportEventLog(ReportEventLogSearchTerms searchTerms)
        {
            return _session.Query<ReportEventLogViewModel>()
                .ApplyOrganizationFilter(_userContext)
                .ApplyQuickSearch(searchTerms.QuickSearch)
                .ApplyTimestampFromSearch(searchTerms.TimestampFrom)
                .ApplyTimestampToSearch(searchTerms.TimestampTo)
                .FetchSimpleSearchResult(searchTerms.PagingData ?? new PagingData(1, DefaultPageSize, 0));
        }
    }
}