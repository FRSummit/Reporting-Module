using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenReportDeleted : IHandleMessages<IReportDeleted>
    {
        public Task Handle(IReportDeleted message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ReportDeleted(message.Report.Id);
            return Task.CompletedTask;
        }
    }
}