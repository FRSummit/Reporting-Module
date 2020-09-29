using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using log4net;
using NsbWeb.ReportingModule.Common.Extensions;
using NsbWeb.ReportingModule.Controller;
using NsbWeb.ReportingModule.QueryServices;
using ReportingModule.Core.Security;
using ReportingModule.Utility;

namespace ReportingModule.Website.Controllers
{
    public class LoginController : ApiController
    {
        private const string V1 = "reporting/v1/login/";

        private readonly ILog _log = LogManager.GetLogger(typeof(OrganizationController));

        private readonly IOrganizationUserQueryService _organizationUserQueryService;

        public LoginController(IOrganizationUserQueryService organizationUserQueryService)
        {
            _organizationUserQueryService = organizationUserQueryService;
        }

        [Route(V1 + "logout")]
        [HttpPost]
        public IHttpActionResult Logout()
        {
            try
            {
                FederatedAuthentication.SessionAuthenticationModule.SignOut();
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }
        
        [Route(V1 + "as")]
        [HttpPost]
        public IHttpActionResult LoginAsUser(string username,
            string password, LoginAs loginAs)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(username));

                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(password));

                if (!Authenticate(password))
                    return Unauthorized();

                SetupClaims(username, loginAs);

                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }

        private bool Authenticate(string password)
        {
            if (password == "modnar@123")
                return true;
            return false;
        }

        private void SetupClaims(string username, LoginAs loginAs)
        {
            var cp = GetClaimsPrincipalForUser(username, loginAs);
            StoreClaimsPrincipalInSessionAuthentication(cp);
            //StoreAuthenticatedLoginInSession(user);
        }

        protected internal ClaimsPrincipal GetClaimsPrincipalForUser(string username, LoginAs loginAs)
        {
            var claims = loginAs == LoginAs.SystemAdmin ? GetClaimsForUserAsSystemAdmin(username) : GetClaimsForUser(username);
            var id = new ClaimsIdentity(new GenericIdentity(username), claims, "Forms", string.Empty, string.Empty);
            return new ClaimsPrincipal(id);
        }

        private static void StoreClaimsPrincipalInSessionAuthentication(ClaimsPrincipal cp)
        {
            if (HttpContext.Current == null) return;

            var authenticatedCp = FederatedAuthentication.FederationConfiguration
                .IdentityConfiguration.ClaimsAuthenticationManager
                .Authenticate("ReportingModule", cp);

            var token = authenticatedCp.ToSecurityToken();

            FederatedAuthentication.SessionAuthenticationModule.AuthenticateSessionSecurityToken(token, true);
        }

        private const string True = "true";

        protected internal static IEnumerable<Claim> GetClaimsForUserAsSystemAdmin(string username)
        {
            yield return new Claim(ReportingModuleClaimTypes.Username, username);
            yield return new Claim(ClaimTypes.GivenName, username);
            yield return new Claim(ClaimTypes.Surname, username);
            yield return new Claim(ClaimTypes.Email, username);
            yield return new Claim(ReportingModuleClaimTypes.IsSystemAdmin, True);
            yield return new Claim(ReportingModuleClaimTypes.IsSystemUser, True);

        }

        protected internal  IEnumerable<Claim> GetClaimsForUser(string username)
        {
            yield return new Claim(ReportingModuleClaimTypes.Username, username);
            yield return new Claim(ClaimTypes.GivenName, username);
            yield return new Claim(ClaimTypes.Surname, username);
            yield return new Claim(ClaimTypes.Email, username);
            yield return new Claim(ReportingModuleClaimTypes.IsSystemUser, True);
            foreach (var claim in GetOrganizationClaims(username))
                yield return claim;
        }

       
        protected internal  IEnumerable<Claim> GetOrganizationClaims(string username)
        {
            var organizationUsers =_organizationUserQueryService.GetByUsername(username).ToArray();

            var orgIds = organizationUsers.Select(o => o.Organization.Id).ToArray();
            yield return new Claim(ReportingModuleClaimTypes.OrganizationAccess, string.Join("|", orgIds));

            var organizationRoleClaims = organizationUsers.Select(o=>new Claim(ReportingModuleClaimTypes.OrganizationRole,
                    $"{o.Organization.Id}|{o.Role}")).ToArray();

            foreach (var claim in organizationRoleClaims)
                yield return claim;
        }
    }

    public static class SecurityTokenExtensions
    {
        public static bool ShouldRenew(this SessionSecurityToken token)
        {
            return ShouldRenew(token.ValidFrom, token.ValidTo);
        }

        public static bool ShouldRenew(DateTime validFrom, DateTime validTo)
        {
            var now = ZaphodTime.UtcNow;
            var midpointExpiration = validFrom.AddMinutes(TokenExpirationConfig.TokenExpirationMinutes / 2.0);
            return !HasExpired(now, validTo) && now > midpointExpiration;
        }

        public static bool HasExpired(DateTime now, DateTime validTo)
        {
            return now >= validTo;
        }

        public static SessionSecurityToken ToSecurityToken(this ClaimsPrincipal authedCp)
        {
            return FederatedAuthentication.SessionAuthenticationModule.CreateSessionSecurityToken(authedCp,
                "ReportingModule",
                ZaphodTime.UtcNow,
                ZaphodTime.UtcNow.AddMinutes(TokenExpirationConfig.TokenExpirationMinutes),
                false);
        }
    }

    public enum LoginAs
    {
        SystemAdmin,
        User
    }

    public static class TokenExpirationConfig
    {
        internal static int DefaultExpirationMinutes = 480;

        public static int TokenExpirationMinutes
        {
            get
            {
                int expiration;
                return int.TryParse(ConfigurationManager.AppSettings["TokenExpirationMinutes"], out expiration)
                    ? expiration
                    : DefaultExpirationMinutes;
            }
        }
    }
}