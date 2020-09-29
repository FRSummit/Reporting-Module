using NServiceBus;

namespace ReportingModule.Commands
{
    public class DeleteReportCommand : ICommand
    {
        public DeleteReportCommand(int reportId)
        {
            ReportId = reportId;
        }

        public int ReportId { get; private set; }
    }
}