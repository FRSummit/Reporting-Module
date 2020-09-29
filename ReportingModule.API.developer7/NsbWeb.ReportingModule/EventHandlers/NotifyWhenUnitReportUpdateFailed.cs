using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenUnitReportUpdateFailed
        : IHandleMessages<IUnitReportUpdateFailed>
    {
        public Task Handle(IUnitReportUpdateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.UnitReportUpdateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}