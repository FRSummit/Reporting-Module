using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Caches.SysCache2;
using ReportingModule.Core.Fluent;

namespace ReportingModule.DataAccessLayer.Core.EndpointConfiguration
{
    public static class NsbSqlDatabase
    {
        public static ISessionFactory Configure(string connectionString,
			string defaultSchema,
            Assembly[] hbmAssemblies,
            Assembly[] fluentAssemblies)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(connectionString)
                    //.ShowSql()
					.DefaultSchema(defaultSchema))
                .Cache(c => c.UseQueryCache().ProviderClass<SysCacheProvider>())
                .Mappings(m =>
                {
                    foreach (var assembly in hbmAssemblies)
                    {
                        m.HbmMappings.AddFromAssembly(assembly);
                    }

                    foreach (var assembly in fluentAssemblies)
                    {
                        m.FluentMappings.AddFromAssembly(assembly);
                    }

                    m.FluentMappings.Conventions.AddFromAssemblyOf<EnumIntConvention>()
                        .Conventions.Add(PrimaryKey.Name.Is(x => "id"));
                    //.ExportTo(@"c:\temp\otDump"); // Uncomment to dump fluently generated .hbm.xml files
                })
                .ExposeConfiguration(c => { c.SetProperty("sql_types.keep_datetime", "true"); })
                .BuildSessionFactory();
            return sessionFactory;
        }
    }
}