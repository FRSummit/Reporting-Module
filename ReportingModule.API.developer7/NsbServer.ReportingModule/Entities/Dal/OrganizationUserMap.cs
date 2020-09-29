using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;
using ReportingModule.Entities;

namespace ReportingModule.Dal
{
    public class OrganizationUserMap : ClassMap<OrganizationUser>
    {
        public OrganizationUserMap()
        {
            Where("IsDeleted = 0");
            Not.LazyLoad();
            Id(x => x.Id);
            Map(x => x.Username);
            Map(x => x.Role);
            this.MapComponentWithPrefix(x => x.Organization);
            Map(x => x.Timestamp);
            Map(x => x.IsDeleted);
        }
    }
}