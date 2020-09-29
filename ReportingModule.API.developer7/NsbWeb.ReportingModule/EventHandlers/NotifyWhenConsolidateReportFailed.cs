using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenConsolidateReportFailed
        : IHandleMessages<IConsolidateReportFailed>
    {
        public Task Handle(IConsolidateReportFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ConsolidateReportFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}