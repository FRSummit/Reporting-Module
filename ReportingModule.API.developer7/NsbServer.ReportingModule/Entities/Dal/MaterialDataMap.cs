using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace ReportingModule.Dal
{
    public class MaterialDataMap : ComponentMap<MaterialData>
    {
        public MaterialDataMap()
        {
            Map(x => x.Target);
            Map(x => x.DateAndAction);
            Map(x => x.Actual);
            Map(x => x.Comment);
        }
    }
}