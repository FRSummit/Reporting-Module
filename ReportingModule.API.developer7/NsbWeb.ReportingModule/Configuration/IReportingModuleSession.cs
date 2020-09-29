using System;
using NHibernate;

namespace NsbWeb.ReportingModule.Configuration
{
    public interface IReportingModuleSessionFactory
    {
        IReportingModuleSession OpenSession();
        IReportingModuleStatelessSession OpenStatelessSession();
    }

    public class ReportingModuleSessionFactory : IReportingModuleSessionFactory
    {
        public ReportingModuleSessionFactory(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        private ISessionFactory SessionFactory { get; }
        public IReportingModuleSession OpenSession()
        {
            return new ReportingModuleSession(SessionFactory.OpenSession());
        }

        public IReportingModuleStatelessSession OpenStatelessSession()
        {
            return new ReportingModuleStatelessSession(SessionFactory.OpenStatelessSession());
        }
    }

    public interface IReportingModuleSession : IDisposable
    {
        ISession Session { get; }
    }

    public class ReportingModuleSession : IReportingModuleSession
    {
        public ReportingModuleSession(ISession session)
        {
            Session = session;
        }

        public ISession Session { get; }

        public void Dispose()
        {
            Session?.Dispose();
        }
    }

    public interface IReportingModuleStatelessSession : IDisposable
    {
        IStatelessSession Session { get; }
    }

    public class ReportingModuleStatelessSession : IReportingModuleStatelessSession
    {
        public ReportingModuleStatelessSession(IStatelessSession session)
        {
            Session = session;
        }

        public IStatelessSession Session { get; }

        public void Dispose()
        {
            Session?.Dispose();
        }
    }
}