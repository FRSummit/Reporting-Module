namespace ReportingModule.ValueObjects
{
    public class SocialWelfareData
    {
        protected SocialWelfareData()
        {
        }

        public SocialWelfareData(int target, string dateAndAction, int actual, string comment)
        {
            Target = target;
            DateAndAction = dateAndAction;
            Actual = actual;
            Comment = comment;
        }
        public int Target { get; private set; }
        public string DateAndAction { get; private set; }
        public int Actual { get; private set; }
        public string Comment { get; private set; }
        
        public static SocialWelfareData Default() => new SocialWelfareData(0, null, 0, null);

        public static implicit operator SocialWelfarePlanData(SocialWelfareData data)
        {
            return new SocialWelfarePlanData(data.Target,
                data.DateAndAction);
        }

        public static implicit operator SocialWelfareReportData(SocialWelfareData data)
        {
            return new SocialWelfareReportData(data.Actual,
                data.Comment);
        }
    }
}