using System;
using ReportingModule.Utility;

namespace ReportingModule.Core
{
	public class DateRange : IEquatable<DateRange>
	{
	    protected DateRange()
	    {
	    }

		public DateRange(DateTime from, DateTime to)
		{
			if (from.Date != from)
			{
				throw new ArgumentException("'From' date must not include time component", nameof(@from));
			}

			if (to.Date != to)
			{
				throw new ArgumentException("'To' date must not include time component", nameof(to));
			}

			if (from > to)
			{
				throw new ArgumentException("'From' date must not be after 'To' date");
			}

			From = from;
			To = to;
		}

		public bool ContainsDate(DateTime date)
		{
			if (date.Date != date)
			{
				throw new ArgumentException("date must not include time component", nameof(date));
			}
			return date >= From && date <= To;
		}

		public DateTime From { get; private set; }
		public DateTime To { get; private set; }

	    public override string ToString()
	    {
	        return $"{From.GetDateString()} - {To.GetDateString()}";
	    }

	    #region Equality

		public bool Equals(DateRange other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return From.Equals(other.From) && To.Equals(other.To);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((DateRange) obj);
		}

		public override int GetHashCode()
		{
			return new object[] {From, To}.GenerateHashCode();
		}

		public static bool operator ==(DateRange left, DateRange right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(DateRange left, DateRange right)
		{
			return !Equals(left, right);
		}

		#endregion
	}
}