using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenZoneReportUpdated : IHandleMessages<IZoneReportUpdated>
    {
        public Task Handle(IZoneReportUpdated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ZoneReportUpdated(message.ZoneReport.Id);
            return Task.CompletedTask;
        }

    }
}