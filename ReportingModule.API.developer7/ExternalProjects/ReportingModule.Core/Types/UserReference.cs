using System;
using FluentNHibernate.Mapping;

//using ReportingModule.Core.Mail;

namespace ReportingModule.Core
{
    public class UserReference : IEquatable<UserReference>
    {
        protected UserReference()
        {    
        }

        public UserReference(int id, string userId, string fullName, string emailAddress)
        {
            Id = id;
            UserId = userId;
            FullName = fullName;
            EmailAddress = emailAddress;
        }

        public override string ToString()
        {
            return FullName;
        }

        //public static implicit operator MailAddress(UserReference user)
        //{
        //    return user == null
        //        ? null
        //        : new MailAddress(user.FullName, user.EmailAddress);
        //}

        public int Id { get; protected set; }
        public string UserId { get; protected set; }
        public string FullName { get; protected set; }
        public string EmailAddress { get; protected set; }

		public static implicit operator EntityReference(UserReference user)
	    {
			return new EntityReference(user.Id, user.FullName);
	    }

        #region Equality

        public bool Equals(UserReference other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((UserReference) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(UserReference left, UserReference right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserReference left, UserReference right)
        {
            return !Equals(left, right);
        }

        #endregion
    }

    public class UserReferenceMap: ComponentMap<UserReference>
	{
		 public UserReferenceMap()
		 {
		 	Map(x => x.Id);
		 	Map(x => x.UserId);
		 	Map(x => x.FullName);
		 	Map(x => x.EmailAddress);
		 }
	}

    public sealed class UserReferenceComponentMap
    {
        public static void Map(CompositeElementPart<UserReference> part)
        {
            part.Map(x => x.Id);
            part.Map(x => x.UserId);
            part.Map(x => x.FullName);
            part.Map(x => x.EmailAddress);
        }
    }
}
