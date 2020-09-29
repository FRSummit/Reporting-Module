using System.Linq;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    internal static class OrganizationQueryServiceExtensions
    {
        internal static IQueryable<OrganizationViewModel> ApplyQuickSearch(
            this IQueryable<OrganizationViewModel> query,
            string quickSearch) 
        {
            return string.IsNullOrWhiteSpace(quickSearch)
                ? query
                : query.Where(x => x.Description.Contains(quickSearch));
        }

        internal static IQueryable<OrganizationViewModel> ApplyOrganizationTypeSearch(
            this IQueryable<OrganizationViewModel> query,
            OrganizationType? organizationType)
        {
            return organizationType == null
                ? query
                : query.Where(x => x.OrganizationType == organizationType.Value);
        }



    }
}