using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenStatePlanCreateFailed
        : IHandleMessages<IStatePlanCreateFailed>
    {
        public Task Handle(IStatePlanCreateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.StatePlanCreateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}