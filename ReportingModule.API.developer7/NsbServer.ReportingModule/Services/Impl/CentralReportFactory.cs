using System;
using System.Linq;
using NHibernate;
using ReportingModule.Common;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class CentralReportFactory : ICentralReportFactory
    {
        private readonly ISession _session;
        private readonly ICentralReportService _centralReportService;

        public CentralReportFactory(ISession session, ICentralReportService centralReportService)
        {
            _session = session;
            _centralReportService = centralReportService;
        }

        public CentralReport CreateNewCentralPlan(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year, ReportingFrequency reportingFrequency)
        {
            var organization = _session.Query<Organization>().Single(o => o.Id == organizationRef.Id);
            if (organization.OrganizationType != OrganizationType.Central)
                throw new ArgumentException("Invalid Organization Type");
            if (reportingFrequency != ReportingFrequency.Quarterly && reportingFrequency != ReportingFrequency.Yearly)
                throw new ArgumentException("Invalid Reporting Frequency");

            var reportingPeriod =
                new ReportingPeriod(reportingFrequency, reportingTerm, year);
            var reportData = _centralReportService.GetGeneratedData(organizationRef.Id, reportingPeriod);
            var report = new CentralReport(description, organization, reportingPeriod, reportData);
            report.UpdateGeneratedData(reportData);
            _session.Save(report);
            return report;
        }

        public CentralReport CopyCentralPlan(string description, int copyFromReportId, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year)
        {
            if (organizationRef.OrganizationType != OrganizationType.Central)
                throw new ArgumentException("Invalid Organization Type");

            var copyFromReport = _session.Get<CentralReport>(copyFromReportId);
            if (copyFromReport.ReportingPeriod.ReportingFrequency != ReportingFrequency.Quarterly && copyFromReport.ReportingPeriod.ReportingFrequency != ReportingFrequency.Yearly)
                throw new ArgumentException("Invalid Reporting Frequency");

            ReportData reportData = copyFromReport;
            var lastPeriodUpdateData = Calculator.GetLastPeriodUpdateData(reportData);

            var newReport = CreateNewCentralPlan(description, copyFromReport.Organization, reportingTerm, year, copyFromReport.ReportingPeriod.ReportingFrequency);
            newReport.UpdatePlan(reportData);
            newReport.Update(reportData);
            newReport.Update(lastPeriodUpdateData);
            _session.Save(newReport);

            return newReport;
        }

    }
}