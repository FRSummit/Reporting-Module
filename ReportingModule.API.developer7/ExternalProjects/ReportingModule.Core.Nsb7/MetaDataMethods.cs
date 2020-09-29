using System;
using System.Collections.Generic;
using NServiceBus;
using ReportingModule.Core.Exceptions;
using ReportingModule.Core.Metadata;
using ReportingModule.Utility;

namespace ReportingModule.Core.Nsb7
{
    public static class MetaDataMethods
    {
        public static SendOptions SetUserIdAndTimestampOnMessageHeader(
            this SendOptions sendOptions,
            int userId,
            DateTime utcTime)
        {
            if (sendOptions == null) throw new ArgumentNullException(nameof(sendOptions));
            sendOptions.SetHeader(MetaDataConstants.UserId, userId.SerializeViewModel());
            sendOptions.SetHeader(MetaDataConstants.CommandSentUtc, utcTime.SerializeViewModel());
            return sendOptions;
        }

        public static SendOptions SetSystemUserAndTimestampOnMessageHeader(this SendOptions sendOptions, DateTime utcTime)
        {
            return sendOptions.SetUserIdAndTimestampOnMessageHeader(SystemUserId, utcTime);
        }

        private const int SystemUserId = 295;

        public static IDictionary<string, object> GetMetaDataDictionary(
            this IMessage message,
            IMessageHandlerContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            var result = new Dictionary<string, object>();


            if (context.MessageHeaders.TryGetValue(MetaDataConstants.UserId, out var userIdString) && int.TryParse(userIdString, out var userId))
            {
                result.Add(MetaDataConstants.UserId, userId);
            }

            if (context.MessageHeaders.TryGetValue(MetaDataConstants.CommandSentUtc, out var commandSentUtcString) && commandSentUtcString.TryDeserializeUtcTime(out var commandSentUtc))
            {
                result.Add(MetaDataConstants.CommandSentUtc, commandSentUtc);
            }

            return result;
        }

        public static int GetUserIdFromMetadata(
            this IMessage message,
            IMessageHandlerContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (context.MessageHeaders.TryGetValue(MetaDataConstants.UserId, out var userIdString) && int.TryParse(userIdString, out var userId))
            {
                return userId;
            }

            throw new CannotGetUserIdFromNsbMetaDataException();
        }

        public static string GetUsernameFromMetadata(
            this IMessage message,
            IMessageHandlerContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (context.MessageHeaders.TryGetValue(MetaDataConstants.Username, out var userName))
            {
                if (!string.IsNullOrWhiteSpace(userName))
                    return userName;
            }

            throw new CannotGetUsernameFromNsbMetaDataException();
        }

        public static DateTime GetTimestampFromMetadata(
            this IMessage message,
            IMessageHandlerContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (context.MessageHeaders.TryGetValue(MetaDataConstants.CommandSentUtc, out var commandSentUtcString) && commandSentUtcString.TryDeserializeUtcTime(out var commandSentUtc))
            {
                return commandSentUtc;
            }

            throw new CannotGetTimestampFromNsbMetaDataException();
        }

        public static Dictionary<string, string> AddHeadersIfDoNotExist(
            this Dictionary<string, string> headers,
            IEnumerable<KeyValuePair<string, string>> headerValues)
        {
            foreach (var headerValue in headerValues)
            {
                if (!headers.ContainsKey(headerValue.Key))
                {
                    headers[headerValue.Key] = headerValue.Value;
                }
            }

            return headers;
        }
    }
}