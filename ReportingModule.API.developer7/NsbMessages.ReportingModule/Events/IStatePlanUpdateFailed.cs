using NServiceBus;

namespace ReportingModule.Events
{
    public interface IStatePlanUpdateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}