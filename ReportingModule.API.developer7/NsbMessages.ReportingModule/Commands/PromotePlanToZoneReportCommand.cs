using NServiceBus;

namespace ReportingModule.Commands
{
    public class PromotePlanToZoneReportCommand : ICommand
    {
        public PromotePlanToZoneReportCommand(
            int planId)
        {
            PlanId = planId;
        }

        public int PlanId { get; private set; }
    }
}