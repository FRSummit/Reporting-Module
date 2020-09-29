using System;

namespace ReportingModule.Core
{
    public class EntityReference : IEquatable<EntityReference>
	{
		protected EntityReference()
		{}

		public EntityReference(int id, string description, string searchTerms = null)
		{
			Id = id;
			Description = description;
			SearchTerms = searchTerms;
		}

        public virtual int Id { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual string SearchTerms { get; protected set; }

		public override string ToString()
		{
			return string.Format("EntityReference: {0}: {1}", Id, Description);
		}

		public virtual bool Equals(EntityReference other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id == Id;
		}

        public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (EntityReference)) return false;
			return Equals((EntityReference) obj);
		}

		public override int GetHashCode()
		{
			return Id;
		}

		public static bool operator ==(EntityReference left, EntityReference right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(EntityReference left, EntityReference right)
		{
			return !Equals(left, right);
		}
	}
}