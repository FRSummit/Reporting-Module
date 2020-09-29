using NHibernate;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Builders
{
    public class ReportBuilder
    {
        private string _description = DataProvider.Get<string>();

        public ReportBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        private OrganizationReference _organization = DataProvider.Get<OrganizationReference>();

        public ReportBuilder SetOrganization(OrganizationReference organization)
        {
            _organization = organization;
            return this;
        }

        private ReportingPeriod _reportingPeriod = new ReportingPeriod(ReportingFrequency.Quarterly, ReportingTerm.One, 2019);

        public ReportBuilder SetReportingPeriod(ReportingPeriod reportingPeriod)
        {
            _reportingPeriod = reportingPeriod;
            return this;
        }

        private string _comment = DataProvider.Get<string>();

        public ReportBuilder SetComment(string comment)
        {
            _comment = comment;
            return this;
        }

        public Report Build()
        {
            var report = new TestObjectBuilder<Report>()
                .SetArgument(o => o.Description, _description)
                .SetArgument(o => o.Organization, _organization)
                .SetArgument(o => o.ReportingPeriod, _reportingPeriod)
                .SetArgument(o => o.Comment, _comment)
                .Build();
            return report;
        }

        
        public Report BuildAndPersist(ISession s)
        {
            var report = Build();
            s.Save(report);
            return report;
        }
    }
}