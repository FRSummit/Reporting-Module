using System.Web.Http;
using NsbWeb.ReportingModule.QueryServices;
using NsbWeb.Core;
using NsbWeb.ReportingModule.Common.ActionResults;

namespace NsbWeb.ReportingModule.Controller
{
    //[CorsPolicy("CorsAllowedSites")]
    public class InquiryController : ApiController
    {
        private const string V1 = "reporting/v1/inquiry/";

        private readonly IUserContext _userContext;
        private readonly IInquiryQueryService _queryService;

        public InquiryController(IUserContext userContext, IInquiryQueryService queryService1)
        {
            _userContext = userContext;
            _queryService = queryService1;
        }

        [Route(V1 + "download/unit/report/excel")]
        [HttpGet]
        public IHttpActionResult DownloadReportSearchResult([FromUri] UnitReportInquirySearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            if (searchTerms == null)
                searchTerms = new UnitReportInquirySearchTerms();

            var response = _queryService.SearchUnitReport(searchTerms);
            return new ExcelResult(response, "UnitReport.xlsx");
        }

    }
}