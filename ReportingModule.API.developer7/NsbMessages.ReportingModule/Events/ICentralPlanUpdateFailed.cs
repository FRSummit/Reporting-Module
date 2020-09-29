using NServiceBus;

namespace ReportingModule.Events
{
    public interface ICentralPlanUpdateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}