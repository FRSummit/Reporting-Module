using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenUnitPlanCreated : IHandleMessages<IUnitPlanCreated>
    {
        public Task Handle(IUnitPlanCreated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.UnitPlanCreated(message.UnitReport.Id);
            return Task.CompletedTask;
        }

    }
}
