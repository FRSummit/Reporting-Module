using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenStateReportUpdated : IHandleMessages<IStateReportUpdated>
    {
        public Task Handle(IStateReportUpdated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.StateReportUpdated(message.StateReport.Id);
            return Task.CompletedTask;
        }

    }
}