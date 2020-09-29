using System.Collections.Generic;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.Helpers
{
    
    public class IntegrationTestOrganizationHelper
    {
        public const string Central = "Central";
        public const string VictoriaState = "Victoria State";
        public const string Footscray = "Footscray Unit";
        public const string TruganinaNorth = "Truganina North Unit";
        public const string NswState = "Nsw State";
        public const string NswZoneOne = "Nsw Zone One";
        public const string Lakemba = "Lakemba";
        public const string Minto = "Minto";
        public static Dictionary<string, Organization> SetupOrzanizations(ReportingFrequency centralReportingFrequency = ReportingFrequency.Yearly, 
            ReportingFrequency stateReportingFrequency = ReportingFrequency.Yearly,
            ReportingFrequency zoneReportingFrequency = ReportingFrequency.Yearly,
            ReportingFrequency unitReportingFrequency = ReportingFrequency.Quarterly)
        {
            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
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

                    var footscray = new OrganizationBuilder()
                        .SetDescription(Footscray)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    var truganinaNorth = new OrganizationBuilder()
                        .SetDescription(TruganinaNorth)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(victoriaState)
                        .BuildAndPersist(s);

                    var nswState = new OrganizationBuilder()
                        .SetDescription(NswState)
                        .SetOrganizationType(OrganizationType.State)
                        .SetReportingFreQuency(stateReportingFrequency)
                        .SetParent(central)
                        .BuildAndPersist(s);

                    var nswStateZone1 = new OrganizationBuilder()
                        .SetDescription(NswZoneOne)
                        .SetOrganizationType(OrganizationType.Zone)
                        .SetReportingFreQuency(zoneReportingFrequency)
                        .SetParent(nswState)
                        .BuildAndPersist(s);

                    var lakemba = new OrganizationBuilder()
                        .SetDescription(Lakemba)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(nswStateZone1)
                        .BuildAndPersist(s);

                    var minto = new OrganizationBuilder()
                        .SetDescription(Minto)
                        .SetOrganizationType(OrganizationType.Unit)
                        .SetReportingFreQuency(unitReportingFrequency)
                        .SetParent(nswStateZone1)
                        .BuildAndPersist(s);

                    var data = new Dictionary<string, Organization>
                    {
                        {central.Description, central},
                        {victoriaState.Description, victoriaState},
                        {footscray.Description, footscray},
                        {truganinaNorth.Description, truganinaNorth},
                        {nswState.Description, nswState},
                        {nswStateZone1.Description, nswStateZone1},
                        {lakemba.Description, lakemba},
                        {minto.Description, minto}
                    };

                    return data;
                });

            return testParams;

        }
    }
}