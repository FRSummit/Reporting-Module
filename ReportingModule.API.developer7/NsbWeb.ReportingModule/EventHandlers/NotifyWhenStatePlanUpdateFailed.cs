using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenStatePlanUpdateFailed
        : IHandleMessages<IStatePlanUpdateFailed>
    {
        public Task Handle(IStatePlanUpdateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.StatePlanUpdateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}