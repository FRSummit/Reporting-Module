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
    public class CentralReportQueryService : ICentralReportQueryService
    {
        private const int DefaultPageSize = 10;
        private const int ExcelDefaultPageSize = 1000;

        private readonly ISession _session;
        private readonly IUserContext _userContext;
        private readonly IExcelReportFactory _excelReportFactory;

        public CentralReportQueryService(IReportingModuleSession customerReportingInterfaceSession, IUserContext userContext, IExcelReportFactory excelReportFactory)
        {
            _userContext = userContext;
            _excelReportFactory = excelReportFactory;
            _session = customerReportingInterfaceSession.Session;
        }
    
        public CentralReportViewModel GetCentralReportViewModel(int reportId)
        {
            var report = _session.Query<ReportViewModel>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.Central)
                .ApplyOrganizationReferenceFilter(_userContext)
                .ApplyOnlyReportFilter(_userContext)
                .SingleOrDefault(o => o.Id == reportId);
            return report == null ? null : _session.Query<CentralReportViewModel>().Single(o => o.Id == report.Id);
        }

        public CentralPlanViewModel GetCentralPlanViewModel(int planId)
        {
            var report = _session.Query<ReportViewModel>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.Central)
                .ApplyOrganizationReferenceFilter(_userContext)
                .ApplyOnlyPlanFilter()
                .SingleOrDefault(o => o.Id == planId);
            return report == null ? null : _session.Query<CentralPlanViewModel>().Single(o => o.Id == report.Id);
        }

        public byte[] DownloadCentralReportViewModel(int reportId, ExcelReportType excelReportType)
        {
            var report = GetCentralReportViewModel(reportId);
            return excelReportType == ExcelReportType.List
                ? _excelReportFactory.CreateExcelReport(new SearchResult<CentralReportViewModel>(
                    new List<CentralReportViewModel>()
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