using System.Collections.Generic;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices
{
    public interface IOrganizationUserQueryService
    {
        SearchResult<OrganizationUserViewModel> SearchOrganizationUser(OrganizationUserSearchTerms searchTerms);
        IEnumerable<OrganizationUserViewModel> GetByUsername(string username);
        bool HasCentralAccess(string username);
    }
}