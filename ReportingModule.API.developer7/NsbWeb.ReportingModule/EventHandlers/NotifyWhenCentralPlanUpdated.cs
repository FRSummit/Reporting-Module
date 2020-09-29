using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenCentralPlanUpdated : IHandleMessages<ICentralPlanUpdated>
    {
        public Task Handle(ICentralPlanUpdated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();

            client?.CentralPlanUpdated(message.CentralReport.Id);
            return Task.CompletedTask;
        }

    }
}