using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace NsbWeb.ReportingModule.ViewModels
{
    public class KingLivingOutboundApiPurchaseOrderViewModel
    {
        protected KingLivingOutboundApiPurchaseOrderViewModel()
        {
        }

        public Guid OperationId { get; private set; }
        public string CustomerPo { get; private set; }
        public string Url { get; private set; }
        public string ApiData { get; private set; }
        public DateTime Timestamp { get; private set; }
        public bool HasErrors => _errorsInternal.Any();
        public string[] Errors => _errorsInternal.ToArray();

        protected internal IEnumerable<string> ErrorsInternal => _errorsInternal;
        private readonly ICollection<string> _errorsInternal = new List<string>();
    }
}