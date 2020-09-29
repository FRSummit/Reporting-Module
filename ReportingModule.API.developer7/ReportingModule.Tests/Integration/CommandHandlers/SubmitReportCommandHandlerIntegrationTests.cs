using System.Threading.Tasks;
using FluentAssertions;
using NServiceBus.Testing;
using NUnit.Framework;
using ReportingModule.CommandHandlers;
using ReportingModule.Commands;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.Events;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.ValueObjects;


namespace ReportingModule.Tests.Integration.CommandHandlers
{
    [TestFixture(Category = "Integration")]
    public class SubmitReportCommandHandlerIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [TestCase(OrganizationType.Unit, ReportingFrequency.Monthly)]
        [TestCase(OrganizationType.Zone, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.Zone, ReportingFrequency.Yearly)]
        [TestCase(OrganizationType.State, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.State, ReportingFrequency.Yearly)]
        [TestCase(OrganizationType.Central, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.Central, ReportingFrequency.Yearly)]
        public async Task Handle_SavesReport(OrganizationType organizationType, ReportingFrequency reportingFrequency)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new OrganizationBuilder()
                        .SetOrganizationType(organizationType)
                        .SetReportingFreQuency(reportingFrequency)
                        .BuildAndPersist(s);

                    Report report = new ReportBuilder()
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .Build();
                    report.MarkStatusAsPlanPromoted();
                    s.Save(report);

                    EntityReference reportRef = report;
                    var expectedEvt = Test.CreateInstance<IReportSubmitted>(e =>
                    {
                        e.Organization = organization;
                        e.Username = username;
                        e.Report = reportRef;
                    });

                    return new
                    {
                        Cmd = new SubmitReportCommand(report.Id),
                        Organization = organization,
                        Report = report,
                        username,
                        expectedEvt
                    };
                });

            var context = await Endpoint.Act<SubmitReportCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<IReportSubmitted>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Get<Report>(testParams.Cmd.ReportId);
                    report.Should().NotBeNull();
                    report.Should().BeEquivalentTo(testParams.Report, e => e.Excluding(p => p.ReportStatus));
                    report.ReportStatus.Should().Be(ReportStatus.Submitted);

                    evt.Should().BeEquivalentTo(testParams.expectedEvt, e => e.Excluding(p => p.SerializedData));
                    evt.SerializedData.Should().NotBe(null);
                });
        }
    }
}