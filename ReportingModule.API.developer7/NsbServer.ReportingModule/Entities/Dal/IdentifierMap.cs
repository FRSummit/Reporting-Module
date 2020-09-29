using FluentNHibernate.Mapping;
using ReportingModule.Entities;

namespace ReportingModule.Dal
{
    public class IdentifierMap : ClassMap<Identifier>
    {
        public IdentifierMap()
        {
            Not.LazyLoad();

            Id(x => x.Id);
            Map(x => x.IdentifierType);
            Map(x => x.CurrentIndex);
        }
    }
}