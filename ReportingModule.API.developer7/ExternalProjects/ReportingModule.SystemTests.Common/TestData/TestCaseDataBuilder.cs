using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace ReportingModule.Tests.Shared.Core.TestData
{
	// Set it up with a testObject (instance of a unit test object), and testName (name of a unit test function).
	// Primarily used via the TestCaseAutoSourceAttribute.
	// However, you can also manually use it yourself, see FclShipmentCostingSampleTests 
	public class TestCaseDataBuilder
	{
		private readonly MethodInfo _testMethodInfo;
		private string TestDescription { get; set; }
		private readonly ParameterProvider _parameterProvider;

		public TestCaseDataBuilder(Type testObjectType, string testName)
		{
		    if (testObjectType == null) throw new ArgumentNullException(nameof(testObjectType));
		    if (string.IsNullOrWhiteSpace(testName)) throw new ArgumentNullException(nameof(testName), "A test function name is required");
			_testMethodInfo = testObjectType.GetMethod(testName);
			if (_testMethodInfo == null)
			{
				throw new Exception($"Test method {testObjectType.Name}.{testName} does not exist");
			}
			TestDescription = testName;
			_parameterProvider = new ParameterProvider();
		}

		public TestCaseDataBuilder Name(string name)
		{
			TestDescription = name;
			return this;
		}

		public TestCaseDataBuilder SetTypeProvider<T2>(Func<T2> provider)
		{
			_parameterProvider.SetTypeProvider(provider);
			return this;
		}

		public TestCaseDataBuilder SetTypeProvider<T2>(T2 value)
		{
			_parameterProvider.SetTypeProvider(value);
			return this;
		}

		public TestCaseDataBuilder SetArgument(string arg, object value)
		{
			_parameterProvider.SetArgument(arg, value);
			return this;
		}

		public static implicit operator TestCaseData(TestCaseDataBuilder b)
		{
			return b.Build();
		}

		public TestCaseData Build()
		{
			var testParameters = _testMethodInfo.GetParameters();
			if (!testParameters.Any())
			{
				string msg =
				    $"There are no parameters for the test {_testMethodInfo.Name}. Your test function must have some parameters for the builder to provide test values.";
				throw new Exception(msg);
			}

			object[] testParametersValues = testParameters.Select(_parameterProvider.GetValue).ToArray();
			return new TestCaseData(testParametersValues).SetName(TestDescription);
		}
	}
}