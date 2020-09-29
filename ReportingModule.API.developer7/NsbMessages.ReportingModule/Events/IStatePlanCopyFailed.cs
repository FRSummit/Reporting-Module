using NServiceBus;

namespace ReportingModule.Events
{
    public interface IStatePlanCopyFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}