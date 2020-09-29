using Microsoft.AspNet.SignalR;

// ReSharper disable UnusedMember.

namespace NsbWeb.ReportingModule.SignalR
{
    public class ReportingModuleHub : Hub
    {
        public string Ping(string message)
        {
            Clients.Caller.Pong(message);
            return $"Received '{message}'";
        }
    }
}