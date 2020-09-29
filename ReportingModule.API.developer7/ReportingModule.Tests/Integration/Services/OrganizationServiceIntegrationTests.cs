using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using ReportingModule.Entities;
using ReportingModule.Services;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Integration.Helpers;

namespace ReportingModule.Tests.Integration.Services
{
    [TestFixture(Category = "Integration")]
    public class OrganizationServiceIntegrationTests
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
        public void GetManagedOrganizationsAsExpected()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations();
                    
                    var central = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.Central).Value; 
                    var nswState = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswState).Value; 
                    var victoriaState = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.VictoriaState).Value; 
                    var footscray = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.Footscray).Value; 
                    var truganinaNorth = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.TruganinaNorth).Value; 

                    return new
                    {
                        central,
                        victoriaState,
                        expectedCentralManagedOrganizations = new List<Organization> { victoriaState, nswState},
                        expectedVictoriaStateManagedOrganizations = new List<Organization> { footscray, truganinaNorth},
                    };
                });

            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
            c =>
            {
                var centralManagedOrganizations = c.GetInstance<IOrganizationService>().GetManagedOrganizations(testParams.central.Id);
                var victoriaStateManagedOrganizations = c.GetInstance<IOrganizationService>().GetManagedOrganizations(testParams.victoriaState.Id);
                return new
                {
                    centralManagedOrganizations,
                    victoriaStateManagedOrganizations

                };
            });

            result.centralManagedOrganizations.Should()
                .BeEquivalentTo(testParams.expectedCentralManagedOrganizations,
                    x => x.WithStrictOrderingFor(o => o));
            result.victoriaStateManagedOrganizations.Should().BeEquivalentTo(testParams.expectedVictoriaStateManagedOrganizations);
        }
    }
}
