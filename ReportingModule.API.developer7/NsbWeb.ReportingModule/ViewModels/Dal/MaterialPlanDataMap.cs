using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class MaterialPlanDataMap : ComponentMap<MaterialPlanData>
    {
        public MaterialPlanDataMap()
        {
            Map(x => x.Target);
            Map(x => x.DateAndAction);
        }
    }
}