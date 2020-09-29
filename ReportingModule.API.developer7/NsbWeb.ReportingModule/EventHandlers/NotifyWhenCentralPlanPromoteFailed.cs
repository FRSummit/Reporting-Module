using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenCentralPlanPromoteFailed
        : IHandleMessages<ICentralPlanPromoteFailed>
    {
        public Task Handle(ICentralPlanPromoteFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.CentralPlanSubmitFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}