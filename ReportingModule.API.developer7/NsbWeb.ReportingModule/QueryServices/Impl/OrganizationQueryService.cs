using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NsbWeb.Core;
using NsbWeb.ReportingModule.Configuration;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ViewModels.Extensions;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public class OrganizationQueryService : IOrganizationQueryService
    {
        private const int DefaultPageSize = 10;

        private readonly ISession _session;
        private readonly IUserContext _userContext;
        private readonly IReportingPeriodQueryService _reportingPeriodQueryService;

        public OrganizationQueryService(IReportingModuleSession customerReportingInterfaceSession, IUserContext userContext, IReportingPeriodQueryService reportingPeriodQueryService)
        {
            _userContext = userContext;
            _reportingPeriodQueryService = reportingPeriodQueryService;
            _session = customerReportingInterfaceSession.Session;
        }

        public SearchResult<OrganizationViewModel> SearchOrganization(OrganizationSearchTerms searchTerms)
        {
            return _session.Query<OrganizationViewModel>()
                .ApplyQuickSearch(searchTerms.QuickSearch)
                .ApplyOrganizationTypeSearch(searchTerms.OrganizationType)
                .OrderBy(o => o.Parent.Description)
                .ThenBy(o => o.OrganizationType)
                .ThenBy(o => o.Description)
                .FetchSimpleSearchResult(searchTerms.PagingData ?? new PagingData(1, DefaultPageSize, 0));
        }

        public OrganizationViewModel GetOrganizationViewModel(int organizationId)
        {
            var org = _session.Get<OrganizationViewModel>(organizationId);
            var managedOrganizations = GetManagedOrganizations(org.Id).ToList();
            managedOrganizations.ForEach(o => org.AddOrganizationReference(o));
            return org;
        }

        public OrganizationViewModel[] GetManagedOrganizations(int id)
        {
            var organizations = _session.Query<OrganizationViewModel>().ToArray();
            var recursiveList = organizations
                .Where(x => x.Id == id)
                .SelectMany(c => GetChildren(c, organizations)).ToArray();

            return recursiveList.Select(o => o).Distinct().ToArray();

        }
        public int[] GetManagedOrganizationIds(int id)
        {
            var organizations = _session.Query<OrganizationViewModel>().ToArray();
            var recursiveList = organizations
                .Where(x => x.Id == id)
                .SelectMany(c => GetChildren(c, organizations)).ToArray();

            return recursiveList.Select(o => o.Id).Distinct().ToArray();

        }

        public int[] GetManagedOrganizationIds(int[] ids)
        {
            var organizations = _session.Query<OrganizationViewModel>().ToArray();
            var recursiveList = ids.SelectMany(id => organizations
               .Where(x => x.Id == id)
               .SelectMany(c => GetChildren(c, organizations))
               .ToArray()
            ).ToArray();

            return recursiveList.Select(o => o.Id).Distinct().ToArray();

        }

        IEnumerable<OrganizationViewModel> GetChildren(OrganizationViewModel parent, IEnumerable<OrganizationViewModel> orgs)
        {
            var organizationViewModels = orgs as OrganizationViewModel[] ?? orgs.ToArray();
            var anchor = organizationViewModels.Where(o => o.Parent.Id == parent.Id).ToArray();
            foreach (var organizationViewModel in anchor)
                yield return organizationViewModel;

            var selectMany = anchor.SelectMany(c => GetChildren(c, organizationViewModels));
            foreach (var organizationViewModel in selectMany)
                yield return organizationViewModel;
        }

        public OrganizationViewModel[] GetMyOrganizations()
        {
            if (_userContext.CurrentUserCanAccessAllOrganizations())
                return _session.Query<OrganizationViewModel>()
                    .OrderBy(o => o.Parent.Description)
                    .ThenBy(o => o.OrganizationType)
                    .ThenBy(o => o.Description).ToArray();

            var organizationIds = _session.Query<OrganizationUserViewModel>().Where(o => o.Username == _userContext.Username).Select(o => o.Organization.Id).ToArray();

            var organizations = _session.Query<OrganizationViewModel>().Where(o => organizationIds.Contains(o.Id))
                .ToArray();
            var managedOrganizations = organizations.SelectMany(o =>
                GetManagedOrganizations(o.Id).ToArray()
            ).ToArray();

            return organizations.Concat(managedOrganizations)
                .ToArray()
                .Distinct()
                .ToArray()
                .OrderBy(o => o.Parent.Description)
                .ThenBy(o => o.OrganizationType)
                .ThenBy(o => o.Description)
                .Select(o => o)
                .ToArray();
        }

        //remove this once call is made to the reportingperiodcontroller
        public ReportingPeriodViewModel[] GetReportingPeriods(int organizationId)
        {
            return _reportingPeriodQueryService.GetReportingPeriods(organizationId);
        }
    }
}