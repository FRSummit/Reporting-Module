using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenOrganizationUserCreated : IHandleMessages<IOrganizationUserCreated>
    {
        public Task Handle(IOrganizationUserCreated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.OrganizationUserCreated(message.OrganizationUser.Id);
            return Task.CompletedTask;
        }
    }
}