using log4net;
using StructureMap;

namespace ReportingModule.Configuration
{
	public class EndpointRegistry : Registry
	{
	    private static readonly ILog Log = LogManager.GetLogger(typeof(EndpointRegistry));

		public EndpointRegistry()
		{
			Scan(cfg =>
			{
				cfg.TheCallingAssembly();
				cfg.WithDefaultConventions();
			});
		}
	}
}
