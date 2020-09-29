using System;
using ReportingModule.Core;
using ReportingModule.ValueObjects;
using ICommand = NServiceBus.ICommand;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

namespace ReportingModule.Commands
{
    public class CreateOrganizationCommand : ICommand
    {
        public CreateOrganizationCommand(string description,
            string details,
            OrganizationType organizationType,
            ReportingFrequency reportingFrequency,
            EntityReference parent)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));

            Description = description;
            Details = details;
            OrganizationType = organizationType;
            ReportingFrequency = reportingFrequency;
            Parent = parent;
        }

        public string Description { get; private set; }
        public string Details { get; private set; }
        public OrganizationType OrganizationType { get; private set; }
        public ReportingFrequency ReportingFrequency { get; private set; }
        public EntityReference Parent { get; private set; }

    }
}