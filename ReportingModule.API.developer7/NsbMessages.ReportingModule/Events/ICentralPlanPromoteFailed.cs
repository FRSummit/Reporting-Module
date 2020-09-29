using NServiceBus;

namespace ReportingModule.Events
{
    public interface ICentralPlanPromoteFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}