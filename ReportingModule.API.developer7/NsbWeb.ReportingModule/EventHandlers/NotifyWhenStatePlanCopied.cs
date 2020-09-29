using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenStatePlanCopied : IHandleMessages<IStatePlanCopied>
    {
        public Task Handle(IStatePlanCopied message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.StatePlanCopied(message.StateReport.Id);
            return Task.CompletedTask;
        }

    }
    
}