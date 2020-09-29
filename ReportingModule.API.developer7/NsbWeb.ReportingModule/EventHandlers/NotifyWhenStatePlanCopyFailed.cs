using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenStatePlanCopyFailed
        : IHandleMessages<IStatePlanCopyFailed>
    {
        public Task Handle(IStatePlanCopyFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.StatePlanCopyFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}