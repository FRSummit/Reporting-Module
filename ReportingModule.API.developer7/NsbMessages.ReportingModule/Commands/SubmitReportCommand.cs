using NServiceBus;

namespace ReportingModule.Commands
{
    public class SubmitReportCommand : ICommand
    {
        public SubmitReportCommand(int reportId)
        {
            
            ReportId = reportId;
        }

        public int ReportId { get; private set; }
    }
}