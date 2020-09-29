using FluentNHibernate.Mapping;
using NsbWeb.ReportingModule.ViewModels;

namespace ReportingModule.Dal
{
    public class ReportEventLogViewModelMap : ClassMap<ReportEventLogViewModel>
    {
        public ReportEventLogViewModelMap()
        {
            Not.LazyLoad();
            ReadOnly();

            Table("ReportEventLog");
            Id(x => x.Id);
            this.Map(x => x.OrganizationId);
            Map(x => x.ReportId);
            Map(x => x.MessageType);
            Map(x => x.Message);
            Map(x => x.CreatedByUsername);
            Map(x => x.Timestamp);
            Map(x => x.Visibility);
        }
    }
}