using FluentAssertions;
using NUnit.Framework;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Unit
{
    [TestFixture(Category = "Unit")]
    public class LibraryStockDataTests
    {
        [Test]
        public void SetThisPeriod_Asssigns_ExpectedValue()
        {
            var whenLastPeriodGreaterThanThisPeriod = new LibraryStockData(100, 0, 0, null);
            whenLastPeriodGreaterThanThisPeriod.SetThisPeriod(10);
            whenLastPeriodGreaterThanThisPeriod.ThisPeriod.Should().Be(10);

            var whenLastPeriodLessThanThisPeriod = new LibraryStockData(25, 0, 100, null);
            whenLastPeriodLessThanThisPeriod.SetThisPeriod(50);
            whenLastPeriodLessThanThisPeriod.ThisPeriod.Should().Be(50);

            var whenLastPeriodAndThisPeriodSame = new LibraryStockData(100, 0, 0, null);
            whenLastPeriodAndThisPeriodSame.SetThisPeriod(100);
            whenLastPeriodAndThisPeriodSame.ThisPeriod.Should().Be(100);
        }
    }
}