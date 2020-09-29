using System;
using System.Configuration;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using NsbWeb.ReportingModule.Configuration;
using NServiceBus;
using NServiceBus.Persistence.Sql;
using NServiceBus.Transport.SQLServer;
using ReportingModule.Core.Configuration;

namespace ReportingModule.Website
{
    public class EndpointConfig
    {
        public static ILog Log;
        public static string ApiEndpointName => ConfigurationExtensions.GetStringConfigValue(nameof(ApiEndpointName));
        private static string ApiTransportSchema => ConfigurationExtensions.GetStringConfigValue(nameof(ApiTransportSchema));
        private static string ApiErrorQueue => ConfigurationExtensions.GetStringConfigValue(nameof(ApiErrorQueue));
        private static int ApiCacheSubscriptionsForMinutes => ConfigurationExtensions.GetIntConfigValue(nameof(ApiCacheSubscriptionsForMinutes));
        private static string ServiceControlQueue => ConfigurationManager.AppSettings["ServiceControl/Queue"];
        private static TimeSpan HeartbeatInterval =>
            TimeSpan.TryParse(ConfigurationManager.AppSettings["heartbeat/interval"], out var p)
                ? p
                : TimeSpan.FromSeconds(10);

        public static void Customize(EndpointConfiguration endpointConfiguration)
        {
            XmlConfigurator.Configure();
            NServiceBus.Logging.LogManager.Use<Log4NetFactory>();
            if (Log == null)
                Log = LogManager.GetLogger(nameof(EndpointConfig));
            
            Log.Info("Logging configured. Configuring the bus.");

            endpointConfiguration.EnableInstallers();
            endpointConfiguration.SendFailedMessagesTo(ApiErrorQueue);
            endpointConfiguration.UseContainer<StructureMapBuilder>(customizations => customizations.ExistingContainer(Ioc.Container));
            
            endpointConfiguration.UseSerialization<XmlSerializer>();

            // transport
            var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
            transport.CreateMessageBodyComputedColumn();
            transport.ConnectionString(WebSchemaConfigurationUtility.ReportingModuleConnectionString);
            transport.DefaultSchema(ApiTransportSchema);
            transport.UseSchemaForQueue(ApiErrorQueue, ApiTransportSchema);
            transport.Transactions(TransportTransactionMode.SendsAtomicWithReceive);
            transport.NativeDelayedDelivery().DisableTimeoutManagerCompatibility();

            var routing = transport.Routing();
            foreach (var (assembly, endpoint) in ConfigurationAssemblies.MessageRoutes)
            {
                routing.RouteToEndpoint(assembly, endpoint);
            }

            // persistence
            endpointConfiguration.UsePersistence<SqlPersistence>();
            var sqlPersistence = endpointConfiguration.UsePersistence<SqlPersistence>();
            var dialect = sqlPersistence.SqlDialect<SqlDialect.MsSqlServer>();
            dialect.Schema(ApiTransportSchema);
            sqlPersistence.ConnectionBuilder(() => new SqlConnection(WebSchemaConfigurationUtility.ReportingModuleConnectionString));
            sqlPersistence.SubscriptionSettings().CacheFor(TimeSpan.FromMinutes(ApiCacheSubscriptionsForMinutes));

            endpointConfiguration.SendHeartbeatTo(ServiceControlQueue, HeartbeatInterval);
        }
    }
}