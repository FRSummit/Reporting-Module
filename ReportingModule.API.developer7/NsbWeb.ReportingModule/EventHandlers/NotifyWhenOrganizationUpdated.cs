using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenOrganizationUpdated : IHandleMessages<IOrganizationUpdated>
    {
        public Task Handle(IOrganizationUpdated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.OrganizationUpdated(message.Organization.Id);
            return Task.CompletedTask;
        }
    }
}