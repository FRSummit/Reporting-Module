namespace ReportingModule.ValueObjects
{
    public class SocialWelfareReportData
    {
        protected SocialWelfareReportData()
        {
        }

        public SocialWelfareReportData(int actual, string comment)
        {
            Actual = actual;
            Comment = comment;
        }
        public int Actual { get; private set; }
        public string Comment{ get; private set; }
    }
}