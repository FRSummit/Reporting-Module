using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class SocialWelfarePlanDataMap : ComponentMap<SocialWelfarePlanData>
    {
        public SocialWelfarePlanDataMap()
        {
            Map(x => x.Target);
            Map(x => x.DateAndAction);
        }
    }
}