using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenCentralPlanCreated : IHandleMessages<ICentralPlanCreated>
    {
        public Task Handle(ICentralPlanCreated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();

            client?.CentralPlanCreated(message.CentralReport.Id);
            return Task.CompletedTask;
        }

    }
}