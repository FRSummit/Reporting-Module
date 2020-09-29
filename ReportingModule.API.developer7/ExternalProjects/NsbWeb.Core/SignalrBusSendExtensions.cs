using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NServiceBus;
using ReportingModule.Core.Metadata;
using ReportingModule.Utility;
using ICommand = NServiceBus.ICommand;

namespace NsbWeb.Core
{
    public static class SignalRBusSendExtensions
    {
        public static Task SendWithSignalRMetaData(this IEndpointInstance endpointInstance, ICommand command, HttpRequestMessage request, SendOptions incomingOptions = null)
        {
            var sendOptions = incomingOptions ?? new SendOptions();
            if (request.Headers.Contains(MetaDataConstants.SignalRConnectionId))
            {
                var connectionId = request.Headers.GetValues(MetaDataConstants.SignalRConnectionId).Single();
                sendOptions.SetHeader(MetaDataConstants.SignalRConnectionId, connectionId);
                if (request.Properties.ContainsKey(MetaDataConstants.SignalRCorrelationId))
                {
                    var correlationId = request.Properties[MetaDataConstants.SignalRCorrelationId] as string;
                    sendOptions.SetHeader(MetaDataConstants.SignalRCorrelationId, correlationId);
                }
            }
            sendOptions.SetHeader(MetaDataConstants.CommandSentUtc, ZaphodTime.UtcNow.SerializeViewModel());
            sendOptions.SetUserInfoOnHeader();

            return endpointInstance.Send(command, sendOptions);
        }

        public static void SetUserInfoOnHeader(this SendOptions sendOptions)
        {
            var userId = UserContext.GetLoggedInUserId();
            if (userId != null)
                sendOptions.SetHeader(MetaDataConstants.UserId, userId.SerializeViewModel());

            var userRef = UserContext.GetLoggedInUser();
            if (userRef != null)
                sendOptions.SetHeader(MetaDataConstants.UserRef, userRef.SerializeViewModel());

            var username = UserContext.GetLoggedInUsername();
            if (username != null)
                sendOptions.SetHeader(MetaDataConstants.Username, username.SerializeViewModel());
        }
    }
}