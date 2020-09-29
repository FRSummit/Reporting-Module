using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenUnitPlanCopyFailed
        : IHandleMessages<IUnitPlanCopyFailed>
    {
        public Task Handle(IUnitPlanCopyFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.UnitPlanCopyFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}