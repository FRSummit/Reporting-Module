using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NsbWeb.Core;
using NsbWeb.ReportingModule.Configuration;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.ValueObjects;
using ReportingModule.ViewModels.Extensions;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public class ZoneReportQueryService : IZoneReportQueryService
    {
        private const int DefaultPageSize = 10;
        private const int ExcelDefaultPageSize = 1000;

        private readonly ISession _session;
        private readonly IUserContext _userContext;
        private readonly IExcelReportFactory _excelReportFactory;
        private readonly IOrganizationUserQueryService _organizationUserQueryService;

        public ZoneReportQueryService(IReportingModuleSession customerReportingInterfaceSession, IUserContext userContext, IExcelReportFactory excelReportFactory, IOrganizationUserQueryService organizationUserQueryService)
        {
            _userContext = userContext;
            _excelReportFactory = excelReportFactory;
            _session = customerReportingInterfaceSession.Session;
            _organizationUserQueryService = organizationUserQueryService;
        }

        public ZoneReportViewModel GetZoneReportViewModel(int reportId)
        {
            var report = _session.Query<ReportViewModel>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.Zone)
                .ApplyOrganizationReferenceFilter(_userContext)
                .ApplyOnlyReportFilter(_userContext)
                .SingleOrDefault(o => o.Id == reportId);

            return report == null ? null : _session.Query<ZoneReportViewModel>().Single(o => o.Id == report.Id);

        }

        public ZonePlanViewModel GetZonePlanViewModel(int planId)
        {
            var report = _session.Query<ReportViewModel>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.Zone)
                .ApplyOrganizationReferenceFilter(_userContext)
                .ApplyOnlyPlanFilter()
                .SingleOrDefault(o => o.Id == planId);

            return report == null ? null : _session.Query<ZonePlanViewModel>().Single(o => o.Id == report.Id);

        }

        public byte[] DownloadZoneReportViewModel(int reportId, ExcelReportType excelReportType)
        {
            var report = GetZoneReportViewModel(reportId);
            return excelReportType == ExcelReportType.List
                ? _excelReportFactory.CreateExcelReport(new SearchResult<ZoneReportViewModel>(
                    new List<ZoneReportViewModel>()
                    {
                        report
                    },
                    new PagingData(1,
                        DefaultPageSize,
                        1)
                ))
                : _excelReportFactory.CreateExcelReport(report);
        }
    }
}