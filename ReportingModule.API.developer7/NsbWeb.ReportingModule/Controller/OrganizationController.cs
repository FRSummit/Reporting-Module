using System;
using System.Threading.Tasks;
using System.Web.Http;
using NsbWeb.ReportingModule.Common.ActionFilters;
using NsbWeb.ReportingModule.Common.Extensions;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.ValueObjects;
using log4net;
using NsbWeb.Core;
using NsbWeb.Core.Extensions;
using NsbWeb.ReportingModule.QueryServices;
using ReportingModule.Core;

namespace NsbWeb.ReportingModule.Controller
{
    //[CorsPolicy("CorsAllowedSites")]
    public class OrganizationController : ApiController
    {
        private const string V1 = "reporting/v1/organization/";

        private readonly Func<IEndpointInstance> _endpointInstance;
        private readonly IUserContext _userContext;
        private readonly ILog _log = LogManager.GetLogger(typeof(OrganizationController));

        private readonly IOrganizationQueryService _queryService;
        //private readonly IUserContext _userContext;

        public OrganizationController(Func<IEndpointInstance> endpointInstance, IOrganizationQueryService queryService, IUserContext userContext)
        {
            _endpointInstance = endpointInstance;
            _queryService = queryService;
            _userContext = userContext;
        }

        [Route(V1 + "search")]
        [HttpGet]
        public IHttpActionResult GetOrganizationSearchResult([FromUri] OrganizationSearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();


            if (searchTerms == null)
                searchTerms = new OrganizationSearchTerms();

            return _queryService.SearchOrganization(searchTerms).ToJson(this);
        }

        [Route(V1 + "myorganizations")]
        [HttpGet]
        public IHttpActionResult GetMyOrganizationResult()
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            return _queryService.GetMyOrganizations().ToJson(this);
        }

        [Route(V1 + "id")]
        [HttpGet]
        public IHttpActionResult GetOrganization(int organizationId)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            return _queryService.GetOrganizationViewModel(organizationId).ToJson(this);
        }

        [Route(V1 + "create")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> CreateOrganization(string description,
            string details,
            OrganizationType organizationType,
            ReportingFrequency reportingFrequency,
            EntityReference parent)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (string.IsNullOrWhiteSpace(description))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));

                if (!_userContext.CurrentUserIsSystemAdmin())
                    return Unauthorized();

                var cmd = new CreateOrganizationCommand(description, details, organizationType, reportingFrequency, parent);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        [Route(V1 + "update")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> UpdateOrganization(int organizationId, string description,
            string details,
            OrganizationType organizationType,
            ReportingFrequency reportingFrequency,
            EntityReference parent)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (string.IsNullOrWhiteSpace(description))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));

                if (!_userContext.CurrentUserIsSystemAdmin())
                    return Unauthorized();

                var organization = _queryService.GetOrganizationViewModel(organizationId);
                if (organization == null)
                    throw new ArgumentException("Invalid Organization Id", nameof(organizationId)); 

                var cmd = new UpdateOrganizationCommand(organizationId, description, details, organizationType, reportingFrequency, parent);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        [Route(V1 + "delete")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> DeleteOrganization(int organizationId)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserIsSystemAdmin())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationId))
                    return Unauthorized();

                var cmd = new DeleteOrganizationCommand(organizationId);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        //Remove this once calls are moved to reportingperiodcontroller
        [Route(V1 + "createplanreportingperiods")]
        [HttpGet]
        public IHttpActionResult GetReportingPeriodsToCreatePlan(int organizationId)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            return _queryService.GetReportingPeriods(organizationId).ToJson(this);
        }
    }
}