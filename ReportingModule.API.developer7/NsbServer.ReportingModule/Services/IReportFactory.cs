using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    //sk comment 20 04 2019 - this has become obsolete as separate factories created for organization type e.g. IUnitReportFactory
    public interface IReportFactory
    {
        Report CreateNewReport(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year);
    }
}