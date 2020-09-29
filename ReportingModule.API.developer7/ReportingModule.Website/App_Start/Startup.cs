using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Cors;
using System.Web.Http;
using Auth0.Owin;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Jwt;
using NsbWeb.Core.SignalR;
using NsbWeb.ReportingModule.QueryServices;
using NsbWeb.ReportingModule.SignalR;
using Owin;
using ReportingModule.Website;
using AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode;

[assembly: OwinStartup(typeof(Startup))]

namespace ReportingModule.Website
{
    public class Startup
    {
        private const string OidcAuth0DomainConfig = "OidcAuth0Domain";
        private const string OidcAuth0Audience = "OidcAuth0Audience";
        private const string Auth0CorsOriginsConfig = "CommaSeparatedAuth0CorsOrigins";

        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseJwtBearerAuthentication(JwtBearerAuthenticationOptionsOidc.Value);
            ConfigureCors(appBuilder);

            appBuilder.ConfigureSignalR(ExternalAssembliesContainingHubs,
                false);

            ConfigureWebApi(appBuilder);

            appBuilder.ConfigureStaticFiles();
        }

        private static void ConfigureWebApi(IAppBuilder appBuilder)
        {
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }

        private static readonly Assembly[] ExternalAssembliesContainingHubs =
        {
            typeof(ReportingModuleHub).Assembly
        };
        
        private static readonly Lazy<JwtBearerAuthenticationOptions> JwtBearerAuthenticationOptionsOidc = new Lazy<JwtBearerAuthenticationOptions>(() =>
        {
            var organizationUserQueryService = Ioc.Container.GetInstance<IOrganizationUserQueryService>();
            var organizationQueryService = Ioc.Container.GetInstance<IOrganizationQueryService>();
            var issuer = "https://" + WebConfigurationManager.AppSettings[OidcAuth0DomainConfig] + "/";
            var audience = WebConfigurationManager.AppSettings[OidcAuth0Audience];

            var keyResolver = new OpenIdConnectSigningKeyResolver(issuer);
            return new JwtBearerAuthenticationOptions
            {
                TokenHandler = new ReportingModuleJwtSecurityTokenHandler(organizationUserQueryService, organizationQueryService),
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKeyResolver = (token, securityToken, identifier, parameters) => keyResolver.GetSigningKey(identifier),
                    ValidAudience = audience,
                    ValidIssuer = issuer
                }
            };
        });

        private static void ConfigureCors(IAppBuilder app)
        {
            var origins = GetOriginsFromWebCofig(WebConfigurationManager.AppSettings[Auth0CorsOriginsConfig]);
            var corsPolicy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            foreach (var origin in origins)
            {
                corsPolicy.Origins.Add(origin);
            }

            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            };

            app.UseCors(corsOptions);
        }

        internal static IEnumerable<string> GetOriginsFromWebCofig(string commaSeparatedOrigins)
        {
            if (string.IsNullOrWhiteSpace(commaSeparatedOrigins)) return new string[0];

            var origins = commaSeparatedOrigins.Split(',');

            return origins.Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();
        }
    }
}