using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    public interface IZoneReportFactory
    {
        ZoneReport CreateNewZonePlan(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year, ReportingFrequency reportingFrequency);
        ZoneReport CopyZonePlan(string description, int copyFromReportId, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year);

    }


}