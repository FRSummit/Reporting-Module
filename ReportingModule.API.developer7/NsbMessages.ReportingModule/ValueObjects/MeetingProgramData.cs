namespace ReportingModule.ValueObjects
{
    public class MeetingProgramData
    {
        protected MeetingProgramData()
        {
        }

        public MeetingProgramData(int target, string dateAndAction, int actual, int averageAttendance, string comment)
        {
            Target = target;
            DateAndAction = dateAndAction;
            Actual = actual;
            AverageAttendance = averageAttendance;
            Comment = comment;
        }
        public int Target { get; private set; }
        public string DateAndAction { get; private set; }
        public int Actual { get; private set; }
        public int AverageAttendance { get; private set; }
        public string Comment { get; private set; }
        
        public static MeetingProgramData Default() => new MeetingProgramData(0, null, 0, 0, null);

        public static implicit operator MeetingProgramPlanData(MeetingProgramData data)
        {
            return new MeetingProgramPlanData(data.Target,
                data.DateAndAction);
        }

        public static implicit operator MeetingProgramReportData(MeetingProgramData data)
        {
            return new MeetingProgramReportData(data.Actual,
                data.AverageAttendance,
                data.Comment);
        }
    }
}