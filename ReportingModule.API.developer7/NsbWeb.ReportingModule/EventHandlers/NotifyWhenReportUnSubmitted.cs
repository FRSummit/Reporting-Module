using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenReportUnSubmitted : IHandleMessages<IReportUnSubmitted>
    {
        public Task Handle(IReportUnSubmitted message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ReportUnSubmitted(message.Report.Id);
            return Task.CompletedTask;
        }
    }
}