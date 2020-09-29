using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenStatePlanCreated : IHandleMessages<IStatePlanCreated>
    {
        public Task Handle(IStatePlanCreated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.StatePlanCreated(message.StateReport.Id);
            return Task.CompletedTask;
        }

    }
}