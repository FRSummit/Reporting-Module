namespace ReportingModule.ValueObjects
{
    public class MaterialPlanData
    {
        protected MaterialPlanData()
        {
        }

        public MaterialPlanData(int target, string dateAndAction)
        {
            Target = target;
            DateAndAction = dateAndAction;
        }
        public int Target { get; private set; }
        public string DateAndAction { get; private set; }
    }
}