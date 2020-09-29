using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenStatePlanPromoted : IHandleMessages<IStatePlanPromoted>
    {
        public Task Handle(IStatePlanPromoted message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.StatePlanSubmitted(message.StateReport.Id);
            return Task.CompletedTask;
        }

    }
}