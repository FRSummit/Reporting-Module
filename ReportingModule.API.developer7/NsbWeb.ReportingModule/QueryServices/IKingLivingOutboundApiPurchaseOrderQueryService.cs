using System;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices
{
    public interface IKingLivingOutboundApiPurchaseOrderQueryService
    {
        SearchResult<KingLivingOutboundApiPurchaseOrderViewModel> Search(KingLivingOutboundApiPurchaseOrderSearchTerms searchTerms);
    }

    public class KingLivingOutboundApiPurchaseOrderSearchTerms : GridSearchTerms
    {
        public string QuickSearch { get; set; }
        public DateTime? TimestampFrom { get; set; }
        public DateTime? TimestampTo { get; set; }
        public KingLivingInterfaceStatus? Status { get; set; }

    }

    public enum KingLivingInterfaceStatus
    {
        All = 0,
        Success = 1,
        Failure = 2
    }
}