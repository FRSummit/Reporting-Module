using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenZonePlanCreated : IHandleMessages<IZonePlanCreated>
    {
        public Task Handle(IZonePlanCreated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ZonePlanCreated(message.ZoneReport.Id);
            return Task.CompletedTask;
        }

    }
}