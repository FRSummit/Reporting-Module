using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenZonePlanPromoted : IHandleMessages<IZonePlanPromoted>
    {
        public Task Handle(IZonePlanPromoted message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ZonePlanSubmitted(message.ZoneReport.Id);
            return Task.CompletedTask;
        }

    }
}