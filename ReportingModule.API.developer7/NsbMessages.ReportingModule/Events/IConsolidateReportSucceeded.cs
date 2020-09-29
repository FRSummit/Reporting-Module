using NServiceBus;
using ReportingModule.ValueObjects;

namespace ReportingModule.Events
{
    public interface IConsolidateReportSucceeded : IEvent
    {
        string Username { get; set; }
        int[] ReportIds { get; set; }
        ReportData ReportData { get; set; }
        
    }
}