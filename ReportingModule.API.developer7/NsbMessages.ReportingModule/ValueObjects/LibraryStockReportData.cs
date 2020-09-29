namespace ReportingModule.ValueObjects
{
    public class LibraryStockReportData
    {
        protected LibraryStockReportData()
        {
        }

        public LibraryStockReportData(int lastPeriod, int increased, int decreased, string comment)
        {
            LastPeriod = lastPeriod;
            Increased = increased;
            Decreased = decreased;
            Comment = comment;
        }
        public int LastPeriod { get; private set; }
        public int Increased { get; private set; }
        public int Decreased { get; private set; }
        public string Comment { get; private set; }
    }
}