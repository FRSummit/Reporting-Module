using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace ReportingModule.Dal
{
    public class LibraryStockDataMap : ComponentMap<LibraryStockData>
    {
        public LibraryStockDataMap()
        {
            Map(x => x.LastPeriod);
            Map(x => x.Increased);
            Map(x => x.Decreased);
            Map(x => x.Comment);
        }
    }
}