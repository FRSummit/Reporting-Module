using System;
using System.Linq;
using NsbWeb.Core;
using NsbWeb.ReportingModule.ViewModels;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    internal static class ReportEventLogQueryServiceExtensions
    {
        internal static IQueryable<ReportEventLogViewModel> ApplyOrganizationFilter(
            this IQueryable<ReportEventLogViewModel> query,
            IUserContext userContext) 
        {
            return userContext.CurrentUserCanAccessAllOrganizations()
                ? query
                : query.Where(x => x.OrganizationId != null && userContext.GetOrganizationIds().Contains((int)x.OrganizationId));
        }

        internal static IQueryable<ReportEventLogViewModel> ApplyQuickSearch(
            this IQueryable<ReportEventLogViewModel> query,
            string quickSearch)
        {
            return string.IsNullOrWhiteSpace(quickSearch)
                ? query
                : query.Where(o => o.Message.Contains(quickSearch));
        }

        internal static IQueryable<ReportEventLogViewModel> ApplyTimestampFromSearch(
            this IQueryable<ReportEventLogViewModel> query,
            DateTime? timestampFrom)
        {
            return timestampFrom == null
                ? query
                : query.Where(o => o.Timestamp >= timestampFrom.Value.ToUniversalTime());
        }

        internal static IQueryable<ReportEventLogViewModel> ApplyTimestampToSearch(
            this IQueryable<ReportEventLogViewModel> query,
            DateTime? timestampTo)
        {
            return timestampTo == null
                ? query
                : query.Where(o => o.Timestamp < timestampTo.Value.ToUniversalTime());
        }


    }
}