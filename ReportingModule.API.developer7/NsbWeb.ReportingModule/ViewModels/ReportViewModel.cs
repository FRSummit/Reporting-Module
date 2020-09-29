using System;
using System.Diagnostics.CodeAnalysis;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class ReportViewModel : IReportSearchTermsFilter
    {
        public ReportViewModel() { }
        public int Id { get; set; }
        public string Description { get; set; }
        public OrganizationReference Organization { get; set; }
        public ReportingPeriod ReportingPeriod { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string ReportStatusDescription => ReportStatus.ToString();
        public ReopenedReportStatus ReOpenedReportStatus { get; set; }
        public string ReOpenedReportStatusDescription => ReOpenedReportStatus.ToString();
        public DateTime Timestamp { get; set; }
    }
}