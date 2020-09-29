using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    public interface ICentralReportFactory
    {
        CentralReport CreateNewCentralPlan(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year, ReportingFrequency reportingFrequency);
        CentralReport CopyCentralPlan(string description, int copyFromReportId, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year);

    }
}