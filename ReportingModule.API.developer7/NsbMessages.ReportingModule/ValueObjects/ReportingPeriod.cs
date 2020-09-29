using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportingModule.ValueObjects
{
    public class ReportingPeriod : IEquatable<ReportingPeriod>
    {
        protected ReportingPeriod() { }
        public ReportingPeriod(ReportingFrequency reportingFrequency, ReportingTerm reportingTerm, int year)
        {
            ReportingFrequency = reportingFrequency;
            ReportingTerm = reportingTerm;
            Year = year;
            SetStartDateAndEndDate();
        }


        private DateTime _startDate;
        private DateTime _endDate;
        public DateTime StartDate => _startDate;
        public DateTime EndDate => _endDate;

        public ReportingFrequency ReportingFrequency { get; private set; }
        public ReportingTerm ReportingTerm { get; private set; }
        public int Year { get; private set; }

        public ReportingPeriod GetReportingPeriodOfPreviousTerm()
        {
            var reportingTerms = GetReportingTerms(this.ReportingFrequency);
            var enumerable = reportingTerms as ReportingTerm[] ?? reportingTerms.ToArray();
            var firstTerm = enumerable.First();
            var lastTerm = enumerable.Last();

            if (this.ReportingFrequency == ReportingFrequency.Monthly)
            {
                if (this.ReportingTerm == ReportingTerm.Four)
                    return new ReportingPeriod(this.ReportingFrequency, ReportingTerm.Three, this.Year - 1);
            }

            if (this.ReportingFrequency == ReportingFrequency.EveryTwoMonth)
            {
                if (this.ReportingTerm == ReportingTerm.Three)
                    return new ReportingPeriod(this.ReportingFrequency, ReportingTerm.Two, this.Year - 1);
            }

            if (this.ReportingFrequency == ReportingFrequency.Quarterly || this.ReportingFrequency == ReportingFrequency.EveryFourMonth)
            {
                if (this.ReportingTerm == ReportingTerm.Two)
                    return new ReportingPeriod(this.ReportingFrequency, ReportingTerm.One, this.Year - 1);
            }

            if (this.ReportingFrequency == ReportingFrequency.HalfYearly)
            {
                if (this.ReportingTerm == ReportingTerm.Two)
                    return new ReportingPeriod(this.ReportingFrequency, ReportingTerm.One, this.Year - 1);
            }

            if (this.ReportingFrequency == ReportingFrequency.Yearly)
            {
                if (this.ReportingTerm == ReportingTerm.One)
                    return new ReportingPeriod(this.ReportingFrequency, ReportingTerm.One, this.Year - 1);
            }

            var reportingTermInt = (int)this.ReportingTerm;
            var previousTermInt = reportingTermInt - 1;

            if (reportingTermInt == (int)firstTerm)
                previousTermInt = (int)lastTerm;

            return new ReportingPeriod(this.ReportingFrequency, GetReportingTerm(previousTermInt), this.Year);

        }
        public ReportingPeriod GetReportingPeriodOfNextTerm()
        {
            var reportingTerms = GetReportingTerms(this.ReportingFrequency);
            var enumerable = reportingTerms as ReportingTerm[] ?? reportingTerms.ToArray();
            var firstTerm = enumerable.First();
            var lastTerm = enumerable.Last();

            if (this.ReportingFrequency == ReportingFrequency.Monthly)
            {
                if (this.ReportingTerm == ReportingTerm.Three)
                    return new ReportingPeriod(this.ReportingFrequency, ReportingTerm.Four, this.Year + 1);
            }

            if (this.ReportingFrequency == ReportingFrequency.EveryTwoMonth)
            {
                if (this.ReportingTerm == ReportingTerm.Two)
                    return new ReportingPeriod(this.ReportingFrequency, ReportingTerm.Three, this.Year + 1);
            }

            if (this.ReportingFrequency == ReportingFrequency.Quarterly || this.ReportingFrequency == ReportingFrequency.EveryFourMonth)
            {
                if (this.ReportingTerm == ReportingTerm.One)
                    return new ReportingPeriod(this.ReportingFrequency, ReportingTerm.Two, this.Year + 1);
            }

            if (this.ReportingFrequency == ReportingFrequency.HalfYearly)
            {
                if (this.ReportingTerm == ReportingTerm.One)
                    return new ReportingPeriod(this.ReportingFrequency, ReportingTerm.Two, this.Year + 1);
            }

            if (this.ReportingFrequency == ReportingFrequency.Yearly)
            {
                if (this.ReportingTerm == ReportingTerm.One)
                    return new ReportingPeriod(this.ReportingFrequency, ReportingTerm.One, this.Year + 1);
            }

            var reportingTermInt = (int)this.ReportingTerm;
            var nextTermInt = reportingTermInt + 1;

            if (reportingTermInt == (int)lastTerm)
                nextTermInt = (int)firstTerm;

            return new ReportingPeriod(this.ReportingFrequency, GetReportingTerm(nextTermInt), this.Year);

        }


        public static ReportingTerm GetReportingTerm(int reportingTerm)
        {
            switch (reportingTerm)
            {
                case (int)ReportingTerm.One:
                    return ReportingTerm.One;
                case (int)ReportingTerm.Two:
                    return ReportingTerm.Two;
                case (int)ReportingTerm.Three:
                    return ReportingTerm.Three;
                case (int)ReportingTerm.Four:
                    return ReportingTerm.Four;
                case (int)ReportingTerm.Five:
                    return ReportingTerm.Five;
                case (int)ReportingTerm.Six:
                    return ReportingTerm.Six;
                case (int)ReportingTerm.Seven:
                    return ReportingTerm.Seven;
                case (int)ReportingTerm.Eight:
                    return ReportingTerm.Eight;
                case (int)ReportingTerm.Nine:
                    return ReportingTerm.Nine;
                case (int)ReportingTerm.Ten:
                    return ReportingTerm.Ten;
                case (int)ReportingTerm.Eleven:
                    return ReportingTerm.Eleven;
                case (int)ReportingTerm.Twelve:
                    return ReportingTerm.Twelve;
            }
            throw new ArgumentOutOfRangeException(nameof(reportingTerm));
        }

        public static IEnumerable<ReportingTerm> GetReportingTerms(ReportingFrequency reportingFrequency)
        {
            switch (reportingFrequency)
            {
                case ReportingFrequency.Yearly:
                    yield return ReportingTerm.One;
                    break;
                case ReportingFrequency.HalfYearly:
                    yield return ReportingTerm.One;
                    yield return ReportingTerm.Two;
                    break;
                case ReportingFrequency.EveryFourMonth:
                    yield return ReportingTerm.One;
                    yield return ReportingTerm.Two;
                    yield return ReportingTerm.Three;
                    break;
                case ReportingFrequency.Quarterly:
                    yield return ReportingTerm.One;
                    yield return ReportingTerm.Two;
                    yield return ReportingTerm.Three;
                    yield return ReportingTerm.Four;
                    break;
                case ReportingFrequency.EveryTwoMonth:
                    yield return ReportingTerm.One;
                    yield return ReportingTerm.Two;
                    yield return ReportingTerm.Three;
                    yield return ReportingTerm.Four;
                    yield return ReportingTerm.Five;
                    yield return ReportingTerm.Six;
                    break;
                case ReportingFrequency.Monthly:
                    yield return ReportingTerm.One;
                    yield return ReportingTerm.Two;
                    yield return ReportingTerm.Three;
                    yield return ReportingTerm.Four;
                    yield return ReportingTerm.Five;
                    yield return ReportingTerm.Six;
                    yield return ReportingTerm.Seven;
                    yield return ReportingTerm.Eight;
                    yield return ReportingTerm.Nine;
                    yield return ReportingTerm.Ten;
                    yield return ReportingTerm.Eleven;
                    yield return ReportingTerm.Twelve;
                    break;
            }
        }

        public static ReportingPeriod[] GetReportingPeriods(int year, ReportingFrequency reportingFrequency)
        {
            var reportingTerms = GetReportingTerms(reportingFrequency);
            return reportingTerms.Select(o => new ReportingPeriod(reportingFrequency, o, year)).ToArray();
        }

        public static ReportingPeriod[] GetReportingPeriods(DateTime startDate, DateTime endDate, ReportingFrequency reportingFrequency)
        {
            var reportingTerms = GetReportingTerms(reportingFrequency);
            var years = new List<int>();
            for (var date = startDate;
                date <= endDate;
                date = date.AddYears(1))
                years.Add(date.Year);
            return years.SelectMany(y =>
                    reportingTerms.Select(o => new ReportingPeriod(reportingFrequency,
                        o,
                        y)))
                .ToArray();
        }

        private void SetStartDateAndEndDate()
        {
            switch (ReportingFrequency)
            {
                case ReportingFrequency.Monthly:
                    SetDateForMonthly();
                    break;
                case ReportingFrequency.EveryTwoMonth:
                    SetDateForEveryTwoMonth();
                    break;
                case ReportingFrequency.Quarterly:
                    SetDateForQuarterly();
                    break;
                case ReportingFrequency.EveryFourMonth:
                    SetDateForEveryFourMonth();
                    break;
                case ReportingFrequency.HalfYearly:
                    SetDateForHalfYearly();
                    break;
                case ReportingFrequency.Yearly:
                    SetDateForYearly();
                    break;
                default:
                    SetDateForYearly();
                    break;
            }
        }


        private void SetDateForMonthly()
        {
            switch (ReportingTerm)
            {
                case ReportingTerm.One:
                    PopulateDate(new DateTime(Year, 10, 1), new DateTime(Year, 10, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Two:
                    PopulateDate(new DateTime(Year, 11, 1), new DateTime(Year, 11, 30, 23, 59, 59));
                    break;
                case ReportingTerm.Three:
                    PopulateDate(new DateTime(Year, 12, 1), new DateTime(Year, 12, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Four:
                    PopulateDate(new DateTime(Year + 1, 1, 1), new DateTime(Year + 1, 1, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Five:
                    PopulateDate(new DateTime(Year + 1, 2, 1), new DateTime(Year + 1, 3, 1).AddSeconds(-1));
                    break;
                case ReportingTerm.Six:
                    PopulateDate(new DateTime(Year + 1, 3, 1), new DateTime(Year + 1, 3, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Seven:
                    PopulateDate(new DateTime(Year + 1, 4, 1), new DateTime(Year + 1, 4, 30, 23, 59, 59));
                    break;
                case ReportingTerm.Eight:
                    PopulateDate(new DateTime(Year + 1, 5, 1), new DateTime(Year + 1, 5, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Nine:
                    PopulateDate(new DateTime(Year + 1, 6, 1), new DateTime(Year + 1, 6, 30, 23, 59, 59));
                    break;
                case ReportingTerm.Ten:
                    PopulateDate(new DateTime(Year + 1, 7, 1), new DateTime(Year + 1, 7, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Eleven:
                    PopulateDate(new DateTime(Year + 1, 8, 1), new DateTime(Year + 1, 8, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Twelve:
                    PopulateDate(new DateTime(Year + 1, 9, 1), new DateTime(Year + 1, 9, 30, 23, 59, 59));
                    break;
            }
        }

        private void SetDateForEveryTwoMonth()
        {
            switch (ReportingTerm)
            {
                case ReportingTerm.One:
                    PopulateDate(new DateTime(Year, 10, 1), new DateTime(Year, 11, 30, 23, 59, 59));
                    break;
                case ReportingTerm.Two:
                    PopulateDate(new DateTime(Year, 12, 1), new DateTime(Year + 1, 1, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Three:
                    PopulateDate(new DateTime(Year + 1, 2, 1), new DateTime(Year + 1, 3, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Four:
                    PopulateDate(new DateTime(Year + 1, 4, 1), new DateTime(Year + 1, 5, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Five:
                    PopulateDate(new DateTime(Year + 1, 6, 1), new DateTime(Year + 1, 7, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Six:
                    PopulateDate(new DateTime(Year + 1, 8, 1), new DateTime(Year + 1, 9, 30, 23, 59, 59));
                    break;

            }
        }

        private void SetDateForQuarterly()
        {
            switch (ReportingTerm)
            {
                case ReportingTerm.One:
                    PopulateDate(new DateTime(Year, 10, 1), new DateTime(Year, 12, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Two:
                    PopulateDate(new DateTime(Year + 1, 1, 1), new DateTime(Year + 1, 3, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Three:
                    PopulateDate(new DateTime(Year + 1, 4, 1), new DateTime(Year + 1, 6, 30, 23, 59, 59));
                    break;
                case ReportingTerm.Four:
                    PopulateDate(new DateTime(Year + 1, 7, 1), new DateTime(Year + 1, 9, 30, 23, 59, 59));
                    break;
            }
        }

        private void SetDateForEveryFourMonth()
        {
            switch (ReportingTerm)
            {
                case ReportingTerm.One:
                    PopulateDate(new DateTime(Year, 10, 1), new DateTime(Year + 1, 1, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Two:
                    PopulateDate(new DateTime(Year + 1, 2, 1), new DateTime(Year + 1, 5, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Three:
                    PopulateDate(new DateTime(Year + 1, 6, 1), new DateTime(Year + 1, 9, 30, 23, 59, 59));
                    break;
            }
        }

        private void SetDateForHalfYearly()
        {
            switch (ReportingTerm)
            {
                case ReportingTerm.One:
                    PopulateDate(new DateTime(Year, 10, 1), new DateTime(Year + 1, 3, 31, 23, 59, 59));
                    break;
                case ReportingTerm.Two:
                    PopulateDate(new DateTime(Year + 1, 4, 1), new DateTime(Year + 1, 9, 30, 23, 59, 59));
                    break;
            }
        }

        private void SetDateForYearly()
        {
            PopulateDate(new DateTime(Year, 10, 1), new DateTime(Year + 1, 9, 30, 23, 59, 59));
        }

        private void PopulateDate(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public bool Equals(ReportingPeriod other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _startDate.Equals(other._startDate) && _endDate.Equals(other._endDate) && ReportingFrequency == other.ReportingFrequency && ReportingTerm == other.ReportingTerm && Year == other.Year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ReportingPeriod)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _startDate.GetHashCode();
                hashCode = (hashCode * 397) ^ _endDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)ReportingFrequency;
                hashCode = (hashCode * 397) ^ (int)ReportingTerm;
                hashCode = (hashCode * 397) ^ Year;
                return hashCode;
            }
        }
    }
}