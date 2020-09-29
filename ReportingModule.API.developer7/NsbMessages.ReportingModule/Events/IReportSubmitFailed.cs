using NServiceBus;

namespace ReportingModule.Events
{
    public interface IReportSubmitFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}