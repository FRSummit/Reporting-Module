using ReportingModule.Core;

namespace ReportingModule.ValueObjects
{
    public class FinanceReportData
    {
        protected FinanceReportData()
        {
        }

        public FinanceReportData(Money workerPromiseLastPeriod,
            Money workerPromiseIncreased,
            Money workerPromiseDecreased,
            Money lastPeriod,
            Money collection,
            Money expense,
            Money nisabPaidToCentral,
            string comment)
        {
            WorkerPromiseLastPeriod = workerPromiseLastPeriod ?? Money.Zero();
            WorkerPromiseIncreased = workerPromiseIncreased ?? Money.Zero();
            WorkerPromiseDecreased = workerPromiseDecreased ?? Money.Zero();
            LastPeriod = lastPeriod ?? Money.Zero();
            Collection = collection ?? Money.Zero();
            Expense = expense ?? Money.Zero();
            NisabPaidToCentral = nisabPaidToCentral ?? Money.Zero();
            Comment = comment;
        }
        public Money WorkerPromiseLastPeriod { get; private set; }
        public Money WorkerPromiseIncreased { get; private set; }
        public Money WorkerPromiseDecreased { get; private set; }
        public Money LastPeriod { get; private set; }
        public Money Collection { get; private set; }
        public Money Expense { get; private set; }
        public Money NisabPaidToCentral { get; private set; }
        public string Comment { get; private set; }

    }
}