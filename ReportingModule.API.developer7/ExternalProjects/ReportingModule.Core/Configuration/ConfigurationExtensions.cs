using System;
using System.Configuration;

namespace ReportingModule.Core.Configuration
{
    public class ConfigurationExtensions
    {
        public static string GetStringConfigValue(string appSettingKey)
        {
            return ConfigurationManager.AppSettings[appSettingKey] ??
                   throw new Exception($"No {appSettingKey} specified in config");
        }

        public static int GetIntConfigValue(string appSettingKey)
        {
            return int.TryParse(ConfigurationManager.AppSettings[appSettingKey], out var p)
                ? p
                : throw new Exception($"No {appSettingKey} specified in config");
        }

        public static bool GetBoolConfigValue(string appSettingKey)
        {
            return bool.TryParse(ConfigurationManager.AppSettings[appSettingKey], out var p)
                ? p
                : throw new Exception($"No {appSettingKey} specified in config");
        }
    }
}