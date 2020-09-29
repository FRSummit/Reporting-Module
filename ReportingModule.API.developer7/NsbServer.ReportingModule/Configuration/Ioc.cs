using log4net;
using StructureMap;

namespace ReportingModule.Configuration
{
	public static class Ioc
	{
		public static ILog Log = LogManager.GetLogger("Global");

		public static IContainer Container { get; set; }

		static Ioc()
		{
			Log.Info("Creating the StuctureMap Container.");
			Container = new Container()
			{
				Name = "ReportingModuleStructureMapContainer"
			};
		}
	}
}
