using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace ReportingModule.Dal
{
    public class ReportingPeriodMap : ComponentMap<ReportingPeriod>
    {
        public ReportingPeriodMap()
        {
            Map(x => x.Year);
            Map(x => x.ReportingFrequency);
            Map(x => x.ReportingTerm);
            Map(x => x.StartDate);
            Map(x => x.EndDate);
        }
    }
}