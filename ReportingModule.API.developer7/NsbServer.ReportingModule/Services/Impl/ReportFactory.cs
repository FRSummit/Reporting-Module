using System.Linq;
using NHibernate;
using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class ReportFactory : IReportFactory
    {
        private readonly ISession _session;
        private readonly IUnitReportFactory _unitReportFactory;

        public ReportFactory(ISession session, IUnitReportFactory unitReportFactory)
        {
            _session = session;
            _unitReportFactory = unitReportFactory;
        }

        public Report CreateNewReport(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year)
        {
            var organization = _session.Query<Organization>().Single(o => o.Id == organizationRef.Id);
            var reportingPeriod =
                new ReportingPeriod(organization.ReportingFrequency, reportingTerm, year);
            var report = new Report(description, organization, reportingPeriod, null);
            _session.Save(report);
            return report;
        }
    }
}
