using System;

namespace ReportingModule.Utility
{
	/// <summary>
	/// 
	/// Probably should be called SystemTime, but that name is already taken, numerous times over.
	/// 
	/// Provides the ability to override the current moment in time to facilitate testing.
	/// Original idea by Ayende Rahien:
	/// http://ayende.com/Blog/archive/2008/07/07/Dealing-with-time-in-tests.aspx
	/// This version was, er, borrowed, from JOliver's EventStore.
	/// </summary>
	public static class ZaphodTime
	{
		/// <summary>
		/// The callback to be used to resolve the current moment in time.
		/// </summary>
		public static Func<DateTime> UtcNowResolver;

		public static Func<DateTime> LocalNowResolver; 

		/// <summary>
		/// Gets the current moment in time.
		/// </summary>
		public static DateTime UtcNow
		{
			get { return UtcNowResolver == null ? DateTime.UtcNow : UtcNowResolver(); }
		}

		public static DateTime LocalNow
		{
			get { return LocalNowResolver == null ? DateTime.Now : LocalNowResolver(); }
		}

		
		// The newer than new way (for timestamp like properties)...
		public static Func<DateTimeOffset> UtcOffsetNowResolver;

		public static DateTimeOffset UtcOffsetNow
		{
			get { return UtcOffsetNowResolver == null ? DateTimeOffset.UtcNow : UtcOffsetNowResolver(); }
		}
	}
}