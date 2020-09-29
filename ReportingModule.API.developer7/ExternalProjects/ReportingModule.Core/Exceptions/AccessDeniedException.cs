namespace ReportingModule.Core.Exceptions
{
	/// <summary>
	/// Summary description for AccessDeniedException.
	/// </summary>
	public class AccessDeniedException : ReportingModuleException
	{
		public AccessDeniedException() : base("Access to this function is denied") { }

		public AccessDeniedException(string message) : base(message) { }

		public AccessDeniedException(string format, params object[] args) : base(string.Format(format, args)) { }
	}
}
