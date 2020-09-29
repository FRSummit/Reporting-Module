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
    public class UpdateStateReportGeneratedDataCommandHandlerIntegrationTests
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

        [TestCase(ReportingFrequency.Yearly, true)]
        [TestCase(ReportingFrequency.Yearly, false)]
        [TestCase(ReportingFrequency.Quarterly, true)]
        [TestCase(ReportingFrequency.Quarterly, false)]
        public async Task Handle_SavesReportWhenNoPreviousReportSubmitted(ReportingFrequency reportingFrequency, bool overrideReportData)
        {

            var now = DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();

                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new OrganizationBuilder()
                        .SetOrganizationType(OrganizationType.State)
                        .SetReportingFreQuency(reportingFrequency)
                        .BuildAndPersist(s);
                    var report = new StateReportBuilder()
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .Build();
                    report.MarkStatusAsPlanPromoted();
                    s.Save(report);

                    var generatedData = GetStateReportData();

                    report.UpdateGeneratedData(generatedData);
                    report.Update(generatedData);
                    s.Save(report);

                    EntityReference reportRef = report;
                    var expectedEvt = Test.CreateInstance<IStateReportUpdated>(e =>
                    {
                        e.Organization = organization;
                        e.Username = username;
                        e.StateReport = reportRef;
                    });

                    return new
                    {
                        Cmd = new UpdateStateReportGeneratedDataCommand(report.Id, overrideReportData),
                        Organization = organization,
                        Report = report,
                        zoneReportData = generatedData,
                        overrideReportData,
                        username,
                        expectedEvt

                    };
                });


            var context = await Endpoint.Act<UpdateStateReportGeneratedDataCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) =>
                    {
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<IStateReportUpdated>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Get<Report>(testParams.Cmd.ReportId);
                    report.Should().NotBeNull();
                    report.Description.Should().Be(testParams.Report.Description);
                    report.ReportingPeriod.Year.Should().Be(testParams.Report.ReportingPeriod.Year);
                    report.ReportingPeriod.ReportingFrequency.Should().Be(testParams.Organization.ReportingFrequency);
                    report.ReportingPeriod.ReportingTerm.Should().Be(testParams.Report.ReportingPeriod.ReportingTerm);
                    report.Organization.Should().Be(testParams.Report.Organization);
                    report.ReportStatus.Should().Be(ReportStatus.PlanPromoted);
                    report.Timestamp.Should().Be(now);
                    report.IsDeleted.Should().Be(false);

                    var stateReport = s.Get<StateReport>(testParams.Cmd.ReportId);
                    stateReport.Should().NotBeNull();
                    stateReport.Description.Should().Be(testParams.Report.Description);
                    stateReport.ReportingPeriod.Year.Should().Be(testParams.Report.ReportingPeriod.Year);
                    stateReport.ReportingPeriod.ReportingFrequency.Should()
                        .Be(testParams.Organization.ReportingFrequency);
                    stateReport.ReportingPeriod.ReportingTerm.Should()
                        .Be(testParams.Report.ReportingPeriod.ReportingTerm);
                    stateReport.Organization.Should().Be(testParams.Report.Organization);
                    //stateReport.AssociateMemberData.Should().Be(overrideReportData
                    //    ? MemberData.Default()
                    //    : testParams.zoneReportData.AssociateMemberData);
                    //stateReport.AssociateMemberGeneratedData.Should().Be(MemberData.Default());
                    //stateReport.PreliminaryMemberData.Should().Be(overrideReportData
                    //    ? MemberData.Default()
                    //    : testParams.zoneReportData.PreliminaryMemberData);
                    //stateReport.PreliminaryMemberGeneratedData.Should().Be(MemberData.Default());
                    //stateReport.WorkerMeetingProgramData.Should().Be(overrideReportData
                    //    ? MeetingProgramData.Default()
                    //    : testParams.zoneReportData.WorkerMeetingProgramData);
                    //stateReport.WorkerMeetingProgramGeneratedData.Should().Be(MeetingProgramData.Default());
                    stateReport.Timestamp.Should().Be(now);
                    stateReport.IsDeleted.Should().Be(false);

                    evt.Should().BeEquivalentTo(testParams.expectedEvt, e => e.Excluding(p => p.SerializedData));
                    evt.SerializedData.Should().NotBe(null);

                });
        }

        private static ReportData GetStateReportData()
        {
            var reportData = new ReportDataBuilder()
                .Build();
            return reportData;
        }
    }
}