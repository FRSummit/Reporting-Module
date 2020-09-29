using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenOrganizationUserCreateFailed
        : IHandleMessages<IOrganizationUserCreateFailed>
    {
        public Task Handle(IOrganizationUserCreateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.OrganizationUserCreateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}