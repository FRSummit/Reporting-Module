using FluentNHibernate.Mapping;
using ReportingModule.Entities;

namespace ReportingModule.Dal
{
    public class ReportEventLogMap : ClassMap<ReportEventLog>
    {
        public ReportEventLogMap()
        {
            Not.LazyLoad();

            Id(x => x.Id);
            Map(x => x.OrganizationId);
            Map(x => x.ReportId);
            Map(x => x.MessageType);
            Map(x => x.Message);
            Map(x => x.CreatedByUsername);
            Map(x => x.Timestamp);
            Map(x => x.Visibility);
        }
    }
}