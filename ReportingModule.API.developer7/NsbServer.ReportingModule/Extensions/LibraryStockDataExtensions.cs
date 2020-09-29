using ReportingModule.ValueObjects;

namespace ReportingModule.Extensions
{
    public static class LibraryStockDataExtensions
    {
        public static LibraryStockData ToLibraryStockData(this LibraryStockData data, LibraryStockPlanData planData)
        {
            return new LibraryStockData(
                data.LastPeriod,
                data.Increased,
                data.Decreased,
                data.Comment);
        }

        public static LibraryStockData ToLibraryStockData(this LibraryStockData data, LibraryStockReportData reportData)
        {
            return new LibraryStockData(
                reportData.LastPeriod,
                reportData.Increased,
                reportData.Decreased,
                reportData.Comment
                );
        }

        
    }
}