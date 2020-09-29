using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using log4net;
using NsbWeb.Core;
using NsbWeb.Core.Extensions;
using NsbWeb.ReportingModule.Common.ActionFilters;
using NsbWeb.ReportingModule.Common.Extensions;
using NsbWeb.ReportingModule.QueryServices;
using NsbWeb.ReportingModule.ViewModels;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.Utility;

namespace NsbWeb.ReportingModule.Controller
{
    public class AllReportController : ApiController
    {
        private const string V1 = "reporting/v1/all/";

        private readonly IAllReportQueryService _queryService;
        private readonly ILog _log = LogManager.GetLogger(typeof(AllReportController));
        private readonly IUserContext _userContext;
        private readonly Func<IEndpointInstance> _endpointInstance;

        public AllReportController(IAllReportQueryService queryService, IUserContext userContext, Func<IEndpointInstance> endpointInstance)
        {
            _queryService = queryService;
            _userContext = userContext;
            _endpointInstance = endpointInstance;
        }

        [Route(V1 + "search")]
        [HttpGet]
        public IHttpActionResult GetSearchResult([FromUri] AllReportSearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            if (searchTerms == null)
                searchTerms = new AllReportSearchTerms();

            if (searchTerms.Organization.HasValue && !_userContext.CurrentUserCanAccess(searchTerms.Organization.Value))
                return Unauthorized();

            if (searchTerms.Parent.HasValue && !_userContext.CurrentUserCanAccess(searchTerms.Parent.Value))
                return Unauthorized();

            return _queryService.Search(searchTerms).ToJson(this);
        }

        [Route(V1 + "plan/search")]
        [HttpGet]
        public IHttpActionResult GetPlanSearchResult([FromUri] AllReportSearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            if (searchTerms == null)
                searchTerms = new AllReportSearchTerms();

            if (searchTerms.Organization.HasValue && !_userContext.CurrentUserCanAccess(searchTerms.Organization.Value))
                return Unauthorized();

            if (searchTerms.Parent.HasValue && !_userContext.CurrentUserCanAccess(searchTerms.Parent.Value))
                return Unauthorized();


            return _queryService.SearchPlan(searchTerms).ToJson(this);
        }


        [Route(V1 + "report/search")]
        [HttpGet]
        public IHttpActionResult GetReportSearchResult([FromUri] AllReportSearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            if (searchTerms == null)
                searchTerms = new AllReportSearchTerms();

            if (searchTerms.Organization.HasValue && !_userContext.CurrentUserCanAccess(searchTerms.Organization.Value))
                return Unauthorized();

            if (searchTerms.Parent.HasValue && !_userContext.CurrentUserCanAccess(searchTerms.Parent.Value))
                return Unauthorized();

            return _queryService.SearchReport(searchTerms).ToJson(this);
        }

        [Route(V1 + "consolidate/search")]
        [HttpGet]
        public IHttpActionResult ConsolidateQuery([FromUri] AllReportSearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            if (searchTerms == null)
                searchTerms = new AllReportSearchTerms();

            if (searchTerms.Organization.HasValue && !_userContext.CurrentUserCanAccess(searchTerms.Organization.Value))
                return Unauthorized();

            if (searchTerms.Parent.HasValue && !_userContext.CurrentUserCanAccess(searchTerms.Parent.Value))
                return Unauthorized();

            return _queryService.Query(searchTerms).ToJson(this);
        }

        [Route(V1 + "consolidate/reports")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> Consolidate(ReportQueryViewModel[] reports)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                var organizationIds = reports.Select(o => o.Organization.Id).Distinct().ToArray();
                if (organizationIds.Any(organizationId => !_userContext.CurrentUserCanAccess(organizationId)))
                    return Unauthorized();

                var reportIds = reports.Select(o => o.Id).ToArray();
                var cmd = new ConsolidateReportCommand(reportIds);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }




        [Route(V1 + "download")]
        [HttpGet]
        public IHttpActionResult DownloadSearchResult([FromUri] AllReportSearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            if (searchTerms == null)
                searchTerms = new AllReportSearchTerms();
            return _queryService.Download(searchTerms).ToExcel($"All_{ZaphodTime.UtcNow.ToFileTime()}.xlsx");
        }

        [Route(V1 + "download/plan")]
        [HttpGet]
        public IHttpActionResult DownloadPlanSearchResult([FromUri] AllReportSearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            if (searchTerms == null)
                searchTerms = new AllReportSearchTerms();
            return _queryService.DownloadPlan(searchTerms).ToExcel($"AllPlan_{ZaphodTime.UtcNow.ToFileTime()}.xlsx");
        }


        [Route(V1 + "download/report")]
        [HttpGet]
        public IHttpActionResult DownloadReportSearchResult([FromUri] AllReportSearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            if (searchTerms == null)
                searchTerms = new AllReportSearchTerms();
            return _queryService.DownloadReport(searchTerms).ToExcel($"AllReport_{ZaphodTime.UtcNow.ToFileTime()}.xlsx");
        }


    }


}