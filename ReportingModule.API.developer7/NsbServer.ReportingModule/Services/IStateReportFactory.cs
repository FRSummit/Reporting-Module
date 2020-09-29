using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    public interface IStateReportFactory
    {
        StateReport CreateNewStatePlan(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year, ReportingFrequency reportingFrequency);
        StateReport CopyStatePlan(string description, int copyFromReportId, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year);

    }
}