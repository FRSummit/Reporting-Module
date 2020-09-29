using System.Configuration;

namespace NsbWeb.ReportingModule.Configuration
{
    public static class WebSchemaConfigurationUtility
    {
        public static string ReportingModuleSchema => ConfigurationManager.AppSettings["ReportingModuleDefaultSchema"];
        public static string ReportingModuleConnectionString => ConfigurationManager.ConnectionStrings["ReportingModule"].ConnectionString;
    }
}