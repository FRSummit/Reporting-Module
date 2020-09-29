namespace ReportingModule.ValueObjects
{
    public class MemberReportData
    {
        protected MemberReportData()
        {
        }

        public MemberReportData(int lastPeriod, int increased, int decreased, string comment, int personalContact)
        {
            LastPeriod = lastPeriod;
            Increased = increased;
            Decreased = decreased;
            Comment = comment;
            PersonalContact = personalContact;
        }
        public int LastPeriod { get; private set; }
        public int Increased { get; private set; }
        public int Decreased { get; private set; }
        public string Comment { get; private set; }
        public int PersonalContact { get; private set; }

    }
}