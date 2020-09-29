using FluentAssertions;
using NUnit.Framework;
using ReportingModule.Entities;
using ReportingModule.Services.Impl;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.Tests.Integration.CommandHandlers;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.Services
{
    [TestFixture(Category = "Integration")]
    public class UnitReportFactoryIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [TestCase(ReportingFrequency.Monthly)]
        public void CreateNewUnitPlan_SavesCorrectlyWhenLastYearSubmitted(ReportingFrequency reportingFrequency)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizationType = OrganizationType.Unit;

                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, organizationType)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    OrganizationReference organizationRef = organization;

                    var reportingPeriod = new ReportingPeriod(reportingFrequency, reportingTerm, year);

                    
                    var expected = new UnitReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .SetReportData(ReportData.Default())
                        .Build();
                    return new
                    {
                        description,
                        organizationRef,
                        reportingPeriod,
                        expected
                    };
                });
            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c =>
                {
                    var unitReport = c.GetInstance<UnitReportFactory>()
                        .CreateNewUnitPlan(testParams.description,
                            testParams.organizationRef,
                            testParams.reportingPeriod.ReportingTerm,
                            testParams.reportingPeriod.Year,
                            reportingFrequency);
                    return new
                    {
                        unitReport
                    };
                });
            result.unitReport.Should().NotBeNull();

            result.unitReport.Should().BeEquivalentTo(testParams.expected, e =>
                e.Excluding(p => p.Id));
        }

        [Explicit]
        [TestCase(ReportingFrequency.Monthly)]
        public void CreateNewUnitPlanAi_SavesCorrectlyWhenLastYearSubmitted(ReportingFrequency reportingFrequency)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizationType = OrganizationType.Unit;

                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, organizationType)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    OrganizationReference organizationRef = organization;

                    var reportingPeriod = new ReportingPeriod(reportingFrequency, reportingTerm, year);

                    var lastPeriod1 = reportingPeriod.GetReportingPeriodOfPreviousTerm();
                    var lastPeriod1ReportingData = new ReportDataBuilder().Build();
                    var lastPeriod1UnitReport = new UnitReport(description, organization, lastPeriod1, lastPeriod1ReportingData);
                    lastPeriod1UnitReport.MarkStatusAsSubmitted();
                    s.Save(lastPeriod1UnitReport);

                    var lastPeriod2 = lastPeriod1.GetReportingPeriodOfPreviousTerm();
                    var lastPeriod2ReportingData = new ReportDataBuilder().Build();
                    var lastPeriod2UnitReport = new UnitReport(description, organization, lastPeriod2, lastPeriod2ReportingData);
                    lastPeriod2UnitReport.MarkStatusAsSubmitted();
                    s.Save(lastPeriod2UnitReport);

                    var expected = new UnitReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .Build();

                    return new
                    {
                        description,
                        organizationRef,
                        reportingPeriod,
                        lastPeriod1UnitReport,
                        expected
                    };
                });
            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c =>
                {
                    var unitReport = c.GetInstance<UnitReportFactory>()
                        .CreateNewUnitPlanAi(testParams.description,
                            testParams.organizationRef,
                            testParams.reportingPeriod.ReportingTerm,
                            testParams.reportingPeriod.Year,
                            reportingFrequency);
                    return new
                    {
                        unitReport
                    };
                });
            result.unitReport.Should().NotBeNull();

            result.unitReport.Should().BeEquivalentTo(testParams.expected, e =>
                e.Excluding(p=>p.Id)
                    .Excluding(p => p.AssociateMemberData)
                    .Excluding(p => p.PreliminaryMemberData)
                    .Excluding(p => p.WorkerMeetingProgramData)
                    .Excluding(p => p.SupporterMemberData)
                    .Excluding(p => p.DawahMeetingProgramData)
                    .Excluding(p => p.MemberMemberData));


            TestHelper.MemberDataForCreateUnitPlanShouldBeEquivalent(result.unitReport.AssociateMemberData, testParams.lastPeriod1UnitReport.AssociateMemberData);
            TestHelper.MemberDataForCreateUnitPlanShouldBeEquivalent(result.unitReport.PreliminaryMemberData, testParams.lastPeriod1UnitReport.PreliminaryMemberData);
            result.unitReport.PreliminaryMemberData.Should().BeEquivalentTo(testParams.lastPeriod1UnitReport.WorkerMeetingProgramData);

        }

        [Explicit]
        [TestCase(ReportingFrequency.Monthly)]
        public void CreateNewUnitPlanAi_SavesCorrectlyWhenLastYearMissingHOrNotSubmitted(ReportingFrequency reportingFrequency)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizationType = OrganizationType.Unit;

                    var description = DataProvider.Get<string>();
                    var year = 2019;
                    var reportingTerm = ReportingTerm.One;
                    var organization = new TestObjectBuilder<Organization>()
                        .SetArgument(o => o.OrganizationType, organizationType)
                        .SetArgument(o => o.ReportingFrequency, reportingFrequency)
                        .BuildAndPersist(s);

                    OrganizationReference organizationRef = organization;

                    var reportingPeriod = new ReportingPeriod(reportingFrequency, reportingTerm, year);

                    var lastPeriod1 = reportingPeriod.GetReportingPeriodOfPreviousTerm();
                    var lastPeriod1ReportingData = new ReportDataBuilder().Build();
                    var lastPeriod1UnitReport = new UnitReport(description, organization, lastPeriod1, lastPeriod1ReportingData);
                    s.Save(lastPeriod1UnitReport);

                    var lastPeriod2 = lastPeriod1.GetReportingPeriodOfPreviousTerm();
                    var lastPeriod2ReportingData = new ReportDataBuilder().Build();
                    var lastPeriod2UnitReport = new UnitReport(description, organization, lastPeriod2, lastPeriod2ReportingData);
                    lastPeriod2UnitReport.MarkStatusAsSubmitted();
                    s.Save(lastPeriod2UnitReport);

                    var lastPeriod3 = lastPeriod2.GetReportingPeriodOfPreviousTerm();
                    var lastPeriod3ReportingData = new ReportDataBuilder().Build();
                    var lastPeriod3UnitReport = new UnitReport(description, organization, lastPeriod3, lastPeriod3ReportingData);
                    lastPeriod3UnitReport.MarkStatusAsSubmitted();
                    s.Save(lastPeriod3UnitReport);

                    var expected = new UnitReportBuilder()
                        .SetDescription(description)
                        .SetOrganization(organization)
                        .SetReportingPeriod(new ReportingPeriod(reportingFrequency, reportingTerm, year))
                        .Build();

                    return new
                    {
                        description,
                        reportingFrequency,
                        organizationRef,
                        reportingPeriod,
                        lastPeriod2UnitReport,
                        expected
                    };
                });
            var result = Endpoint.Act(AssemblySetupFixture.EndpointTestContainer,
                c =>
                {
                    var unitReport = c.GetInstance<UnitReportFactory>()
                        .CreateNewUnitPlanAi(testParams.description,
                            testParams.organizationRef,
                            testParams.reportingPeriod.ReportingTerm,
                            testParams.reportingPeriod.Year,
                            reportingFrequency);
                    return new
                    {
                        unitReport
                    };
                });
            result.unitReport.Should().NotBeNull();
            result.unitReport.Should().BeEquivalentTo(testParams.expected, e =>
                e.Excluding(p => p.Id)
                    .Excluding(p => p.AssociateMemberData)
                    .Excluding(p => p.PreliminaryMemberData)
                    .Excluding(p => p.WorkerMeetingProgramData)
                    .Excluding(p => p.SupporterMemberData)
                    .Excluding(p => p.DawahMeetingProgramData)
                    .Excluding(p => p.MemberMemberData));

            TestHelper.MemberDataForCreateUnitPlanShouldBeEquivalent(result.unitReport.AssociateMemberData, testParams.lastPeriod2UnitReport.AssociateMemberData);
            TestHelper.MemberDataForCreateUnitPlanShouldBeEquivalent(result.unitReport.PreliminaryMemberData, testParams.lastPeriod2UnitReport.PreliminaryMemberData);
            TestHelper.MemberDataForCreateUnitPlanShouldBeEquivalent(result.unitReport.SupporterMemberData, testParams.lastPeriod2UnitReport.SupporterMemberData);
            TestHelper.MemberDataForCreateUnitPlanShouldBeEquivalent(result.unitReport.MemberMemberData, testParams.lastPeriod2UnitReport.MemberMemberData);
            result.unitReport.WorkerMeetingProgramData.Should().BeEquivalentTo(testParams.lastPeriod2UnitReport.WorkerMeetingProgramData);
            result.unitReport.DawahMeetingProgramData.Should().BeEquivalentTo(testParams.lastPeriod2UnitReport.DawahMeetingProgramData);

        }
    }
}