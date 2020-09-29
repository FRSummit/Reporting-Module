namespace ReportingModule.ValueObjects
{
    public class TeachingLearningProgramPlanData
    {
        protected TeachingLearningProgramPlanData()
        {
        }

        public TeachingLearningProgramPlanData(int target, string dateAndAction)
        {
            Target = target;
            DateAndAction = dateAndAction;
        }
        public int Target { get; private set; }
        public string DateAndAction { get; private set; }
    }
}