using System;
using System.Linq;
using NHibernate;
using ReportingModule.Common;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class ZoneReportFactory : IZoneReportFactory
    {
        private readonly ISession _session;
        private readonly IZoneReportService _zoneReportService;

        public ZoneReportFactory(ISession session, IZoneReportService zoneReportService)
        {
            _session = session;
            _zoneReportService = zoneReportService;
        }

        public ZoneReport CreateNewZonePlan(string description, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year, ReportingFrequency reportingFrequency)
        {
            var organization = _session.Query<Organization>().Single(o => o.Id == organizationRef.Id);
            if (organization.OrganizationType != OrganizationType.Zone)
                throw new ArgumentException("Invalid Organization Type");
            if (reportingFrequency != ReportingFrequency.Quarterly && reportingFrequency != ReportingFrequency.Yearly)
                throw new ArgumentException("Invalid Reporting Frequency");

            var reportingPeriod =
                new ReportingPeriod(reportingFrequency, reportingTerm, year);
            var reportData = _zoneReportService.GetGeneratedData(organizationRef.Id, reportingPeriod);
            var report = new ZoneReport(description, organization, reportingPeriod, reportData);
            report.UpdateGeneratedData(reportData);
            _session.Save(report);
            return report;
        }
        public ZoneReport CopyZonePlan(string description, int copyFromReportId, OrganizationReference organizationRef, ReportingTerm reportingTerm, int year)
        {
            if (organizationRef.OrganizationType != OrganizationType.Zone)
                throw new ArgumentException("Invalid Organization Type");
           
            var copyFromReport = _session.Get<ZoneReport>(copyFromReportId);
            if (copyFromReport.ReportingPeriod.ReportingFrequency != ReportingFrequency.Quarterly && copyFromReport.ReportingPeriod.ReportingFrequency != ReportingFrequency.Yearly)
                throw new ArgumentException("Invalid Reporting Frequency");

            ReportData reportData = copyFromReport;
            var lastPeriodUpdateData = Calculator.GetLastPeriodUpdateData(reportData);

            var newReport = CreateNewZonePlan(description, copyFromReport.Organization, reportingTerm, year, copyFromReport.ReportingPeriod.ReportingFrequency);
            newReport.UpdatePlan(reportData);
            newReport.Update(reportData);
            newReport.Update(lastPeriodUpdateData);
            _session.Save(newReport);

            return newReport;
        }

    }
}