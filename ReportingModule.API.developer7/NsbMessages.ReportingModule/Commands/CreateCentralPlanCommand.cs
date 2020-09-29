using System;
using NServiceBus;
using ReportingModule.ValueObjects;

namespace ReportingModule.Commands
{
    public class CreateCentralPlanCommand : ICommand
    {
        public CreateCentralPlanCommand(
            OrganizationReference organization,
            int year,
            ReportingTerm reportingTerm,
            ReportingFrequency reportingFrequency)
        {

            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            Year = year;
            ReportingTerm = reportingTerm;
            ReportingFrequency = reportingFrequency;
        }

        public OrganizationReference Organization { get; private set; }
        public int Year { get; private set; }
        public ReportingTerm ReportingTerm { get; private set; }
        public ReportingFrequency ReportingFrequency { get; private set; }

        public string Description => GetDescription();
        private string GetDescription()
        {
            var reportingPeriod =
                new ReportingPeriod(ReportingFrequency, ReportingTerm, Year);
            var monthStart = reportingPeriod.StartDate.ToString("MMM");
            var monthEnd = reportingPeriod.EndDate.ToString("MMM");
            var description = $"{reportingPeriod.StartDate.Year}_{monthStart}-{reportingPeriod.EndDate.Year}_{monthEnd}_{OrganizationType.Central}_{Organization.Description}";
            return description;
        }

    }
}