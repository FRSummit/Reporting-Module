using System.Reflection;
using NHibernate;
using ReportingModule.DataAccessLayer.Core.EndpointConfiguration;
using StructureMap;

namespace ReportingModule.Configuration
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry(
			string connectionString,
			string schema,
            Assembly[] hbmAssemblies,
            Assembly[] fluentAssemblies)
        {
            ForSingletonOf<ISessionFactory>().Use(NsbSqlDatabase.Configure(
				connectionString,
				schema,
                hbmAssemblies,
                fluentAssemblies));

            For<ISession>().Use(ctx => ctx.GetInstance<ISessionFactory>().OpenSession());
        }
    }
}
