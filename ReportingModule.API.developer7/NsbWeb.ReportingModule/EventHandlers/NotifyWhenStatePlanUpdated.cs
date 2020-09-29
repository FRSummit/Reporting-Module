using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenStatePlanUpdated : IHandleMessages<IStatePlanUpdated>
    {
        public Task Handle(IStatePlanUpdated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.StatePlanUpdated(message.StateReport.Id);
            return Task.CompletedTask;
        }

    }
}