using System.Reflection;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.Core;
using ReportingModule.DataAccessLayer.Core.EndpointConfiguration;
using StructureMap;

namespace NsbWeb.ReportingModule.Configuration
{
    public class NsbWebReportingModuleIocRegistry : Registry
    {
        public NsbWebReportingModuleIocRegistry()
        {
            Scan(cfg =>
                {
                    cfg.TheCallingAssembly();
                    cfg.WithDefaultConventions();
                }
            );

            ForSingletonOf<IReportingModuleSessionFactory>().Use(() => GetSessionFactory());
            For<IReportingModuleSession>().Use(ctx => ctx.GetInstance<IReportingModuleSessionFactory>()
                .OpenSession());
            For<IReportingModuleStatelessSession>().Use(ctx => ctx.GetInstance<IReportingModuleSessionFactory>()
                .OpenStatelessSession());
        }

        protected internal static readonly Assembly[] FluentMappedAssemblies =
        {
            typeof(UnitReportViewModel).Assembly,
            typeof(EntityReference).Assembly
        };

        private static IReportingModuleSessionFactory GetSessionFactory()
        {
            var sessionFactory = NsbSqlDatabase.Configure(
                WebSchemaConfigurationUtility.ReportingModuleConnectionString,
                WebSchemaConfigurationUtility.ReportingModuleSchema,
                new Assembly[0],
                FluentMappedAssemblies);

            return new ReportingModuleSessionFactory(sessionFactory);
        }
    }
}