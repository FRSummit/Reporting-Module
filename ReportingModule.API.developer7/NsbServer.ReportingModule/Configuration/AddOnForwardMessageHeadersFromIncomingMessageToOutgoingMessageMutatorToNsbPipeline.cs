using System.Linq;
using System.Threading.Tasks;
using log4net;
using NServiceBus;
using NServiceBus.MessageMutator;
using ReportingModule.Core.Metadata;
using ReportingModule.Core.Nsb7;

namespace ReportingModule.Configuration
{
    // ReSharper disable once InconsistentNaming
    public class Add_OnForwardMessageHeadersFromIncomingMessageToOutgoingMessageMutator_ToNsbPipeline
        : INeedInitialization
    {
        public static ILog Log =
            LogManager.GetLogger("Add_OnForwardMessageHeadersFromIncomingMessageToOutgoingMessageMutator_ToNsbPipeline");

        public void Customize(EndpointConfiguration configuration)
        {
            Log.Info("Registering onfowarding of headers component");
            configuration.RegisterComponents(
                c => c.ConfigureComponent<OnForwardMessageHeadersFromIncomingMessageToOutgoingMessageMutator>(
                    DependencyLifecycle.InstancePerCall));
        }
    }

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
