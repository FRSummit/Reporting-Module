using ReportingModule.Tests.Shared.Core.TestData;

namespace ReportingModule.SystemTests.Common.TestData
{
	public static class UniqueIdGenerator
	{
		public static int Next()
		{
			return DataProvider.Get<int>();
		}
	}
}