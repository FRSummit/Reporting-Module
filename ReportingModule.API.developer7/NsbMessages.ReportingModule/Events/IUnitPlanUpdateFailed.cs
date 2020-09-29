using NServiceBus;

namespace ReportingModule.Events
{
    public interface IUnitPlanUpdateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}