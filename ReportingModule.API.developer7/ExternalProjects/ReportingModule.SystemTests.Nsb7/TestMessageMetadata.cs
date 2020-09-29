using System;
using NServiceBus.Testing;
using ReportingModule.Core;
using ReportingModule.Core.Metadata;
using ReportingModule.Utility;

namespace ReportingModule.SystemTests.Nsb7
{
	public static class TestMessageMetaData
	{
        public static TestableMessageHandlerContext SetUserIdOnHeader(this TestableMessageHandlerContext context, int userId)
		{
			context.MessageHeaders.Add(MetaDataConstants.UserId, userId.SerializeViewModel());
            return context;
        }

		public static TestableMessageHandlerContext SetUserRefOnHeader(this TestableMessageHandlerContext context, UserReference userRef)
		{
			context
				.SetUserIdOnHeader(userRef.Id)
				.MessageHeaders.Add(MetaDataConstants.UserRef, userRef.SerializeViewModel());
            return context;
        }

		public static TestableMessageHandlerContext SetTimestampOnHeader(this TestableMessageHandlerContext context, DateTime commandSentTimestampUtc)
		{
			context.MessageHeaders.Add(MetaDataConstants.CommandSentUtc, commandSentTimestampUtc.SerializeViewModel());
            return context;
        }

		public static TestableMessageHandlerContext SetUserInfoAndTimestampOnHeader(this TestableMessageHandlerContext context,
			UserReference userRef,
			DateTime messageTimestamp)
		{
			context.SetUserIdOnHeader(userRef.Id)
                .SetUserRefOnHeader(userRef)
                .SetTimestampOnHeader(messageTimestamp);
			return context;
		}

		public static TestableMessageHandlerContext SetUsernameOnHeader(this TestableMessageHandlerContext context, string username)
		{
			context.MessageHeaders.Add(MetaDataConstants.Username, username);
            return context;
        }
	}
}
