using System;
using System.Collections.Generic;
using System.Globalization;

namespace ReportingModule.Utility
{
	public static class DateUtility
	{
		public static readonly string ShortDateFormatString = "dd-MMM-yyyy";
		public static readonly string LongDateFormatString = "dd-MMM-yyyy HH:mm";
		public static readonly string LongDateTimeFormatString = "dd-MMM-yyyy HH:mm:ss";
		public static readonly string TimeOfDayFormatString = "HH:mm:ss";
		public static readonly string FileNameSortableDateTimeFormatString = "yyyyMMddHHmmss";

		public static string GetFormattedDateString(this DateTime? inDate, string format, string defaultValue = null)
		{
			return inDate.HasValue ? inDate.Value.ToString(format, CultureInfo.GetCultureInfo("en-AU")) : defaultValue;
		}

		public static string GetFormattedDateString(this DateTime inDate, string format)
		{
			return inDate.ToString(format, CultureInfo.GetCultureInfo("en-AU"));
		}

		public static string GetDateString(this DateTime? inDate)
		{
			return GetDateString(inDate, null);
		}

		public static string GetDateString(this DateTimeOffset? inDate)
		{
			if (!inDate.HasValue)
				return null;

			var date = inDate.Value;

			return date.ToString(date == date.Date
				? ShortDateFormatString
				: LongDateFormatString,
				CultureInfo.GetCultureInfo("en-AU"));
		}

		public static string GetDateString(DateTime? inDate, string defaultValue)
		{
			return inDate.HasValue ? GetDateString(inDate.Value) : defaultValue;
		}

		public static string GetDateString(this DateTime inDate)
		{
			return inDate.ToString(inDate == inDate.Date
				? ShortDateFormatString
				: LongDateFormatString,
				CultureInfo.GetCultureInfo("en-AU"));
		}

		public static string GetDateTimeString(this DateTime? inDate)
		{
			return GetDateTimeString(inDate, null);
		}

		public static string GetDateTimeString(DateTime? inDate, string defaultValue)
		{
			return inDate.HasValue ? GetDateTimeString(inDate.Value) : defaultValue;
		}

		public static string GetDateTimeString(this DateTime inDate)
		{
			return inDate.ToString(LongDateTimeFormatString, CultureInfo.GetCultureInfo("en-AU"));
		}

		public static string GetIsoDateString(DateTime? inDate)
		{
			return inDate.HasValue ? inDate.Value.ToString("s") : string.Empty;
		}

		public static string GetShortDateString(this DateTime? inDate)
		{
			return inDate.HasValue ? inDate.Value.GetShortDateString() : string.Empty;
		}

		public static string GetShortDateString(this DateTime inDate)
		{
			return inDate.ToString(ShortDateFormatString);
		}

		public static string GetTimeOfDayString(this DateTime? inDateTime)
		{
			return inDateTime.HasValue ? inDateTime.Value.GetTimeOfDayString() : string.Empty;
		}

		public static string GetTimeOfDayString(this DateTime inDateTime)
		{
			return inDateTime.ToString(TimeOfDayFormatString);
		}

		public static string GetFileNameSortableDateString(this DateTime inDate)
		{
			return inDate.ToString(FileNameSortableDateTimeFormatString);
		}

		private static readonly IDictionary<DayOfWeek, int> IsoDayOfWeek
			= new Dictionary<DayOfWeek, int>
			{
				{DayOfWeek.Monday, 0},
				{DayOfWeek.Tuesday, 1},
				{DayOfWeek.Wednesday, 2},
				{DayOfWeek.Thursday, 3},
				{DayOfWeek.Friday, 4},
				{DayOfWeek.Saturday, 5},
				{DayOfWeek.Sunday, 6}
			};

		public static DateTime GetStartOfWeek(int year, int weekNumber)
		{
			// January 4th is by ISO 8601 definition in week 1
			// .NET has DayOfWeek.Sunday = 0 to DayOfWeek.Saturday = 6 - first day of week is Sunday
			// ISO8601 has Monday = 0 to Sunday = 6 - first day of week is Monday
			var start = new DateTime(year, 1, 4);
			return start.AddDays(-IsoDayOfWeek[start.DayOfWeek])
				.AddDays(7*(weekNumber - 1));
		}

		public static DateTime GetMondayOfWeek(this DateTime date)
		{
			return date.AddDays(-1*IsoDayOfWeek[date.DayOfWeek]).Date;
		}

		#region CodeProject article by Siva Ram Mateti

		// http://www.codeproject.com/csharp/GregToISO.asp?msg=396665

		// Static Method to check Leap Year
		public static bool IsLeapYear(int yyyy)
		{
			return (yyyy%4 == 0 && yyyy%100 != 0) || (yyyy%400 == 0);
		}

		// ISO 8601 Week number.
		// Refer http://blogs.msdn.com/b/shawnste/archive/2006/01/24/iso-8601-week-of-year-format-in-microsoft-net.aspx
		public static int GetIsoWeekNumber(this DateTime date)
		{
			// Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
			// be the same week# as whatever Thursday, Friday or Saturday are,
			// and we always get those right
			DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
			if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
			{
				date = date.AddDays(3);
			}

			// Return the week of our adjusted day
			return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}

		#endregion

		public static DateTime? ParseDate(this string dateString)
		{
			DateTime tempDate;
			int relativeDays;

			if (dateString == null || dateString.Trim() == "" || dateString == "TBA")
			{
				return null;
			}

			if (Int32.TryParse(dateString, out relativeDays))
			{
				return DateTime.Now.Date.AddDays(relativeDays);
			}

			if (DateTime.TryParse(dateString, out tempDate))
			{
				return tempDate;
			}

			throw new ArgumentException(String.Format("{0} is not a valid date", dateString), dateString);
		}

		public static TimeSpan? ParseTime(string timeString)
		{
			TimeSpan tempTime;

			if (String.IsNullOrWhiteSpace(timeString) || timeString.Trim() == ":")
			{
				return null;
			}

			if (TimeSpan.TryParse(timeString, out tempTime))
			{
				return tempTime;
			}

			throw new ArgumentException(String.Format("{0} is not a valid time", timeString), timeString);
		}

		public static bool ConsideringWeekendsIsOnOrAfter(this DateTime dateTime, DateTime other)
		{
			var date = dateTime.Date;
			var otherDate = other.Date;
			var consideredDate = otherDate.AddDays(ConsideredDateOffset[otherDate.DayOfWeek]);
			return (date >= consideredDate);
		}

		private static readonly IDictionary<DayOfWeek, int> ConsideredDateOffset
			= new Dictionary<DayOfWeek, int>
			{
				{DayOfWeek.Monday, 0},
				{DayOfWeek.Tuesday, 0},
				{DayOfWeek.Wednesday, 0},
				{DayOfWeek.Thursday, 0},
				{DayOfWeek.Friday, 0},
				{DayOfWeek.Saturday, -1},
				{DayOfWeek.Sunday, -2},
			};


		public static DateTime AddDaysSkippingWeekends(this DateTime date, int daysToAdd)
		{
			var offset = date.AddDays(daysToAdd);
			return offset.AddDays(SkipWeekendOffset[offset.DayOfWeek]);
		}

		private static readonly IDictionary<DayOfWeek, int> SkipWeekendOffset
			= new Dictionary<DayOfWeek, int>
			{
				{DayOfWeek.Monday, 0},
				{DayOfWeek.Tuesday, 0},
				{DayOfWeek.Wednesday, 0},
				{DayOfWeek.Thursday, 0},
				{DayOfWeek.Friday, 0},
				{DayOfWeek.Saturday, 2},
				{DayOfWeek.Sunday, 1}
			};
	}
}