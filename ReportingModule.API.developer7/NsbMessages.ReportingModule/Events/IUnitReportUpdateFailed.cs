using NServiceBus;

namespace ReportingModule.Events
{
    public interface IUnitReportUpdateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}