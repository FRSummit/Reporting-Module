using System.Linq;
using System.Threading.Tasks;
using NServiceBus.MessageMutator;
using ReportingModule.Core.Metadata;
using ReportingModule.Core.Nsb7;

namespace NsbWeb.ReportingModule.Configuration
{
    public class OnForwardMessageHeadersFromIncomingMessageToOutgoingMessageMutator : IMutateOutgoingTransportMessages
    {
        public Task MutateOutgoing(MutateOutgoingTransportMessageContext context)
        {
            if (context == null) return Task.CompletedTask;
            if (!context.TryGetIncomingHeaders(out var incomingHeaders)) return Task.CompletedTask;

            var incomingHeadersOfInterest = incomingHeaders.Where(h => MetaDataConstants.AllConstants.Contains(h.Key));
            context.OutgoingHeaders.AddHeadersIfDoNotExist(incomingHeadersOfInterest);

            return Task.CompletedTask;
        }
    }
}