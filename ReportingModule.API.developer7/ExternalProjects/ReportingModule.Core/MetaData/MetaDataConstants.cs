namespace ReportingModule.Core.Metadata
{
	public static class MetaDataConstants
	{
		public const string UserId = "UserId";
	    public const string UserRef = "UserRef";
        //ReportingModule
        public const string CommandSentUtc = "CommandSentUtc";
		public const string SignalRConnectionId = "SignalRConnectionId";
		public const string Username = "Username";
        public const string SignalRCorrelationId = "SignalRCorrelationId";

        public static string[] AllConstants =
		{
			UserId,
            UserRef,
			CommandSentUtc,
			SignalRConnectionId,
            Username,
            SignalRConnectionId
		};
	}
}