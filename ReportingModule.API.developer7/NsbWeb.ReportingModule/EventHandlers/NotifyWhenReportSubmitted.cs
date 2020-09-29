using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenReportSubmitted : IHandleMessages<IReportSubmitted>
    {
        public Task Handle(IReportSubmitted message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ReportSubmitted(message.Report.Id);
            return Task.CompletedTask;
        }
    }
}