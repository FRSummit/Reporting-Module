using log4net;
using NServiceBus;

namespace NsbWeb.ReportingModule.Configuration
{
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
}