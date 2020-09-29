using System;
using ReportingModule.ValueObjects;

namespace ReportingModule.Entities
{
    public interface IReport
    {
        string Description { get; }
        int Id { get; }
        bool IsDeleted { get; }
        OrganizationReference Organization { get; }
        ReportingPeriod ReportingPeriod { get; }
        string Comment { get; }
        DateTime Timestamp { get; }
    }
}