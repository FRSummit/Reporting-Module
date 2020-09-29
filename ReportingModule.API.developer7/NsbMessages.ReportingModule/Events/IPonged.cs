using NServiceBus;

namespace ReportingModule.Events
{
    public interface IPongedEvent : IEvent
    {
        string Message { get; set; }
    }
}