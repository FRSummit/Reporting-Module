using NServiceBus;

namespace ReportingModule.Events
{
    public interface IStateReportUpdateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}