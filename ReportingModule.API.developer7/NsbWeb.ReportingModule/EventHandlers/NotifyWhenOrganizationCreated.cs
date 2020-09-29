using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenOrganizationCreated : IHandleMessages<IOrganizationCreated>
    {
        public Task Handle(IOrganizationCreated message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.OrganizationCreated(message.Organization.Id);
            return Task.CompletedTask;
        }
    }
}