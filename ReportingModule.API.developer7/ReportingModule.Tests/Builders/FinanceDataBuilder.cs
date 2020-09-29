using ReportingModule.Core;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Builders
{
    public class FinanceDataBuilder
    {
        private const Currency DefaultCurrency = Currency.AUD;

        private string _action = DataProvider.Get<string>();
        public FinanceDataBuilder Action(string action)
        {
            _action = action;
            return this;
        }

        private Money _workerPromiseIncreaseTarget = new TestObjectBuilder<Money>().SetArgument(o => o.Currency, DefaultCurrency).Build();
        public FinanceDataBuilder SetWorkerPromiseIncreaseTarget(Money workerPromiseIncreaseTarget)
        {
            _workerPromiseIncreaseTarget = workerPromiseIncreaseTarget;
            return this;
        }


        private string _otherSourceAction = DataProvider.Get<string>();
        public FinanceDataBuilder OtherSourceAction(string otherSourceAction)
        {
            _otherSourceAction = otherSourceAction;
            return this;
        }

        private Money _otherSourceIncreaseTarget = new TestObjectBuilder<Money>().SetArgument(o => o.Currency, DefaultCurrency).Build();
        public FinanceDataBuilder SetOtherSourceIncreaseTargetIncreaseTarget(Money otherSourceIncreaseTarget)
        {
            _otherSourceIncreaseTarget = otherSourceIncreaseTarget;
            return this;
        }

        private Money _workerPromiseLastPeriod = new TestObjectBuilder<Money>().SetArgument(o => o.Currency, DefaultCurrency).Build();
        public FinanceDataBuilder SetWorkerPromiseLastPeriod(Money workerPromiseLastPeriod)
        {
            _workerPromiseLastPeriod = workerPromiseLastPeriod;
            return this;
        }

        private Money _lastPeriod = new TestObjectBuilder<Money>().SetArgument(o => o.Currency, DefaultCurrency).Build();
        public FinanceDataBuilder SetLastPeriod(Money lastPeriod)
        {
            _lastPeriod = lastPeriod;
            return this;
        }
        private Money _collection = new TestObjectBuilder<Money>().SetArgument(o => o.Currency, DefaultCurrency).Build();
        public FinanceDataBuilder SetCollection(Money collection)
        {
            _collection = collection;
            return this;
        }

        private Money _expense = new TestObjectBuilder<Money>().SetArgument(o => o.Currency, DefaultCurrency).Build();
        public FinanceDataBuilder Setexpense(Money expense)
        {
            _expense = expense;
            return this;
        }

        private Money _nisabPaidToCentral = new TestObjectBuilder<Money>().SetArgument(o => o.Currency, DefaultCurrency).Build();
        public FinanceDataBuilder SetNisabPaidToCentral(Money nisabPaidToCentral)
        {
            _nisabPaidToCentral = nisabPaidToCentral;
            return this;
        }

        private Money _workerPromiseIncreased = new TestObjectBuilder<Money>().SetArgument(o => o.Currency, DefaultCurrency).Build();
        public FinanceDataBuilder SetWorkerPromiseIncreased(Money workerPromiseIncreased)
        {
            _workerPromiseIncreased = workerPromiseIncreased;
            return this;
        }

        private Money _workerPromiseDecreased = new TestObjectBuilder<Money>().SetArgument(o => o.Currency, DefaultCurrency).Build();
        public FinanceDataBuilder SetWorkerPromiseDecreased(Money workerPromiseDecreased)
        {
            _workerPromiseDecreased = workerPromiseDecreased;
            return this;
        }

        

        private string _comment = DataProvider.Get<string>();
        public FinanceDataBuilder SetComment(string comment)
        {
            _comment = comment;
            return this;
        }

        public FinanceData Build()
        {

            var financeData = new TestObjectBuilder<FinanceData>()
                .SetArgument(o => o.Action, _action)
                .SetArgument(o => o.WorkerPromiseIncreaseTarget, _workerPromiseIncreaseTarget)
                .SetArgument(o => o.OtherSourceAction, _otherSourceAction)
                .SetArgument(o => o.OtherSourceIncreaseTarget, _otherSourceIncreaseTarget)

                .SetArgument(o => o.LastPeriod, _lastPeriod)
                .SetArgument(o => o.Collection, _collection)
                .SetArgument(o => o.Expense, _expense)
                .SetArgument(o => o.NisabPaidToCentral, _nisabPaidToCentral)

                .SetArgument(o => o.WorkerPromiseLastPeriod, _workerPromiseLastPeriod)

                .SetArgument(o => o.WorkerPromiseIncreased, _workerPromiseIncreased)
                .SetArgument(o => o.WorkerPromiseDecreased, _workerPromiseDecreased)
                .SetArgument(o => o.Comment, _comment)
                .Build();
            return financeData;
        }
    }
}