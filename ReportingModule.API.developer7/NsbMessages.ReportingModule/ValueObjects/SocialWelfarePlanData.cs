namespace ReportingModule.ValueObjects
{
    public class SocialWelfarePlanData
    {
        protected SocialWelfarePlanData()
        {
        }

        public SocialWelfarePlanData(int target, string dateAndAction)
        {
            Target = target;
            DateAndAction = dateAndAction;
        }
        public int Target { get; private set; }
        public string DateAndAction { get; private set; }
    }
}