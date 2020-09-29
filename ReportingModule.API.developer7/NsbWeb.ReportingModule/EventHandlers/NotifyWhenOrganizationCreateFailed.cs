using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenOrganizationCreateFailed
        : IHandleMessages<IOrganizationCreateFailed>
    {
        public Task Handle(IOrganizationCreateFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.OrganizationCreateFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}