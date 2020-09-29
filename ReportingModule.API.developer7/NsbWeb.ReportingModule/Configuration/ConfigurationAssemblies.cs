using System.Reflection;
using ReportingModule.Commands;

namespace NsbWeb.ReportingModule.Configuration
{
    public static class ConfigurationAssemblies
    {
        public static (Assembly, string)[] MessageRoutes = {
            (typeof(PingCommand).Assembly, EndpointConfig.ApiServerEndpointName)
        };
    }
}