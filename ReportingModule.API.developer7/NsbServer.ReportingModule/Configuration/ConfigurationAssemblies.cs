using System.Reflection;
using ReportingModule.Commands;
using ReportingModule.Core;

namespace ReportingModule.Configuration
{
	public static class ConfigurationAssemblies
	{
		public static Assembly[] Messages =
		{
			typeof(CreateOrganizationCommand).Assembly,
		    //typeof(IShipmentStatusUpdatedEvent).Assembly,
        };

		public static Assembly[] NHibernateFluentAssemblies =
		{
		    typeof(EntityReference).Assembly,
            Assembly.GetExecutingAssembly()
		};

		public static Assembly[] NHibernateHbmAssemblies =
		{
        };

        public static (Assembly, string)[] MessageRoutes = {
            (typeof(PingCommand).Assembly, EndpointConfig.EndpointName)
        };
    }
}
