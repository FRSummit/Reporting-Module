using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenUnitPlanCreateFailed
        : IHandleMessages<IUnitPlanCreateFailed>
    {
        public Task Handle(IUnitPlanCreateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.UnitPlanCreateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}