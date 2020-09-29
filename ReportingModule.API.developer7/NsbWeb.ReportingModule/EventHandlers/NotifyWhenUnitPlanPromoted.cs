using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenUnitPlanPromoted : IHandleMessages<IUnitPlanPromoted>
    {
        public Task Handle(IUnitPlanPromoted message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.UnitPlanSubmitted(message.UnitReport.Id);
            return Task.CompletedTask;
        }

    }
}