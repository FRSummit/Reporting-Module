using System;
using System.Collections.Generic;
using System.Linq;
using NsbWeb.Core;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public static class QueryServiceExtensions
    {
        internal static IQueryable<T> ApplyOrganizationFilter<T>(
            this IQueryable<T> query,
            IUserContext userContext) where T : IOrganizationFilter
        {
            return userContext.CurrentUserCanAccessAllOrganizations()
                ? query
                : query.Where(x => userContext.GetOrganizationIds().Contains(x.Organization.Id));
        }

        internal static IQueryable<T> ApplyOrganizationReferenceFilter<T>(
            this IQueryable<T> query,
            IUserContext userContext) where T : IOrganizationReferenceFilter
        {
            return userContext.CurrentUserCanAccessAllOrganizations()
            ? query
             : query.Where(x => userContext.GetOrganizationIds().Contains(x.Organization.Id));
        }

        internal static IQueryable<T> ApplyQuickSearch<T>(
            this IQueryable<T> query,
            string quickSearch) where T : IReportSearchTermsFilter
        {
            return string.IsNullOrWhiteSpace(quickSearch)
                ? query
                : query.Where(o => o.Description.Contains(quickSearch));
        }

        internal static IQueryable<T> ApplyTimestampFromSearch<T>(
            this IQueryable<T> query,
            DateTime? timestampFrom) where T : IReportSearchTermsFilter
        {
            return timestampFrom == null
                ? query
                : query.Where(o => o.Timestamp >= timestampFrom.Value.ToUniversalTime());
        }

        internal static IQueryable<T> ApplyTimestampToSearch<T>(
            this IQueryable<T> query,
            DateTime? timestampTo) where T : IReportSearchTermsFilter
        {
            return timestampTo == null
                ? query
                : query.Where(o => o.Timestamp < timestampTo.Value.ToUniversalTime());
        }

        internal static IQueryable<T> ApplyReportStatusSearch<T>(
            this IQueryable<T> query,
            ReportStatus? reportStatus) where T : IReportSearchTermsFilter
        {
            return reportStatus == null
                ? query
                : query.Where(o => o.ReportStatus == reportStatus);
        }

        internal static IQueryable<T> ApplyOrganizationTypeSearch<T>(
            this IQueryable<T> query,
            OrganizationType? organizationType) where T : IOrganizationReferenceFilter
        {
            return organizationType == null
                ? query
                : query.Where(o => o.Organization.OrganizationType == organizationType);
        }

        internal static IQueryable<T> ApplyReportingFrequencySearch<T>(
            this IQueryable<T> query,
            ReportingFrequency? reportingFrequency) where T : IReportSearchTermsFilter
        {
            return reportingFrequency == null
                ? query
                : query.Where(o => o.ReportingPeriod.ReportingFrequency == reportingFrequency);
        }
        internal static IQueryable<T> ApplyReportingTermSearch<T>(
           this IQueryable<T> query,
           ReportingTerm? reportingTerm) where T : IReportSearchTermsFilter
        {
            return reportingTerm == null
                ? query
                : query.Where(o => o.ReportingPeriod.ReportingTerm == reportingTerm);
        }

        internal static IQueryable<T> ApplyMyReportSearch<T>(
           this IQueryable<T> query, IEnumerable<int> myOrganizationIds) where T : IReportSearchTermsFilter
        {
            var organizationIds = myOrganizationIds as int[] ?? myOrganizationIds.ToArray();
            return organizationIds.Any() ? query.Where(x => organizationIds.Contains(x.Organization.Id)) : query;
        }

        internal static IQueryable<T> ApplyOrganizationSearch<T>(
            this IQueryable<T> query,
            int? organizationId) where T : IOrganizationReferenceFilter
        {
            return (organizationId.HasValue && organizationId.Value > 0)
                ? query.Where(o => o.Organization.Id == organizationId.Value)
                : query;
        }

        internal static IQueryable<T> ApplyParentSearch<T>(
            this IQueryable<T> query, int? parent,
            int[] organizationIds) where T : IOrganizationReferenceFilter
        {
            var orgIds = organizationIds == null ? new int[0] : organizationIds.ToArray();
            return parent.HasValue ? query.Where(x => orgIds.Contains(x.Organization.Id)) : query;
        }

        internal static IQueryable<T> ApplyOnlyReportFilter<T>(
            this IQueryable<T> query) where T : IReportSearchTermsFilter
        {
            return query.Where(x => x.ReportStatus >= ReportStatus.PlanPromoted);
        }
        internal static IQueryable<T> ApplyOnlyReportFilter<T>(
            this IQueryable<T> query, IUserContext userContext) where T : IReportSearchTermsFilter
        {
            if (userContext.CurrentUserIsSystemAdmin())
                return query.Where(x => x.ReportStatus >= ReportStatus.Draft);
            return query.Where(x => x.ReportStatus >= ReportStatus.PlanPromoted);
        }

        internal static IQueryable<T> ApplyOnlyPlanFilter<T>(
            this IQueryable<T> query) where T : IReportSearchTermsFilter
        {
            return query.Where(x => x.ReportStatus >= ReportStatus.Draft);
        }

        internal static IQueryable<T> ApplyReportingPeriodStartDateFromSearch<T>(
            this IQueryable<T> query,
            DateTime? reportingPeriodStartDateFrom) where T : IReportSearchTermsFilter
        {
            return reportingPeriodStartDateFrom == null
                ? query
                : query.Where(o => o.ReportingPeriod.StartDate >= reportingPeriodStartDateFrom.Value.ToUniversalTime());
        }

        internal static IQueryable<T> ApplyReportingPeriodEndDateToSearch<T>(
            this IQueryable<T> query,
            DateTime? reportingPeriodEndDateTo) where T : IReportSearchTermsFilter
        {
            return reportingPeriodEndDateTo == null
                ? query
                : query.Where(o => o.ReportingPeriod.EndDate < reportingPeriodEndDateTo.Value.ToUniversalTime());
        }

    }
}