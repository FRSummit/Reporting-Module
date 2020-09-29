using System.Collections.Generic;
using System.Linq;
using NHibernate;
using ReportingModule.Entities;

namespace ReportingModule.Services.Impl
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ISession _session;

        public OrganizationService(ISession session)
        {
            _session = session;
        }

        public IEnumerable<Organization> GetManagedOrganizations(int organizationId)
        {
            return _session.Query<Organization>()
                .Where(o => o.Parent.Id == organizationId)
                .ToArray();
        }
    }
}