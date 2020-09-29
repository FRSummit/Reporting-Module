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
    public class DeleteReportCommandHandlerIntegrationTests
    {
        [TestCase(OrganizationType.Unit, ReportingFrequency.Monthly)]
        [TestCase(OrganizationType.Zone, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.Zone, ReportingFrequency.Yearly)]
        [TestCase(OrganizationType.State, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.State, ReportingFrequency.Yearly)]
        [TestCase(OrganizationType.Central, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.Central, ReportingFrequency.Yearly)]
        public async Task Handle_DeletesReport(OrganizationType organizationType, ReportingFrequency reportingFrequency)
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
                        .BuildAndPersist(s);

                    EntityReference reportRef = report;
                    var expectedEvt = Test.CreateInstance<IReportDeleted>(e =>
                    {
                        e.Organization = organization;
                        e.Username = username;
                        e.Report = reportRef;
                    });

                    return new
                    {
                        Cmd = new DeleteReportCommand(report.Id),
                        username,
                        expectedEvt
                    };
                });

            var context = await Endpoint.Act<DeleteReportCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<IReportDeleted>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Get<Report>(testParams.Cmd.ReportId);
                    report.Should().BeNull();

                    evt.Should().BeEquivalentTo(testParams.expectedEvt, e => e.Excluding(p => p.SerializedData));
                    evt.SerializedData.Should().NotBe(null);
                });
        }

    }
}