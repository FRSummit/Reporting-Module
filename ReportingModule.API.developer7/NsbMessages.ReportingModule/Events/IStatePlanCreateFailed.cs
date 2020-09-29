using NServiceBus;

namespace ReportingModule.Events
{
    public interface IStatePlanCreateFailed: IEvent
    {
        string[] Errors { get; set; }
    }
}