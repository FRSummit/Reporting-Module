using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenZonePlanCopied : IHandleMessages<IZonePlanCopied>
    {
        public Task Handle(IZonePlanCopied message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ZonePlanCopied(message.ZoneReport.Id);
            return Task.CompletedTask;
        }

    }
}