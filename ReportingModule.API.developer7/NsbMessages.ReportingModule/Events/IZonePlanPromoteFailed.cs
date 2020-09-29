using NServiceBus;

namespace ReportingModule.Events
{
    public interface IZonePlanPromoteFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}