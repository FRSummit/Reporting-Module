using System;
using ReportingModule.ValueObjects;
using ICommand = NServiceBus.ICommand;

namespace ReportingModule.Commands
{
    public class CreateZoneReportCommand : ICommand
    {
        public CreateZoneReportCommand(string description,
            OrganizationReference organization,
            int year,
            ReportingTerm reportingTerm)
        {
            if(string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));

            Description = description;
            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            Year = year;
            ReportingTerm = reportingTerm;
        }

        public string Description { get; private set; }
        public OrganizationReference Organization { get; private set; }
        public int Year { get; private set; }
        public ReportingTerm ReportingTerm { get; private set; }

    }
}