using NServiceBus;

namespace ReportingModule.Commands
{
    public class UnSubmitReportCommand : ICommand
    {
        public UnSubmitReportCommand(int reportId)
        {
            
            ReportId = reportId;
        }

        public int ReportId { get; private set; }
    }
}