using NServiceBus;

namespace ReportingModule.Events
{
    public interface IZonePlanUpdateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}