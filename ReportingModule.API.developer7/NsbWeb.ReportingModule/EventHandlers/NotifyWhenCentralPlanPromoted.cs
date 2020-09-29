using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenCentralPlanPromoted : IHandleMessages<ICentralPlanPromoted>
    {
        public Task Handle(ICentralPlanPromoted message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.CentralPlanSubmitted(message.CentralReport.Id);
            return Task.CompletedTask;
        }

    }
}