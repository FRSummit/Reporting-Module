using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenOrganizationUpdateFailed
        : IHandleMessages<IOrganizationUpdateFailed>
    {
        public Task Handle(IOrganizationUpdateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.OrganizationUpdateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}