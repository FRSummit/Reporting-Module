using FluentAssertions;
using NUnit.Framework;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Unit
{
    [TestFixture(Category = "Unit")]
    public class MemberDataTests
    {
        [Test]
        public void SetThisPeriod_Asssigns_ExpectedValue()
        {
            var whenLastPeriodGreaterThanThisPeriod = new MemberData(null, null, 100, 0, 0, 50, null, 0);
            whenLastPeriodGreaterThanThisPeriod.SetThisPeriod(10);
            whenLastPeriodGreaterThanThisPeriod.ThisPeriod.Should().Be(10);

            var whenLastPeriodLessThanThisPeriod = new MemberData(null, null, 25, 0, 100, 0, null, 0);
            whenLastPeriodLessThanThisPeriod.SetThisPeriod(50);
            whenLastPeriodLessThanThisPeriod.ThisPeriod.Should().Be(50);

            var whenLastPeriodAndThisPeriodSame = new MemberData(null, null, 100, 0, 0, 0, null, 0);
            whenLastPeriodAndThisPeriodSame.SetThisPeriod(100);
            whenLastPeriodAndThisPeriodSame.ThisPeriod.Should().Be(100);
        }
    }
}