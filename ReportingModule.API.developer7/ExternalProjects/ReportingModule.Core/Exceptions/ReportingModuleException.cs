using System;

namespace ReportingModule.Core.Exceptions
{
	/// <summary>
	/// Base class for all ReportingModule exceptions
	/// The idea is that ReportingModule exceptions contain user-acceptable error messages,
	/// and can be displayed directly
	/// </summary>
	public class ReportingModuleException : Exception
	{
		public ReportingModuleException(string message) : base(message) { }

		public ReportingModuleException(string message, Exception x) : base(message, x) { }

		public ReportingModuleException(string format, params object[] args) : base(String.Format(format, args)) { }

	}
}
