using NHibernate;

namespace ReportingModule.Core.Extensions
{
    public static class SessionResultExtensions
    {
        public static Result<T, string[]> GetAsResult<T>(this ISession session, object id)
        {
            var t = session.Get<T>(id);

            return t != null
                ? Result<T, string[]>.Succeeded(t)
                : Result<T, string[]>.Failed(new[] {$"{typeof(T).Name} with ID {id} does not exist"});
        }

        public static Result<T, string[]> GetAsResult<T>(this IStatelessSession session, object id)
        {
            var t = session.Get<T>(id);

            return t != null
                ? Result<T, string[]>.Succeeded(t)
                : Result<T, string[]>.Failed(new[] {$"{typeof(T).Name} with ID {id} does not exist"});
        }
    }
}