using NServiceBus;

namespace ReportingModule.Events
{
    public interface IReportUnSubmitFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}