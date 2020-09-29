using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    public interface IUnitReportFactory
    {
        UnitReport CreateNewUnitPlan(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year, ReportingFrequency reportingFrequency);
        UnitReport CopyUnitPlan(string description, int copyFromReportId, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year);
        UnitReport CreateNewUnitPlanAi(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm,  int year, ReportingFrequency reportingFrequency);
    }  
}