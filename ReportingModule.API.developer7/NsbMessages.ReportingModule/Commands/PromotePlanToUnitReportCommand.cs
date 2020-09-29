using ICommand = NServiceBus.ICommand;

namespace ReportingModule.Commands
{
    public class PromotePlanToUnitReportCommand : ICommand
    {
        public PromotePlanToUnitReportCommand(
            int planId)
        {
            PlanId = planId;
        }

        public int PlanId { get; private set; }
    }
}