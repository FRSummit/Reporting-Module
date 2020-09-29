using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class MeetingProgramPlanDataMap : ComponentMap<MeetingProgramPlanData>
    {
        public MeetingProgramPlanDataMap()
        {
            Map(x => x.Target);
            Map(x => x.DateAndAction);
        }
    }
}