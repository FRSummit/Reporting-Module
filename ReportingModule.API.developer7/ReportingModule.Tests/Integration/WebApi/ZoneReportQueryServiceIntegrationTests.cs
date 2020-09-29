using FluentAssertions;
using NsbWeb.ReportingModule.QueryServices;
using NUnit.Framework;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.Tests.Integration.CommandHandlers;

namespace ReportingModule.Tests.Integration.WebApi
{
    [TestFixture(Category = "Integration")]
    public class ZoneReportQueryServiceIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                DomainDatabase.ClearAllReportingModuleTables(s);
            });


        }

        [Test]
        public void GetZoneReportViewModel_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var stateReport = new ZoneReportBuilder()
                        .Build();
                    stateReport.MarkStatusAsSubmitted();
                    s.Save(stateReport);

                    var submittedZoneReportViewModel = TestHelper.ConvertToZoneReportViewModel(stateReport);

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);
                    return submittedZoneReportViewModel;
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<IZoneReportQueryService>()
                    .GetZoneReportViewModel(testParams.Id));

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(testParams);
        }

        [Test]
        public void GetZonePlanViewModel_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var stateReport = new ZoneReportBuilder()
                        .BuildAndPersist(s);
                    var stateReportViewModel = TestHelper.ConvertToZonePlanViewModel(stateReport);

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);
                    return stateReportViewModel;
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<IZoneReportQueryService>()
                    .GetZonePlanViewModel(testParams.Id));

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(testParams);
        }
    }
}