using NServiceBus;

namespace ReportingModule.Events
{
    public interface IReportDeleteFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}