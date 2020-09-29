using System;
using FluentAssertions;
using NUnit.Framework;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Unit
{
    [TestFixture(Category = "Unit")]
    public class ReportingPeriodTests
    {
        [TestCase(ReportingTerm.One)]
        public void GetReportingPreviousTerm_Year_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.Yearly, reportingTerm, year);
            var reportingPeriodOfPreviousTerm = reportingPeriod.GetReportingPeriodOfPreviousTerm();
            if (reportingTerm == ReportingTerm.One)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year - 1);

            }
            reportingPeriodOfPreviousTerm.ReportingTerm.Should().Be(ReportingTerm.One);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        public void GetReportingPreviousTerm_HalfYearly_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.HalfYearly, reportingTerm, year);
            var reportingPeriodOfPreviousTerm = reportingPeriod.GetReportingPeriodOfPreviousTerm();
            if (reportingTerm == ReportingTerm.Two)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year - 1);
                reportingPeriodOfPreviousTerm.ReportingTerm.Should().Be(ReportingTerm.One);
                return;
            }
            if (reportingTerm == ReportingTerm.One)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year);
                var previousReportingTerInt = (int)reportingPeriodOfPreviousTerm.ReportingTerm;
                previousReportingTerInt.Should().Be(2);
                return;
            }
            else
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year);
                var reportingTermInt = (int)reportingTerm;
                var previousReportingTerInt = (int)reportingPeriodOfPreviousTerm.ReportingTerm;
                previousReportingTerInt.Should().Be(reportingTermInt - 1);
            }
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        public void GetReportingPreviousTerm_EveryFourMonth_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.EveryFourMonth, reportingTerm, year);
            var reportingPeriodOfPreviousTerm = reportingPeriod.GetReportingPeriodOfPreviousTerm();
            if (reportingTerm == ReportingTerm.Two)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year - 1);
                reportingPeriodOfPreviousTerm.ReportingTerm.Should().Be(ReportingTerm.One);
                return;
            }
            if (reportingTerm == ReportingTerm.One)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year);
                var previousReportingTerInt = (int)reportingPeriodOfPreviousTerm.ReportingTerm;
                previousReportingTerInt.Should().Be(3);
                return;
            }
            else
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year);
                var reportingTermInt = (int)reportingTerm;
                var previousReportingTerInt = (int)reportingPeriodOfPreviousTerm.ReportingTerm;
                previousReportingTerInt.Should().Be(reportingTermInt - 1);
            }
        }
        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        [TestCase(ReportingTerm.Four)]
        public void GetReportingPreviousTerm_Quarterly_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.Quarterly, reportingTerm, year);
            var reportingPeriodOfPreviousTerm = reportingPeriod.GetReportingPeriodOfPreviousTerm();
            if (reportingTerm == ReportingTerm.Two)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year - 1);
                reportingPeriodOfPreviousTerm.ReportingTerm.Should().Be(ReportingTerm.One);
                return;
            }
            if (reportingTerm == ReportingTerm.One)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year);
                var previousReportingTerInt = (int)reportingPeriodOfPreviousTerm.ReportingTerm;
                previousReportingTerInt.Should().Be(4);
                return;
            }
            else
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year);
                var reportingTermInt = (int)reportingTerm;
                var previousReportingTerInt = (int)reportingPeriodOfPreviousTerm.ReportingTerm;
                previousReportingTerInt.Should().Be(reportingTermInt - 1);
            }
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        [TestCase(ReportingTerm.Four)]
        [TestCase(ReportingTerm.Five)]
        [TestCase(ReportingTerm.Six)]
        public void GetReportingPreviousTerm_EveryTwoMonth_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.EveryTwoMonth, reportingTerm, year);
            var reportingPeriodOfPreviousTerm = reportingPeriod.GetReportingPeriodOfPreviousTerm();
            if (reportingTerm == ReportingTerm.Three)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year - 1);
                reportingPeriodOfPreviousTerm.ReportingTerm.Should().Be(ReportingTerm.Two);
                return;
            }
            if (reportingTerm == ReportingTerm.One)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year);
                var previousReportingTerInt = (int)reportingPeriodOfPreviousTerm.ReportingTerm;
                previousReportingTerInt.Should().Be(6);
                return;
            }
            else
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year);
                var reportingTermInt = (int)reportingTerm;
                var previousReportingTerInt = (int)reportingPeriodOfPreviousTerm.ReportingTerm;
                previousReportingTerInt.Should().Be(reportingTermInt - 1);
            }
        }

        [Theory]
        public void GetReportingPreviousTerm_Monthly_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, reportingTerm, year);
            var reportingPeriodOfPreviousTerm = reportingPeriod.GetReportingPeriodOfPreviousTerm();
            if (reportingTerm == ReportingTerm.Four)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year - 1);
                reportingPeriodOfPreviousTerm.ReportingTerm.Should().Be(ReportingTerm.Three);
                return;
            }
            if (reportingTerm == ReportingTerm.One)
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year);
                var previousReportingTerInt = (int)reportingPeriodOfPreviousTerm.ReportingTerm;
                previousReportingTerInt.Should().Be(12);
                return;
            }
            else
            {
                reportingPeriodOfPreviousTerm.Year.Should().Be(year);
                var reportingTermInt = (int)reportingTerm;
                var previousReportingTerInt = (int)reportingPeriodOfPreviousTerm.ReportingTerm;
                previousReportingTerInt.Should().Be(reportingTermInt - 1);
            }
        }

        #region Next Term

        [TestCase(ReportingTerm.One)]
        public void GetReportingNextTerm_Year_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.Yearly, reportingTerm, year);
            var reportingPeriodOfNextTerm = reportingPeriod.GetReportingPeriodOfNextTerm();
            if (reportingTerm == ReportingTerm.One)
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year + 1);

            }
            reportingPeriodOfNextTerm.ReportingTerm.Should().Be(ReportingTerm.One);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        public void GetReportingNextTerm_HalfYearly_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.HalfYearly, reportingTerm, year);
            var reportingPeriodOfNextTerm = reportingPeriod.GetReportingPeriodOfNextTerm();
            
            if (reportingTerm == ReportingTerm.One)
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year + 1);
                var nextReportingTerInt = (int)reportingPeriodOfNextTerm.ReportingTerm;
                nextReportingTerInt.Should().Be(2);
                return;
            }
            else
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year);
                var reportingTermInt = (int)reportingTerm;
                var nextReportingTerInt = (int)reportingPeriodOfNextTerm.ReportingTerm;
                nextReportingTerInt.Should().Be(reportingTermInt - 1);
            }
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        public void GetReportingNextTerm_EveryFourMonth_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.EveryFourMonth, reportingTerm, year);
            var reportingPeriodOfNextTerm = reportingPeriod.GetReportingPeriodOfNextTerm();
            if (reportingTerm == ReportingTerm.Three)
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year);
                reportingPeriodOfNextTerm.ReportingTerm.Should().Be(ReportingTerm.One);
                return;
            }
            if (reportingTerm == ReportingTerm.One)
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year + 1);
                var nextReportingTerInt = (int)reportingPeriodOfNextTerm.ReportingTerm;
                nextReportingTerInt.Should().Be(2);
                return;
            }
            else
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year);
                var reportingTermInt = (int)reportingTerm;
                var nextReportingTerInt = (int)reportingPeriodOfNextTerm.ReportingTerm;
                nextReportingTerInt.Should().Be(reportingTermInt + 1);
            }
        }
        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        [TestCase(ReportingTerm.Four)]
        public void GetReportingNextTerm_Quarterly_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.Quarterly, reportingTerm, year);
            var reportingPeriodOfNextTerm = reportingPeriod.GetReportingPeriodOfNextTerm();
            if (reportingTerm == ReportingTerm.Four)
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year);
                reportingPeriodOfNextTerm.ReportingTerm.Should().Be(ReportingTerm.One);
                return;
            }
            if (reportingTerm == ReportingTerm.One)
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year + 1);
                var nextReportingTerInt = (int)reportingPeriodOfNextTerm.ReportingTerm;
                nextReportingTerInt.Should().Be(2);
                return;
            }
            else
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year);
                var reportingTermInt = (int)reportingTerm;
                var nextReportingTerInt = (int)reportingPeriodOfNextTerm.ReportingTerm;
                nextReportingTerInt.Should().Be(reportingTermInt + 1);
            }
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        [TestCase(ReportingTerm.Four)]
        [TestCase(ReportingTerm.Five)]
        [TestCase(ReportingTerm.Six)]
        public void GetReportingNextTerm_EveryTwoMonth_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.EveryTwoMonth, reportingTerm, year);
            var reportingPeriodOfNextTerm = reportingPeriod.GetReportingPeriodOfNextTerm();
            if (reportingTerm == ReportingTerm.Six)
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year);
                reportingPeriodOfNextTerm.ReportingTerm.Should().Be(ReportingTerm.One);
                return;
            }
            if (reportingTerm == ReportingTerm.Two)
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year+1);
                var nextReportingTerInt = (int)reportingPeriodOfNextTerm.ReportingTerm;
                nextReportingTerInt.Should().Be(3);
                return;
            }
            else
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year);
                var reportingTermInt = (int)reportingTerm;
                var nextReportingTerInt = (int)reportingPeriodOfNextTerm.ReportingTerm;
                nextReportingTerInt.Should().Be(reportingTermInt + 1);
            }
        }

        [Theory]
        public void GetReportingNextTerm_Monthly_ReturnsExpectedResult(ReportingTerm reportingTerm)
        {
            var year = 2019;
            var reportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, reportingTerm, year);
            var reportingPeriodOfNextTerm = reportingPeriod.GetReportingPeriodOfNextTerm();
            if (reportingTerm == ReportingTerm.Twelve)
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year);
                reportingPeriodOfNextTerm.ReportingTerm.Should().Be(ReportingTerm.One);
                return;
            }
            if (reportingTerm == ReportingTerm.Three)
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year+1);
                var nextReportingTerInt = (int)reportingPeriodOfNextTerm.ReportingTerm;
                nextReportingTerInt.Should().Be(4);
                return;
            }
            else
            {
                reportingPeriodOfNextTerm.Year.Should().Be(year);
                var reportingTermInt = (int)reportingTerm;
                var nextReportingTerInt = (int)reportingPeriodOfNextTerm.ReportingTerm;
                nextReportingTerInt.Should().Be(reportingTermInt + 1);
            }
        }
        #endregion

        [Theory]
        public void ReportingPeriod_Monthly_Sets_StartDate_EndDate_Correctly(ReportingTerm reportingTerm)
        {
            var reportingFrequency = ReportingFrequency.Monthly;
            var year = 2018;
            var reportingPeriod = new ReportingPeriod(reportingFrequency, reportingTerm, year);

            var months = GetStartDateEndDateMonthForMonthly(reportingTerm);
            var daysInMonth = DateTime.DaysInMonth(year, months.Item2);
            if (reportingTerm != ReportingTerm.One &&
                reportingTerm != ReportingTerm.Two &&
                reportingTerm != ReportingTerm.Three)
                year = year + 1;

            reportingPeriod.StartDate.Should().Be(new DateTime(year, months.Item1, 1));
            reportingPeriod.EndDate.Should().Be(new DateTime(year, months.Item2, daysInMonth, 23, 59, 59));
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        [TestCase(ReportingTerm.Four)]
        public void ReportingPeriod_Quarterly_Sets_StartDate_EndDate_Correctly(ReportingTerm reportingTerm)
        {
            var reportingFrequency = ReportingFrequency.Quarterly;
            var year = 2018;
            var reportingPeriod = new ReportingPeriod(reportingFrequency, reportingTerm, year);

            var months = GetStartDateEndDateMonthForQuarterly(reportingTerm);
            var daysInMonth = DateTime.DaysInMonth(year, months.Item2);
            if (reportingTerm != ReportingTerm.One)
                year = year + 1;

            reportingPeriod.StartDate.Should().Be(new DateTime(year, months.Item1, 1));
            reportingPeriod.EndDate.Should().Be(new DateTime(year, months.Item2, daysInMonth, 23, 59, 59));
        }

        [TestCase(ReportingFrequency.Yearly)]
        [TestCase(ReportingFrequency.Quarterly)]
        [TestCase(ReportingFrequency.Monthly)]
        public void ReportingPeriod_Returns_AsExpected(ReportingFrequency reportingFrequency)
        {
            var now = DateTimeDbTestExtensions.SetLocalNowToRandomDate();
            var startDate = now.AddYears(-2);
            var endDate = now.AddYears(1);

            var reportingPeriods = ReportingPeriod.GetReportingPeriods(startDate, endDate, reportingFrequency);
            if (reportingFrequency == ReportingFrequency.Yearly)
            {
                reportingPeriods.Length.Should().Be(4);
                reportingPeriods[0].Year.Should().Be(startDate.Year);
                reportingPeriods[0].ReportingTerm.Should().Be(ReportingTerm.One);
                reportingPeriods[0].ReportingFrequency.Should().Be(reportingFrequency);
                reportingPeriods[3].Year.Should().Be(endDate.Year);
                reportingPeriods[3].ReportingTerm.Should().Be(ReportingTerm.One);
                reportingPeriods[3].ReportingFrequency.Should().Be(reportingFrequency);

            }
            if (reportingFrequency == ReportingFrequency.Quarterly)
            {
                reportingPeriods.Length.Should().Be(16);
                reportingPeriods[0].Year.Should().Be(startDate.Year);
                reportingPeriods[0].ReportingTerm.Should().Be(ReportingTerm.One);
                reportingPeriods[0].ReportingFrequency.Should().Be(reportingFrequency);
                reportingPeriods[15].Year.Should().Be(endDate.Year);
                reportingPeriods[15].ReportingTerm.Should().Be(ReportingTerm.Four);
                reportingPeriods[15].ReportingFrequency.Should().Be(reportingFrequency);

            }
            if (reportingFrequency == ReportingFrequency.Monthly)
            {
                reportingPeriods.Length.Should().Be(48);
                reportingPeriods[0].Year.Should().Be(startDate.Year);
                reportingPeriods[0].ReportingTerm.Should().Be(ReportingTerm.One);
                reportingPeriods[0].ReportingFrequency.Should().Be(reportingFrequency);
                reportingPeriods[47].Year.Should().Be(endDate.Year);
                reportingPeriods[47].ReportingTerm.Should().Be(ReportingTerm.Twelve);
                reportingPeriods[47].ReportingFrequency.Should().Be(reportingFrequency);

            }



        }

        private (int, int) GetStartDateEndDateMonthForMonthly(ReportingTerm reportingTerm)
        {
            switch (reportingTerm)
            {
                case ReportingTerm.One:
                    return (10, 10);
                case ReportingTerm.Two:
                    return (11, 11);
                case ReportingTerm.Three:
                    return (12, 12);
                case ReportingTerm.Four:
                    return (1, 1);
                case ReportingTerm.Five:
                    return (2, 2);
                case ReportingTerm.Six:
                    return (3, 3);
                case ReportingTerm.Seven:
                    return (4, 4);
                case ReportingTerm.Eight:
                    return (5, 5);
                case ReportingTerm.Nine:
                    return (6, 6);
                case ReportingTerm.Ten:
                    return (7, 7);
                case ReportingTerm.Eleven:
                    return (8, 8);
                case ReportingTerm.Twelve:
                    return (9, 9);
                default: return (0, 0);
            }
        }

        private (int, int) GetStartDateEndDateMonthForQuarterly(ReportingTerm reportingTerm)
        {
            switch (reportingTerm)
            {
                case ReportingTerm.One:
                    return (10, 12);

                case ReportingTerm.Two:
                    return (1, 3);

                case ReportingTerm.Three:
                    return (4, 6);

                case ReportingTerm.Four:
                    return (7, 9);

                default: return (0, 0);
            }

        }
    }


}