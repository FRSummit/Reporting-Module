using FluentAssertions;
using NsbWeb.ReportingModule.QueryServices;
using NUnit.Framework;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.Tests.Integration.CommandHandlers;

namespace ReportingModule.Tests.Integration.WebApi
{
    [TestFixture(Category = "Integration")]
    public class ReportEventLogQueryServiceIntegrationTests
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
        public void SearchReportEventLog_Should_Return_Result()
        {
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    EntityReference organization1 = new OrganizationBuilder().BuildAndPersist(s);
                    EntityReference organization2 = new OrganizationBuilder().BuildAndPersist(s);

                    var organizationUser1 = new TestObjectBuilder<OrganizationUser>()
                        .SetArgument(o => o.Username, username)
                        .SetArgument(o => o.Organization, organization1)
                        .BuildAndPersist(s);

                    var reportEventLog = new TestObjectBuilder<ReportEventLog>()
                        .SetArgument(o=>o.CreatedByUsername,username)
                        .SetArgument(o=>o.OrganizationId,organization1.Id)
                        .BuildAndPersist(s);

                    new TestObjectBuilder<ReportEventLog>()
                        .SetArgument(o=>o.CreatedByUsername,username)
                        .SetArgument(o=>o.OrganizationId,organization2.Id)
                        .BuildAndPersist(s);

                    new UserContextBuilder()
                        .SetUsername(username)
                        .AddClaims(TestHelper.GetOrganizationClaims(username, new []{organizationUser1}))
                        .SetCurrentPrincipal();

                    return new {reportEventLog, organizationUser1};
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<IReportEventLogQueryService>()
                    .SearchReportEventLog(new ReportEventLogSearchTerms()));

            result.Should().NotBeNull();
            result.Items.Length.Should().Be(1);
            result.Items[0].CreatedByUsername.Should().Be(testParams.organizationUser1.Username);
            result.Items[0].OrganizationId.Should().Be(testParams.organizationUser1.Organization.Id);
        }

        [Test]
        public void SearchReportEventLog_Should_Return_NoResult_ForOrganizationId_Null()
        {
            var username1 = DataProvider.Get<string>();
            var username2 = DataProvider.Get<string>();
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    EntityReference organization1 = new OrganizationBuilder().BuildAndPersist(s);
                    EntityReference organization2 = new OrganizationBuilder().BuildAndPersist(s);

                    var organizationUser1 = new TestObjectBuilder<OrganizationUser>()
                        .SetArgument(o => o.Username, username1)
                        .SetArgument(o => o.Organization, organization1)
                        .BuildAndPersist(s);

                    new TestObjectBuilder<ReportEventLog>()
                        .SetArgument(o => o.CreatedByUsername, username1)
                        .SetArgument(o => o.OrganizationId, null)
                        .BuildAndPersist(s);

                    new TestObjectBuilder<ReportEventLog>()
                        .SetArgument(o => o.CreatedByUsername, username1)
                        .SetArgument(o => o.OrganizationId, organization2.Id)
                        .BuildAndPersist(s);

                    new TestObjectBuilder<ReportEventLog>()
                        .SetArgument(o => o.CreatedByUsername, username2)
                        .SetArgument(o => o.OrganizationId, organization2.Id)
                        .BuildAndPersist(s);

                    new UserContextBuilder()
                        .SetUsername(username1)
                        .AddClaims(TestHelper.GetOrganizationClaims(username1, new[] { organizationUser1 }))
                        .SetCurrentPrincipal();

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<IReportEventLogQueryService>()
                    .SearchReportEventLog(new ReportEventLogSearchTerms()));

            result.Should().NotBeNull();
            result.Items.Length.Should().Be(0);
        }

        [Test]
        public void SearchReportEventLog_Should_Return_NoResult_For_No_OrganizationClaims_Assigned_To_User()
        {
            var username1 = DataProvider.Get<string>();
            var username2 = DataProvider.Get<string>();
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    EntityReference organization1 = new OrganizationBuilder().BuildAndPersist(s);
                    EntityReference organization2 = new OrganizationBuilder().BuildAndPersist(s);

                    new TestObjectBuilder<OrganizationUser>()
                        .SetArgument(o => o.Username, username1)
                        .SetArgument(o => o.Organization, organization1)
                        .BuildAndPersist(s);

                    new TestObjectBuilder<ReportEventLog>()
                        .SetArgument(o => o.CreatedByUsername, username1)
                        .SetArgument(o => o.OrganizationId, null)
                        .BuildAndPersist(s);

                    new TestObjectBuilder<ReportEventLog>()
                        .SetArgument(o => o.CreatedByUsername, username1)
                        .SetArgument(o => o.OrganizationId, organization1.Id)
                        .BuildAndPersist(s);

                    new TestObjectBuilder<ReportEventLog>()
                        .SetArgument(o => o.CreatedByUsername, username1)
                        .SetArgument(o => o.OrganizationId, organization2.Id)
                        .BuildAndPersist(s);

                    new TestObjectBuilder<ReportEventLog>()
                        .SetArgument(o => o.CreatedByUsername, username2)
                        .SetArgument(o => o.OrganizationId, organization2.Id)
                        .BuildAndPersist(s);

                    new UserContextBuilder()
                        .SetUsername(username1)
                        .AddClaims(TestHelper.GetOrganizationClaims(username1, new OrganizationUser[0]))
                        .SetCurrentPrincipal();

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<IReportEventLogQueryService>()
                    .SearchReportEventLog(new ReportEventLogSearchTerms()));

            result.Should().NotBeNull();
            result.Items.Length.Should().Be(0);
        }
    }
}