using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenCentralPlanCreateFailed
        : IHandleMessages<ICentralPlanCreateFailed>
    {
        public Task Handle(ICentralPlanCreateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.CentralPlanCreateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}