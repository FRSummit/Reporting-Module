using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenCentralPlanUpdateFailed
        : IHandleMessages<ICentralPlanUpdateFailed>
    {
        public Task Handle(ICentralPlanUpdateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.CentralPlanUpdateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}