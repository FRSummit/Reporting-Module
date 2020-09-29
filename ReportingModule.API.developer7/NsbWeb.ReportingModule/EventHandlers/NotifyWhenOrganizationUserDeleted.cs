using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenOrganizationUserDeleted : IHandleMessages<IOrganizationUserDeleted>
    {
        public Task Handle(IOrganizationUserDeleted message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.OrganizationUserDeleted(message.OrganizationUser.Id);
            return Task.CompletedTask;
        }
    }
}