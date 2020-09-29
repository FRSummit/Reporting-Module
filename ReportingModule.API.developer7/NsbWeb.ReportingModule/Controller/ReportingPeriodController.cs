using System.Web.Http;
using log4net;
using NsbWeb.Core;
using NsbWeb.Core.Extensions;
using NsbWeb.ReportingModule.QueryServices;

namespace NsbWeb.ReportingModule.Controller
{
    //[CorsPolicy("CorsAllowedSites")]
    public class ReportingPeriodController : ApiController
    {
        private const string V1 = "reporting/v1/reportingperiod/";

        private readonly IUserContext _userContext;
        private readonly ILog _log = LogManager.GetLogger(typeof(ReportingPeriodController));

        private readonly IReportingPeriodQueryService _queryService;

        public ReportingPeriodController(IReportingPeriodQueryService queryService, IUserContext userContext)
        {
            _queryService = queryService;
            _userContext = userContext;
        }

        [Route(V1 + "oforganization")]
        [HttpGet]
        public IHttpActionResult GetReportingPeriodsToCreatePlan(int organizationId)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            return _queryService.GetReportingPeriods(organizationId).ToJson(this);
        }
        [Route(V1 + "next")]
        [HttpGet]
        public IHttpActionResult GetNextReportingPeriod(int reportId)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            var reportingPeriod = _queryService.GetNextReportingPeriod(reportId);
            if (reportingPeriod == null)
                return NotFound();
            return reportingPeriod.ToJson(this);
        }

    }
}