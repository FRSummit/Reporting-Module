using System;
using ReportingModule.ValueObjects;
using ICommand = NServiceBus.ICommand;

namespace ReportingModule.Commands
{
    public class CreateUnitPlanCommand : ICommand
    {
        public CreateUnitPlanCommand(
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
        private  string GetDescription()
        {
            var reportingPeriod =
                new ReportingPeriod(ReportingFrequency, ReportingTerm, Year);
            var monthStart = reportingPeriod.StartDate.ToString("MMM");
            var monthEnd = reportingPeriod.EndDate.ToString("MMM");
            var description = $"{reportingPeriod.StartDate.Year}_{monthStart}-{reportingPeriod.EndDate.Year}_{monthEnd}_{OrganizationType.Unit}_{Organization.Description}";
            return description;
        }

    }
}