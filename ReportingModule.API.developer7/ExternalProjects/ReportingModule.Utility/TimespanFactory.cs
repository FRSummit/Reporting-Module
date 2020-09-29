using System;

namespace ReportingModule.Utility
{
    public static class TimespanFactory
    {
        public static TimeSpan GetTimespanFromKeyValue(string key, int value)
        {
            key = key.ToLower();
            if (key.EndsWith("seconds")) return TimeSpan.FromSeconds(value);
            if(key.EndsWith("hours")) return TimeSpan.FromHours(value);
            return TimeSpan.FromMinutes(value);
        }
    }
}