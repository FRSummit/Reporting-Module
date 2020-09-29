using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services
{
    public interface IConsolidatedReportService
    {
        ReportData GetConsolidatedReportData(int[] reportIds);
    }
}