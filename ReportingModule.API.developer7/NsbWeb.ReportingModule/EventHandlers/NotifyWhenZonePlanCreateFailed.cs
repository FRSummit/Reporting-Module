using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenZonePlanCreateFailed
        : IHandleMessages<IZonePlanCreateFailed>
    {
        public Task Handle(IZonePlanCreateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ZonePlanCreateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}