using NServiceBus;

namespace ReportingModule.Events
{
    public interface IUnitPlanCopyFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}