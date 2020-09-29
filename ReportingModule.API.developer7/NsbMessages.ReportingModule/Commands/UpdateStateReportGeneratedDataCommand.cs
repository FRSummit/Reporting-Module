using NServiceBus;

namespace ReportingModule.Commands
{
    public class UpdateStateReportGeneratedDataCommand : ICommand
    {
        public UpdateStateReportGeneratedDataCommand(int reportId, bool overrideReportData)
        {
            ReportId = reportId;
            OverrideReportData = overrideReportData;
        }

        public int ReportId { get; private set; }
        public bool OverrideReportData { get; private set; }
    }
}