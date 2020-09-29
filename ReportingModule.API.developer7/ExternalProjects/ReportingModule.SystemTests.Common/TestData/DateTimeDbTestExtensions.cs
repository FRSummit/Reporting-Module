using System;
using ReportingModule.Utility;

namespace ReportingModule.SystemTests.Common.TestData
{
	public static class DateTimeDbTestExtensions
	{
		public static DateTime ModifyForPersistenceTests(this DateTime dateTime)
		{
		    return new DateTime(
		        dateTime.Year,
		        dateTime.Month,
		        dateTime.Day,
		        dateTime.Hour,
		        dateTime.Minute,
		        dateTime.Second,
		        dateTime.Kind);
		}

		public static DateTime SetUtcNowToRandomDate()
		{
			var now = DataProvider.RandomDate(DateTimeKind.Utc).ModifyForPersistenceTests();
			ZaphodTime.UtcNowResolver = () => now;
			return now;
		}

        public static DateTime SetLocalNowToRandomDate()
        {
            var now = DataProvider.RandomDate(DateTimeKind.Local).ModifyForPersistenceTests();
            ZaphodTime.LocalNowResolver = () => now;
            return now;
        }
    }
}
