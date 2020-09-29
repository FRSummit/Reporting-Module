using NServiceBus;

namespace ReportingModule.Events
{
    public interface IZoneReportUpdateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}