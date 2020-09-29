using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenUnitPlanPromoteFailed
        : IHandleMessages<IUnitPlanPromoteFailed>
    {
        public Task Handle(IUnitPlanPromoteFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.UnitPlanSubmitFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}