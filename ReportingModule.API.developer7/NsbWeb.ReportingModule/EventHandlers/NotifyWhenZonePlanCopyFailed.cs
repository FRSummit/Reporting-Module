using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenZonePlanCopyFailed
        : IHandleMessages<IZonePlanCopyFailed>
    {
        public Task Handle(IZonePlanCopyFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ZonePlanCopyFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}