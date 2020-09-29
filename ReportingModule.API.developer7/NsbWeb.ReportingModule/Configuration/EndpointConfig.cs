using ReportingModule.Core.Configuration;

namespace NsbWeb.ReportingModule.Configuration
{
    public class EndpointConfig
    {
        public static string ApiServerEndpointName => ConfigurationExtensions.GetStringConfigValue(nameof(ApiServerEndpointName));
    }
}