using System;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels
{
    public interface IReportSearchTermsFilter : IOrganizationReferenceFilter
    {
        string Description { get; }
        ReportStatus ReportStatus { get; }
        ReportingPeriod ReportingPeriod { get; }
        DateTime Timestamp { get; }
    }
}