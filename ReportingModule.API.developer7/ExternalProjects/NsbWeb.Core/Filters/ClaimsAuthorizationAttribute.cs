﻿using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace NsbWeb.Core.Filters
{
    public class ClaimsAuthorizationAttribute : AuthorizationFilterAttribute
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;
            if (principal == null || !principal.Identity.IsAuthenticated
                || !principal.HasClaim(x => x.Type == ClaimType && (ClaimValue == null || x.Value == ClaimValue)))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            return Task.FromResult<object>(null);
        }
    }
}