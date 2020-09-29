using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class OrganizationViewModelMap : ClassMap<OrganizationViewModel>
    {
        public OrganizationViewModelMap()
        {
            Not.LazyLoad();
            ReadOnly();

            Table("Organization");
            Where("IsDeleted = 0");
            Id(x => x.Id);
            Map(x => x.Description);
            Map(x => x.Details);
            Map(x => x.OrganizationType);
            Map(x => x.ReportingFrequency);
            this.MapComponentWithPrefix(x => x.Parent);
            Map(x => x.Timestamp);
        }
    }
}