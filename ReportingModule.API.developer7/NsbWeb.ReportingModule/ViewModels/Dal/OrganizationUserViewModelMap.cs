using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class OrganizationUserViewModelMap : ClassMap<OrganizationUserViewModel>
    {
        public OrganizationUserViewModelMap()
        {
            Not.LazyLoad();
            ReadOnly();

            Table("OrganizationUser");
            Where("IsDeleted = 0");
            Id(x => x.Id);
            Map(x => x.Username);
            Map(x => x.Role);
            this.MapComponentWithPrefix(x => x.Organization);
            Map(x => x.Timestamp);
        }
    }
}