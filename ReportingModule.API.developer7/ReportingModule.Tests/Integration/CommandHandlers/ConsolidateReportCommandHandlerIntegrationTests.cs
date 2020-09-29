using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using ReportingModule.CommandHandlers;
using ReportingModule.Commands;
using ReportingModule.Entities;
using ReportingModule.Events;
using ReportingModule.Services.Impl;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.Tests.Integration.Helpers;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.CommandHandlers
{
    [TestFixture(Category = "Integration")]
    public class ConsolidateReportCommandHandlerIntegrationTests
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
        public async Task Handle_Publishes_ExpectedResult()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var organizations = IntegrationTestOrganizationHelper.SetupOrzanizations();
                    var central = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.Central).Value;
                    var nswState = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswState).Value;
                    var nswZone1 = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.NswZoneOne).Value;
                    var lakemba = organizations.First(o => o.Key == IntegrationTestOrganizationHelper.Lakemba).Value;

                    var year1 = 2019;
                    var year2 = 2020;

                    var period1 = new ReportingPeriod(ReportingFrequency.Monthly, ReportingTerm.One, year1);
                    var period2 = new ReportingPeriod(ReportingFrequency.Monthly, ReportingTerm.One, year2);

                    var period1ReportingData = new ReportDataBuilder().Build();
                    var period2ReportingData = new ReportDataBuilder().Build();

                    var period1UnitReport =
                        new UnitReport(DataProvider.Get<string>(), lakemba, period1, period1ReportingData);
                    s.Save(period1UnitReport);
                    var period2UnitReport =
                        new UnitReport(DataProvider.Get<string>(), lakemba, period2, period2ReportingData);
                    s.Save(period2UnitReport);

                    var period1ZoneReport =
                        new ZoneReport(DataProvider.Get<string>(), nswZone1, period1, period1ReportingData);
                    s.Save(period1ZoneReport);
                    var period2ZoneReport =
                        new ZoneReport(DataProvider.Get<string>(), nswZone1, period2, period2ReportingData);
                    s.Save(period2ZoneReport);

                    var period1StateReport =
                        new StateReport(DataProvider.Get<string>(), nswState, period1, period1ReportingData);
                    s.Save(period1StateReport);
                    var period2StateReport =
                        new StateReport(DataProvider.Get<string>(), nswState, period2, period2ReportingData);
                    s.Save(period2StateReport);

                    var period1CentralReport =
                        new CentralReport(DataProvider.Get<string>(), central, period1, period1ReportingData);
                    s.Save(period1CentralReport);
                    var period2CentralReport =
                        new CentralReport(DataProvider.Get<string>(), central, period2, period2ReportingData);
                    s.Save(period2CentralReport);

                    var reportIds = new[]
                    {
                    period1UnitReport.Id, period2UnitReport.Id, period1ZoneReport.Id, period2ZoneReport.Id,
                    period1StateReport.Id, period2StateReport.Id, period1CentralReport.Id, period2CentralReport.Id,
                };
                    var expectedReportData = ReportDataCalculator.GetCalculatedReportData(new[] { period2UnitReport },
                        new[] { period1UnitReport, period2UnitReport }, new[] { period2ZoneReport },
                        new[] { period1ZoneReport, period2ZoneReport }, new[] { period2StateReport },
                        new[] { period1StateReport, period2StateReport }, new[] { period2CentralReport },
                        new[] { period1CentralReport, period2CentralReport });

                    return new
                    {
                        username,
                        expectedReportData,
                        cmd = new ConsolidateReportCommand(reportIds),
                    };

                });

            var context = await Endpoint.Act<ConsolidateReportCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.cmd, ctx);
                    });
            var evt = context.ExpectPublish<IConsolidateReportSucceeded>();

            evt.ReportIds.Should().BeEquivalentTo(testParams.cmd.ReportIds);
            evt.ReportData.Should().BeEquivalentTo(testParams.expectedReportData);
            evt.Username.Should().BeEquivalentTo(testParams.username);
        }

        [Test]
        public async Task Handle_PublishesError_When_No_ReportIds()
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = new
            {
                username = DataProvider.Get<string>(),
                Cmd = new ConsolidateReportCommand(new int[0]),
                Error = $"Unable to consolidate. Invalid ReportIds"
            };

            var context = await Endpoint.Act<ConsolidateReportCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<IConsolidateReportFailed>();

            evt.Errors[0].Should().Contain(testParams.Error);
        }
        [Test]
        public async Task Handle_PublishesError_When_OnlyOne_ReportIds()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = new
            {
                username = DataProvider.Get<string>(),
                Cmd = new ConsolidateReportCommand(new[] { 1 }),
                Error = $"Nothing to consolidate. Only one report found"
            };
            
            var context = await Endpoint.Act<ConsolidateReportCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<IConsolidateReportFailed>();

            evt.Errors[0].Should().Contain(testParams.Error);
        }
    }
}