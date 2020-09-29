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
    [TestFixture(Category = "Integration")]
    public class StateReportQueryServiceIntegrationTests
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
        public void GetStateReportViewModel_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var stateReport = new StateReportBuilder()
                        .Build();
                    stateReport.MarkStatusAsSubmitted();
                    s.Save(stateReport);

                    var submittedStateReportViewModel = TestHelper.ConvertToStateReportViewModel(stateReport);

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);
                    return submittedStateReportViewModel;
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<IStateReportQueryService>()
                    .GetStateReportViewModel(testParams.Id));

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(testParams);
        }

        [Test]
        public void GetStatePlanViewModel_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var stateReport = new StateReportBuilder()
                        .BuildAndPersist(s);
                    var stateReportViewModel = TestHelper.ConvertToStatePlanViewModel(stateReport);

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);
                    return stateReportViewModel;
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<IStateReportQueryService>()
                    .GetStatePlanViewModel(testParams.Id));

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(testParams);
        }
    }
}