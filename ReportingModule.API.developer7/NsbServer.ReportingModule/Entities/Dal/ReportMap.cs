using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;
using ReportingModule.Entities;

namespace ReportingModule.Dal
{
    public class ReportMap : ClassMap<Report>
    {
        public ReportMap()
        {
            Where("IsDeleted = 0");
            Not.LazyLoad();
            Id(x => x.Id);
            Map(x => x.Description);
            this.MapComponentWithPrefix(x => x.Organization);
            this.MapComponentWithPrefix(x => x.ReportingPeriod);
            Map(x => x.ReportStatus);
            Map(x => x.ReopenedReportStatus);
            Map(x => x.Comment);
            Map(x => x.Timestamp);
            Map(x => x.IsDeleted);
        }
    }
}