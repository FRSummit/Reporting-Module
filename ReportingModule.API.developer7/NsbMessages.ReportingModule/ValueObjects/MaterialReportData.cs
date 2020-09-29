namespace ReportingModule.ValueObjects
{
    public class MaterialReportData
    {
        protected MaterialReportData()
        {
        }

        public MaterialReportData(int actual, string comment)
        {
            Actual = actual;
            Comment = comment;
        }
        public int Actual { get; private set; }
        public string Comment{ get; private set; }
    }
}