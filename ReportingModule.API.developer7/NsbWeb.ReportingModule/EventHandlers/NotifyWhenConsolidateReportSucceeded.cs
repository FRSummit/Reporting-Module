using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenConsolidateReportSucceeded : IHandleMessages<IConsolidateReportSucceeded>
    {
        public Task Handle(IConsolidateReportSucceeded message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ConsolidateReportSucceeded(message.ReportIds, message.ReportData);
            return Task.CompletedTask;
        }

    }
}