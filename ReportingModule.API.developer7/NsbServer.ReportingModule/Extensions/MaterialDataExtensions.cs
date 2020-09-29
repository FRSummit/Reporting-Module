using ReportingModule.ValueObjects;

namespace ReportingModule.Extensions
{
    public static class MaterialDataExtensions
    {
        public static MaterialData ToMaterialData(this MaterialData data, MaterialPlanData planData)
        {
            return new MaterialData(planData.Target,
                planData.DateAndAction,
                data.Actual,
                data.Comment);
        }

        public static MaterialData ToMaterialData(this MaterialData data, MaterialReportData reportData)
        {
            return new MaterialData(data.Target,
                data.DateAndAction,
                reportData.Actual,
                reportData.Comment);
        }
    }
}