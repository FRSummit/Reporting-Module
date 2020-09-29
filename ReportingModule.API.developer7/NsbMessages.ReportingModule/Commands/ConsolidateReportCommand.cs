using NServiceBus;

namespace ReportingModule.Commands
{
    public class ConsolidateReportCommand : ICommand
    {
        public ConsolidateReportCommand(int[] reportIds)
        {
            ReportIds = reportIds ?? new int[0];
        }

        public int[] ReportIds { get; private set; }
    }
}