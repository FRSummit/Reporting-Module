using NServiceBus;

namespace ReportingModule.Events
{
    public interface IConsolidateReportFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}