using System.Linq;
using FluentAssertions;
using NsbWeb.ReportingModule.QueryServices;
using NsbWeb.ReportingModule.QueryServices.Impl;
using NUnit.Framework;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.Tests.Integration.CommandHandlers;
using ReportingModule.Tests.Integration.Helpers;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.WebApi
{
    [TestFixture(Category = "Integration")]
    public class OrganizationUserQueryServiceIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                //DomainDatabase.ClearAllTables(s);

                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [Test]
        public void SearchOrganizationUser_Should_Return_Result()
        {
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    EntityReference organization1 = new OrganizationBuilder().BuildAndPersist(s);
                    EntityReference organization2 = new OrganizationBuilder().BuildAndPersist(s);

                    var organizationUser1 = new TestObjectBuilder<OrganizationUser>()
                        .SetArgument(o=>o.Username,username)
                        .SetArgument(o=>o.Organization,organization1)
                        .BuildAndPersist(s);

                    new TestObjectBuilder<OrganizationUser>()
                        .SetArgument(o=>o.Username,username)
                        .SetArgument(o=>o.Organization,organization2)
                        .BuildAndPersist(s);

                    new UserContextBuilder()
                        .SetUsername(username)
                        .AddClaims(TestHelper.GetOrganizationClaims(username, new []{organizationUser1}))
                        .SetCurrentPrincipal();

                    return new {organizationUser1};
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<IOrganizationUserQueryService>()
                    .SearchOrganizationUser(new OrganizationUserSearchTerms()));

            result.Should().NotBeNull();
            result.Items.Length.Should().Be(1);
            result.Items[0].Role.Should().Be(testParams.organizationUser1.Role);
            result.Items[0].Organization.Should().Be(testParams.organizationUser1.Organization);
        }


        [Theory]
        public void Has_Central_Should_Return_CorrectResult(bool isCentralUser)
        {
            var username = DataProvider.Get<string>();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingFrequency = ReportingFrequency.Monthly;

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);
                    var central = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.Central).Value;
                    var nsw = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswState).Value;
                    
                    var organizationUser1 = new TestObjectBuilder<OrganizationUser>()
                        .SetArgument(o => o.Username, username)
                        .SetArgument(o => o.Organization, isCentralUser?central: nsw)
                        .BuildAndPersist(s);

                
                    new UserContextBuilder()
                        .SetUsername(username)
                        .AddClaims(TestHelper.GetOrganizationClaims(username, new[] { organizationUser1 }))
                        .SetCurrentPrincipal();

                    return new { organizationUser1 };

                    
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<OrganizationUserQueryService>()
                    .HasCentralAccess(testParams.organizationUser1.Username));

            result.Should().Be(isCentralUser);
        }
    }
}