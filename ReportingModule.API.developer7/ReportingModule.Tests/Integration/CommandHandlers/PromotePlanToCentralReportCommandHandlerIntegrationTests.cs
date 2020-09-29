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
    public class PromotePlanToCentralReportCommandHandlerIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [TestCase(ReportingFrequency.Yearly)]
        [TestCase(ReportingFrequency.Quarterly)]
        public async Task Handle_SavesPlan(ReportingFrequency reportingFrequency )
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

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

                    var associateMemberData = new TestObjectBuilder<MemberData>()
                        .Build();

                    var preliminaryMemberData = new TestObjectBuilder<MemberData>()
                        .Build();

                    PlanData planData = new ReportDataBuilder()
                        .SetAssociateMemberData(associateMemberData)
                        .SetPreliminaryMemberData(preliminaryMemberData)
                        .Build();

                    var report = new CentralReportBuilder()
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .BuildAndPersist(s);
                    report.UpdatePlan(planData);
                    s.Save(report);

                    EntityReference reportRef = report;
                    var expectedEvt = Test.CreateInstance<ICentralPlanPromoted>(e =>
                    {
                        e.Organization = organization;
                        e.Username = username;
                        e.CentralReport = reportRef;
                    });

                    return new
                    {
                        Cmd = new PromotePlanToCentralReportCommand(report.Id),
                        Report = report,
                        username,
                        expectedEvt
                    };
                });

            var context = await Endpoint.Act<PromotePlanToCentralReportCommandHandler>(
                AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                {
                    ctx.SetUsernameOnHeader(testParams.username);
                    return h.Handle(testParams.Cmd, ctx);
                });
            var evt = context.ExpectPublish<ICentralPlanPromoted>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var centralReport = s.Get<CentralReport>(testParams.Cmd.PlanId);
                    centralReport.Should().NotBeNull();
                    centralReport.Should().BeEquivalentTo(testParams.Report, e=>e.Excluding(p=>p.ReportStatus));
                    centralReport.ReportStatus.Should().Be(ReportStatus.PlanPromoted);

                    evt.Should().BeEquivalentTo(testParams.expectedEvt, e => e.Excluding(p => p.SerializedData));
                    evt.SerializedData.Should().NotBe(null);
                });
        }
    }
}