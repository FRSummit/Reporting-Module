using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class MemberPlanDataMap : ComponentMap<MemberPlanData>
    {
        public MemberPlanDataMap()
        {
            Map(x => x.NameAndContactNumber);
            Map(x => x.Action);
            Map(x => x.UpgradeTarget);
        }
    }
}