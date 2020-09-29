using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenZonePlanPromoteFailed
        : IHandleMessages<IZonePlanPromoteFailed>
    {
        public Task Handle(IZonePlanPromoteFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ZonePlanSubmitFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}