using NHibernate;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Builders
{
    public class OrganizationBuilder
    {
        private string _description = DataProvider.Get<string>();

        public OrganizationBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        private string _details = DataProvider.Get<string>();

        public OrganizationBuilder SetDetails(string details)
        {
            _details = details;
            return this;
        }

        private ReportingFrequency _reportFrequency = DataProvider.Get<ReportingFrequency>();

        public OrganizationBuilder SetReportingFreQuency(ReportingFrequency reportingFrequency)
        {
            _reportFrequency = reportingFrequency;
            return this;
        }

        private OrganizationType _organizationType = DataProvider.Get<OrganizationType>();

        public OrganizationBuilder SetOrganizationType(OrganizationType organizationType)
        {
            _organizationType = organizationType;
            return this;
        }

        private EntityReference _parent = DataProvider.Get<EntityReference>();

        public OrganizationBuilder SetParent(EntityReference parent)
        {
            _parent = parent;
            return this;
        }

        public Organization Build()
        {
            var organization = new TestObjectBuilder<Organization>()
                .SetArgument(o => o.Description, _description)
                .SetArgument(o => o.Details, _details)
                .SetArgument(o => o.ReportingFrequency, _reportFrequency)
                .SetArgument(o => o.OrganizationType, _organizationType)
                .SetArgument(o => o.Parent, _parent)
                .Build();
            return organization;
        }

        public Organization BuildAndPersist(ISession s)
        {
            var organization = Build();
            s.Save(organization);
            return organization;
        }
    }
}