using System;
using System.Linq;
using NHibernate;
using NsbWeb.Core;
using NsbWeb.ReportingModule.Configuration;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ValueObjects;
using ReportingModule.ViewModels.Extensions;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public class AllReportQueryService : IAllReportQueryService
    {
        private const int DefaultPageSize = 10;
        private const int QueryDefaultPageSize = 100;
        private const int ExcelDefaultPageSize = 1000;

        private readonly ISession _session;
        private readonly IUserContext _userContext;
        private readonly IExcelReportFactory _excelReportFactory;
        private readonly IOrganizationUserQueryService _organizationUserQueryService;
        private readonly IOrganizationQueryService _organizationQueryService;

        public AllReportQueryService(IReportingModuleSession customerReportingInterfaceSession, IUserContext userContext, IExcelReportFactory excelReportFactory, IOrganizationUserQueryService organizationUserQueryService, IOrganizationQueryService organizationQueryService)
        {
            _userContext = userContext;
            _excelReportFactory = excelReportFactory;
            _session = customerReportingInterfaceSession.Session;
            _organizationUserQueryService = organizationUserQueryService;
            _organizationQueryService = organizationQueryService;
        }

        public SearchResult<ReportViewModel> Search(AllReportSearchTerms searchTerms)
        {
            return _session.Query<ReportViewModel>()
                .ApplyOrganizationReferenceFilter(_userContext)
                .ApplyQuickSearch(searchTerms.QuickSearch)
                .ApplyTimestampFromSearch(searchTerms.TimestampFrom)
                .ApplyTimestampToSearch(searchTerms.TimestampTo)
                .ApplyReportingPeriodStartDateFromSearch(searchTerms.ReportingPeriodStartDateFrom)
                .ApplyReportingPeriodEndDateToSearch(searchTerms.ReportingPeriodEndDateTo)
                .ApplyReportStatusSearch(searchTerms.Status)
                .ApplyOrganizationTypeSearch(searchTerms.OrganizationalType)
                .ApplyReportingFrequencySearch(searchTerms.ReportingFrequency)
                .ApplyReportingTermSearch(searchTerms.ReportingTerm)
                .ApplyMyReportSearch(searchTerms.MyReports ? _organizationUserQueryService.GetByUsername(UserContext.GetLoggedInUsername()).Select(s => s.Organization.Id) : new int[0])
                .ApplyParentSearch(searchTerms.Parent, searchTerms.Parent.HasValue ?
                    _organizationQueryService.GetManagedOrganizationIds(searchTerms.Parent.Value)
                    : new int[0])
                .ApplyOrganizationSearch(searchTerms.Organization)
                .OrderByDescending(o => o.ReportingPeriod.StartDate)
                .ThenBy(o => o.Organization.OrganizationType)
                .ThenBy(o => o.Organization.Description)
                .FetchSimpleSearchResult(searchTerms.PagingData ?? new PagingData(1, DefaultPageSize, 0));
        }


        public SearchResult<ReportQueryViewModel> Query(AllReportSearchTerms searchTerms)
        {
            var pageSize = QueryDefaultPageSize;

            return _session.Query<ReportViewModel>()
                .ApplyOrganizationReferenceFilter(_userContext)
                .ApplyQuickSearch(searchTerms.QuickSearch)
                .ApplyTimestampFromSearch(searchTerms.TimestampFrom)
                .ApplyTimestampToSearch(searchTerms.TimestampTo)
                .ApplyReportingPeriodStartDateFromSearch(searchTerms.ReportingPeriodStartDateFrom)
                .ApplyReportingPeriodEndDateToSearch(searchTerms.ReportingPeriodEndDateTo)
                .ApplyReportStatusSearch(searchTerms.Status)
                .ApplyOrganizationTypeSearch(searchTerms.OrganizationalType)
                .ApplyReportingFrequencySearch(searchTerms.ReportingFrequency)
                .ApplyReportingTermSearch(searchTerms.ReportingTerm)
                .ApplyMyReportSearch(searchTerms.MyReports ? _organizationUserQueryService.GetByUsername(UserContext.GetLoggedInUsername()).Select(s => s.Organization.Id) : Array.Empty<int>())
                .ApplyParentSearch(searchTerms.Parent, searchTerms.Parent.HasValue ?
                    _organizationQueryService.GetManagedOrganizationIds(searchTerms.Parent.Value)
                    : new int[0])
                .ApplyOrganizationSearch(searchTerms.Organization)
                .OrderByDescending(o => o.ReportingPeriod.StartDate)
                .ThenBy(o => o.Organization.OrganizationType)
                .ThenBy(o => o.Organization.Description)
                .Select(o => new ReportQueryViewModel() { Id = o.Id, Organization = o.Organization })
                .FetchSimpleSearchResult(searchTerms.PagingData ?? new PagingData(1, pageSize, 0));
        }

        public SearchResult<ReportViewModel> SearchPlan(AllReportSearchTerms searchTerms)
        {
            return _session.Query<ReportViewModel>()
                .ApplyOrganizationReferenceFilter(_userContext)
                .ApplyOnlyPlanFilter()
                .ApplyQuickSearch(searchTerms.QuickSearch)
                .ApplyTimestampFromSearch(searchTerms.TimestampFrom)
                .ApplyTimestampToSearch(searchTerms.TimestampTo)
                .ApplyReportingPeriodStartDateFromSearch(searchTerms.ReportingPeriodStartDateFrom)
                .ApplyReportingPeriodEndDateToSearch(searchTerms.ReportingPeriodEndDateTo)
                .ApplyOrganizationTypeSearch(searchTerms.OrganizationalType)
                .ApplyReportingFrequencySearch(searchTerms.ReportingFrequency)
                .ApplyReportingTermSearch(searchTerms.ReportingTerm)
                .ApplyMyReportSearch(searchTerms.MyReports ? _organizationUserQueryService.GetByUsername(UserContext.GetLoggedInUsername()).Select(s => s.Organization.Id) : Array.Empty<int>())
                .ApplyParentSearch(searchTerms.Parent, searchTerms.Parent.HasValue ?
                    _organizationQueryService.GetManagedOrganizationIds(searchTerms.Parent.Value)
                    : new int[0])
                .ApplyOrganizationSearch(searchTerms.Organization)
                .FetchSimpleSearchResult(searchTerms.PagingData ?? new PagingData(1, DefaultPageSize, 0));
        }

        public SearchResult<ReportViewModel> SearchReport(AllReportSearchTerms searchTerms)
        {
            return _session.Query<ReportViewModel>()
                .ApplyOrganizationReferenceFilter(_userContext)
                .ApplyOnlyReportFilter()
                .ApplyQuickSearch(searchTerms.QuickSearch)
                .ApplyTimestampFromSearch(searchTerms.TimestampFrom)
                .ApplyTimestampToSearch(searchTerms.TimestampTo)
                .ApplyReportingPeriodStartDateFromSearch(searchTerms.ReportingPeriodStartDateFrom)
                .ApplyReportingPeriodEndDateToSearch(searchTerms.ReportingPeriodEndDateTo)
                .ApplyOrganizationTypeSearch(searchTerms.OrganizationalType)
                .ApplyReportingFrequencySearch(searchTerms.ReportingFrequency)
                .ApplyReportingTermSearch(searchTerms.ReportingTerm)
                .ApplyMyReportSearch(searchTerms.MyReports ? _organizationUserQueryService.GetByUsername(UserContext.GetLoggedInUsername()).Select(s => s.Organization.Id) : Array.Empty<int>())
                .ApplyParentSearch(searchTerms.Parent, searchTerms.Parent.HasValue ?
                    _organizationQueryService.GetManagedOrganizationIds(searchTerms.Parent.Value)
                    : new int[0])
                .ApplyOrganizationSearch(searchTerms.Organization)
                .FetchSimpleSearchResult(searchTerms.PagingData ?? new PagingData(1, DefaultPageSize, 0));
        }

        public byte[] Download(AllReportSearchTerms searchTerms)
        {
            searchTerms.Page = 1;
            searchTerms.PageSize = ExcelDefaultPageSize;
            var searchResult = Search(searchTerms);
            var excelReportDataSearchResult = GetExcelReportDataSearchResult(searchResult);
            return _excelReportFactory.CreateExcelReport(excelReportDataSearchResult);
        }


        public byte[] DownloadPlan(AllReportSearchTerms searchTerms)
        {
            searchTerms.Page = 1;
            searchTerms.PageSize = ExcelDefaultPageSize;
            var searchResult = SearchPlan(searchTerms);
            var excelReportDataSearchResult = GetExcelReportDataSearchResult(searchResult);
            return _excelReportFactory.CreateExcelReport(excelReportDataSearchResult);
        }

        public byte[] DownloadReport(AllReportSearchTerms searchTerms)
        {
            searchTerms.Page = 1;
            searchTerms.PageSize = ExcelDefaultPageSize;
            var searchResult = SearchReport(searchTerms);
            var excelReportDataSearchResult = GetExcelReportDataSearchResult(searchResult);
            return _excelReportFactory.CreateExcelReport(excelReportDataSearchResult);
        }

        private SearchResult<ExcelReportData> GetExcelReportDataSearchResult(SearchResult<ReportViewModel> searchResult)
        {
            var items = searchResult.Items.GroupBy(o => o.Organization.OrganizationType)
                 .SelectMany((o, g) =>
                 {
                     var ids = o.Select(r => r.Id).ToArray();
                     switch (o.Key)
                     {
                         case OrganizationType.Unit:
                             return _session.Query<UnitReportViewModel>()
                                 .Where(r => ids.Contains(r.Id))
                                 .ToArray()
                                 .Select(ExcelReportDataTranslator.ToExcelReportData)
                                 .ToArray();
                         case OrganizationType.Zone:
                             return _session.Query<ZoneReportViewModel>()
                                 .Where(r => ids.Contains(r.Id))
                                 .ToArray()
                                 .Select(ExcelReportDataTranslator.ToExcelReportData)
                                 .ToArray();
                         case OrganizationType.State:
                             return _session.Query<StateReportViewModel>()
                                 .Where(r => ids.Contains(r.Id))
                                 .ToArray()
                                 .Select(ExcelReportDataTranslator.ToExcelReportData)
                                 .ToArray();
                         case OrganizationType.Central:
                             return _session.Query<CentralReportViewModel>()
                                 .Where(r => ids.Contains(r.Id))
                                 .ToArray()
                                 .Select(ExcelReportDataTranslator.ToExcelReportData)
                                 .ToArray();
                         default:
                             return new ExcelReportData[0];
                     }
                 });

            return new SearchResult<ExcelReportData>(items, searchResult.PagingData);
        }
    }


}