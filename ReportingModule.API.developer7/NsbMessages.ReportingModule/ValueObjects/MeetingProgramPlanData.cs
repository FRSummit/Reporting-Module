namespace ReportingModule.ValueObjects
{
    public class MeetingProgramPlanData
    {
        protected MeetingProgramPlanData()
        {
        }

        public MeetingProgramPlanData(int target, string dateAndAction)
        {
            Target = target;
            DateAndAction = dateAndAction;
        }
        public int Target { get; private set; }
        public string DateAndAction { get; private set; }
    }
}