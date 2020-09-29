using FluentAssertions;
using NsbWeb.ReportingModule.QueryServices;
using NUnit.Framework;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.Tests.Integration.CommandHandlers;
// ReSharper disable CoVariantArrayConversion

namespace ReportingModule.Tests.Integration.WebApi
{
    public class CentralReportQueryServiceIntegrationTests
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
        public void GetCentralReportViewModel_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var centralReport = new CentralReportBuilder()
                        .Build();
                    centralReport.MarkStatusAsSubmitted();
                    s.Save(centralReport);

                    var submittedCentralReportViewModel = TestHelper.ConvertToCentralReportViewModel(centralReport);

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);
                    return submittedCentralReportViewModel;
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<ICentralReportQueryService>()
                    .GetCentralReportViewModel(testParams.Id));

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(testParams);
        }

        [Test]
        public void GetCentralPlanViewModel_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var centralReport = new CentralReportBuilder()
                        .BuildAndPersist(s);
                    var centralPlanViewModel = TestHelper.ConvertToCentralPlanViewModel(centralReport);

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);
                    return centralPlanViewModel;
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<ICentralReportQueryService>()
                    .GetCentralPlanViewModel(testParams.Id));

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(testParams);
        }
    }
}