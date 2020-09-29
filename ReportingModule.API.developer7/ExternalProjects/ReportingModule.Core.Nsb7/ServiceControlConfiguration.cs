using System;
using System.Configuration;
using log4net;
using NServiceBus;

namespace ReportingModule.Core.Nsb7
{
    public static class ServiceControlConfiguration
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ServiceControlConfiguration));
        private static string MetricsAddress => ConfigurationManager.AppSettings["ServiceControl/Metrics"];
        public static string ServiceControlQueue => ConfigurationManager.AppSettings["ServiceControl/Queue"];

        private static TimeSpan HeartbeatInterval =>
            TimeSpan.TryParse(ConfigurationManager.AppSettings["Heartbeat/Interval"], out var p)
                ? p
                : TimeSpan.FromSeconds(30);

        private static TimeSpan MetricsInterval =>
            TimeSpan.TryParse(ConfigurationManager.AppSettings["Metrics/Interval"], out var p)
                ? p
                : TimeSpan.FromSeconds(30);

        public static void ConfigureMetrics(this EndpointConfiguration endpointConfiguration)
        {
            if (string.IsNullOrWhiteSpace(MetricsAddress))
            {
                Log.Info("No metrics address configured");
                return;
            }

            Log.Info($"Sending metrics data to {MetricsAddress}");
            var metrics = endpointConfiguration.EnableMetrics();
            metrics.SendMetricDataToServiceControl(MetricsAddress, MetricsInterval);
        }

        public static void ConfigureHeartbeat(this EndpointConfiguration endpointConfiguration)
        {
            if (string.IsNullOrWhiteSpace(ServiceControlQueue))
            {
                throw new Exception("No heartbeat address configured");
            }

            Log.Info($"Sending heartbeat data to {ServiceControlQueue}");
            endpointConfiguration.SendHeartbeatTo(ServiceControlQueue, HeartbeatInterval);
        }
    }
}