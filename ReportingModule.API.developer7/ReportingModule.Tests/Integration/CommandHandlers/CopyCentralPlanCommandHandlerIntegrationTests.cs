using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NServiceBus.Testing;
using NUnit.Framework;
using ReportingModule.CommandHandlers;
using ReportingModule.Commands;
using ReportingModule.Common;
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
    public class CopyCentralPlanCommandHandlerIntegrationTests
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

        [TestCase(ReportingFrequency.Yearly, ReportingFrequency.Quarterly)]
        [TestCase(ReportingFrequency.Quarterly, ReportingFrequency.Yearly)]
        public async Task Handle_SavesCentralReport(ReportingFrequency reportingFrequency, ReportingFrequency differentFrequency)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, OrganizationType.Central)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    var existing = new CentralReportBuilder()
                        .SetDescription(DataProvider.Get<string>())
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .BuildAndPersist(s);

                    var newReportYear = year + 1;

                    new CentralReportBuilder()
                        .SetDescription(DataProvider.Get<string>())
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(differentFrequency, reportingTerm, newReportYear))
                        .BuildAndPersist(s);

                    var cmd = new CopyCentralPlanCommand(existing.Id, organization, newReportYear, reportingTerm, reportingFrequency);
                    var description = cmd.Description;
                    var lastPeriodData = Calculator.GetLastPeriodUpdateData(existing);

                    var expected = new CentralReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, newReportYear))
                        .SetReportData(existing)
                        .Build();
                    expected.Update(lastPeriodData);
                    return new
                    {
                        cmd,
                        username,
                        expected
                    };
                });

            


            var context = await Endpoint.Act<CopyCentralPlanCommandHandler>(AssemblySetupFixture.EndpointTestContainer, 
                (h, ctx) =>
                {
                    ctx.SetUsernameOnHeader(testParams.username);
                    return h.Handle(testParams.cmd, ctx);
                });

            var evt = context.ExpectPublish<ICentralPlanCopied>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
            s =>
            {
                var report = s.Query<CentralReport>().OrderByDescending(o => o.Id).First();
                report.Should().NotBeNull();
                report.Should().BeEquivalentTo(testParams.expected, e =>
                    e.Excluding(p => p.Id)
                        .Excluding(p => p.ReportingPeriod)
                        .Excluding(p => p.ReportStatus));

                EntityReference reportRef = report;

                var expectedEvt = Test.CreateInstance<ICentralPlanCopied>(e =>
                {
                    e.Organization = testParams.expected.Organization;
                    e.Username = testParams.username;
                    e.CentralReport = reportRef;
                });

                evt.Should().BeEquivalentTo(expectedEvt, e => e.Excluding(p => p.SerializedData));
                evt.SerializedData.Should().NotBe(null);
            });
        }

        [TestCase(ReportingFrequency.Yearly)]
        [TestCase(ReportingFrequency.Quarterly)]
        public async Task Handle_DoNotSavesCentralReport_WhenDuplicate(ReportingFrequency reportingFrequency)
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, OrganizationType.Central)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    var copyFrom = new CentralReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year - 1))
                        .BuildAndPersist(s);

                    var duplicate = new CentralReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .BuildAndPersist(s);

                    return new
                    {
                        Cmd = new CopyCentralPlanCommand(copyFrom.Id, organization, year, reportingTerm, reportingFrequency),
                        username,
                        duplicate
                    };
                });

            

            var context = await Endpoint.Act<CopyCentralPlanCommandHandler>(AssemblySetupFixture.EndpointTestContainer, (h, ctx) =>
            {
                ctx.SetUsernameOnHeader(testParams.username);
                return h.Handle(testParams.Cmd, ctx);
            });

            var evt = context.ExpectPublish<ICentralPlanCopyFailed>();

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Query<CentralReport>().OrderByDescending(o => o.Id).First();
                    report.Should().NotBeNull();
                    report.Should().BeEquivalentTo(testParams.duplicate);
                    evt.Errors[0].Should().Contain(testParams.duplicate.Description);
                });
        }

        [TestCase(ReportingFrequency.Yearly)]
        [TestCase(ReportingFrequency.Quarterly)]
        public async Task Handle_DoNotSavesCentralReport_WhenDifferentOrganization(ReportingFrequency reportingFrequency)
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, OrganizationType.Central)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);
                    var organization2 = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, OrganizationType.Central)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    var copyFrom = new CentralReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization2)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year - 1))
                        .BuildAndPersist(s);

                    return new
                    {
                        Cmd = new CopyCentralPlanCommand(copyFrom.Id, organization, year, reportingTerm, reportingFrequency),
                        username,
                        copyFrom
                    };
                });

            

            var context = await Endpoint.Act<CopyCentralPlanCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                {
                    ctx.SetUsernameOnHeader(testParams.username);
                    return h.Handle(testParams.Cmd, ctx);
                });

            var evt = context.ExpectPublish<ICentralPlanCopyFailed>();
            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var report = s.Query<CentralReport>().OrderByDescending(o => o.Id).First();
                    report.Should().NotBeNull();
                    report.Should().BeEquivalentTo(testParams.copyFrom);
                    evt.Errors[0].Should().Contain("Unable to copy plan");
                });
        }
    }
}