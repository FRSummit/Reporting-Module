using System.Configuration;
using NsbWeb.Core;
using NsbWeb.ReportingModule.Configuration;
using ReportingModule.Core.Configuration;
using StructureMap;

namespace ReportingModule.Website
{
    public static class Ioc
    {
        private static IContainer _container;

        public static IContainer Container => _container ?? InitialiseContainer();

        private static IContainer InitialiseContainer()
        {
            var container = new Container();
            container.Configure(x =>
            {
                x.AddRegistry<NsbWebReportingModuleIocRegistry>();
                x.AddRegistry<NsbWebCoreIocRegistry>();
            });
            _container = container;
            ObjectFactory.Container = container;
            return _container;
        }
    }
}
