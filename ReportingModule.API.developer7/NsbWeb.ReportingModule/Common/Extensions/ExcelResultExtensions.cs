using NsbWeb.ReportingModule.Common.ActionResults;

namespace NsbWeb.ReportingModule.Common.Extensions
{
    public static class ExcelResultExtensions
    {
        public static ExcelResult ToExcel(this byte[] obj, string filename)
        {
            return new ExcelResult(obj, filename);
        }
    }
}