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
using ReportingModule.Core;
using ReportingModule.Core.Security;

namespace NsbWeb.ReportingModule.Controller
{
    //[CorsPolicy("CorsAllowedSites")]
    public class OrganizationUserController : ApiController
    {
        private const string V1 = "reporting/v1/organization/user/";

        private readonly Func<IEndpointInstance> _endpointInstance;
        private readonly ILog _log = LogManager.GetLogger(typeof(OrganizationController));
        private readonly IOrganizationUserQueryService _queryService;
        private readonly IUserContext _userContext;

        public OrganizationUserController(Func<IEndpointInstance> endpointInstance, IOrganizationUserQueryService queryService, IUserContext userContext)
        {
            _endpointInstance = endpointInstance;
            _queryService = queryService;
            _userContext = userContext;
        }

        [Route(V1 + "search")]
        [HttpGet]
        public IHttpActionResult GerOrganizationUserSearchResult([FromUri] OrganizationUserSearchTerms searchTerms)
        {
            if (!_userContext.CurrentUserIsSystemUser())
                return Unauthorized();

            if (searchTerms == null)
                searchTerms = new OrganizationUserSearchTerms();

            return _queryService.SearchOrganizationUser(searchTerms).ToJson(this);
        }


        [Route(V1 + "create")]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> CreateOrganizationUser(string username,
            OrganizationRoleType organizationRoleType,
            EntityReference organization)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (string.IsNullOrWhiteSpace(username))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(username));

              
                if (organization == null) throw new ArgumentNullException(nameof(organization));

                if (!_userContext.CurrentUserIsSystemAdmin() && !_userContext.CurrentUserIsOrganizationAdmin(organization.Id))
                    return Unauthorized();


                var cmd = new CreateOrganizationUserCommand(username, organizationRoleType.ToString(), organization);
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
        public async Task<IHttpActionResult> UpdateOrganizationUser(string username,
            string role,
            EntityReference organization, string newRole)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (string.IsNullOrWhiteSpace(username))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(username));

                if (string.IsNullOrWhiteSpace(role))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(role));

                if (organization == null) throw new ArgumentNullException(nameof(organization));

                if (string.IsNullOrWhiteSpace(newRole))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(newRole));
                
                if (!_userContext.CurrentUserIsSystemAdmin() && !_userContext.CurrentUserIsOrganizationAdmin(organization.Id))
                    return Unauthorized();

                var cmd = new UpdateOrganizationUserCommand(username, role, organization, newRole);
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
        public async Task<IHttpActionResult> DeleteOrganizationUser(int organizationUserId)
        {
            try
            {
                if (!_userContext.CurrentUserIsSystemUser())
                    return Unauthorized();

                if (!_userContext.CurrentUserIsSystemAdmin())
                    return Unauthorized();

                if (!_userContext.CurrentUserCanAccess(organizationUserId))
                    return Unauthorized();

                var cmd = new DeleteOrganizationUserCommand(organizationUserId);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }
    }
}