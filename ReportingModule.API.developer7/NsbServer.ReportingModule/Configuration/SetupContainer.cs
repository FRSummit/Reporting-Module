using log4net;
using NServiceBus;
using NServiceBus.UnitOfWork;
using StructureMap;

namespace ReportingModule.Configuration
{
	public class SetupContainer : INeedInitialization
	{
		public static ILog Log = LogManager.GetLogger("SetupContainer");

		public void Customize(EndpointConfiguration configuration)
		{
			Log.Info("Initializing Global StructureMap Container");
			InitializeIoc(Ioc.Container);
		}

		public static void InitializeIoc(IContainer container)
		{
            InitialiseIoc(container, SchemaConfigurationUtility.ReportingModuleConnectionString, SchemaConfigurationUtility.ReportingModuleSchema);
		}

		public static void InitialiseIoc(
			IContainer container,
			string sqlConnStr, 
			string sqlSchema)
		{
			container.Configure(c => c.AddRegistry<EndpointRegistry>());
			container.Configure(c => c.For<IManageUnitsOfWork>().Use<SqlUnitOfWork>());

            container.Configure(c => c.AddRegistry(new NHibernateRegistry(
				sqlConnStr,
				sqlSchema,
				ConfigurationAssemblies.NHibernateHbmAssemblies,
				ConfigurationAssemblies.NHibernateFluentAssemblies)));
		}
    }
}
