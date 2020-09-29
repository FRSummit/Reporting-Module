using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace NsbWeb.Core.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CorsPolicyAttribute : Attribute, ICorsPolicyProvider
    {
        private readonly CorsPolicy _policy;

        public CorsPolicyAttribute(string corsPolicyName)
        {
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            var allowedSites = ConfigurationManager.AppSettings[corsPolicyName];
            if (string.IsNullOrWhiteSpace(allowedSites)) throw new ConfigurationErrorsException($"AppSetting {corsPolicyName} is not configured.");

            var urls = allowedSites.Split(',');
            if (!urls.Any()) throw new ConfigurationErrorsException($"AppSetting {corsPolicyName} does not specify any urls.");

            foreach (var url in urls)
            {
                _policy.Origins.Add(url);
            }

            _policy.SupportsCredentials = true;
            _policy.AllowAnyHeader = true;
            _policy.AllowAnyMethod = true;
            _policy.PreflightMaxAge = 86400;
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}
