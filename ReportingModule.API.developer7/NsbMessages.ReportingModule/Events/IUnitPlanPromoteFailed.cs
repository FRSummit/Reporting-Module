using NServiceBus;

namespace ReportingModule.Events
{
    public interface IUnitPlanPromoteFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}