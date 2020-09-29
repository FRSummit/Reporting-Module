using FluentAssertions;
using NUnit.Framework;
using ReportingModule.Core;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Unit
{
    [TestFixture(Category = "Unit")]
    public class FinanceDataTests
    {
        [Test]
        public void SetThisPeriod_Asssigns_ExpectedValue()
        {
            var whenLastPeriodGreaterThanThisPeriod = new FinanceData(null, Money.Zero(), null, Money.Zero(), new Money(100), Money.Zero(),Money.Zero(), Money.Zero(), Money.Zero(),Money.Zero(),new Money(50),null);
            whenLastPeriodGreaterThanThisPeriod.SetWorkerPromiseThisPeriod(new Money(10));
            whenLastPeriodGreaterThanThisPeriod.WorkerPromiseThisPeriod.Should().Be(new Money(10));

            var whenLastPeriodLessThanThisPeriod = new FinanceData( null, Money.Zero(), null,  Money.Zero(), new Money(25),  Money.Zero(), Money.Zero(), Money.Zero(), Money.Zero(), new Money(100), Money.Zero(),  null);
            whenLastPeriodLessThanThisPeriod.SetWorkerPromiseThisPeriod(new Money(50));
            whenLastPeriodLessThanThisPeriod.WorkerPromiseThisPeriod.Should().Be(new Money(50));

            var whenLastPeriodAndThisPeriodSame = new FinanceData( null, Money.Zero(), null, Money.Zero(), new Money(100), Money.Zero(),Money.Zero(), Money.Zero(), Money.Zero(), Money.Zero(), Money.Zero(),  null);
            whenLastPeriodAndThisPeriodSame.SetWorkerPromiseThisPeriod(new Money(100));
            whenLastPeriodAndThisPeriodSame.WorkerPromiseThisPeriod.Should().Be(new Money(100));
        }

        [Test]
        public void DeserializesMoneyCorrectly()
        {
            string data  = "{\"amount\": 12,\"currency\": 8}";
            var money = Newtonsoft.Json.JsonConvert.DeserializeObject<Money>(data);
            money.Amount.Should().Be(12);
            money.Currency.Should().Be(Currency.AUD);
        }

        [Test]
        public void DeserializesFinanceDatCorrectly()
        {
            string data  = "{\"action\": null,\"workerPromiseIncreaseTarget\": {\"amount\": 12,\"currency\": 8},\"otherSourceAction\": null,\"otherSourceIncreaseTarget\": {\"amount\": 0,\"currency\": 8}}";
            var financeData = Newtonsoft.Json.JsonConvert.DeserializeObject<FinanceData>(data);
            financeData.WorkerPromiseIncreaseTarget.Amount.Should().Be(12);
        }
    }
}