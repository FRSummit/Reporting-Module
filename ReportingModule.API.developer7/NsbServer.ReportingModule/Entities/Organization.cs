using System;
using ReportingModule.Core;
using ReportingModule.Core.Domains;
using ReportingModule.Utility;
using ReportingModule.ValueObjects;

// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

namespace ReportingModule.Entities
{
    
    public class Organization : IAggregate<int>
    {
        protected Organization()
        {
        }

        public Organization(string description, string details, OrganizationType organizationType, ReportingFrequency reportingFrequency, EntityReference parent)
        {
            
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));
            Description = description;
            Details = details;
            OrganizationType = organizationType;
            ReportingFrequency = reportingFrequency;
            Parent = parent;
            
            Timestamp = ZaphodTime.UtcNow;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public OrganizationType OrganizationType { get; private set; }
        public string Description { get; private set; }
        public string Details { get; private set; }
        public ReportingFrequency ReportingFrequency { get; private set; }
        public EntityReference Parent { get; private set; }
        public DateTime Timestamp { get; private set; }
        public bool IsDeleted { get; private set; }

        public static EntityReference Root = new EntityReference(0, "Root");

        public void MarkAsDelete()
        {
            IsDeleted = true;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void SetOrganizationType(OrganizationType organizationType)
        {
            OrganizationType = organizationType;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetDetails(string details)
        {
            Details = details;
        }

        public void SetReportingFrequency(ReportingFrequency reportingFrequency)
        {
            ReportingFrequency = reportingFrequency;
        }

        public void SetParent(EntityReference parent)
        {
            Parent = parent;
        }

        public static implicit operator OrganizationReference(Organization organization)
        {
            return new OrganizationReference(organization.Id, organization.OrganizationType, organization.Description, organization.Details, organization.ReportingFrequency);
        }

        public static implicit operator EntityReference(Organization organization)
        {
            return new EntityReference(organization.Id, organization.Description);
        }
    }
}