using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class MemberDataMap : ComponentMap<MemberData>
    {
        public MemberDataMap()
        {
            Map(x => x.NameAndContactNumber);
            Map(x => x.LastPeriod);
            Map(x => x.Increased);
            Map(x => x.Decreased);
            Map(x => x.Action);
            Map(x => x.UpgradeTarget);
            Map(x => x.Comment);
            Map(x => x.PersonalContact);
        }
    }
}