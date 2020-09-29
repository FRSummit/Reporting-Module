using NServiceBus;

namespace ReportingModule.Events
{
    public interface IUnitPlanCreateFailed: IEvent
    {
        string[] Errors { get; set; }
    }
}