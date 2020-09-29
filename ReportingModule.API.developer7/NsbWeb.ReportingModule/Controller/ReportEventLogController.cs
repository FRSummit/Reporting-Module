using System.Web.Http;
using log4net;
using NsbWeb.Core;
using NsbWeb.Core.Extensions;
using NsbWeb.ReportingModule.QueryServices;

namespace NsbWeb.ReportingModule.Controller
{
    //[CorsPolicy("CorsAllowedSites")]
    public class ReportEventLogController : ApiController
    {
        private const string V1 = "reporting/v1/log/";

        private readonly ILog _log = LogManager.GetLogger(typeof(OrganizationController));
        private readonly IReportEventLogQueryService _queryService;
        private readonly IUserContext _userContext;

        public ReportEventLogController(IReportEventLogQueryService queryService, IUserContext userContext)
        {
            _queryService = queryService;
            _userContext = userContext;
        }

        [Route(V1 + "search")]
        [HttpGet]
        public IHttpActionResult GerOrganizationUserSearchResult([FromUri] ReportEventLogSearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();


            if (searchTerms == null)
                searchTerms = new ReportEventLogSearchTerms();

            return _queryService.SearchReportEventLog(searchTerms).ToJson(this);
        }
    }
}