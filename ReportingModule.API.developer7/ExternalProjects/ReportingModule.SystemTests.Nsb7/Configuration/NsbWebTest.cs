using System;
using NHibernate;
using StructureMap;

namespace ReportingModule.SystemTests.Nsb7.Configuration
{
    public static class NsbWebTest
    {
        public static void ArrangeOnSqlSession(
            IContainer container,
            Action<ISession> arrange)
        {
            using (var nestedContainer = container.GetNestedContainer())
            {
                using (var session = nestedContainer.GetInstance<ISession>())
                {
                    arrange(session);
                }
            }
        }

        public static void ArrangeOnSqlStatelessSession(
            IContainer container,
            Action<IStatelessSession> arrange)
        {
            using (var nestedContainer = container.GetNestedContainer())
            {
                using (var session = nestedContainer.GetInstance<IStatelessSession>())
                {
                    arrange(session);
                }
            }
        }

        public static T ArrangeOnSqlSession<T>(
            IContainer container,
            Func<ISession, T> arrange)
        {
            using (var nestedContainer = container.GetNestedContainer())
            {
                using (var session = nestedContainer.GetInstance<ISession>())
                {
                    return arrange(session);
                }
            }
        }

        public static T Act<T>(
            IContainer container,
            Func<IContainer, T> act)
        {
            using (var nestedContainer = container.GetNestedContainer())
            {
                return act(nestedContainer);
            }
        }

        public static void Act(
            IContainer container,
            Action<IContainer> act)
        {
            using (var nestedContainer = container.GetNestedContainer())
            {
                act(nestedContainer);
            }
        }

        public static void Assert(
            IContainer container,
            Action<IContainer> act)
        {
            Act(container, act);
        }

        public static T ActOnSqlSession<T>(
            IContainer container,
            Func<ISession, T> act)
        {
            using (var nestedContainer = container.GetNestedContainer())
            {
                using (var session = nestedContainer.GetInstance<ISession>())
                {
                    return act(session);
                }
            }
        }

        public static T ActOnStatelessSqlSession<T>(
            IContainer container,
            Func<IStatelessSession, T> act)
        {
            using (var nestedContainer = container.GetNestedContainer())
            {
                using (var session = nestedContainer.GetInstance<IStatelessSession>())
                {
                    return act(session);
                }
            }
        }

        public static void AssertOnSqlSessionThat(
            IContainer container,
            Action<ISession> act)
        {
            using (var nestedContainer = container.GetNestedContainer())
            {
                using (var session = nestedContainer.GetInstance<ISession>())
                {
                    act(session);
                }
            }
        }

        public static void AssertOnSqlStatelessSessionThat(
            IContainer container,
            Action<IStatelessSession> act)
        {
            using (var nestedContainer = container.GetNestedContainer())
            {
                using (var session = nestedContainer.GetInstance<IStatelessSession>())
                {
                    act(session);
                }
            }
        }
    }
}
