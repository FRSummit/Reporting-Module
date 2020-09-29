using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenStateReportUpdateFailed
        : IHandleMessages<IStateReportUpdateFailed>
    {
        public Task Handle(IStateReportUpdateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.StateReportUpdateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}