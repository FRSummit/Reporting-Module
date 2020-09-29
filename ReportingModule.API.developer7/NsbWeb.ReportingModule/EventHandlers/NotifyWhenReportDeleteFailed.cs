using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenReportDeleteFailed
        : IHandleMessages<IReportDeleteFailed>
    {
        public Task Handle(IReportDeleteFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ReportDeleteFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}