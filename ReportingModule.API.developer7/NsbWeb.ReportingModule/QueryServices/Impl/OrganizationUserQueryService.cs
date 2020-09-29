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
    public class OrganizationUserQueryService : IOrganizationUserQueryService
    {
        private const int DefaultPageSize = 10;

        private readonly ISession _session;
        private readonly IUserContext _userContext;
        private const string Central = "Central";

        public OrganizationUserQueryService(IReportingModuleSession customerReportingInterfaceSession,
            IUserContext userContext)
        {
            _userContext = userContext;
            _session = customerReportingInterfaceSession.Session;
        }

        public SearchResult<OrganizationUserViewModel> SearchOrganizationUser(OrganizationUserSearchTerms searchTerms)
        {
            return _session.Query<OrganizationUserViewModel>()
                .ApplyOrganizationFilter(_userContext)
                .ApplyOrderBy(searchTerms.OrderBy)
                .FetchSimpleSearchResult(searchTerms.PagingData ?? new PagingData(1, DefaultPageSize, 0));
        }

     
        public IEnumerable<OrganizationUserViewModel> GetByUsername(string username)
        {
            return _session.Query<OrganizationUserViewModel>()
                .Where(o => o.Username == username)
                .ToArray();
        }

        public bool HasCentralAccess(string username)
        {
            return GetByUsername(username).Any(o => o.Organization.Description == Central);
        }
    }

    public static class OrganizationUserQueryServiceExtensions
    {
        internal static IQueryable<OrganizationUserViewModel> ApplyOrderBy(
            this IQueryable<OrganizationUserViewModel> query,
            OrganizationUserOrderBy orderBy)
        {
            return orderBy == OrganizationUserOrderBy.UserName
                    ? query.OrderBy(o => o.Username)
                        .ThenBy(o => o.Organization.Description)
                    : query.OrderBy(o => o.Organization.Description)
                        .ThenBy(o => o.Username);
        }
    }
}

