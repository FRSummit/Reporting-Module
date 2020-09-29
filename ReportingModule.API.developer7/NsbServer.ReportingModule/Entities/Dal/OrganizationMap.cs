using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;
using ReportingModule.Entities;

namespace ReportingModule.Dal
{
    public class OrganizationMap : ClassMap<Organization>
    {
        public OrganizationMap()
        {
            Where("IsDeleted = 0");
            Not.LazyLoad();
            Id(x => x.Id);
            Map(x => x.Description);
            Map(x => x.Details);
            Map(x => x.OrganizationType);
            Map(x => x.ReportingFrequency);
            this.MapComponentWithPrefix(x=>x.Parent);
            Map(x => x.Timestamp);
            Map(x => x.IsDeleted);
        }
    }
}