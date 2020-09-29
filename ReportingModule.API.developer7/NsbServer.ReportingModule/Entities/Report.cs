using System;
using ReportingModule.Core;
using ReportingModule.Core.Domains;
using ReportingModule.Utility;
using ReportingModule.ValueObjects;

namespace ReportingModule.Entities
{
    public class Report : IAggregate<int>, IReport
    {
        protected Report()
        {
        }

        public Report(string description, OrganizationReference organization, ReportingPeriod reportingPeriod, string comment)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));

            Description = description;
            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            ReportingPeriod = reportingPeriod ?? throw new ArgumentNullException(nameof(reportingPeriod));
            ReportStatus = ReportStatus.Draft;
            ReopenedReportStatus = ReopenedReportStatus.None;
            Comment = comment;
        
            Timestamp = ZaphodTime.UtcNow;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public EntityReference ReportTemplate { get; private set; }
        public OrganizationReference Organization { get; private set; }
        public ReportingPeriod ReportingPeriod { get; private set; }
        public ReportStatus ReportStatus { get; private set; }
        public ReopenedReportStatus ReopenedReportStatus { get; private set; }
        public string Comment { get; private set; }
        public DateTime Timestamp { get; private set; }
        public bool IsDeleted { get; private set; }

        public void MarkAsDelete()
        {
            IsDeleted = true;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void MarkStatusAsPlanPromoted()
        {
            ReportStatus = ReportStatus.PlanPromoted;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void MarkStatusAsSubmitted()
        {
            ReportStatus = ReportStatus.Submitted;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void MarkStatusAsDraft()
        {
            ReportStatus = ReportStatus.Draft;
            Timestamp = ZaphodTime.UtcNow;
        }

        public void Update(string description,
            OrganizationReference organization,
            ReportingPeriod reportingPeriod)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));

            Description = description;
            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            ReportingPeriod = reportingPeriod ?? throw new ArgumentNullException(nameof(reportingPeriod));
            Timestamp = ZaphodTime.UtcNow;
        }

        public static implicit operator EntityReference(Report report)
        {
            return new EntityReference(report.Id, report.Description);
        }
    }
}