namespace ReportingModule.ValueObjects
{
    public class MaterialData
    {
        protected MaterialData()
        {
        }

        public MaterialData(int target, string dateAndAction, int actual, string comment)
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
        
        public static MaterialData Default() => new MaterialData(0, null, 0, null);

        public static implicit operator MaterialPlanData(MaterialData data)
        {
            return new MaterialPlanData(data.Target,
                data.DateAndAction);
        }

        public static implicit operator MaterialReportData(MaterialData data)
        {
            return new MaterialReportData(data.Actual,
                data.Comment);
        }
    }
}