using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenPonged : IHandleMessages<IPongedEvent>
    {
        public Task Handle(IPongedEvent message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.Pong(message.Message);
            return Task.CompletedTask;
        }

    }
}