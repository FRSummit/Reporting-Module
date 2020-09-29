using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenZoneReportUpdateFailed
        : IHandleMessages<IZoneReportUpdateFailed>
    {
        public Task Handle(IZoneReportUpdateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ZoneReportUpdateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}