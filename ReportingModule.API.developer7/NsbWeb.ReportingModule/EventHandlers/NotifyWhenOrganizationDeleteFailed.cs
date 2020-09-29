using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenOrganizationDeleteFailed
        : IHandleMessages<IOrganizationDeleteFailed>
    {
        public Task Handle(IOrganizationDeleteFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.OrganizationDeleteFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}