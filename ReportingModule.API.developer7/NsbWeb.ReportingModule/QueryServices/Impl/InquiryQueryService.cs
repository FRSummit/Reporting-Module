using NHibernate;
using NsbWeb.Core;
using NsbWeb.ReportingModule.Configuration;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ViewModels.Extensions;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public class InquiryQueryService : IInquiryQueryService
    {
        private const int DefaultPageSize = 10;

        private readonly ISession _session;
        private readonly IUserContext _userContext;
        private readonly IExcelReportFactory _excelReportFactory;

        public InquiryQueryService(IReportingModuleSession customerReportingInterfaceSession, IUserContext userContext, IExcelReportFactory excelReportFactory)
        {
            _userContext = userContext;
            _excelReportFactory = excelReportFactory;
            _session = customerReportingInterfaceSession.Session;
        }

        public byte[] SearchUnitReport(UnitReportInquirySearchTerms searchTerms)
        {
            var result = _session.Query<UnitReportViewModel>()
                .ApplyOrganizationReferenceFilter(_userContext)
            .ApplyOnlyReportFilter()
            .ApplyQuickSearch(searchTerms.QuickSearch)
            .ApplyTimestampFromSearch(searchTerms.TimestampFrom)
            .ApplyTimestampToSearch(searchTerms.TimestampTo)
            .FetchSimpleSearchResult(searchTerms.PagingData ?? new PagingData(1, DefaultPageSize, 0));

            return _excelReportFactory.CreateExcelReport(result);
        }
    }




}