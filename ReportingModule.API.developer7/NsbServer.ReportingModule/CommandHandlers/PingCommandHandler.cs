using System.Threading.Tasks;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.Events;

namespace ReportingModule.CommandHandlers
{
    public class PingCommandHandler : IHandleMessages<PingCommand>
    {
        public Task Handle(PingCommand message, IMessageHandlerContext context)
        {
            return context.Publish<IPongedEvent>(e =>
            {
                e.Message = message.Message;
            });
        }

        
    }
}