using NServiceBus;

namespace ReportingModule.Commands
{
    public class PromotePlanToCentralReportCommand : ICommand
    {
        public PromotePlanToCentralReportCommand(
            int planId)
        {
            PlanId = planId;
        }

        public int PlanId { get; private set; }
    }
}