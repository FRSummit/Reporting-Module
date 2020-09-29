using NServiceBus;

namespace ReportingModule.Commands
{
    public class PingCommand : ICommand
    {
        public PingCommand(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}