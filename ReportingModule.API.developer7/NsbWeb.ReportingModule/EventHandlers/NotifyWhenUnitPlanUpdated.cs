using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenUnitPlanUpdated : IHandleMessages<IUnitPlanUpdated>
    {
        public Task Handle(IUnitPlanUpdated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.UnitPlanUpdated(message.UnitReport.Id);
            return Task.CompletedTask;
        }

    }
}