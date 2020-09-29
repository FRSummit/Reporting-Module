using NServiceBus;

namespace ReportingModule.Commands
{
    public class PromotePlanToStateReportCommand : ICommand
    {
        public PromotePlanToStateReportCommand(
            int planId)
        {
            PlanId = planId;
        }

        public int PlanId { get; private set; }
    }
}