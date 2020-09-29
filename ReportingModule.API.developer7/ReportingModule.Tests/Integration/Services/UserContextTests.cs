using System.Security.Claims;
using FluentAssertions;
using NsbWeb.Core;
using NUnit.Framework;
using ReportingModule.Core.Security;
using ReportingModule.SystemTests.Common;
using ReportingModule.SystemTests.Nsb7.Configuration;

namespace ReportingModule.Tests.Integration.Services
{
    [TestFixture(Category = "Integration")]
    public class UserContextTests
    {
        [Theory]
        public void CurrentUserIsSystemUser_IsBasedOnReportingModuleClaim(bool hasClaim)
        {
            var builder = new UserContextBuilder();
            
            if (hasClaim)
                builder.AddClaim(new Claim(ReportingModuleClaimTypes.IsSystemUser, "true"));

            builder.SetCurrentPrincipal();

            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c => c.GetInstance<UserContext>().CurrentUserIsSystemUser());

            result.Should().Be(hasClaim);
        }

        [Theory]
        public void CurrentUserIsSystemAdmin_IsBasedOnReportingModuleClaim(bool hasClaim)
        {
            var builder = new UserContextBuilder();

            if (hasClaim)
                builder.AddClaim(new Claim(ReportingModuleClaimTypes.IsSystemAdmin, "true"));

            builder.SetCurrentPrincipal();

            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c => c.GetInstance<UserContext>().CurrentUserIsSystemAdmin());

            result.Should().Be(hasClaim);
        }

        [Theory]
        public void CurrentUserCanAccessAllOrganizations_IsBasedOnReportingModuleClaim(bool hasClaim)
        {
            var builder = new UserContextBuilder();

            if (hasClaim)
                builder.AddClaim(new Claim(ReportingModuleClaimTypes.AccessAllOrganizations, "true"));

            builder.SetCurrentPrincipal();

            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c => c.GetInstance<UserContext>().CurrentUserCanAccessAllOrganizations());

            result.Should().Be(hasClaim);
        }

        [Theory]
        public void CurrentUserCanAccess_IsBasedOnReportingModuleClaim(bool hasAccessAllOrganizationsClaim, bool hasIsSystemAdminClaim)
        {
            var builder = new UserContextBuilder();

            if (hasAccessAllOrganizationsClaim)
                builder.AddClaim(new Claim(ReportingModuleClaimTypes.AccessAllOrganizations, "true"));
            if (hasIsSystemAdminClaim)
                builder.AddClaim(new Claim(ReportingModuleClaimTypes.IsSystemAdmin, "true"));

            builder.SetCurrentPrincipal();

            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c => c.GetInstance<UserContext>().CurrentUserCanAccess(0));

            result.Should().Be(hasAccessAllOrganizationsClaim || hasIsSystemAdminClaim);
        }


    }
}
