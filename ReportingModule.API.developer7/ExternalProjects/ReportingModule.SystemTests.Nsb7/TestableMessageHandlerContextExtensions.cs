using System;
using System.Collections.Generic;
using System.Linq;
using NServiceBus;
using NServiceBus.Testing;

namespace ReportingModule.SystemTests.Nsb7
{
    public static class TestableMessageHandlerContextExtensions
    {
        public static T ExpectPublish<T>(this TestableMessageHandlerContext context, Func<T, bool> matching = null) where T : IMessage
        {
            var publishedMessages = GetPublishedMessages(context, matching);
            if (publishedMessages.Count < 1)
            {
                var eventsString = GetPublishedEvents(context);
                eventsString = !string.IsNullOrWhiteSpace(eventsString) ? $"Actual Events published: {eventsString}" : null;
                throw new Exception($"Expected 1 message of type {typeof(T)} but found {publishedMessages.Count}. {eventsString}");
            }

            return publishedMessages.First();
        }

        public static List<T> ExpectPublish<T>(this TestableMessageHandlerContext context, int expectedNumberOfMessages, Func<T, bool> matching = null) where T : IMessage
        {
            var publishedMessages = GetPublishedMessages(context, matching);
            if (publishedMessages.Count != expectedNumberOfMessages)
                throw new Exception($"Expected {expectedNumberOfMessages} messages of type {typeof(T)} but found {publishedMessages.Count}");
            return publishedMessages;
        }

        public static void ExpectNotPublish<T>(this TestableMessageHandlerContext context, Func<T, bool> matching = null) where T : IMessage
        {
            var publishedMessages = GetPublishedMessages(context, matching);
            if (publishedMessages.Count != 0)
                throw new Exception($"Expected no message of type {typeof(T)} but found {publishedMessages.Count}");
        }

        private static List<T> GetPublishedMessages<T>(TestableMessageHandlerContext context, Func<T, bool> matching) where T : IMessage
        {
            return context.PublishedMessages
                .Select(x => x.Message)
                .Where(x => x is T)
                .Cast<T>()
                .Where(m => matching?.Invoke(m) ?? true)
                .ToList();
        }

        private static string GetPublishedEvents(TestableMessageHandlerContext context)
        {
            var eventType = typeof(IEvent);
            return string.Join(Environment.NewLine,
                context.PublishedMessages
                    .Select(x => x.Message)
                    .Select(o => o.GetType().GetInterfaces()
                        .Any(y => eventType.IsAssignableFrom(y))
                        ? o.ToString()
                        : null)
                    .Where(x => !string.IsNullOrWhiteSpace(x)));

        }

        public static T ExpectSend<T>(this TestableMessageHandlerContext context, Func<T, bool> matching = null) where T : IMessage
        {
            var sentMessages = GetSentMessages(context, matching);
            if (sentMessages.Count < 1)
                throw new Exception($"Expected 1 messages of type {typeof(T)} but found {sentMessages.Count}");
            return sentMessages.First();
        }

        public static List<T> ExpectSendMany<T>(this TestableMessageHandlerContext context, Func<T, bool> matching = null) where T : IMessage
        {
            var sentMessages = GetSentMessages(context, matching);
            if (sentMessages.Count < 1)
                throw new Exception($"Expected 1 messages of type {typeof(T)} but found {sentMessages.Count}");
            return sentMessages;
        }

        public static List<T> ExpectSend<T>(this TestableMessageHandlerContext context, int expectedNumberOfMessages, Func<T, bool> matching = null) where T : IMessage
        {
            var sentMessages = GetSentMessages(context, matching);
            if (sentMessages.Count != expectedNumberOfMessages)
                throw new Exception($"Expected {expectedNumberOfMessages} messages of type {typeof(T)} but found {sentMessages.Count}");
            return sentMessages;
        }

        public static void ExpectNotSend<T>(this TestableMessageHandlerContext context, Func<T, bool> matching = null) where T : IMessage
        {
            var sentMessages = GetSentMessages(context, matching);
            if (sentMessages.Count != 0)
                throw new Exception($"Expected no message of type {typeof(T)} but found {sentMessages.Count}");
        }

        private static List<T> GetSentMessages<T>(TestableMessageHandlerContext context, Func<T, bool> matching) where T : IMessage
        {
            return context.SentMessages
                .Select(x => x.Message)
                .Where(x => x is T)
                .Cast<T>()
                .Where(m => matching?.Invoke(m) ?? true)
                .ToList();
        }
    }
}
