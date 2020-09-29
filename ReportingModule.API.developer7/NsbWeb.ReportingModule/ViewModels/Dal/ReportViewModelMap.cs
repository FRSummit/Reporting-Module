using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class ReportViewModelMap : ClassMap<ReportViewModel>
    {
        public ReportViewModelMap()
        {
            Not.LazyLoad();
            ReadOnly();

            Table("Report");
            Where("IsDeleted = 0");
            Id(x => x.Id);
            Map(x => x.Description);
            this.MapComponentWithPrefix(x => x.Organization);
            this.MapComponentWithPrefix(x => x.ReportingPeriod);
            Map(x => x.ReportStatus);
            Map(x => x.ReOpenedReportStatus);
            Map(x => x.Timestamp);
        }
    }
}