namespace ReportingModule.ValueObjects
{
    public class TeachingLearningProgramData
    {
        protected TeachingLearningProgramData()
        {
        }

        public TeachingLearningProgramData(int target, string dateAndAction, int actual, int averageAttendance, string comment)
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
        
        public static TeachingLearningProgramData Default() => new TeachingLearningProgramData(0, null, 0, 0, null);

        public static implicit operator TeachingLearningProgramPlanData(TeachingLearningProgramData data)
        {
            return new TeachingLearningProgramPlanData(data.Target,
                data.DateAndAction);
        }

        public static implicit operator TeachingLearningProgramReportData(TeachingLearningProgramData data)
        {
            return new TeachingLearningProgramReportData(data.Actual,
                data.AverageAttendance,
                data.Comment);
        }
    }
}