using System;
using System.Linq;
using System.Security.Claims;
using ReportingModule.Core;
using ReportingModule.Core.Exceptions;
using ReportingModule.Core.Security;

namespace NsbWeb.Core
{
    public class UserContext : IUserContext
    {
        public UserReference UserRef => GetLoggedInUser();

        public static UserReference GetLoggedInUser()
        {
            var cp = ClaimsPrincipal.Current;

            if (cp == null)
            {
                return null;
            }

            var userId = GetLoggedInUserId();

            return userId != null
                ? new UserReference(userId.Value,
                    cp.FindFirst(ClaimTypes.Name).Value,
                    $"{cp.FindFirst(ClaimTypes.GivenName)?.Value} {cp.FindFirst(ClaimTypes.Surname)?.Value}",
                    cp.FindFirst(ClaimTypes.Email).Value)
                : null;
        }

        public static int? GetLoggedInUserId()
        {
            var cp = ClaimsPrincipal.Current;
            var userIdClaim = cp.FindFirst(ReportingModuleClaimTypes.UserDbId);

            return userIdClaim != null
                ? int.Parse(userIdClaim.Value)
                : (int?)null;
        }
        
        public string Username => GetLoggedInUsername();


        public static string GetLoggedInUsername()
        {
            var cp = ClaimsPrincipal.Current;
            var usernameClaim = cp.FindFirst(ReportingModuleClaimTypes.Username);
            return usernameClaim?.Value;
        }

        public bool CurrentUserIsSystemAdmin()
        {
            var cp = ClaimsPrincipal.Current;

            if (cp == null)
                throw new AccessDeniedException();

            return cp.HasClaim(c => c.Type == ReportingModuleClaimTypes.IsSystemAdmin);
        }

        public bool CurrentUserIsSystemUser()
        {
            var cp = ClaimsPrincipal.Current;

            if (cp == null)
                throw new AccessDeniedException();

            return cp.HasClaim(c => c.Type == ReportingModuleClaimTypes.IsSystemUser);
        }

        public bool CurrentUserCanAccessAllOrganizations()
        {
            var cp = ClaimsPrincipal.Current;

            if (cp == null)
                throw new AccessDeniedException();


            return CurrentUserIsSystemAdmin() || cp.HasClaim(c => c.Type == ReportingModuleClaimTypes.AccessAllOrganizations);
        }

        public bool CurrentUserCanAccess(int organizationId)
        {
            return CurrentUserIsSystemAdmin()
                   || CurrentUserCanAccessAllOrganizations()
                || CurrentUserIsOrganizationAdmin(organizationId)
                   || CurrentUserIsOrganizationUser(organizationId);
        }

        public bool CurrentUserIsOrganizationAdmin(int organizationId)
        {
            
            var role = Enum.GetName(typeof(OrganizationRoleType), OrganizationRoleType.Admin);
            var cp = ClaimsPrincipal.Current;
            if (cp == null)
                throw new AccessDeniedException();
            return cp.HasClaim(c =>
                c.Type == ReportingModuleClaimTypes.OrganizationRole && c.Value == $"{organizationId}|{role}");
        }

        private bool CurrentUserIsOrganizationUser(int organizationId)
        {

            var role = Enum.GetName(typeof(OrganizationRoleType), OrganizationRoleType.User);
            var cp = ClaimsPrincipal.Current;
            if (cp == null)
                throw new AccessDeniedException();
            return cp.HasClaim(c =>
                c.Type == ReportingModuleClaimTypes.OrganizationRole && c.Value == $"{organizationId}|{role}");
        }
        public int[] GetOrganizationIds()
        {
            var cp = ClaimsPrincipal.Current;

            if (cp == null)
                throw new AccessDeniedException();

            var organizationIdClaim = cp.FindFirst(ReportingModuleClaimTypes.OrganizationAccess);

            if (string.IsNullOrWhiteSpace(organizationIdClaim?.Value))
                return new int[0];

            return organizationIdClaim.Value.Split('|')
                .Select(int.Parse)
                .ToArray();
        }

    }
}