using System;
using System.Linq;
using NHibernate;
using NsbWeb.ReportingModule.Configuration;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ViewModels.Extensions;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public class KingLivingOutboundApiPurchaseOrderQueryService : IKingLivingOutboundApiPurchaseOrderQueryService
    {
        private const int DefaultPageSize = 10;

        private readonly ISession _session;

        public KingLivingOutboundApiPurchaseOrderQueryService(IReportingModuleSession customerReportingInterfaceSession)
        {
            _session = customerReportingInterfaceSession.Session;
        }

        public SearchResult<KingLivingOutboundApiPurchaseOrderViewModel> Search(KingLivingOutboundApiPurchaseOrderSearchTerms searchTerms)
        {
            return _session.Query<KingLivingOutboundApiPurchaseOrderViewModel>()
                .ApplySearchTerms(searchTerms)
                .OrderByDescending(o => o.Timestamp)
                .FetchSimpleSearchResult(searchTerms.PagingData ?? new PagingData(1, DefaultPageSize, 0));
        }
    }

    internal static class KingLivingOutboundApiPurchaseOrderQueryServiceExtensions
    {
        internal static IQueryable<KingLivingOutboundApiPurchaseOrderViewModel> ApplySearchTerms(
            this IQueryable<KingLivingOutboundApiPurchaseOrderViewModel> query,
            KingLivingOutboundApiPurchaseOrderSearchTerms searchTerms)
        {
            return query
                .ApplyQuickSearch(searchTerms.QuickSearch)
                .ApplyStatusSearch(searchTerms.Status)
                .ApplyTimestampFromSearch(searchTerms.TimestampFrom)
                .ApplyTimestampToSearch(searchTerms.TimestampTo);
        }

        internal static IQueryable<KingLivingOutboundApiPurchaseOrderViewModel> ApplyStatusSearch(
            this IQueryable<KingLivingOutboundApiPurchaseOrderViewModel> query,
            KingLivingInterfaceStatus? status)
        {
            if (status == null || status == KingLivingInterfaceStatus.All)
                return query;

            switch (status.Value)
            {
                case KingLivingInterfaceStatus.Success:
                    return query.Where(o => !o.ErrorsInternal.Any());
                default:
                    return query.Where(o => o.ErrorsInternal.Any());
            }
        }


        internal static IQueryable<KingLivingOutboundApiPurchaseOrderViewModel> ApplyQuickSearch(
            this IQueryable<KingLivingOutboundApiPurchaseOrderViewModel> query,
            string quickSearch)
        {
            return string.IsNullOrWhiteSpace(quickSearch)
                ? query
                : query.Where(o => o.CustomerPo.Contains(quickSearch)
                                   || o.ApiData.Contains(quickSearch));
        }

        internal static IQueryable<KingLivingOutboundApiPurchaseOrderViewModel> ApplyTimestampFromSearch(
            this IQueryable<KingLivingOutboundApiPurchaseOrderViewModel> query,
            DateTime? timestampFrom)
        {
            return timestampFrom == null
                ? query
                : query.Where(o => o.Timestamp >= timestampFrom.Value.ToUniversalTime());
        }

        internal static IQueryable<KingLivingOutboundApiPurchaseOrderViewModel> ApplyTimestampToSearch(
            this IQueryable<KingLivingOutboundApiPurchaseOrderViewModel> query,
            DateTime? timestampTo)
        {
            return timestampTo == null
                ? query
                : query.Where(o => o.Timestamp < timestampTo.Value.ToUniversalTime());
        }
    }
}