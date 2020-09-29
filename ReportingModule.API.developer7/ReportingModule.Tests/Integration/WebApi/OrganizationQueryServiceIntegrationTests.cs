using System.Linq;
using FluentAssertions;
using NsbWeb.ReportingModule.QueryServices.Impl;
using NUnit.Framework;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Integration.CommandHandlers;
using ReportingModule.Tests.Integration.Helpers;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.WebApi
{
    [TestFixture(Category = "Integration")]
    public class OrganizationQueryServiceIntegrationTests
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
        public void GetOrganizationViewModel_For_Central_Should_Return_CorrectResult()
        {
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingFrequency = ReportingFrequency.Monthly;

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);
                    var central = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.Central).Value;

                    return new
                    {
                        organizations,
                        central
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<OrganizationQueryService>()
                    .GetOrganizationViewModel(testParams.central.Id));

            result.Should().NotBeNull();
            result.ManagedOrganizations.Count().Should().Be(7);
        }
        [Test]
        public void GetManagedOrganizationViewModel_For_State_Should_Return_CorrectResult()
        {
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingFrequency = ReportingFrequency.Monthly;

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);
                    var state = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswState).Value;

                    return new
                    {
                        organizations,
                        state
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<OrganizationQueryService>()
                    .GetOrganizationViewModel(testParams.state.Id));

            result.Should().NotBeNull();
            result.ManagedOrganizations.Count().Should().Be(3);
        }

        [Test]
        public void GetManagedOrganizationViewModel_For_Zone_Should_Return_CorrectResult()
        {
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingFrequency = ReportingFrequency.Monthly;

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);
                    var zone = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswZoneOne).Value;

                    return new
                    {
                        organizations,
                        zone
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<OrganizationQueryService>()
                    .GetOrganizationViewModel(testParams.zone.Id));

            result.Should().NotBeNull();
            result.ManagedOrganizations.Count().Should().Be(2);
        }

        [Test]
        public void GetManagedOrganizationIds_For_Central_Should_Return_CorrectResult()
        {
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingFrequency = ReportingFrequency.Monthly;

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);
                    var central = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.Central).Value;

                    return new
                    {
                        organizations,
                        central
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<OrganizationQueryService>()
                    .GetManagedOrganizationIds(testParams.central.Id));

            result.Should().NotBeNull();
            result.Length.Should().Be(7);
        }

        [Test]
        public void GetManagedOrganizationIds_For_State_Should_Return_CorrectResult()
        {
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingFrequency = ReportingFrequency.Monthly;

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);
                    var state = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswState).Value;

                    return new
                    {
                        organizations,
                        state
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<OrganizationQueryService>()
                    .GetManagedOrganizationIds(testParams.state.Id));

            result.Should().NotBeNull();
            result.Length.Should().Be(3);
        }

        [Test]
        public void GetManagedOrganizationIds_For_Zone_Should_Return_CorrectResult()
        {
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingFrequency = ReportingFrequency.Monthly;

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);
                    var zone = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswZoneOne).Value;

                    return new
                    {
                        organizations,
                        zone
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<OrganizationQueryService>()
                    .GetManagedOrganizationIds(testParams.zone.Id));

            result.Should().NotBeNull();
            result.Length.Should().Be(2);
        }

        [Test]
        public void GetMyOrganizations_For_SystemAdmin_Should_Return_CorrectResult()
        {
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingFrequency = ReportingFrequency.Monthly;

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);

                    TestHelper.SetUserAccessAsSystemAdmin(username);

                    return new
                    {
                        organizations,
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<OrganizationQueryService>()
                    .GetMyOrganizations());

            result.Should().NotBeNull();
            result.Length.Should().Be(testParams.organizations.Count);
        }

        [Test]
        public void GetMyOrganizations_For_CentralUser_Should_Return_CorrectResult()
        {
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingFrequency = ReportingFrequency.Monthly;

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new
                    {
                        organizations,
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<OrganizationQueryService>()
                    .GetMyOrganizations());

            result.Should().NotBeNull();
            result.Length.Should().Be(testParams.organizations.Count);
        }

        [TestCase(OrganizationType.State)]
        [TestCase(OrganizationType.Unit)]
        public void GetMyOrganizations_For_User_Should_Return_CorrectResult(OrganizationType organizationType)
        {
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingFrequency = ReportingFrequency.Monthly;

                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations(
                        stateReportingFrequency: reportingFrequency,
                        zoneReportingFrequency: ReportingFrequency.Monthly);

                    var state = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswState).Value;
                    var unit = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.Footscray).Value;



                    var organizationUser1 = new TestObjectBuilder<OrganizationUser>()
                        .SetArgument(o => o.Username, username)
                        .SetArgument(o => o.Organization, organizationType == OrganizationType.State? state : unit)
                        .BuildAndPersist(s);

                    new UserContextBuilder()
                        .SetUsername(username)
                        .AddClaims(TestHelper.GetOrganizationClaims(username, new[] { organizationUser1 }))
                        .SetCurrentPrincipal();
                    return new
                    {
                        state,
                        unit
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<OrganizationQueryService>()
                    .GetMyOrganizations());

            var organizationId = organizationType == OrganizationType.State ? testParams.state.Id : testParams.unit.Id;
            result.Should().NotBeNull();
            result.Where(o=>o.Id == organizationId).Should().NotBeNull();
        }

        [TestCase(OrganizationType.State)]
        [TestCase(OrganizationType.Zone)]
        [TestCase(OrganizationType.Central)]
        [TestCase(OrganizationType.Unit)]
        public void GetReportingPeriodsToCreatePlan_For_User_Should_Return_CorrectResult( OrganizationType organizationType)
        {
            DateTimeDbTestExtensions.SetLocalNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations();

                    var central = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.Central).Value;
                    var state = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswState).Value;
                    var zone = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswZoneOne).Value;
                    var unit = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.Footscray).Value;

                    EntityReference sut = null;
                    switch (organizationType)
                    {
                        case OrganizationType.Central:
                            sut = central;
                            break;
                        case OrganizationType.State:
                            sut = state;
                            break;
                        case OrganizationType.Zone:
                            sut = zone;
                            break;
                        default:
                            sut = unit;
                            break;
                    }

                    var organizationUser1 = new TestObjectBuilder<OrganizationUser>()
                        .SetArgument(o => o.Username, username)
                        .SetArgument(o => o.Organization, sut)
                        .BuildAndPersist(s);

                    new UserContextBuilder()
                        .SetUsername(username)
                        .AddClaims(TestHelper.GetOrganizationClaims(username, new[] { organizationUser1 }))
                        .SetCurrentPrincipal();


                    return new
                    {
                        sut
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c =>
                {
                    return c.GetInstance<OrganizationQueryService>()
                        .GetReportingPeriods(testParams.sut.Id);
                });

            if (organizationType == OrganizationType.Unit)
            {
                result.Length.Should().Be(36);
                var activeReportPeriod = result.Single(o => o.IsActive);
                activeReportPeriod.Should().NotBeNull();
            }
            else
            {
                result.Length.Should().Be(20);
                var activeAnnualReportPeriod = result.Single(o => o.IsActive && o.ReportingFrequency == ReportingFrequency.Yearly);
                activeAnnualReportPeriod.Should().NotBeNull();

                var activeQuarterlyReportPeriod = result.Single(o => o.IsActive && o.ReportingFrequency == ReportingFrequency.Quarterly);
                activeQuarterlyReportPeriod.Should().NotBeNull();
            }

          
        }
    }
}