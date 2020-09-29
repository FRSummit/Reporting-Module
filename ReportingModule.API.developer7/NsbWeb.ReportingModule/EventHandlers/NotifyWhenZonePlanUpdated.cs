using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenZonePlanUpdated : IHandleMessages<IZonePlanUpdated>
    {
        public Task Handle(IZonePlanUpdated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ZonePlanUpdated(message.ZoneReport.Id);
            return Task.CompletedTask;
        }

    }
}