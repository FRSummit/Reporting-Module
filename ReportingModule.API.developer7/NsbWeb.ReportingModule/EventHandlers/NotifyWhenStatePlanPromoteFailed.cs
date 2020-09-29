using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenStatePlanPromoteFailed
        : IHandleMessages<IStatePlanPromoteFailed>
    {
        public Task Handle(IStatePlanPromoteFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.StatePlanSubmitFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}