using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices
{
    public interface IOrganizationQueryService
    {
        SearchResult<OrganizationViewModel> SearchOrganization(OrganizationSearchTerms searchTerms);
        OrganizationViewModel GetOrganizationViewModel(int organizationId);
        int[] GetManagedOrganizationIds(int organizationId);
        OrganizationViewModel[] GetManagedOrganizations(int organizationId);
        OrganizationViewModel[] GetMyOrganizations();
        ReportingPeriodViewModel[] GetReportingPeriods(int organizationId);
    }
}