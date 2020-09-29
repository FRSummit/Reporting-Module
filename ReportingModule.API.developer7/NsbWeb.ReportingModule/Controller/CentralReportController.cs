using System;
using System.Threading.Tasks;
using System.Web.Http;
using log4net;
using NsbWeb.Core;
using NsbWeb.Core.Extensions;
using NsbWeb.ReportingModule.Common.ActionFilters;
using NsbWeb.ReportingModule.Common.Extensions;
using NsbWeb.ReportingModule.QueryServices;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.Utility;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.Controller
{
    public class CentralReportController : ApiController
    {
        private const string V1 = "reporting/v1/central/";

        private readonly ICentralReportQueryService _queryService;
        private readonly Func<IEndpointInstance> _endpointInstance;
        private readonly ILog _log = LogManager.GetLogger(typeof(CentralReportController));
        private readonly IUserContext _userContext;

        //private readonly IUserContext _userContext;

        public CentralReportController(ICentralReportQueryService queryService, Func<IEndpointInstance> endpointInstance, IUserContext userContext)
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
            return _queryService.GetCentralPlanViewModel(planId).ToJson(this);
        }

        [Route(V1 + "plan/create")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> MakeCentralPlan(
            OrganizationReference organization,
            int year,
            ReportingTerm reportingTerm)
        {
            return await MakeCentralPlan2(organization, year, reportingTerm, ReportingFrequency.Yearly);
        }

        [Route(V1 + "plan/create2")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> MakeCentralPlan2(
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

                var cmd = new CreateCentralPlanCommand(organization, year, reportingTerm, reportingFrequency);
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

                var cmd = new CopyCentralPlanCommand(copyFromReportId, organization, year, reportingTerm, reportingFrequency);
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

                var plan = _queryService.GetCentralPlanViewModel(planId);
                if (plan == null)
                    return NotFound();
                if (plan.ReportStatus == ReportStatus.Submitted && !_userContext.CurrentUserCanAccessAllOrganizations())
                    return Unauthorized();
                var cmd = new UpdateCentralPlanCommand(planId, planData);
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

                var cmd = new PromotePlanToCentralReportCommand(planId);
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
            return _queryService.GetCentralReportViewModel(reportId).ToJson(this);
        }

        [Route(V1 + "report/update/id")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> UpdateCentralReport(int organizationId, int reportId, ReportData reportData)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (reportData == null) throw new ArgumentNullException(nameof(reportData));

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();
                var report = _queryService.GetCentralReportViewModel(reportId);
                if (report == null)
                    return NotFound();
                if (report.ReportStatus == ReportStatus.Submitted && !_userContext.CurrentUserCanAccessAllOrganizations())
                    return Unauthorized();

                var cmd = new UpdateCentralReportCommand(reportId, reportData);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        [Route(V1 + "report/updateLastPeriod/id")]
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
                var report = _queryService.GetCentralReportViewModel(reportId);
                if (report == null)
                    return NotFound();
                if (report.ReportStatus == ReportStatus.Submitted && !_userContext.CurrentUserCanAccessAllOrganizations())
                    return Unauthorized();

                var cmd = new UpdateCentralReportLastPeriodDataCommand(reportId, reportLastPeriodUpdateData);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }


        [Route(V1 + "report/recalculate/id")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> Recalculate(int organizationId, int reportId)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();

                var cmd = new UpdateCentralReportGeneratedDataCommand(reportId, false);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        [Route(V1 + "report/reset/id")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> Reset(int organizationId, int reportId)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();

                var cmd = new UpdateCentralReportGeneratedDataCommand(reportId, true);
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
        public IHttpActionResult DownloadCentralReport(int reportId, ExcelReportType excelReportType = ExcelReportType.List)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();
            return _queryService.DownloadCentralReportViewModel(reportId, excelReportType).ToExcel($"CentralReport_{ZaphodTime.UtcNow.ToFileTime()}.xlsx");
        }
    }
}