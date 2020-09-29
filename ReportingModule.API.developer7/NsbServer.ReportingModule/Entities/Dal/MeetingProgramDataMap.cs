using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace ReportingModule.Dal
{
    public class MeetingProgramDataMap : ComponentMap<MeetingProgramData>
    {
        public MeetingProgramDataMap()
        {
            Map(x => x.Target);
            Map(x => x.DateAndAction);
            Map(x => x.Actual);
            Map(x => x.AverageAttendance);
            Map(x => x.Comment);
        }
    }
}