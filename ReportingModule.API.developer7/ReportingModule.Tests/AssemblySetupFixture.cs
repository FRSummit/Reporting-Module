using NsbWeb.Core;
using NsbWeb.ReportingModule.Configuration;
using NUnit.Framework;
using ReportingModule.Configuration;
using StructureMap;

namespace ReportingModule.Tests
{
    [SetUpFixture]
	public class AssemblySetupFixture
	{
	    public static IContainer EndpointTestContainer => Container ?? (Container = CreateContainer());
        private static IContainer Container { get; set; }

        private static IContainer CreateContainer()
        {
            var c = new Container
            {
                Name = "ReportingModule.Tests"
            };

            SetupContainer.InitializeIoc(c);
            return c;
        }

        public static IContainer WebTestContainer => WebContainer ?? (WebContainer = CreateWebContainer());
        private static IContainer WebContainer { get; set; }
        private static IContainer CreateWebContainer()
        {
            var container = new Container
            {
                Name = "Nsb.Web.ReportingModule.Tests"
            };

            container.Configure(x => x.AddRegistry<NsbWebCoreIocRegistry>());
            container.Configure(x => x.AddRegistry<NsbWebReportingModuleIocRegistry>());
            return container;
        }

    }
    
}
