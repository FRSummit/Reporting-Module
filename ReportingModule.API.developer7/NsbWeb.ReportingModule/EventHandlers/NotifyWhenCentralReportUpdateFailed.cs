using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenCentralReportUpdateFailed
        : IHandleMessages<ICentralReportUpdateFailed>
    {
        public Task Handle(ICentralReportUpdateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.CentralReportUpdateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}