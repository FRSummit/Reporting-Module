using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenUnitPlanCopied : IHandleMessages<IUnitPlanCopied>
    {
        public Task Handle(IUnitPlanCopied message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.UnitPlanCopied(message.UnitReport.Id);
            return Task.CompletedTask;
        }

    }
}