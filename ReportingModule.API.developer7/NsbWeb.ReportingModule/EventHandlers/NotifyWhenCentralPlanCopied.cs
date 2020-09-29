using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenCentralPlanCopied : IHandleMessages<ICentralPlanCopied>
    {
        public Task Handle(ICentralPlanCopied message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.CentralPlanCopied(message.CentralReport.Id);

            return Task.CompletedTask;
        }

    }
}