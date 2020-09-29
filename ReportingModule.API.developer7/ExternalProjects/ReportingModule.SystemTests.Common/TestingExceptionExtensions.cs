using System;
using NUnit.Framework;

namespace ReportingModule.SystemTests.Common
{
    public static class TestingExceptionExtensions
    {
        public static ArgumentException FailedParameterIs(this ArgumentException e, string paramName)
        {
            Assert.AreEqual(paramName, e.ParamName);
            return e;
        }

		public static Exception MessageContains(this Exception e, string messageString)
		{
			Assert.IsTrue(e.Message.IndexOf(messageString, StringComparison.InvariantCultureIgnoreCase) >= 0,
				string.Format("Expected message to contain '{0}' but was '{1}'", messageString, e.Message));
			return e;
		}

		public static T OfExceptionType<T>(this Exception e) where T: Exception
		{
			Assert.IsInstanceOf<T>(e);
			return (T)e;
		}

		public static Exception ContainingMessageText(this Exception e, params string[] messageText)
		{
			foreach (var msgText in messageText)
			{
				Assert.IsTrue(e.Message.Contains(msgText));
			}
			return e;
		}
    }
}