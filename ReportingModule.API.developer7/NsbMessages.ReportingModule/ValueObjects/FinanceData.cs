using System;
using ReportingModule.Core;

namespace ReportingModule.ValueObjects
{
    public class FinanceData
    {
        protected FinanceData()
        {
        }

        public FinanceData(string action,
            Money workerPromiseIncreaseTarget,
            string otherSourceAction,
            Money otherSourceIncreaseTarget,
            Money workerPromiseLastPeriod,
            Money lastPeriod,
            Money collection,
            Money expense,
            Money nisabPaidToCentral,
            Money workerPromiseIncreased,
            Money workerPromiseDecreased,
            string comment)
        {
            Action = action;
            WorkerPromiseIncreaseTarget = workerPromiseIncreaseTarget ?? Money.Zero();

            OtherSourceIncreaseTarget = otherSourceIncreaseTarget ?? Money.Zero();
            OtherSourceAction = otherSourceAction;

            WorkerPromiseLastPeriod = workerPromiseLastPeriod ?? Money.Zero();

            LastPeriod = lastPeriod ?? Money.Zero();
            Collection = collection ?? Money.Zero();
            Expense = expense ?? Money.Zero();
            NisabPaidToCentral = nisabPaidToCentral ?? Money.Zero();

            WorkerPromiseIncreased = workerPromiseIncreased ?? Money.Zero();
            WorkerPromiseDecreased = workerPromiseDecreased ?? Money.Zero();

            Comment = comment;
        }
        public Money WorkerPromiseIncreaseTarget { get; private set; }
        public string Action { get; private set; }
        public Money OtherSourceIncreaseTarget { get; private set; }
        public string OtherSourceAction { get; private set; }
        public Money TotalIncreaseTarget => GetTotalIncreaseTarget();

        public Money WorkerPromiseLastPeriod { get; private set; }

        public Money WorkerPromiseThisPeriod => GetWorkerPromiseThisPeriod();

        public Money LastPeriod { get; private set; }
        public Money Collection { get; private set; }
        public Money Expense { get; private set; }
        public Money NisabPaidToCentral { get; private set; }
        public Money Balance => GetBalance();

        public Money WorkerPromiseIncreased { get; private set; }
        public Money WorkerPromiseDecreased { get; private set; }
        public string Comment { get; private set; }

        public void SetIncreased(Money increased)
        {
            if (increased < Money.Zero())
                throw new ArgumentOutOfRangeException(nameof(increased));
            WorkerPromiseIncreased = increased;
        }

        public void SetDecreased(Money decreased)
        {
            if (decreased < Money.Zero())
                throw new ArgumentOutOfRangeException(nameof(decreased));

            WorkerPromiseDecreased = decreased;
        }

        public void SetWorkerPromiseThisPeriod(Money workerPromiseThisPeriod)
        {
            if (workerPromiseThisPeriod < Money.Zero())
                throw new ArgumentOutOfRangeException(nameof(workerPromiseThisPeriod));

            if (WorkerPromiseLastPeriod > workerPromiseThisPeriod)
            {
                var diff = WorkerPromiseLastPeriod - workerPromiseThisPeriod;
                WorkerPromiseIncreased = Money.Zero();
                WorkerPromiseDecreased = diff;
            }
            else if (WorkerPromiseLastPeriod < workerPromiseThisPeriod)
            {
                var diff = workerPromiseThisPeriod - WorkerPromiseLastPeriod;
                WorkerPromiseIncreased = diff;
                WorkerPromiseDecreased = Money.Zero();
            }
            else
            {
                WorkerPromiseIncreased = Money.Zero();
                WorkerPromiseDecreased = Money.Zero();
            }
        }

        public static FinanceData Default() =>
            new FinanceData(null,
                Money.Zero(),
                null,
                Money.Zero(),
                Money.Zero(),
                Money.Zero(),
                Money.Zero(),
                Money.Zero(),
                Money.Zero(),
                Money.Zero(),
                Money.Zero(),
                null);

        private Money GetTotalIncreaseTarget()
        {
            return WorkerPromiseIncreaseTarget + OtherSourceIncreaseTarget <= Money.Zero()
                ? Money.Zero()
                : WorkerPromiseIncreaseTarget + OtherSourceIncreaseTarget;
        }
        private Money GetWorkerPromiseThisPeriod()
        {
            return WorkerPromiseLastPeriod + WorkerPromiseIncreased - WorkerPromiseDecreased;
        }

        private Money GetBalance()
        {
            return LastPeriod + Collection - (Expense + NisabPaidToCentral);
        }

        public static implicit operator FinancePlanData(FinanceData data)
        {
            return new FinancePlanData(
                data.Action,
                data.WorkerPromiseIncreaseTarget,
                data.OtherSourceAction,
                data.OtherSourceIncreaseTarget);
        }

        public static implicit operator FinanceReportData(FinanceData data)
        {
            return new FinanceReportData(data.WorkerPromiseLastPeriod,
                data.WorkerPromiseIncreased,
                data.WorkerPromiseDecreased,
                data.LastPeriod,
                data.Collection,
                data.Expense,
                data.NisabPaidToCentral,
                data.Comment);
        }
    }
}