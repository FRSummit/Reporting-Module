using NServiceBus;

namespace ReportingModule.Events
{
    public interface IStatePlanPromoteFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}