using Microsoft.AspNet.SignalR;
using NServiceBus;
using ReportingModule.Core;
using ReportingModule.Core.Metadata;

namespace NsbWeb.Core
{
    public static class SignalRClientUtility
    {
        public static dynamic GetSignalRClientFromMessageContext<THub>(this IMessageHandlerContext context) 
            where THub : Hub
        {

            var connectionId = context.GetSignalRConnectionIdFromMessageContext();
            if (connectionId == null) return null;
            var hubClient = GlobalHost.ConnectionManager.GetHubContext<THub>().Clients.Client(connectionId);

            return hubClient;
        }

        public static dynamic GetSignalRClientFromUserRef<THub>(UserReference userRef) 
            where THub : Hub
        {
            if (userRef == null)
                return null;

            var context = GlobalHost.ConnectionManager.GetHubContext<THub>();
            return context.Clients.User(userRef.UserId);
        }

        public static string GetSignalRConnectionIdFromMessageContext(this IMessageHandlerContext messageHandlerContext)
        {
            if (!messageHandlerContext.MessageHeaders.ContainsKey(MetaDataConstants.SignalRConnectionId)) return null;
            return messageHandlerContext.MessageHeaders[MetaDataConstants.SignalRConnectionId];
        }

        public static string GetSignalRCorrelationIdFromMessageContext(this IMessageHandlerContext messageHandlerContext)
        {
            if (!messageHandlerContext.MessageHeaders.ContainsKey(MetaDataConstants.SignalRCorrelationId)) return null;
            return messageHandlerContext.MessageHeaders[MetaDataConstants.SignalRCorrelationId];
        }
    }
}