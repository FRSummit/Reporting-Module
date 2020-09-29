using System;
using System.Linq;
using NHibernate;
using NsbWeb.Core;
using NsbWeb.ReportingModule.Configuration;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.Utility;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public class ReportingPeriodQueryService : IReportingPeriodQueryService
    {
        private readonly ISession _session;
        private readonly IUserContext _userContext;

        public ReportingPeriodQueryService(IReportingModuleSession customerReportingInterfaceSession, IUserContext userContext)
        {
            _userContext = userContext;
            _session = customerReportingInterfaceSession.Session;
        }
        
        public ReportingPeriodViewModel GetNextReportingPeriod(int reportId)
        {
            var report = _session
                .Query<ReportViewModel>()
                .ApplyOrganizationReferenceFilter(_userContext)
                .SingleOrDefault(o => o.Id == reportId);

            if (report == null)
                return null;


            var nextReportingPeriod = report.ReportingPeriod.GetReportingPeriodOfNextTerm();
            var isActive = ZaphodTime.LocalNow >= nextReportingPeriod.StartDate && ZaphodTime.LocalNow <= nextReportingPeriod.EndDate;
            return new ReportingPeriodViewModel() { IsActive = isActive, OrganizationReference = report.Organization, ReportingPeriodData = nextReportingPeriod };
        }



        public ReportingPeriodViewModel[] GetReportingPeriods(int organizationId)
        {
            var org = _session.Get<OrganizationViewModel>(organizationId);
            if (org != null)
            {
                return GetReportingPeriodByOrganizationType(org);
            }
            return new ReportingPeriodViewModel[0];
        }
        private ReportingPeriodViewModel[] GetReportingPeriodByOrganizationType(OrganizationReference organizationReference)
        {
            switch (organizationReference.OrganizationType)
            {
                case OrganizationType.Unit:
                    {
                        var now = ZaphodTime.LocalNow;
                        var startDate = ZaphodTime.LocalNow.AddMonths(-20);
                        var endDate = ZaphodTime.LocalNow.AddMonths(8);
                        return GetReportingPeriods(organizationReference, startDate, endDate, ReportingFrequency.Monthly);
                    }
                default:
                    {
                        var startDate = ZaphodTime.LocalNow.AddYears(-2);
                        var endDate = ZaphodTime.LocalNow.AddYears(1);
                        var annualReportingPeriods = GetReportingPeriods(organizationReference, startDate, endDate, ReportingFrequency.Yearly);
                        var quarterlyReportingPeriods = GetReportingPeriods(organizationReference, startDate, endDate, ReportingFrequency.Quarterly);
                        return annualReportingPeriods.Concat(quarterlyReportingPeriods).ToArray();
                    }
            }
        }

        private ReportingPeriodViewModel[] GetReportingPeriods(OrganizationReference organizationReference, DateTime startDate, DateTime endDate, ReportingFrequency reportingFrequency)
        {
            var reportingPeriods = ReportingPeriod.GetReportingPeriods(startDate, endDate, reportingFrequency);
            return reportingPeriods.Select(o =>
            {
                var isActive = ZaphodTime.LocalNow >= o.StartDate && ZaphodTime.LocalNow <= o.EndDate;
                return new ReportingPeriodViewModel() { IsActive = isActive, OrganizationReference = organizationReference, ReportingPeriodData = o };
            }).ToArray();
        }
    }
}