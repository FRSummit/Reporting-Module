using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using NsbWeb.ReportingModule.QueryServices;
using ReportingModule.Core.Security;

namespace ReportingModule.Website
{
    public class ReportingModuleJwtSecurityTokenHandler : JwtSecurityTokenHandler
    {
        private readonly IOrganizationUserQueryService _organizationUserQueryService;
        private readonly IOrganizationQueryService _organizationQueryService;
        private const string True = "true";


        public ReportingModuleJwtSecurityTokenHandler(IOrganizationUserQueryService organizationUserQueryService, IOrganizationQueryService organizationQueryService)
        {
            _organizationUserQueryService = organizationUserQueryService;
            _organizationQueryService = organizationQueryService;
        }
        protected override ClaimsIdentity CreateClaimsIdentity(
            JwtSecurityToken jwtToken,
            string issuer,
            TokenValidationParameters validationParameters)


        { 
            var identity = base.CreateClaimsIdentity(jwtToken, issuer, validationParameters);
            return AddIdentityToClaimsPrincipal(identity);
        }

        private ClaimsIdentity AddIdentityToClaimsPrincipal(ClaimsIdentity identity)
        {
            if (!identity.IsAuthenticated)
                return identity;
            if (identity.HasClaim(c => c.Type == ReportingModuleClaimTypes.IsSystemAdmin))
                return identity;
            if (identity.HasClaim(c => c.Type == ReportingModuleClaimTypes.IsSystemUser))
            {
                var usernameClaim = identity.FindFirst(ReportingModuleClaimTypes.Username);
                var username = usernameClaim?.Value;
                if (!string.IsNullOrWhiteSpace(username))
                {
                    var claims = GetOrganizationClaims(username);
                    identity.AddClaims(claims);
                }
            }

            return identity;
        }

        private class OrganizationRole
        {
            public int Id { get; set; }
            public string Role { get; set; }
        }

        protected internal IEnumerable<Claim> GetOrganizationClaims(string username)
        {
            var hasCentralAccess = _organizationUserQueryService.HasCentralAccess(username);
            if (hasCentralAccess)
                yield return new Claim(ReportingModuleClaimTypes.AccessAllOrganizations, True);
            var organizationUsers = _organizationUserQueryService.GetByUsername(username).ToArray();
            var organizationRoles = new List<OrganizationRole>();
            var organizationIds = new List<int>();
            foreach (var organizationUserViewModel in organizationUsers)
            {
                var managedOrganizationIds = _organizationQueryService.GetManagedOrganizationIds(organizationUserViewModel.Organization.Id);
                var orgIds = new[] { organizationUserViewModel.Organization.Id }.Concat(managedOrganizationIds).ToArray().Distinct().ToArray();
                organizationIds.AddRange(orgIds);
                organizationRoles.AddRange( orgIds.Select(o => new OrganizationRole{Id = o, Role = organizationUserViewModel.Role}).ToArray());
            }
            yield return new Claim(ReportingModuleClaimTypes.OrganizationAccess, string.Join("|", organizationIds.Distinct().ToArray()));

            var organizationRoleClaims = organizationRoles.Distinct()
                .OrderBy(o => o.Id)
                .ThenBy(o => o.Role)
                .Select(o => new Claim(ReportingModuleClaimTypes.OrganizationRole,
                $"{o.Id}|{o.Role}")).ToArray();

            foreach (var claim in organizationRoleClaims)
                yield return claim;
        }
    }
}