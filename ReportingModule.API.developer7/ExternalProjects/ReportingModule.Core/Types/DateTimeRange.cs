using System;
using ReportingModule.Utility;

namespace ReportingModule.Core
{
	public class DateTimeRange : IEquatable<DateTimeRange>
	{
		protected DateTimeRange()
		{	
		}

		public DateTimeRange(DateTime from, DateTime to)
		{
			From = from;
			To = to;

			if (from > to)
			{
				throw new ArgumentException("'From' date must not be after 'To' date");
			}
		}

		public virtual DateTime From { get; protected set; }
		public virtual DateTime To { get; protected set; }

		#region Equality

		public bool Equals(DateTimeRange other)
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
			return Equals((DateTimeRange)obj);
		}

		public override int GetHashCode()
		{
			return new object[]
			{
				From,
				To
			}.GenerateHashCode();
		}

		public static bool operator ==(DateTimeRange left, DateTimeRange right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(DateTimeRange left, DateTimeRange right)
		{
			return !Equals(left, right);
		}

		#endregion

	}
}