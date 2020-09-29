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
    public class UpdateCentralReportGeneratedDataCommandHandlerIntegrationTests
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
                        .SetOrganizationType(OrganizationType.Central)
                        .SetReportingFreQuency(reportingFrequency)
                        .BuildAndPersist(s);
                    var report = new CentralReportBuilder()
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .Build();
                    report.MarkStatusAsPlanPromoted();
                    s.Save(report);

                    var generatedData = GetCentralReportData();

                    report.UpdateGeneratedData(generatedData);
                    report.Update(generatedData);
                    s.Save(report);

                    EntityReference reportRef = report;
                    var expectedEvt = Test.CreateInstance<ICentralReportUpdated>(e =>
                    {
                        e.Organization = organization;
                        e.Username = username;
                        e.CentralReport = reportRef;
                    });

                    return new
                    {
                        Cmd = new UpdateCentralReportGeneratedDataCommand(report.Id, overrideReportData),
                        Organization = organization,
                        Report = report,
                        centralReportData = generatedData,
                        overrideReportData,
                        username,
                        expectedEvt

                    };
                });


            var context = await Endpoint.Act<UpdateCentralReportGeneratedDataCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                    {
                    
                        ctx.SetUsernameOnHeader(testParams.username);
                        return h.Handle(testParams.Cmd, ctx);
                    });
            var evt = context.ExpectPublish<ICentralReportUpdated>();

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

                    var centralReport = s.Get<CentralReport>(testParams.Cmd.ReportId);
                    centralReport.Should().NotBeNull();
                    centralReport.Description.Should().Be(testParams.Report.Description);
                    centralReport.ReportingPeriod.Year.Should().Be(testParams.Report.ReportingPeriod.Year);
                    centralReport.ReportingPeriod.ReportingFrequency.Should()
                        .Be(testParams.Organization.ReportingFrequency);
                    centralReport.ReportingPeriod.ReportingTerm.Should()
                        .Be(testParams.Report.ReportingPeriod.ReportingTerm);
                    centralReport.Organization.Should().Be(testParams.Report.Organization);
                    //centralReport.AssociateMemberData.Should().Be(overrideReportData
                    //    ? MemberData.Default()
                    //    : testParams.centralReportData.AssociateMemberData);
                    //centralReport.AssociateMemberGeneratedData.Should().Be(MemberData.Default());
                    //centralReport.PreliminaryMemberData.Should().Be(overrideReportData
                    //    ? MemberData.Default()
                    //    : testParams.centralReportData.PreliminaryMemberData);
                    //centralReport.PreliminaryMemberGeneratedData.Should().Be(MemberData.Default());
                    //centralReport.WorkerMeetingProgramData.Should().Be(overrideReportData
                    //    ? MeetingProgramData.Default()
                    //    : testParams.centralReportData.WorkerMeetingProgramData);
                    //centralReport.WorkerMeetingProgramGeneratedData.Should().Be(MeetingProgramData.Default());
                    centralReport.Timestamp.Should().Be(now);
                    centralReport.IsDeleted.Should().Be(false);

                    evt.Should().BeEquivalentTo(testParams.expectedEvt, e => e.Excluding(p => p.SerializedData));
                    evt.SerializedData.Should().NotBe(null);

                });
        }

        private static ReportData GetCentralReportData()
        {
            var reportData = new ReportDataBuilder()
                .Build();
            return reportData;
        }
    }
}