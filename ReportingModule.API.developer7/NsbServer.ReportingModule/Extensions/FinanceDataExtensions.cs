using ReportingModule.ValueObjects;

namespace ReportingModule.Extensions
{
    public static class FinanceDataExtensions
    {
        public static FinanceData ToFinanceData(this FinanceData data, FinancePlanData planData)
        {
            return new FinanceData(
                planData.Action,
                planData.WorkerPromiseIncreaseTarget,
                planData.OtherSourceAction,
                planData.OtherSourceIncreaseTarget,
                data.WorkerPromiseLastPeriod,
                data.LastPeriod,
                data.Collection,
                data.Expense,
                data.NisabPaidToCentral,
                data.WorkerPromiseIncreased,
                data.WorkerPromiseDecreased,
                data.Comment);
        }

        public static FinanceData ToFinanceData(this FinanceData data, FinanceReportData reportData)
        {
            return new FinanceData(
                data.Action,
                data.WorkerPromiseIncreaseTarget,
                data.OtherSourceAction,
                data.OtherSourceIncreaseTarget,
                reportData.WorkerPromiseLastPeriod,
                reportData.LastPeriod,
                reportData.Collection,
                reportData.Expense,
                reportData.NisabPaidToCentral,
                reportData.WorkerPromiseIncreased,
                reportData.WorkerPromiseDecreased,
                reportData.Comment);
        }


    }
}