using NServiceBus;

namespace ReportingModule.Commands
{
    public class UpdateZoneReportGeneratedDataCommand : ICommand
    {
        public UpdateZoneReportGeneratedDataCommand(int reportId, bool overrideReportData)
        {
            ReportId = reportId;
            OverrideReportData = overrideReportData;
        }

        public int ReportId { get; private set; }
        public bool OverrideReportData { get; private set; }
    }
}