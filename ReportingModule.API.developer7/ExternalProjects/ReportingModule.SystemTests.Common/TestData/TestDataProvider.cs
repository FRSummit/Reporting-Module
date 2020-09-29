using System;
using System.Linq;
using NUnit.Framework;

namespace ReportingModule.Tests.Shared.Core.TestData
{
	public static class TestDataProvider
	{
		public static void Initialise(object testObject)
		{
			if (testObject == null) throw new ArgumentNullException(nameof(testObject));

		    var testObjectType = testObject.GetType();

		    var allFunctions = testObjectType
				.GetMethods()
				.Where(x => x.GetCustomAttributes(typeof (TestCaseAutoSourceAttribute), false).Any()).ToArray();

			if (!allFunctions.Any())
			{
				var devMsg =
				    $"The {testObjectType.Name} test object does not have any tests that use an automatically provided source of test data. There must be at least one unit test with the TestCaseAutoSourceAttribute.";
				throw new ArgumentException(devMsg, nameof(testObject));
			}

			foreach (var testFunc in allFunctions)
			{
				var attr = testFunc.GetCustomAttributes(typeof (TestCaseAutoSourceAttribute), false)
				    .Cast<TestCaseAutoSourceAttribute>()
				    .First();
				var testDataSource = attr.SourceName;
				var propertyInfo = testObjectType.GetProperty(testDataSource);
				if (propertyInfo == null)
				{
					var msg = string.Format("The specified datasource, {0}, for the test {1}.{2}, is not a property.\nYou need something like this in your test class: 'public IEnumerable<TestCaseData> {0} {{get;set;}}'.",
					                        testDataSource,
					                        testObjectType.Name,
					                        testFunc.Name);
					throw new Exception(msg);
				}

				var dsSetter = propertyInfo.GetSetMethod(true);
				if (dsSetter == null)
				{
					var msg = string.Format("The specified datasource, {0}, for test {1}.{2}, is not a property with a setter.\nYou need something like this in your test class: 'public IEnumerable<TestCaseData> {0} {{get;set;}}'.",
					                        testDataSource,
					                        testObjectType.Name,
					                        testFunc.Name);
					throw new Exception(msg);
				}

				var testName = testFunc.Name;
				TestCaseData testCaseData = new TestCaseDataBuilder(testObjectType, testName).Name(testName);
				var testData = new[] {testCaseData};
				dsSetter.Invoke(testObject, new object[] {testData});
			}
		}
	}
}