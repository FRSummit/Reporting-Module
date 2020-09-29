using ReportingModule.Core;

namespace ReportingModule.ValueObjects
{
    public class FinancePlanData
    {
        protected FinancePlanData()
        {
        }

        public FinancePlanData(string action,
            Money workerPromiseIncreaseTarget,
            string otherSourceAction,
            Money otherSourceIncreaseTarget)
        {
            Action = action;
            WorkerPromiseIncreaseTarget = workerPromiseIncreaseTarget ?? Money.Zero();
            OtherSourceAction = otherSourceAction;
            OtherSourceIncreaseTarget = otherSourceIncreaseTarget ?? Money.Zero();
        }

        public string Action { get; private set; }
        public Money WorkerPromiseIncreaseTarget { get; private set; }
        public string OtherSourceAction { get; private set; }
        public Money OtherSourceIncreaseTarget { get; private set; }

    }
}