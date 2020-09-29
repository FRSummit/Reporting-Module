using NServiceBus;

namespace ReportingModule.Events
{
    public interface ICentralReportUpdateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}