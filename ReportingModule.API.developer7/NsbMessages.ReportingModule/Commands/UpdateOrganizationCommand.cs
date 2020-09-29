using System;
using NServiceBus;
using ReportingModule.Core;
using ReportingModule.ValueObjects;

namespace ReportingModule.Commands
{
    public class UpdateOrganizationCommand : ICommand
    {
        public UpdateOrganizationCommand(int organizationId, 
            string description,
            string details,
            OrganizationType organizationType,
            ReportingFrequency reportingFrequency,
            EntityReference parent)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));

            OrganizationId = organizationId;
            Description = description;
            Details = details;
            OrganizationType = organizationType;
            ReportingFrequency = reportingFrequency;
            Parent = parent;
        }

        public int OrganizationId { get; private set; }
        public string Description { get; private set; }
        public string Details { get; private set; }
        public OrganizationType OrganizationType { get; private set; }
        public ReportingFrequency ReportingFrequency { get; private set; }
        public EntityReference Parent { get; private set; }

    }
}