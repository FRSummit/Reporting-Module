using NHibernate;
using ReportingModule.SystemTests.Common;

namespace ReportingModule.Tests
{
    public static class DomainDatabase
    {
        public static readonly string[] Tables =
        {
            
            "UnitReportData",
            "ZoneReportData",
            "StateReportData",
            "CentralReportData",

            "ReportEventLog",
            
            "Report",
            "OrganizationUser",
            "Organization",
            "Identifier"
        };

        public static void ClearAllReportingModuleTables(ISession session)
        {
            session.ClearAllTables(Tables);
        }

        public static void ClearTables(ISession session, string[] tables)
        {
            session.ClearAllTables(tables);
        }
    }
}