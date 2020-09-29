using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class FinancePlanDataMap : ComponentMap<FinancePlanData>
    {
        public FinancePlanDataMap()
        {
            Map(x => x.Action);
            this.MapComponentWithPrefix(x => x.WorkerPromiseIncreaseTarget);
            Map(x => x.OtherSourceAction);
            this.MapComponentWithPrefix(x => x.OtherSourceIncreaseTarget);
        }
    }
}