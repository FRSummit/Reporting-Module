using System;
using ReportingModule.Core;

namespace ReportingModule.ValueObjects
{
    public class OrganizationReference : IEquatable<OrganizationReference>
    {
        protected OrganizationReference()
        {
        }
        public OrganizationReference(int id, OrganizationType organizationType, string description, string details, ReportingFrequency reportingFrequency)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));
            Description = description;

            Id = id;
            OrganizationType = organizationType;
            Description = description;
            Details = details;
            ReportingFrequency = reportingFrequency;
        }
        public int Id { get; private set; }
        public OrganizationType OrganizationType { get; private set; }
        public string Description { get; private set; }
        public string Details { get; private set; }

        public ReportingFrequency ReportingFrequency { get; private set; }

        public static implicit operator EntityReference(OrganizationReference organizationReference)
        {
            return new EntityReference(organizationReference.Id, organizationReference.Description);
        }

        public bool Equals(OrganizationReference other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && OrganizationType == other.OrganizationType && string.Equals(Description, other.Description) && ReportingFrequency == other.ReportingFrequency;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrganizationReference) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (int) OrganizationType;
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) ReportingFrequency;
                return hashCode;
            }
        }
    }
}