using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenZonePlanUpdateFailed
        : IHandleMessages<IZonePlanUpdateFailed>
    {
        public Task Handle(IZonePlanUpdateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ZonePlanUpdateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}