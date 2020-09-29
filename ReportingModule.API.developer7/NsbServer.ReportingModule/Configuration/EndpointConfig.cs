using System;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using NServiceBus;
using NServiceBus.Persistence.Sql;
using NServiceBus.Transport.SQLServer;
using ReportingModule.Core;
using ReportingModule.Core.Configuration;
using ReportingModule.Core.Nsb7;

namespace ReportingModule.Configuration
{
	public class EndpointConfig
	{
        public static ILog Log;
        public static string EndpointName => ConfigurationExtensions.GetStringConfigValue(nameof(EndpointName));
        public static string TransportSchema => ConfigurationExtensions.GetStringConfigValue(nameof(TransportSchema));
        public static string ErrorQueue => ConfigurationExtensions.GetStringConfigValue(nameof(ErrorQueue));
        public static int ImmediateRetries => ConfigurationExtensions.GetIntConfigValue(nameof(ImmediateRetries));
        public static bool DelayedRetriesEnabled => ConfigurationExtensions.GetBoolConfigValue(nameof(DelayedRetriesEnabled));
        public static int DelayedRetries => ConfigurationExtensions.GetIntConfigValue(nameof(DelayedRetries));
        public static int DelayedRetriesTimeIncreaseSeconds => ConfigurationExtensions.GetIntConfigValue(nameof(DelayedRetriesTimeIncreaseSeconds));
        public static int Concurrency => ConfigurationExtensions.GetIntConfigValue(nameof(Concurrency));
        public static int CacheSubscriptionsForMinutes => ConfigurationExtensions.GetIntConfigValue(nameof(CacheSubscriptionsForMinutes));
        public static string AuditQueue => ConfigurationExtensions.GetStringConfigValue(nameof(AuditQueue));


		public static void Customize(EndpointConfiguration endpointConfiguration)
		{
			XmlConfigurator.Configure();
			NServiceBus.Logging.LogManager.Use<Log4NetFactory>();

            if (Log == null)
                Log = LogManager.GetLogger("EndpointConfig");

			Log.Info("Logging configured. Configuring the bus.");

            endpointConfiguration.EnableInstallers();
            endpointConfiguration.AuditProcessedMessagesTo(AuditQueue);
            endpointConfiguration.SendFailedMessagesTo(ErrorQueue);
            endpointConfiguration.UseContainer<StructureMapBuilder>(customizations => customizations.ExistingContainer(Ioc.Container));

            endpointConfiguration.UseSerialization<XmlSerializer>();

            // transport
            var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
            transport.CreateMessageBodyComputedColumn();
            transport.ConnectionString(SchemaConfigurationUtility.ReportingModuleConnectionString);
            transport.DefaultSchema(TransportSchema);
            transport.UseSchemaForQueue(ErrorQueue, TransportSchema);
            transport.UseSchemaForQueue(AuditQueue, TransportSchema);
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
            dialect.Schema(TransportSchema);
            sqlPersistence.ConnectionBuilder(() => new SqlConnection(SchemaConfigurationUtility.ReportingModuleConnectionString));
            sqlPersistence.SubscriptionSettings().CacheFor(TimeSpan.FromMinutes(CacheSubscriptionsForMinutes));

            endpointConfiguration.Recoverability().Delayed(settings =>
            {
                if (DelayedRetriesEnabled)
                {
                    settings.NumberOfRetries(DelayedRetries);
                    settings.TimeIncrease(TimeSpan.FromSeconds(DelayedRetriesTimeIncreaseSeconds));
                }
                else
                {
                    settings.NumberOfRetries(0);
                }
            });

            endpointConfiguration.Recoverability().Immediate(settings => settings.NumberOfRetries(ImmediateRetries));
            endpointConfiguration.TimeoutManager().LimitMessageProcessingConcurrencyTo(Concurrency);

            endpointConfiguration.ConfigureMetrics();
		    endpointConfiguration.ConfigureHeartbeat();
		}
	}
}
