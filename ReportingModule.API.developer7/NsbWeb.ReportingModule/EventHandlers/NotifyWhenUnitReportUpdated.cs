using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenUnitReportUpdated : IHandleMessages<IUnitReportUpdated>
    {
        public Task Handle(IUnitReportUpdated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.UnitReportUpdated(message.UnitReport.Id);
            return Task.CompletedTask;
        }

    }
}