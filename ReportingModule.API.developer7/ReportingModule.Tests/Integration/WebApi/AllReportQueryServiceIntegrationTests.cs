using FluentAssertions;
using NsbWeb.ReportingModule.QueryServices;
using NsbWeb.ReportingModule.QueryServices.Impl;
using NsbWeb.ReportingModule.ViewModels;
using NUnit.Framework;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.Tests.Integration.CommandHandlers;
using ReportingModule.ValueObjects;
using System;
using NHibernate;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common;

// ReSharper disable CoVariantArrayConversion

namespace ReportingModule.Tests.Integration.WebApi
{
    [TestFixture(Category = "Integration")]
    public class AllReportQueryServiceIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                DomainDatabase.ClearAllReportingModuleTables(s);
            });


        }


        [Theory]
        public void SearchPlan_Should_Return_Draft(bool isPlanPromoted)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    //Draft
                    var statePlan = new StateReportBuilder()
                        .Build();

                    ////PromotedPlan
                    if (isPlanPromoted)
                        statePlan.MarkStatusAsPlanPromoted();
                    s.Save(statePlan);
                    var statePlanViewModel = TestHelper.ConvertToReportViewModel(statePlan);

                    //Submitted
                    var submittedStateReport = new StateReportBuilder()
                        .Build();
                    submittedStateReport.MarkStatusAsSubmitted();
                    s.Save(submittedStateReport);
                    var submittedStateReportViewModel = TestHelper.ConvertToReportViewModel(submittedStateReport);
                    //Draft
                    var unitPlan = new UnitReportBuilder()
                        .Build();


                    ////PromotedPlan
                    if (isPlanPromoted)
                        unitPlan.MarkStatusAsPlanPromoted();
                    s.Save(unitPlan);
                    var unitPlanViewModel = TestHelper.ConvertToReportViewModel(unitPlan);

                    //Submitted
                    var submittedUnitReport = new UnitReportBuilder()
                        .Build();
                    submittedUnitReport.MarkStatusAsSubmitted();
                    s.Save(submittedUnitReport);
                    var submittedUnitReportViewModel = TestHelper.ConvertToReportViewModel(submittedUnitReport);

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);
                    return new[]
                    {
                        statePlanViewModel,
                        submittedStateReportViewModel,
                        unitPlanViewModel,
                        submittedUnitReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .SearchPlan(new AllReportSearchTerms()));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }


        [Test]
        public void SearchReport_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    // Submitted State Report
                    var submittedStateReport = new StateReportBuilder()
                        .Build();
                    submittedStateReport.MarkStatusAsSubmitted();
                    s.Save(submittedStateReport);

                    var submittedStateReportViewModel = TestHelper.ConvertToReportViewModel(submittedStateReport);

                    //Draft State Report
                    var draftStateReport = new StateReportBuilder()
                        .Build();
                    draftStateReport.MarkStatusAsPlanPromoted();
                    s.Save(draftStateReport);

                    var draftStateReportViewModel = TestHelper.ConvertToReportViewModel(draftStateReport);


                    // Submitted Unit Report
                    var submittedUnitReport = new UnitReportBuilder()
                        .Build();
                    submittedUnitReport.MarkStatusAsSubmitted();
                    s.Save(submittedUnitReport);

                    var submittedUnitReportViewModel = TestHelper.ConvertToReportViewModel(submittedUnitReport);

                    //Draft Unit Report
                    var draftUnitReport = new UnitReportBuilder()
                        .Build();
                    draftUnitReport.MarkStatusAsPlanPromoted();
                    s.Save(draftUnitReport);

                    var draftUnitReportViewModel = TestHelper.ConvertToReportViewModel(draftUnitReport);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        submittedStateReportViewModel,
                        draftStateReportViewModel,
                        submittedUnitReportViewModel,
                        draftUnitReportViewModel
                    };

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .SearchReport(new AllReportSearchTerms()));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }


        [Theory]
        public void Search_Should_Return_Result(bool isPlanPromoted)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    //Draft
                    var statePlan = new StateReportBuilder()
                        .Build();

                    ////PromotedPlan
                    if (isPlanPromoted)
                        statePlan.MarkStatusAsPlanPromoted();
                    s.Save(statePlan);
                    var statePlanViewModel = TestHelper.ConvertToReportViewModel(statePlan);

                    //Draft
                    var unitPlan = new UnitReportBuilder()
                        .Build();


                    ////PromotedPlan
                    if (isPlanPromoted)
                        unitPlan.MarkStatusAsPlanPromoted();
                    s.Save(unitPlan);
                    var unitPlanViewModel = TestHelper.ConvertToReportViewModel(unitPlan);

                    // Submitted State Report
                    var submittedStateReport = new StateReportBuilder()
                        .Build();
                    submittedStateReport.MarkStatusAsSubmitted();
                    s.Save(submittedStateReport);

                    var submittedStateReportViewModel = TestHelper.ConvertToReportViewModel(submittedStateReport);

                    //Draft State Report
                    var draftStateReport = new StateReportBuilder()
                        .Build();
                    draftStateReport.MarkStatusAsPlanPromoted();
                    s.Save(draftStateReport);

                    var draftStateReportViewModel = TestHelper.ConvertToReportViewModel(draftStateReport);


                    // Submitted Unit Report
                    var submittedUnitReport = new UnitReportBuilder()
                        .Build();
                    submittedUnitReport.MarkStatusAsSubmitted();
                    s.Save(submittedUnitReport);

                    var submittedUnitReportViewModel = TestHelper.ConvertToReportViewModel(submittedUnitReport);

                    //Draft Unit Report
                    var draftUnitReport = new UnitReportBuilder()
                        .Build();
                    draftUnitReport.MarkStatusAsPlanPromoted();
                    s.Save(draftUnitReport);

                    var draftUnitReportViewModel = TestHelper.ConvertToReportViewModel(draftUnitReport);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        statePlanViewModel,
                        unitPlanViewModel,
                        submittedStateReportViewModel,
                        draftStateReportViewModel,
                        submittedUnitReportViewModel,
                        draftUnitReportViewModel
                    };

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms()));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Theory]
        public void Search_By_OrganizationType_And_ReportStatus_Draft_Should_Return_Result(OrganizationType organizationType)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organization = new TestObjectBuilder<OrganizationReference>()
                    .SetArgument(o => o.OrganizationType, organizationType)
                    .Build();

                    ReportViewModel reportViewModel = null;
                    if (OrganizationType.State == organizationType)
                    {
                        var state = new StateReportBuilder()
                        .SetOrganization(organization)
                        .Build();

                        s.Save(state);

                        reportViewModel = TestHelper.ConvertToReportViewModel(state);
                    }
                    else if (OrganizationType.Unit == organizationType)
                    {
                        var unit = new UnitReportBuilder()
                            .SetOrganization(organization)
                                .Build();

                        s.Save(unit);
                        reportViewModel = TestHelper.ConvertToReportViewModel(unit);
                    }
                    else if (OrganizationType.Zone == organizationType)
                    {
                        var zone = new ZoneReportBuilder()
                            .SetOrganization(organization)
                                .Build();

                        s.Save(zone);
                        reportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    }
                    else if (OrganizationType.Central == organizationType)
                    {
                        var central = new CentralReportBuilder()
                            .SetOrganization(organization)
                                .Build();

                        s.Save(central);
                        reportViewModel = TestHelper.ConvertToReportViewModel(central);

                    }

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                            reportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Draft, OrganizationalType = organizationType }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Theory]
        public void Search_By_OrganizationType_And_ReportStatus_PlanPromoted_Should_Return_Result(OrganizationType organizationType)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organization = new TestObjectBuilder<OrganizationReference>()
                    .SetArgument(o => o.OrganizationType, organizationType)
                    .Build();

                    ReportViewModel reportViewModel = null;
                    if (OrganizationType.State == organizationType)
                    {
                        var state = new StateReportBuilder()
                        .SetOrganization(organization)
                        .Build();
                        state.MarkStatusAsPlanPromoted();
                        s.Save(state);

                        reportViewModel = TestHelper.ConvertToReportViewModel(state);
                    }
                    else if (OrganizationType.Unit == organizationType)
                    {
                        var unit = new UnitReportBuilder()
                            .SetOrganization(organization)
                                .Build();
                        unit.MarkStatusAsPlanPromoted();
                        s.Save(unit);
                        reportViewModel = TestHelper.ConvertToReportViewModel(unit);
                    }
                    else if (OrganizationType.Zone == organizationType)
                    {
                        var zone = new ZoneReportBuilder()
                            .SetOrganization(organization)
                                .Build();
                        zone.MarkStatusAsPlanPromoted();
                        s.Save(zone);
                        reportViewModel = TestHelper.ConvertToReportViewModel(zone);
                    }
                    else if (OrganizationType.Central == organizationType)
                    {
                        var central = new CentralReportBuilder()
                            .SetOrganization(organization)
                                .Build();
                        central.MarkStatusAsPlanPromoted();
                        s.Save(central);
                        reportViewModel = TestHelper.ConvertToReportViewModel(central);
                    }

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        reportViewModel
                    };

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.PlanPromoted, OrganizationalType = organizationType }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Theory]
        public void Search_By_OrganizationType_And_ReportStatus_Submitted_Should_Return_Result(OrganizationType organizationType)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organization = new TestObjectBuilder<OrganizationReference>()
                    .SetArgument(o => o.OrganizationType, organizationType)
                    .Build();

                    ReportViewModel reportViewModel = null;
                    if (OrganizationType.State == organizationType)
                    {
                        var state = new StateReportBuilder()
                        .SetOrganization(organization)
                        .Build();
                        state.MarkStatusAsSubmitted();
                        s.Save(state);

                        reportViewModel = TestHelper.ConvertToReportViewModel(state);
                    }
                    else if (OrganizationType.Unit == organizationType)
                    {
                        var unit = new UnitReportBuilder()
                            .SetOrganization(organization)
                                .Build();
                        unit.MarkStatusAsSubmitted();
                        s.Save(unit);
                        reportViewModel = TestHelper.ConvertToReportViewModel(unit);
                    }
                    else if (OrganizationType.Zone == organizationType)
                    {
                        var zone = new ZoneReportBuilder()
                            .SetOrganization(organization)
                                .Build();
                        zone.MarkStatusAsSubmitted();
                        s.Save(zone);
                        reportViewModel = TestHelper.ConvertToReportViewModel(zone);
                    }
                    else if (OrganizationType.Central == organizationType)
                    {
                        var central = new CentralReportBuilder()
                            .SetOrganization(organization)
                                .Build();
                        central.MarkStatusAsSubmitted();
                        s.Save(central);
                        reportViewModel = TestHelper.ConvertToReportViewModel(central);
                    }

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        reportViewModel
                    };

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Submitted, OrganizationalType = organizationType }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Theory]
        public void Search_By_OrganizationType_And_OnlyPlan_Should_Return_Result(OrganizationType organizationType)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organization = new TestObjectBuilder<OrganizationReference>()
                    .SetArgument(o => o.OrganizationType, organizationType)
                    .Build();

                    ReportViewModel reportViewModel = null;
                    if (OrganizationType.State == organizationType)
                    {
                        var state = new StateReportBuilder()
                        .SetOrganization(organization)
                        .Build();

                        s.Save(state);

                        reportViewModel = TestHelper.ConvertToReportViewModel(state);
                    }
                    else if (OrganizationType.Unit == organizationType)
                    {
                        var unit = new UnitReportBuilder()
                            .SetOrganization(organization)
                                .Build();

                        s.Save(unit);
                        reportViewModel = TestHelper.ConvertToReportViewModel(unit);



                    }
                    else if (OrganizationType.Zone == organizationType)
                    {
                        var zone = new ZoneReportBuilder()
                            .SetOrganization(organization)
                                .Build();

                        s.Save(zone);
                        reportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    }
                    else if (OrganizationType.Central == organizationType)
                    {
                        var central = new CentralReportBuilder()
                            .SetOrganization(organization)
                                .Build();

                        s.Save(central);
                        reportViewModel = TestHelper.ConvertToReportViewModel(central);

                    }

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        reportViewModel
                    };

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .SearchPlan(new AllReportSearchTerms { Status = ReportStatus.Draft, OrganizationalType = organizationType }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Theory]
        public void Search_By_OrganizationType_And_OnlyReport_Should_Return_Result(OrganizationType organizationType)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();

            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organization = new TestObjectBuilder<OrganizationReference>()
                    .SetArgument(o => o.OrganizationType, organizationType)
                    .Build();

                    ReportViewModel reportViewModel = null;
                    if (OrganizationType.State == organizationType)
                    {
                        var state = new StateReportBuilder()
                        .SetOrganization(organization)
                        .Build();
                        state.MarkStatusAsPlanPromoted();
                        s.Save(state);

                        reportViewModel = TestHelper.ConvertToReportViewModel(state);
                    }
                    else if (OrganizationType.Unit == organizationType)
                    {
                        var unit = new UnitReportBuilder()
                            .SetOrganization(organization)
                                .Build();
                        unit.MarkStatusAsPlanPromoted();
                        s.Save(unit);
                        reportViewModel = TestHelper.ConvertToReportViewModel(unit);
                    }
                    else if (OrganizationType.Zone == organizationType)
                    {
                        var zone = new ZoneReportBuilder()
                            .SetOrganization(organization)
                                .Build();
                        zone.MarkStatusAsPlanPromoted();
                        s.Save(zone);
                        reportViewModel = TestHelper.ConvertToReportViewModel(zone);
                    }
                    else if (OrganizationType.Central == organizationType)
                    {
                        var central = new CentralReportBuilder()
                            .SetOrganization(organization)
                                .Build();
                        central.MarkStatusAsPlanPromoted();
                        s.Save(central);
                        reportViewModel = TestHelper.ConvertToReportViewModel(central);
                    }

                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        reportViewModel
                    };

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .SearchReport(new AllReportSearchTerms { Status = ReportStatus.PlanPromoted, OrganizationalType = organizationType }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }



        [TestCase(ReportingTerm.One)]
        public void Search_By_ReportingTerm_With_Yearly_And_ReportStatus_Draft_Should_Return_Result(ReportingTerm reportingTerm)
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Yearly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Draft, ReportingFrequency = ReportingFrequency.Yearly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        public void Search_By_ReportingTerm_With_HalfYearly_And_ReportStatus_Draft_Should_Return_Result(ReportingTerm reportingTerm)
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.HalfYearly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Draft, ReportingFrequency = ReportingFrequency.HalfYearly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        [TestCase(ReportingTerm.Four)]
        public void Search_By_ReportingTerm_With_Quarterly_And_ReportStatus_Draft_Should_Return_Result(ReportingTerm reportingTerm)
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Quarterly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Draft, ReportingFrequency = ReportingFrequency.Quarterly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Theory]
        public void Search_By_ReportingTerm_With_Monthly_And_ReportStatus_Draft_Should_Return_Result(ReportingTerm reportingTerm)
        {

            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Draft, ReportingFrequency = ReportingFrequency.Monthly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }


        [TestCase(ReportingTerm.One)]
        public void Search_By_ReportingTerm_With_Yearly_And_ReportStatus_PlanPromoted_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Yearly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsPlanPromoted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsPlanPromoted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsPlanPromoted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsPlanPromoted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.PlanPromoted, ReportingFrequency = ReportingFrequency.Yearly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        public void Search_By_ReportingTerm_With_HalfYearly_And_ReportStatus_PlanPromoted_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.HalfYearly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsPlanPromoted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsPlanPromoted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsPlanPromoted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsPlanPromoted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.PlanPromoted, ReportingFrequency = ReportingFrequency.HalfYearly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        [TestCase(ReportingTerm.Four)]
        public void Search_By_ReportingTerm_With_Quarterly_And_ReportStatus_PlanPromoted_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Quarterly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsPlanPromoted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsPlanPromoted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsPlanPromoted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsPlanPromoted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.PlanPromoted, ReportingFrequency = ReportingFrequency.Quarterly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Theory]
        public void Search_By_ReportingTerm_With_Monthly_And_ReportStatus_PlanPromoted_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsPlanPromoted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsPlanPromoted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsPlanPromoted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsPlanPromoted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.PlanPromoted, ReportingFrequency = ReportingFrequency.Monthly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        public void Search_By_ReportingTerm_With_Yearly_And_ReportStatus_Submitted_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Yearly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsSubmitted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsSubmitted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsSubmitted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsSubmitted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Submitted, ReportingFrequency = ReportingFrequency.Yearly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        public void Search_By_ReportingTerm_With_HalfYearly_And_ReportStatus_Submitted_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.HalfYearly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsSubmitted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsSubmitted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsSubmitted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsSubmitted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Submitted, ReportingFrequency = ReportingFrequency.HalfYearly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        [TestCase(ReportingTerm.Four)]
        public void Search_By_ReportingTerm_With_Quarterly_And_ReportStatus_Submitted_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Quarterly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsSubmitted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsSubmitted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsSubmitted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsSubmitted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Submitted, ReportingFrequency = ReportingFrequency.Quarterly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Theory]
        public void Search_By_ReportingTerm_With_Monthly_And_ReportStatus_Submitted_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsSubmitted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsSubmitted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsSubmitted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsSubmitted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Submitted, ReportingFrequency = ReportingFrequency.Monthly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        public void Search_By_ReportingTerm_With_Yearly_And_OnlyPlan_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var todayDate = DateTime.Now;
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Yearly, reportingTerm, DateTime.Now.Year);

                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    //state
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Draft, ReportingFrequency = ReportingFrequency.Yearly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        public void Search_By_ReportingTerm_With_HalfYearly_And_OnlyPlan_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var todayDate = DateTime.Now;
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.HalfYearly, reportingTerm, DateTime.Now.Year);

                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    //state
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Draft, ReportingFrequency = ReportingFrequency.HalfYearly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        [TestCase(ReportingTerm.Four)]
        public void Search_By_ReportingTerm_With_Quarterly_And_OnlyPlan_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var todayDate = DateTime.Now;
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Quarterly, reportingTerm, DateTime.Now.Year);

                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Draft, ReportingFrequency = ReportingFrequency.Quarterly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Theory]
        public void Search_By_ReportingTerm_With_Monthly_And_OnlyPlan_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var todayDate = DateTime.Now;
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, reportingTerm, DateTime.Now.Year);

                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();

                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.Draft, ReportingFrequency = ReportingFrequency.Monthly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        public void Search_By_ReportingTerm_With_Yearly_And_OnlyReport_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Yearly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsPlanPromoted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsPlanPromoted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsPlanPromoted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsPlanPromoted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.PlanPromoted, ReportingFrequency = ReportingFrequency.Yearly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        public void Search_By_ReportingTerm_With_HalfYearly_And_OnlyReport_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.HalfYearly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsPlanPromoted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsPlanPromoted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsPlanPromoted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsPlanPromoted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.PlanPromoted, ReportingFrequency = ReportingFrequency.HalfYearly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [TestCase(ReportingTerm.One)]
        [TestCase(ReportingTerm.Two)]
        [TestCase(ReportingTerm.Three)]
        [TestCase(ReportingTerm.Four)]
        public void Search_By_ReportingTerm_With_Quarterly_And_OnlyReport_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Quarterly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsPlanPromoted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsPlanPromoted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsPlanPromoted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsPlanPromoted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.PlanPromoted, ReportingFrequency = ReportingFrequency.Quarterly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Theory]
        public void Search_By_ReportingTerm_With_Monthly_And_OnlyReport_Should_Return_Result(ReportingTerm reportingTerm)
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var username = DataProvider.Get<string>();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var reportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, reportingTerm, DateTime.Now.Year);
                    var state = new StateReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    state.MarkStatusAsPlanPromoted();
                    s.Save(state);

                    var stateReportViewModel = TestHelper.ConvertToReportViewModel(state);

                    var unit = new UnitReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    unit.MarkStatusAsPlanPromoted();
                    s.Save(unit);
                    var unitReportViewModel = TestHelper.ConvertToReportViewModel(unit);

                    var zone = new ZoneReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    zone.MarkStatusAsPlanPromoted();
                    s.Save(zone);
                    var zoneReportViewModel = TestHelper.ConvertToReportViewModel(zone);

                    var central = new CentralReportBuilder()
                    .SetReportingPeriod(reportingPeriod)
                    .Build();
                    central.MarkStatusAsPlanPromoted();
                    s.Save(central);
                    var centralReportViewModel = TestHelper.ConvertToReportViewModel(central);


                    TestHelper.SetUserAccessAllOrganizationsClaim(username);

                    return new[]
                    {
                        stateReportViewModel,
                        unitReportViewModel,
                        zoneReportViewModel,
                        centralReportViewModel
                    };
                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Status = ReportStatus.PlanPromoted, ReportingFrequency = ReportingFrequency.Monthly, ReportingTerm = reportingTerm }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Test]
        public void Search_MyReports_User_SystemAdmin_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {

                    var usernameForState = DataProvider.Get<string>();
                    var usernameForUnit = DataProvider.Get<string>();

                    const string Central = "Central";
                    const string VictoriaState = "Victoria State";
                    const string Footscray = "Footscray Unit";
                    const string TruganinaNorth = "Truganina North Unit";
                    ReportingFrequency centralReportingFrequency = ReportingFrequency.Yearly;
                    ReportingFrequency stateReportingFrequency = ReportingFrequency.Yearly;
                    ReportingFrequency unitReportingFrequency = ReportingFrequency.Quarterly;

                    var central = new OrganizationBuilder()
                        .SetDescription(Central)
                        .SetOrganizationType(OrganizationType.Central)
                        .SetReportingFreQuency(centralReportingFrequency)
                        .SetParent(Organization.Root)
                        .BuildAndPersist(s);

                    var victoriaState = new OrganizationBuilder()
                        .SetDescription(VictoriaState)
                        .SetOrganizationType(OrganizationType.State)
                        .SetReportingFreQuency(stateReportingFrequency)
                        .SetParent(central)
                        .BuildAndPersist(s);

                    var footscrayUnit = new OrganizationBuilder()
                        .SetDescription(Footscray)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    var truganinaNorthUnit = new OrganizationBuilder()
                        .SetDescription(TruganinaNorth)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    BuildAndPersistOrganizationUser(s, victoriaState, usernameForState, true, true);
                    BuildAndPersistOrganizationUser(s, footscrayUnit, usernameForUnit, false, false);
                    BuildAndPersistOrganizationUser(s, truganinaNorthUnit, usernameForUnit, false, false);

                    var stateVictoriaReportViewModelYearly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.State, victoriaState, false, true, ReportingFrequency.Yearly, ReportingTerm.One);
                    var stateVictoriaReportViewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.State, victoriaState, true, false, ReportingFrequency.Quarterly, ReportingTerm.Four);

                    var unitFootscrayReportiewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.Unit, footscrayUnit, false, false, ReportingFrequency.Quarterly, ReportingTerm.One);
                    var unitTruganinaNorthReportiewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.Unit, truganinaNorthUnit, false, false, ReportingFrequency.Quarterly, ReportingTerm.One);

                    return new[]
                    {
                        stateVictoriaReportViewModelYearly,
                        stateVictoriaReportViewModelQuarterly
                    };

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { MyReports = true }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Test]
        public void Search_MyReports_User_NotSystemAdmin_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var usernameForState = DataProvider.Get<string>();
                    var usernameForUnit = DataProvider.Get<string>();

                    const string Central = "Central";
                    const string VictoriaState = "Victoria State";
                    const string Footscray = "Footscray Unit";
                    const string TruganinaNorth = "Truganina North Unit";
                    ReportingFrequency centralReportingFrequency = ReportingFrequency.Yearly;
                    ReportingFrequency stateReportingFrequency = ReportingFrequency.Yearly;
                    ReportingFrequency unitReportingFrequency = ReportingFrequency.Quarterly;

                    var central = new OrganizationBuilder()
                        .SetDescription(Central)
                        .SetOrganizationType(OrganizationType.Central)
                        .SetReportingFreQuency(centralReportingFrequency)
                        .SetParent(Organization.Root)
                        .BuildAndPersist(s);

                    var victoriaState = new OrganizationBuilder()
                        .SetDescription(VictoriaState)
                        .SetOrganizationType(OrganizationType.State)
                        .SetReportingFreQuency(stateReportingFrequency)
                        .SetParent(central)
                        .BuildAndPersist(s);

                    var footscrayUnit = new OrganizationBuilder()
                        .SetDescription(Footscray)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    var truganinaNorthUnit = new OrganizationBuilder()
                        .SetDescription(TruganinaNorth)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    BuildAndPersistOrganizationUser(s, victoriaState, usernameForState, true, false);
                    BuildAndPersistOrganizationUser(s, footscrayUnit, usernameForUnit, false, false);
                    BuildAndPersistOrganizationUser(s, truganinaNorthUnit, usernameForUnit, false, false);

                    var stateVictoriaReportViewModelYearly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.State, victoriaState, false, true, ReportingFrequency.Yearly, ReportingTerm.One);
                    var stateVictoriaReportViewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.State, victoriaState, true, false, ReportingFrequency.Quarterly, ReportingTerm.Four);

                    var unitFootscrayReportiewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.Unit, footscrayUnit, false, false, ReportingFrequency.Quarterly, ReportingTerm.One);
                    var unitTruganinaNorthReportiewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.Unit, truganinaNorthUnit, false, false, ReportingFrequency.Quarterly, ReportingTerm.One);

                    return new[]
                    {
                        stateVictoriaReportViewModelYearly,
                        stateVictoriaReportViewModelQuarterly
                    };

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { MyReports = true }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Test]
        public void Search_MyReports_User_NoOrganization_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var usernameForState = DataProvider.Get<string>();
                    var usernameForUnit = DataProvider.Get<string>();

                    const string Central = "Central";
                    const string VictoriaState = "Victoria State";
                    const string Footscray = "Footscray Unit";
                    const string TruganinaNorth = "Truganina North Unit";
                    ReportingFrequency centralReportingFrequency = ReportingFrequency.Yearly;
                    ReportingFrequency stateReportingFrequency = ReportingFrequency.Yearly;
                    ReportingFrequency unitReportingFrequency = ReportingFrequency.Quarterly;

                    var central = new OrganizationBuilder()
                        .SetDescription(Central)
                        .SetOrganizationType(OrganizationType.Central)
                        .SetReportingFreQuency(centralReportingFrequency)
                        .SetParent(Organization.Root)
                        .BuildAndPersist(s);

                    var victoriaState = new OrganizationBuilder()
                        .SetDescription(VictoriaState)
                        .SetOrganizationType(OrganizationType.State)
                        .SetReportingFreQuency(stateReportingFrequency)
                        .SetParent(central)
                        .BuildAndPersist(s);

                    var footscrayUnit = new OrganizationBuilder()
                        .SetDescription(Footscray)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    var truganinaNorthUnit = new OrganizationBuilder()
                        .SetDescription(TruganinaNorth)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    
                    SetUser(new UserContextBuilder(), usernameForState, true, false);
                    BuildAndPersistOrganizationUser(s, footscrayUnit, usernameForUnit, false, false);
                    BuildAndPersistOrganizationUser(s, truganinaNorthUnit, usernameForUnit, false, false);

                    var stateVictoriaReportViewModelYearly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.State, victoriaState, false, true, ReportingFrequency.Yearly, ReportingTerm.One);
                    var stateVictoriaReportViewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.State, victoriaState, true, false, ReportingFrequency.Quarterly, ReportingTerm.Four);

                    var unitFootscrayReportiewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.Unit, footscrayUnit, false, false, ReportingFrequency.Quarterly, ReportingTerm.One);
                    var unitTruganinaNorthReportiewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.Unit, truganinaNorthUnit, false, false, ReportingFrequency.Quarterly, ReportingTerm.One);

                    return Array.Empty<ReportViewModel>();

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { MyReports = true }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Test]
        public void Search_MyOrganization_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var usernameForState = DataProvider.Get<string>();
                    var usernameForUnit = DataProvider.Get<string>();
                    const string Central = "Central";
                    const string VictoriaState = "Victoria State";
                    const string Footscray = "Footscray Unit";
                    const string TruganinaNorth = "Truganina North Unit";
                    ReportingFrequency centralReportingFrequency = ReportingFrequency.Yearly;
                    ReportingFrequency stateReportingFrequency = ReportingFrequency.Yearly;
                    ReportingFrequency unitReportingFrequency = ReportingFrequency.Quarterly;

                    var central = new OrganizationBuilder()
                        .SetDescription(Central)
                        .SetOrganizationType(OrganizationType.Central)
                        .SetReportingFreQuency(centralReportingFrequency)
                        .SetParent(Organization.Root)
                        .BuildAndPersist(s);

                    var victoriaState = new OrganizationBuilder()
                        .SetDescription(VictoriaState)
                        .SetOrganizationType(OrganizationType.State)
                        .SetReportingFreQuency(stateReportingFrequency)
                        .SetParent(central)
                        .BuildAndPersist(s);

                    var footscrayUnit = new OrganizationBuilder()
                        .SetDescription(Footscray)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    var truganinaNorthUnit = new OrganizationBuilder()
                        .SetDescription(TruganinaNorth)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    BuildAndPersistOrganizationUser(s, victoriaState, usernameForState, true, true);
                    BuildAndPersistOrganizationUser(s, footscrayUnit, usernameForUnit, false, false);
                    BuildAndPersistOrganizationUser(s, truganinaNorthUnit, usernameForUnit, false, false);

                    var stateVictoriaReportViewModelYearly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.State, victoriaState, false, true, ReportingFrequency.Yearly, ReportingTerm.One);
                    var stateVictoriaReportViewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.State, victoriaState, true, false, ReportingFrequency.Quarterly, ReportingTerm.Four);

                    var unitFootscrayReportiewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.Unit, footscrayUnit, false, false, ReportingFrequency.Quarterly, ReportingTerm.One);
                    var unitTruganinaNorthReportiewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.Unit, truganinaNorthUnit, false, false, ReportingFrequency.Quarterly, ReportingTerm.One);

                    return new[]
                    {
                        stateVictoriaReportViewModelYearly,
                        stateVictoriaReportViewModelQuarterly
                    };

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Organization = testParams[0].Organization.Id }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams);
        }

        [Test]
        public void Search_MyOrganization_NoReport_Should_Return_Result()
        {
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var usernameForState = DataProvider.Get<string>();
                    var usernameForUnit = DataProvider.Get<string>();

                    const string Central = "Central";
                    const string VictoriaState = "Victoria State";
                    const string Footscray = "Footscray Unit";
                    const string TruganinaNorth = "Truganina North Unit";
                    ReportingFrequency centralReportingFrequency = ReportingFrequency.Yearly;
                    ReportingFrequency stateReportingFrequency = ReportingFrequency.Yearly;
                    ReportingFrequency unitReportingFrequency = ReportingFrequency.Quarterly;

                    var central = new OrganizationBuilder()
                        .SetDescription(Central)
                        .SetOrganizationType(OrganizationType.Central)
                        .SetReportingFreQuency(centralReportingFrequency)
                        .SetParent(Organization.Root)
                        .BuildAndPersist(s);

                    var victoriaState = new OrganizationBuilder()
                        .SetDescription(VictoriaState)
                        .SetOrganizationType(OrganizationType.State)
                        .SetReportingFreQuency(stateReportingFrequency)
                        .SetParent(central)
                        .BuildAndPersist(s);

                    var footscrayUnit = new OrganizationBuilder()
                        .SetDescription(Footscray)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    var truganinaNorthUnit = new OrganizationBuilder()
                        .SetDescription(TruganinaNorth)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    
                    BuildAndPersistOrganizationUser(s, victoriaState, usernameForState, true, false);
                    BuildAndPersistOrganizationUser(s, footscrayUnit, usernameForUnit, false, false);
                    BuildAndPersistOrganizationUser(s, truganinaNorthUnit, usernameForUnit, false, false);

                    var unitFootscrayReportiewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.Unit, footscrayUnit, false, false, ReportingFrequency.Quarterly, ReportingTerm.One);
                    var unitTruganinaNorthReportiewModelQuarterly = BuildAndPersistReportViewModelBasedOnOrganizationType(s, OrganizationType.Unit, truganinaNorthUnit, false, false, ReportingFrequency.Quarterly, ReportingTerm.One);

                    return new
                    {
                        victoriaState,
                        emptyReportViewModel = Array.Empty<ReportViewModel>()
                    };

                });

            var result = NsbWebTest.Act(AssemblySetupFixture.WebTestContainer,
                c => c.GetInstance<AllReportQueryService>()
                    .Search(new AllReportSearchTerms { Organization = testParams.victoriaState.Id }));

            result.Should().NotBeNull();
            result.Items.Should().BeEquivalentTo(testParams.emptyReportViewModel);
        }

        private ReportingPeriod GetReportingPeriod(ReportingFrequency rf, ReportingTerm rt)
        {
            var year = DateTime.Now.Year;
            return new ReportingPeriod(rf, rt, year);
        }

        private StateReport BuildAndPersistStateReport(ISession s, OrganizationReference organization, bool isSubmitted, bool isPlanPromoted, ReportingFrequency rf, ReportingTerm rt)
        {
            var rp = GetReportingPeriod(rf, rt);
            var state = new StateReportBuilder()
                .SetOrganization(organization)
                .SetReportingPeriod(rp)
                .Build();
            if (isSubmitted)
                state.MarkStatusAsSubmitted();
            else if (isPlanPromoted)
                state.MarkStatusAsPlanPromoted();
            s.Save(state);
            return state;
        }

        private UnitReport BuildAndPersistUnitReport(ISession s, OrganizationReference organization, bool isSubmitted, bool isPlanPromoted, ReportingFrequency rf, ReportingTerm rt)
        {
            var rp = GetReportingPeriod(rf, rt);
            var unit = new UnitReportBuilder()
                .SetOrganization(organization)
                .SetReportingPeriod(rp)
                .Build();
            if (isSubmitted)
                unit.MarkStatusAsSubmitted();
            else if (isPlanPromoted)
                unit.MarkStatusAsPlanPromoted();
            s.Save(unit);
            return unit;
        }

        private ZoneReport BuildAndPersistZoneReport(ISession s, OrganizationReference organization, bool isSubmitted, bool isPlanPromoted, ReportingFrequency rf, ReportingTerm rt)
        {
            var rp = GetReportingPeriod(rf, rt);
            var zone = new ZoneReportBuilder()
                .SetOrganization(organization)
                .SetReportingPeriod(rp)
                .Build();
            if (isSubmitted)
                zone.MarkStatusAsSubmitted();
            else if (isPlanPromoted)
                zone.MarkStatusAsPlanPromoted();
            s.Save(zone);
            return zone;
        }

        private CentralReport BuildAndPersistCentralReport(ISession s, OrganizationReference organization, bool isSubmitted, bool isPlanPromoted, ReportingFrequency rf, ReportingTerm rt)
        {
            var rp = GetReportingPeriod(rf, rt);
            var central = new CentralReportBuilder()
                .SetOrganization(organization)
                 .SetReportingPeriod(rp)
                .Build();
            if (isSubmitted)
                central.MarkStatusAsSubmitted();
            else if (isPlanPromoted)
                central.MarkStatusAsPlanPromoted();
            s.Save(central);
            return central;
        }

        private void BuildAndPersistOrganizationUser(ISession s, OrganizationReference organization, string username, bool isCurrentUser, bool isSysAdmin)
        {
            var organizationUser = new TestObjectBuilder<OrganizationUser>()
                .SetArgument(o => o.Username, username)
                .SetArgument(o => o.Organization, organization)
                .BuildAndPersist(s);

            var user = new UserContextBuilder()
            .AddClaims(TestHelper.GetOrganizationClaims(username, new[] { organizationUser }));
            SetUser(user, username, isCurrentUser, isSysAdmin);
        }

        private void SetUser(UserContextBuilder user, string username, bool isCurrentUser, bool isSysAdmin)
        {
            user = user.SetUsername(username);

            if (isSysAdmin)
            {
                user = user.AsSystemAdmin();
            }

            if (isCurrentUser)
                user.SetCurrentPrincipal();
        }
    

        private ReportViewModel BuildAndPersistReportViewModelBasedOnOrganizationType(ISession s, OrganizationType organizationType, OrganizationReference organization, bool isSubmitted, bool isPlanPromoted, ReportingFrequency rf, ReportingTerm rt)
        {
            ReportViewModel reportViewModel = null;
            if (OrganizationType.State == organizationType)
            {
                reportViewModel = TestHelper.ConvertToReportViewModel(BuildAndPersistStateReport(s, organization, isSubmitted, isPlanPromoted, rf, rt));
            }
            else if (OrganizationType.Unit == organizationType)
            {
                reportViewModel = TestHelper.ConvertToReportViewModel(BuildAndPersistUnitReport(s, organization, isSubmitted, isPlanPromoted, rf, rt));
            }
            else if (OrganizationType.Zone == organizationType)
            {
                reportViewModel = TestHelper.ConvertToReportViewModel(BuildAndPersistZoneReport(s, organization, isSubmitted, isPlanPromoted, rf, rt));
            }
            else if (OrganizationType.Central == organizationType)
            {
                reportViewModel = TestHelper.ConvertToReportViewModel(BuildAndPersistCentralReport(s, organization, isSubmitted, isPlanPromoted, rf, rt));
            }

            return reportViewModel;

        }


    }
}