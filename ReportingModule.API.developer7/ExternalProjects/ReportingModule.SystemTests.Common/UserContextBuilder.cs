using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using ReportingModule.Core.Security;
using ReportingModule.SystemTests.Common.TestData;

namespace ReportingModule.SystemTests.Common
{
    public class UserContextBuilder
    {
        private bool _isSystemAdmin;

        public UserContextBuilder AsSystemAdmin()
        {
            _isSystemAdmin = true;
            return this;
        }

        private readonly IList<Claim> _claims = new List<Claim>();

        public UserContextBuilder AddClaim(Claim claim)
        {
            _claims.Add(claim);
            return this;
        }
        public UserContextBuilder AddClaims(IEnumerable<Claim> claims)
        {
            claims.ToList().ForEach(o=> _claims.Add(o));
            return this;
        }

        public UserContextBuilder AddClaim(string type, string value)
        {
            _claims.Add(new Claim(type, value));
            return this;
        }

        private string _username = DataProvider.Get<string>();

        public UserContextBuilder SetUsername(string username)
        {
            _username = username;
            return this;
        }

        


        private IEnumerable<Claim> GetClaims()
        {
            if (_isSystemAdmin)
            {
                yield return new Claim(ReportingModuleClaimTypes.IsSystemAdmin, "true");
            }


            foreach (var claim in _claims)
            {
                yield return claim;
            }

            if (_username != null)
            {
                yield return new Claim(ReportingModuleClaimTypes.Username, _username);
                yield return new Claim(ClaimTypes.GivenName, _username);
                yield return new Claim(ClaimTypes.Surname, _username);
                yield return new Claim(ClaimTypes.Email, _username);
            }
        }
        
        private ClaimsPrincipal Build()
        {
            var id = new ClaimsIdentity(new GenericIdentity(_username),
                GetClaims(),
                "Forms",
                string.Empty,
                string.Empty);

            return new ClaimsPrincipal(id);
        }

        public ClaimsPrincipal SetCurrentPrincipal()
        {
            var principal = Build();
            Thread.CurrentPrincipal = principal;
            return principal;
        }
    }
}