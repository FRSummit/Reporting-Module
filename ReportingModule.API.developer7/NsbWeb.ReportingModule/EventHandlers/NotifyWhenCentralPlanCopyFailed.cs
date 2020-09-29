using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenCentralPlanCopyFailed
        : IHandleMessages<ICentralPlanCopyFailed>
    {
        public Task Handle(ICentralPlanCopyFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();

            client?.CentralPlanCopyFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}