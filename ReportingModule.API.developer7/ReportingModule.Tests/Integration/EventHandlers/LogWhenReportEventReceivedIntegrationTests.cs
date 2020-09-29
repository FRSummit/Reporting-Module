using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NServiceBus.Testing;
using NUnit.Framework;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.EventHandlers;
using ReportingModule.Events;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.EventHandlers
{
    [TestFixture(Category = "Integration")]
    public class LogWhenReportEventReceivedIntegrationTests
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
        public async Task Handle_UnitPlanCreated(ReportingFrequency reportingFrequency)
        {

            var now = DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var username = DataProvider.Get<string>();
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, OrganizationType.Unit)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    var evt = Test.CreateInstance<IUnitPlanCreated>(x =>
                    {
                        x.Username = username;
                        x.Organization = organization;
                        x.UnitReport = DataProvider.Get<EntityReference>();
                        x.SerializedData = DataProvider.Get<string>();
                    });
                    return new
                    {
                        evt
                    };
                });


            await Endpoint.Act<LogWhenReportEventReceived>(AssemblySetupFixture.EndpointTestContainer,
                    (h, ctx) => h.Handle(testParams.evt, ctx));

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportEventLog = s.Query<ReportEventLog>().Single();
                    reportEventLog.Should().NotBeNull();
                    reportEventLog.OrganizationId.Should().Be(testParams.evt.Organization.Id);
                    reportEventLog.Timestamp.Should().Be(now);

                });
        }
    }
}