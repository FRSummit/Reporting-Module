using NServiceBus;

namespace ReportingModule.Events
{
    public interface ICentralPlanCreateFailed: IEvent
    {
        string[] Errors { get; set; }
    }
}