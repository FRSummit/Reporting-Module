using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ReportingModule.Common;
using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class ReportDataCalculator
    {
        [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
        public static ReportData GetCalculatedReportData(UnitReport[] onlyRecentUnitReports,
            UnitReport[] allUnitReports,
            ZoneReport[] onlyRecentZoneReports = null,
            ZoneReport[] allZoneReports = null,
            StateReport[] onlyRecentStateReports = null,
            StateReport[] allStateReports = null,
            CentralReport[] onlyRecentCentralReports = null,
            CentralReport[] allCentralReports = null

        )
        {
            if (onlyRecentUnitReports == null)
                onlyRecentUnitReports = new UnitReport[0];
            if (onlyRecentZoneReports == null)
                onlyRecentZoneReports = new ZoneReport[0];
            if (onlyRecentStateReports == null)
                onlyRecentStateReports = new StateReport[0];
            if (onlyRecentCentralReports == null)
                onlyRecentCentralReports = new CentralReport[0];

            if (allUnitReports == null)
                allUnitReports = new UnitReport[0];
            if (allZoneReports == null)
                allZoneReports = new ZoneReport[0];
            if (allStateReports == null)
                allStateReports = new StateReport[0];
            if (allCentralReports == null)
                allCentralReports = new CentralReport[0];
            
            return Calculator.GetCalculatedReportData(onlyRecentUnitReports.Select(o =>
            {
                ReportData r = o;
                return r;
            }).ToArray(),
                allUnitReports.Select(o =>
            {
                ReportData r = o;
                return r;
            }).ToArray(),
                onlyRecentZoneReports.Select(o =>
            {
                ReportData r = o;
                return r;
            }).ToArray(),
                allZoneReports.Select(o =>
            {
                ReportData r = o;
                return r;
            }).ToArray(),
                onlyRecentStateReports.Select(o =>
            {
                ReportData r = o;
                return r;
            }).ToArray(),
                allStateReports.Select(o =>
            {
                ReportData r = o;
                return r;
            }).ToArray(),
                onlyRecentCentralReports.Select(o =>
            {
                ReportData r = o;
                return r;
            }).ToArray(),
                allCentralReports.Select(o =>
            {
                ReportData r = o;
                return r;
            }).ToArray());
        }
        
    }
}
