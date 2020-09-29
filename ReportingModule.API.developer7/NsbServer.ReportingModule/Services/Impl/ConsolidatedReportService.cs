using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NHibernate;
using ReportingModule.Common;
using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class ConsolidatedReportService : IConsolidatedReportService
    {
        private readonly ISession _session;
        public ConsolidatedReportService(ISession session)
        {
            _session = session;
        }

        public ReportData GetConsolidatedReportData(int[] reportIds)
        {
            return GetConsolidatedReportDataInternal(reportIds);
        }

        private ReportData GetConsolidatedReportDataInternal(int[] reportIds)
        {
            var reports = _session.Query<Report>().Where(o => reportIds.Contains(o.Id)).ToArray();

            var onlyRecentUnitReports = GetRecentReports(reports, OrganizationType.Unit);
            var onlyRecentStateReports = GetRecentReports(reports, OrganizationType.State);
            var onlyRecentZoneReports = GetRecentReports(reports, OrganizationType.Zone);
            var onlyRecentCentralReports = GetRecentReports(reports, OrganizationType.Central);

            var allUnitReports = GetAllReports(reports, OrganizationType.Unit);
            var allStateReports = GetAllReports(reports, OrganizationType.State);
            var allZoneReports = GetAllReports(reports, OrganizationType.Zone);
            var allCentralReports = GetAllReports(reports, OrganizationType.Central);

            var onlyRecentUnitReportData = GetAllReportData(onlyRecentUnitReports, OrganizationType.Unit);
            var onlyRecentStateReportData = GetAllReportData(onlyRecentStateReports, OrganizationType.State);
            var onlyRecentZoneReportData = GetAllReportData(onlyRecentZoneReports, OrganizationType.Zone);
            var onlyRecentCentralReportData = GetAllReportData(onlyRecentCentralReports, OrganizationType.Central);

            var allUnitReportData = GetAllReportData(allUnitReports, OrganizationType.Unit);
            var allStateReportData = GetAllReportData(allStateReports, OrganizationType.State);
            var allZoneReportData = GetAllReportData(allZoneReports, OrganizationType.Zone);
            var allCentralReportData = GetAllReportData(allCentralReports, OrganizationType.Central);

            return Calculator.GetCalculatedReportData(onlyRecentUnitReportData, allUnitReportData, onlyRecentZoneReportData, allZoneReportData, onlyRecentStateReportData, allStateReportData, onlyRecentCentralReportData, allCentralReportData);
        }

        private static Report[] GetRecentReports(Report[] reports, OrganizationType organizationType)
        {
            var list = reports.Where(o => o.Organization.OrganizationType == organizationType).Select(o => o).ToArray();

            return list.GroupBy(o => o.Organization.Id).Select(o =>
                o.OrderByDescending(r => r.ReportingPeriod.EndDate).First()
            ).ToArray();
        }

        private Report[] GetAllReports(Report[] reports, OrganizationType organizationType)
        {
            return reports.Where(o => o.Organization.OrganizationType == organizationType).ToArray();
        }

        [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
        private ReportData[] GetAllReportData(Report[] reports, OrganizationType organizationType)
        {
            var filteredReports = reports.Where(o => o.Organization.OrganizationType == organizationType).ToArray();
            var ids = filteredReports.Select(r => r.Id).ToArray();
            switch (organizationType)
            {
                case OrganizationType.Unit:
                    return _session.Query<UnitReport>()
                        .Where(r => ids.Contains(r.Id))
                        .ToArray().Select(o =>
                        {
                            ReportData r = o;
                            return r;
                        }).ToArray();
                case OrganizationType.Zone:
                    return _session.Query<ZoneReport>()
                        .Where(r => ids.Contains(r.Id))
                        .ToArray().Select(o =>
                        {
                            ReportData r = o;
                            return r;
                        }).ToArray();
                case OrganizationType.State:
                    return _session.Query<StateReport>()
                        .Where(r => ids.Contains(r.Id))
                        .ToArray().Select(o =>
                        {
                            ReportData r = o;
                            return r;
                        }).ToArray();
                case OrganizationType.Central:
                    return _session.Query<CentralReport>()
                        .Where(r => ids.Contains(r.Id))
                        .ToArray().Select(o =>
                        {
                            ReportData r = o;
                            return r;
                        }).ToArray();
                default:
                    return new ReportData[0];
            }
        }

        // ReSharper disable once UnusedMember.Local
        [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
        private ReportData[] GetAllReportData(Report[] reports)
        {
            var items = reports.GroupBy(o => o.Organization.OrganizationType)
                .SelectMany((o, g) =>
                {
                    var ids = o.Select(r => r.Id).ToArray();
                    switch (o.Key)
                    {
                        case OrganizationType.Unit:
                            return _session.Query<UnitReport>()
                                .Where(r => ids.Contains(r.Id))
                                .ToArray().Select(x =>
                                {
                                    ReportData r = x;
                                    return r;
                                }).ToArray();
                        case OrganizationType.Zone:
                            return _session.Query<ZoneReport>()
                                .Where(r => ids.Contains(r.Id))
                                .ToArray().Select(x =>
                                {
                                    ReportData r = x;
                                    return r;
                                }).ToArray();
                        case OrganizationType.State:
                            return _session.Query<StateReport>()
                                .Where(r => ids.Contains(r.Id))
                                .ToArray().Select(x =>
                                {
                                    ReportData r = x;
                                    return r;
                                }).ToArray();
                        case OrganizationType.Central:
                            return _session.Query<CentralReport>()
                                .Where(r => ids.Contains(r.Id))
                                .ToArray().Select(x =>
                                {
                                    ReportData r = x;
                                    return r;
                                }).ToArray();
                        default:
                            return new ReportData[0];
                    }
                });

            return items.ToArray();
        }
    }
}
