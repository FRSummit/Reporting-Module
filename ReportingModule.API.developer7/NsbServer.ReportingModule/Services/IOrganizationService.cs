using System.Collections.Generic;
using ReportingModule.Entities;

namespace ReportingModule.Services
{
    public interface IOrganizationService
    {
        IEnumerable<Organization> GetManagedOrganizations(int organizationId);
    }
}