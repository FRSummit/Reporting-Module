using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenUnitPlanUpdateFailed
        : IHandleMessages<IUnitPlanUpdateFailed>
    {
        public Task Handle(IUnitPlanUpdateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.UnitPlanUpdateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}