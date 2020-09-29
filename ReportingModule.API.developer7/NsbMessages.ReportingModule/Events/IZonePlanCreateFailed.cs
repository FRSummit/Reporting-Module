using NServiceBus;

namespace ReportingModule.Events
{
    public interface IZonePlanCreateFailed: IEvent
    {
        string[] Errors { get; set; }
    }
}