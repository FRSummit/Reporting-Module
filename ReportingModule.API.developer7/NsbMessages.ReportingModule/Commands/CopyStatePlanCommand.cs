using System;
using NServiceBus;
using ReportingModule.ValueObjects;

namespace ReportingModule.Commands
{
    public class CopyStatePlanCommand : ICommand
    {
        public CopyStatePlanCommand(
            int copyFromReportId,
            OrganizationReference organization,
            int year,
            ReportingTerm reportingTerm,
            ReportingFrequency reportingFrequency = ReportingFrequency.Quarterly)
        {
            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            CopyFromReportId = copyFromReportId;
            Year = year;
            ReportingTerm = reportingTerm;
            ReportingFrequency = reportingFrequency;
        }

        public int CopyFromReportId { get; private set; }
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
            var description = $"{reportingPeriod.StartDate.Year}_{monthStart}-{reportingPeriod.EndDate.Year}_{monthEnd}_{OrganizationType.State}_{Organization.Description}";
            return description;
        }

    }
}