using System;
using NServiceBus;
using ReportingModule.ValueObjects;

namespace ReportingModule.Commands
{
    public class UpdateUnitPlanCommand : ICommand
    {
        public UpdateUnitPlanCommand(int reportId,
            PlanData planData)
        {
            
            ReportId = reportId;
            PlanData = planData ?? throw new ArgumentNullException(nameof(planData));
        }

        public int ReportId { get; private set; }
        public PlanData PlanData { get; private set; }
    }
}