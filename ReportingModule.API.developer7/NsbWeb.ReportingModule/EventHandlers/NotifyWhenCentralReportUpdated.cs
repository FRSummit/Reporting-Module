using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenCentralReportUpdated : IHandleMessages<ICentralReportUpdated>
    {
        public Task Handle(ICentralReportUpdated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.CentralReportUpdated(message.CentralReport.Id);
            return Task.CompletedTask;
        }

    }
}