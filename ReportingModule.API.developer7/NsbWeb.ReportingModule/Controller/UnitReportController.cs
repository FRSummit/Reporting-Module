using System;
using System.Threading.Tasks;
using System.Web.Http;
using NsbWeb.Core.Extensions;
using NsbWeb.ReportingModule.Common.ActionFilters;
using NsbWeb.ReportingModule.Common.Extensions;
using NsbWeb.ReportingModule.QueryServices;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.ValueObjects;
using log4net;
using NsbWeb.Core;
using ReportingModule.Utility;

namespace NsbWeb.ReportingModule.Controller
{
    //[CorsPolicy("CorsAllowedSites")]
    public class UnitReportController : ApiController
    {
        private const string V1 = "reporting/v1/unit/";

        private readonly IUnitReportQueryService _queryService;
        private readonly Func<IEndpointInstance> _endpointInstance;
        private readonly ILog _log = LogManager.GetLogger(typeof(UnitReportController));
        private readonly IUserContext _userContext;

        public UnitReportController(IUnitReportQueryService queryService, Func<IEndpointInstance> endpointInstance, IUserContext userContext)
        {
            _queryService = queryService;
            _endpointInstance = endpointInstance;
            _userContext = userContext;
        }
        
        [Route(V1 + "plan/{planId}")]
        [HttpGet]
        public IHttpActionResult GetPlan(int planId)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();
            return _queryService.GetUnitPlanViewModel(planId).ToJson(this);
        }

        [Route(V1 + "plan/create")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> MakeUnitPlan(
            OrganizationReference organization,
            int year,
            ReportingTerm reportingTerm)
        {
            return await MakeUnitPlan2(organization, year, reportingTerm, ReportingFrequency.Monthly);
        }

        [Route(V1 + "plan/create2")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> MakeUnitPlan2(
                    OrganizationReference organization,
                    int year,
                    ReportingTerm reportingTerm,
                    ReportingFrequency reportingFrequency)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (organization == null) throw new ArgumentNullException(nameof(organization));

                if (!_userContext.CurrentUserCanAccess(organization.Id))
                    return Unauthorized();

                var cmd = new CreateUnitPlanCommand(organization, year, reportingTerm, reportingFrequency);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        [Route(V1 + "plan/copy")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> CopyCentralPlan(
            int copyFromReportId,
            OrganizationReference organization,
            int year,
            ReportingTerm reportingTerm,
            ReportingFrequency reportingFrequency)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (organization == null) throw new ArgumentNullException(nameof(organization));

                if (!_userContext.CurrentUserCanAccess(organization.Id))
                    return Unauthorized();

                var cmd = new CopyUnitPlanCommand(copyFromReportId, organization, year, reportingTerm, reportingFrequency);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }


        [Route(V1 + "plan/update")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> UpdatePlan(int organizationId, int planId, PlanData planData)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();
                var plan = _queryService.GetUnitPlanViewModel(planId);
                if (plan == null)
                    return NotFound();
                if (plan.ReportStatus == ReportStatus.Submitted && !_userContext.CurrentUserCanAccessAllOrganizations())
                    return Unauthorized();
                var cmd = new UpdateUnitPlanCommand(planId, planData);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }


        [Route(V1 + "plan/submit")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> PromotePlanToReport(int organizationId, int planId)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();

                var cmd = new PromotePlanToUnitReportCommand(planId);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }
        
        [Route(V1 + "report/{reportId}")]
        [HttpGet]
        public IHttpActionResult GetUnitReport(int reportId)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();
            return _queryService.GetUnitReportViewModel(reportId).ToJson(this);
        }

        [Route(V1 + "report/update")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> UpdateReport(int organizationId, int reportId, ReportUpdateData reportUpdateData)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();
                var report = _queryService.GetUnitReportViewModel(reportId);
                if (report == null)
                    return NotFound();
                if (report.ReportStatus == ReportStatus.Submitted && !_userContext.CurrentUserCanAccessAllOrganizations())
                    return Unauthorized();

                var cmd = new UpdateUnitReportCommand(reportId, reportUpdateData);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        [Route(V1 + "report/updateLastPeriod")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> UpdateLastPeriod(int organizationId, int reportId, ReportLastPeriodUpdateData reportLastPeriodUpdateData)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();
                var report = _queryService.GetUnitReportViewModel(reportId);
                if (report == null)
                    return NotFound();
                if (report.ReportStatus == ReportStatus.Submitted && !_userContext.CurrentUserCanAccessAllOrganizations())
                    return Unauthorized();

                var cmd = new UpdateUnitReportLastPeriodDataCommand(reportId, reportLastPeriodUpdateData);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }


        [Route(V1 + "report/submit")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> SubmitReport(int organizationId, int reportId)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();

                var cmd = new SubmitReportCommand(reportId);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        [Route(V1 + "report/delete")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> DeleteReport(int organizationId, int reportId)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserIsSystemAdmin())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();

                var cmd = new DeleteReportCommand(reportId);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }
        [Route(V1 + "report/unsubmit")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> UnSubmitReport(int organizationId, int reportId)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserIsSystemAdmin())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();

                var cmd = new UnSubmitReportCommand(reportId);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }
        
        [Route(V1 + "download/report/{reportId}")]
        [HttpGet]
        public IHttpActionResult DownloadUnitReport(int reportId, ExcelReportType excelReportType = ExcelReportType.List)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();
            return _queryService.DownloadUnitReportViewModel(reportId, excelReportType).ToExcel($"UnitReport_{ZaphodTime.UtcNow.ToFileTime()}.xlsx");
        }
    }
}