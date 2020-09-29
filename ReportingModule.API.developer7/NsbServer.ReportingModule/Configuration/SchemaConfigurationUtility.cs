using System.Configuration;

namespace ReportingModule.Configuration
{
    public static class SchemaConfigurationUtility
    {
        public static string ReportingModuleConnectionString => 
            ConfigurationManager.ConnectionStrings["ReportingModule"].ConnectionString;
        public static string ReportingModuleSchema => ConfigurationManager.AppSettings["ReportingModuleDefaultSchema"];
        
    }
}