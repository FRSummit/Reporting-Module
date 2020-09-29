namespace ReportingModule.ValueObjects
{
    public class MeetingProgramReportData
    {
        protected MeetingProgramReportData()
        {
        }

        public MeetingProgramReportData(int actual, int averageAttendance, string comment)
        {
            Actual = actual;
            AverageAttendance = averageAttendance;
            Comment = comment;
        }
        public int Actual { get; private set; }
        public int AverageAttendance{ get; private set; }
        public string Comment{ get; private set; }
    }
}