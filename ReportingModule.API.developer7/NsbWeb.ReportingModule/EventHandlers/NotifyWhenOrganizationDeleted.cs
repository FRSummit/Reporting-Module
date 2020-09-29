using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenOrganizationDeleted : IHandleMessages<IOrganizationDeleted>
    {
        public Task Handle(IOrganizationDeleted message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.OrganizationDeleted(message.Organization.Id);
            return Task.CompletedTask;
        }
    }
}