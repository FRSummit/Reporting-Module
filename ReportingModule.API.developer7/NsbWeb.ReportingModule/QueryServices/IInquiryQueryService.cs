
namespace NsbWeb.ReportingModule.QueryServices
{
    public interface IInquiryQueryService
    {
        byte[] SearchUnitReport(UnitReportInquirySearchTerms searchTerms);
    }
}