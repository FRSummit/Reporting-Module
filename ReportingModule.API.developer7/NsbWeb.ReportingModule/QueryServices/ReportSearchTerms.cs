using System;
using ReportingModule.ValueObjects;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices
{
    public class ReportSearchTerms : GridSearchTerms
    {
        public string QuickSearch { get; set; }
        public DateTime? TimestampFrom { get; set; }
        public DateTime? TimestampTo { get; set; }
        public ReportStatus? Status { get; set; }
        public OrganizationType? OrganizationalType { get; set; }
        public ReportingFrequency? ReportingFrequency { get; set; }
        public ReportingTerm? ReportingTerm { get; set; }
        public bool MyReports { get; set; }
        public int? Organization { get; set; }
        public int? Parent { get; set; }
        public DateTime? ReportingPeriodStartDateFrom { get; set; }
        public DateTime? ReportingPeriodEndDateTo { get; set; }

    }
}