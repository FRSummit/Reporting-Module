using FluentNHibernate.Mapping;

namespace ReportingModule.Core.Fluent
{
    public class MoneyMap: ComponentMap<Money>
    {
        public MoneyMap()
        {
            Map(x => x.Currency);
            Map(x => x.Amount);
        }
    }

    public sealed class MoneyComponentMapping
    {
        public static void Map(CompositeElementPart<Money> part)
        {
            part.Map(x => x.Currency);
            part.Map(x => x.Amount);
        }
    }
}