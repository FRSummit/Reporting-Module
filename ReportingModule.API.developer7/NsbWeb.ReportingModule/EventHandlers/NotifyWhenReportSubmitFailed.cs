using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenReportSubmitFailed
        : IHandleMessages<IReportSubmitFailed>
    {
        public Task Handle(IReportSubmitFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.ReportSubmitFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}