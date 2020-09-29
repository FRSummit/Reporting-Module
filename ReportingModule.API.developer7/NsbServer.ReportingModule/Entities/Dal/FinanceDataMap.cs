using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;
using ReportingModule.ValueObjects;

namespace ReportingModule.Entities.Dal
{
    public class FinanceDataMap : ComponentMap<FinanceData>
    {
        public FinanceDataMap()
        {
            Map(x => x.Action);
            this.MapComponentWithPrefix(x => x.WorkerPromiseIncreaseTarget);
            Map(x => x.OtherSourceAction);
            this.MapComponentWithPrefix(x => x.OtherSourceIncreaseTarget);

            this.MapComponentWithPrefix(x => x.WorkerPromiseLastPeriod);

            this.MapComponentWithPrefix(x => x.LastPeriod);
            this.MapComponentWithPrefix(x => x.Collection);
            this.MapComponentWithPrefix(x => x.Expense);
            this.MapComponentWithPrefix(x => x.NisabPaidToCentral);

            this.MapComponentWithPrefix(x => x.WorkerPromiseIncreased);
            this.MapComponentWithPrefix(x => x.WorkerPromiseDecreased);
            
            Map(x => x.Comment);
        }
    }
}