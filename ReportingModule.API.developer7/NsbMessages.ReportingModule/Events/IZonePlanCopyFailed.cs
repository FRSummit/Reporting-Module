using NServiceBus;

namespace ReportingModule.Events
{
    public interface IZonePlanCopyFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}