using System;
using System.Data.Common;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using ReportingModule.Utility;

namespace ReportingModule.Core
{
    [Serializable]
    public class JsonSerializedObjectType<T>
        : IUserType where T : class //, IEquatable<T>
    {
        public new bool Equals(object x, object y)
        {
            return (T)x == (T)y;
        }

        public object Disassemble(object value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetHashCode(object x)
        {
            return ((T)x).GetHashCode();
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            if (names.Length != 1)
            {
                throw new InvalidOperationException("names array has more than one element. can't handle this!");
            }

            var val = rs[names[0]] as string;
            return val?.DeserializeViewModel<T>();
        }

        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            var parameter = cmd.Parameters[index];
            if (value == null)
            {
                parameter.Value = DBNull.Value;
                return;
            }

            var searchValues = (T)value;
            parameter.Value = searchValues.SerializeViewModel();
        }

        public object DeepCopy(object value)
        {
            return (T)value;
        }

        public SqlType[] SqlTypes => new[] { NHibernateUtil.StringClob.SqlType };

        public Type ReturnedType => typeof(T);

        public bool IsMutable => false;
    }
}