using System;
using NUnit.Framework;

namespace ReportingModule.Tests.Shared.Core.TestData
{
	public class TestCaseAutoSourceAttribute : TestCaseSourceAttribute
	{
		public TestCaseAutoSourceAttribute(string sourceName) 
			: base(sourceName)
		{
		}

		public TestCaseAutoSourceAttribute(Type sourceType, string sourceName) 
			: base(sourceType, sourceName)
		{
		}
	}
}