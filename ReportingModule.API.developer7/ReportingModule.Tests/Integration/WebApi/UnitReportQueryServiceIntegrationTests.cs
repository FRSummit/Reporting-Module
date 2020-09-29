using FluentAssertions;
using NsbWeb.ReportingModule.QueryServices;
using NsbWeb.ReportingModule.QueryServices.Impl;
using NUnit.Framework;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.Tests.Integration.CommandHandlers;
// ReSharper disable CoVariantArrayConversion

namespace ReportingModule.Tests.Integration.WebApi
{
    [TestFixture(Category = "Integration")]
    public class UnitReportQueryServiceIntegrationTests
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
        public void GetUnitReportViewModel_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var unitReport = new UnitReportBuilder()
                        .Build();
                    unitReport.MarkStatusAsSubmitted();
                    s.Save(unitReport);

                    var submittedUnitReportViewModel = TestHelper.ConvertToUnitReportViewModel(unitReport);

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);
                    return submittedUnitReportViewModel;
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<UnitReportQueryService>()
                    .GetUnitReportViewModel(testParams.Id));

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(testParams);
        }
      
        [Test]
        public void GetUnitPlanViewModel_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var unitReport = new UnitReportBuilder()
                        .BuildAndPersist(s);
                    var unitReportViewModel = TestHelper.ConvertToUnitPlanViewModel(unitReport);

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return unitReportViewModel;
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<IUnitReportQueryService>()
                    .GetUnitPlanViewModel(testParams.Id));

            result.Should().NotBeNull();
            //-- after finding the issue it will be removed
            result.BookLibraryStockPlanData = ValueObjects.LibraryStockData.Default();
            result.VhsLibraryStockPlanData = ValueObjects.LibraryStockData.Default();
            result.OtherLibraryStockPlanData = ValueObjects.LibraryStockData.Default();
            //---------
            result.Should().BeEquivalentTo(testParams);
        }
    }
}
