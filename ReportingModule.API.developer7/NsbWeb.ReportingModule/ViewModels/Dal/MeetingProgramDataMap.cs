using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class MeetingProgramDataMap : ComponentMap<MeetingProgramData>
    {
        public MeetingProgramDataMap()
        {
            Map(x => x.Target);
            Map(x => x.Actual);
            Map(x => x.AverageAttendance);
            Map(x => x.Comment);
            Map(x => x.DateAndAction);
        }
    }
}