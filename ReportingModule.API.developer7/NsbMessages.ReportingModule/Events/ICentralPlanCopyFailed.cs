using NServiceBus;

namespace ReportingModule.Events
{
    public interface ICentralPlanCopyFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}