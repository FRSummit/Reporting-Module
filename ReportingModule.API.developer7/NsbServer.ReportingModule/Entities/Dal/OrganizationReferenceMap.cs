using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace ReportingModule.Dal
{
    
    public class OrganizationReferenceMap : ComponentMap<OrganizationReference>
    {
        public OrganizationReferenceMap()
        {
            Map(x => x.Id);
            Map(x => x.Description);
            Map(x => x.Details);
            Map(x => x.OrganizationType);
            Map(x => x.ReportingFrequency);
        }
    }
}