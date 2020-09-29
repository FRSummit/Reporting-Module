using System.Linq;
using NHibernate;
using ReportingModule.Entities;
using ReportingModule.ValueObjects;

namespace ReportingModule.Services.Impl
{
    public class StateReportService : IStateReportService
    {
        private readonly ISession _session;
        private readonly IOrganizationService _organizationService;
        private readonly IUnitReportService _unitReportService;
        private readonly IZoneReportService _zoneReportService;

        public StateReportService(ISession session, IOrganizationService organizationService,
            IUnitReportService unitReportService, IZoneReportService zoneReportService)
        {
            _session = session;
            _organizationService = organizationService;
            _unitReportService = unitReportService;
            _zoneReportService = zoneReportService;
        }

        public ReportData GetGeneratedData(int organizationId, ReportingPeriod reportingPeriod)
        {
            var managedOrganizations = _organizationService.GetManagedOrganizations(organizationId);
            var organizations = managedOrganizations as Organization[] ?? managedOrganizations.ToArray();

            var onlyRecentStateReports = new StateReport[0];
            var allStateReports = new StateReport[0];

            var onlyRecentZoneReports = _zoneReportService.GetOnlyRecentZoneReports(reportingPeriod, organizations);
            var allZoneReports = _zoneReportService.GetAllZoneReports(reportingPeriod, organizations);

            var onlyRecentUnitReports = _unitReportService.GetOnlyRecentUnitReports(reportingPeriod, organizations);
            var allUnitReports = _unitReportService.GetAllUnitReports(reportingPeriod, organizations);

            return ReportDataCalculator.GetCalculatedReportData(onlyRecentUnitReports, allUnitReports, onlyRecentZoneReports, allZoneReports, onlyRecentStateReports, allStateReports);
            
        }

        public StateReport[] GetAllStateReports(ReportingPeriod reportingPeriod, Organization[] organizations)
        {
            var orgIds = organizations
                .Where(managedOrganization => managedOrganization.OrganizationType == OrganizationType.State)
                .Select(managedOrganization => managedOrganization.Id)
                .ToArray();

            var reportIds = _session.Query<Report>()
                .Where(o => orgIds.Contains(o.Organization.Id) &&
                            o.ReportStatus == ReportStatus.Submitted &&
                            o.ReportingPeriod.EndDate <= reportingPeriod.EndDate &&
                            o.ReportingPeriod.StartDate >=
                            reportingPeriod.StartDate)
                .OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o.Id)
                .ToArray();

            return _session.Query<StateReport>()
                .Where(r => reportIds.Contains(r.Id)).ToArray();
        }
        public StateReport[] GetOnlyRecentStateReports(ReportingPeriod reportingPeriod, Organization[] organizations)
        {
            var reportIds = organizations
                .Where(managedOrganization => managedOrganization.OrganizationType == OrganizationType.State)
                .Select(managedOrganization =>
                    GetSubmittedStateReportInReportingPeriod(managedOrganization.Id, reportingPeriod))
                .ToArray()
                .Where(o => o != null)
                .Select(o=>o.Id)
                .ToArray();
            return _session.Query<StateReport>()
                .Where(r => reportIds.Contains(r.Id)).ToArray();
        }

        private Report GetSubmittedStateReportInReportingPeriod(int organizationId,
            ReportingPeriod reportingPeriod)
        {
            return _session.Query<Report>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.State && 
                            o.Organization.Id == organizationId &&
                            o.ReportStatus == ReportStatus.Submitted &&
                            o.ReportingPeriod.EndDate <= reportingPeriod.EndDate &&
                            o.ReportingPeriod.StartDate >=
                            reportingPeriod.StartDate)
                .OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o)
                .FirstOrDefault();

        }
        public StateReport PromotePlanToStateReport(int reportId)
        {
            var report = _session.Query<StateReport>().Single(o => o.Id == reportId);
            report.MarkStatusAsPlanPromoted();
            _session.Save(report);
            return report;
        }

        public StateReport GetLastSubmittedStateReport(int organizationId,
            ReportingPeriod reportingPeriod,
            int pastTermCycle = 1)
        {
            var reportingPeriodOfPreviousTerm1 = reportingPeriod.GetReportingPeriodOfPreviousTerm();

            var reportIds = _session.Query<Report>()
                .Where(o => o.Organization.OrganizationType == OrganizationType.State &&
                            o.Organization.Id == organizationId &&
                            o.ReportStatus == ReportStatus.Submitted &&
                            o.ReportingPeriod.EndDate < reportingPeriod.StartDate &&
                            o.ReportingPeriod.StartDate >=
                            reportingPeriodOfPreviousTerm1.StartDate)
                .OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o.Id)
                .ToArray();

            var stateReports = _session.Query<StateReport>()
                .Where(r => reportIds.Contains(r.Id)).ToArray();

            if (stateReports.Length == 0 && pastTermCycle <= 3)
                return GetLastSubmittedStateReport(organizationId,
                    reportingPeriodOfPreviousTerm1, pastTermCycle + 1);
            return stateReports.FirstOrDefault();
        }

        public StateReport[] GetStateReports(int[] reportIds)
        {
            if (reportIds == null)
                reportIds = new int[0];
            return _session.Query<StateReport>().Where(r => reportIds.Contains(r.Id)).ToArray();
        }
    }
}


//private MemberData GetCalculatedMemberData(IEnumerable<MemberData> zoneMemberDatas, IEnumerable<MemberData> unitMemberDatas)
//{
//    if (unitMemberDatas == null)
//        return MemberData.Default();

//    var enumerableZoneMemberDatas = zoneMemberDatas as MemberData[] ?? zoneMemberDatas.ToArray();
//    var enumerableUnitMemberDatas = unitMemberDatas as MemberData[] ?? unitMemberDatas.ToArray();
//    int lastPeriod = enumerableZoneMemberDatas.Sum(o => o.LastPeriod) + enumerableUnitMemberDatas.Sum(o => o.LastPeriod);
//    int upgradeTarget = enumerableZoneMemberDatas.Sum(o => o.UpgradeTarget) + enumerableUnitMemberDatas.Sum(o => o.UpgradeTarget);
//    int increased = enumerableZoneMemberDatas.Sum(o => o.Increased) + enumerableUnitMemberDatas.Sum(o => o.Increased);
//    int decreased = enumerableZoneMemberDatas.Sum(o => o.Decreased) + enumerableUnitMemberDatas.Sum(o => o.Decreased);

//    return new MemberData(null, null, lastPeriod, upgradeTarget, increased, decreased, null, null);
//}

//[SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
//private MeetingProgramData GetCalculatedMeetingProgramData(IEnumerable<MeetingProgramData> zoneMemberDatas, IEnumerable<MeetingProgramData> unitMemberDatas)
//{
//    if (unitMemberDatas == null)
//        return MeetingProgramData.Default();

//    var enumerableZoneMemberDatas = zoneMemberDatas as MeetingProgramData[] ?? zoneMemberDatas.ToArray();
//    var enumerableUnitMemberDatas = unitMemberDatas as MeetingProgramData[] ?? unitMemberDatas.ToArray();
//    int target = enumerableZoneMemberDatas.Sum(o => o.Target) + enumerableUnitMemberDatas.Sum(o => o.Target);
//    int actual = enumerableZoneMemberDatas.Sum(o => o.Actual) + enumerableUnitMemberDatas.Sum(o => o.Actual);

//    double averageInZone = 0;
//    if (enumerableZoneMemberDatas.Length > 0)
//        averageInZone = enumerableZoneMemberDatas.Average(o => o.AverageAttendance);

//    double averageInUnit = 0;
//    if (enumerableUnitMemberDatas.Length > 0)
//        averageInUnit = enumerableUnitMemberDatas.Average(o => o.AverageAttendance);

//    double average;
//    if (averageInUnit == 0 && averageInZone > 0)
//        average = averageInZone;
//    else if (averageInZone == 0 && averageInUnit > 0)
//        average = averageInUnit;
//    else
//        average = new[] { averageInZone, averageInUnit }.Average();

//    var averageAttendance = Convert.ToInt32(average);
//    return new MeetingProgramData(target, null, actual, averageAttendance, null);
//}

//[SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
//private TeachingLearningProgramData GetCalculatedTeachingLearningProgramData(IEnumerable<TeachingLearningProgramData> zoneMemberDatas, IEnumerable<TeachingLearningProgramData> unitMemberDatas)
//{
//    if (unitMemberDatas == null)
//        return TeachingLearningProgramData.Default();

//    var enumerableZoneMemberDatas = zoneMemberDatas as TeachingLearningProgramData[] ?? zoneMemberDatas.ToArray();
//    var enumerableUnitMemberDatas = unitMemberDatas as TeachingLearningProgramData[] ?? unitMemberDatas.ToArray();
//    int target = enumerableZoneMemberDatas.Sum(o => o.Target) + enumerableUnitMemberDatas.Sum(o => o.Target);
//    int actual = enumerableZoneMemberDatas.Sum(o => o.Actual) + enumerableUnitMemberDatas.Sum(o => o.Actual);

//    double averageInZone = 0;
//    if (enumerableZoneMemberDatas.Length > 0)
//        averageInZone = enumerableZoneMemberDatas.Average(o => o.AverageAttendance);

//    double averageInUnit = 0;
//    if (enumerableUnitMemberDatas.Length > 0)
//        averageInUnit = enumerableUnitMemberDatas.Average(o => o.AverageAttendance);

//    double average;
//    if (averageInUnit == 0 && averageInZone > 0)
//        average = averageInZone;
//    else if (averageInZone == 0 && averageInUnit > 0)
//        average = averageInUnit;
//    else
//        average = new[] { averageInZone, averageInUnit }.Average();

//    var averageAttendance = Convert.ToInt32(average);
//    return new TeachingLearningProgramData(target, null, actual, averageAttendance, null);
//}


//[SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
//private MaterialData GetCalculatedMaterialData(IEnumerable<MaterialData> zoneMemberDatas, IEnumerable<MaterialData> unitMemberDatas)
//{
//    if (unitMemberDatas == null)
//        return MaterialData.Default();

//    var enumerableZoneMemberDatas = zoneMemberDatas as MaterialData[] ?? zoneMemberDatas.ToArray();
//    var enumerableUnitMemberDatas = unitMemberDatas as MaterialData[] ?? unitMemberDatas.ToArray();
//    int target = enumerableZoneMemberDatas.Sum(o => o.Target) + enumerableUnitMemberDatas.Sum(o => o.Target);
//    int actual = enumerableZoneMemberDatas.Sum(o => o.Actual) + enumerableUnitMemberDatas.Sum(o => o.Actual);

//    return new MaterialData(target, null, actual, null);
//}

//private LibraryStockData GetCalculatedLibraryStockData(IEnumerable<LibraryStockData> zoneLibraryStockDatas, IEnumerable<LibraryStockData> unitLibraryStockDatas)
//{
//    if (unitLibraryStockDatas == null)
//        return LibraryStockData.Default();

//    var enumerableZoneLibraryStockDatas = zoneLibraryStockDatas as LibraryStockData[] ?? zoneLibraryStockDatas.ToArray();
//    var enumerableUnitLibraryStockDatas = unitLibraryStockDatas as LibraryStockData[] ?? unitLibraryStockDatas.ToArray();
//    int lastPeriod = enumerableZoneLibraryStockDatas.Sum(o => o.LastPeriod) + enumerableUnitLibraryStockDatas.Sum(o => o.LastPeriod);
//    int increased = enumerableZoneLibraryStockDatas.Sum(o => o.Increased) + enumerableUnitLibraryStockDatas.Sum(o => o.Increased);
//    int decreased = enumerableZoneLibraryStockDatas.Sum(o => o.Decreased) + enumerableUnitLibraryStockDatas.Sum(o => o.Decreased);

//    return new LibraryStockData(lastPeriod, increased, decreased, null);
//}

//private FinanceData GetCalculatedFinanceData(IEnumerable<FinanceData> zoneFinanceDatas, IEnumerable<FinanceData> unitFinanceDatas)
//{
//    if (unitFinanceDatas == null)
//        return FinanceData.Default();

//    var enumerableZoneFinanceDatas = zoneFinanceDatas as FinanceData[] ?? zoneFinanceDatas.ToArray();
//    var enumerableUnitFinanceDatas = unitFinanceDatas as FinanceData[] ?? unitFinanceDatas.ToArray();

//    decimal workerPromiseLastPeriod = enumerableZoneFinanceDatas.Sum(o => o.WorkerPromiseLastPeriod.Amount) + enumerableUnitFinanceDatas.Sum(o => o.WorkerPromiseLastPeriod.Amount);
//    decimal workerPromiseIncreaseTarget = enumerableZoneFinanceDatas.Sum(o => o.WorkerPromiseIncreaseTarget.Amount) + enumerableUnitFinanceDatas.Sum(o => o.WorkerPromiseIncreaseTarget.Amount);
//    decimal workerPromiseIncreased = enumerableZoneFinanceDatas.Sum(o => o.WorkerPromiseIncreased.Amount) + enumerableUnitFinanceDatas.Sum(o => o.WorkerPromiseIncreased.Amount);
//    decimal workerPromiseDecreased = enumerableZoneFinanceDatas.Sum(o => o.WorkerPromiseDecreased.Amount) + enumerableUnitFinanceDatas.Sum(o => o.WorkerPromiseDecreased.Amount);
//    decimal lastPeriod = enumerableZoneFinanceDatas.Sum(o => o.LastPeriod.Amount) + enumerableUnitFinanceDatas.Sum(o => o.LastPeriod.Amount);
//    decimal collection = enumerableZoneFinanceDatas.Sum(o => o.Collection.Amount) + enumerableUnitFinanceDatas.Sum(o => o.Collection.Amount);
//    decimal expenses = enumerableZoneFinanceDatas.Sum(o => o.Expense.Amount) + enumerableUnitFinanceDatas.Sum(o => o.Expense.Amount);
//    decimal nisabPaidToCentral = enumerableZoneFinanceDatas.Sum(o => o.NisabPaidToCentral.Amount) + enumerableUnitFinanceDatas.Sum(o => o.NisabPaidToCentral.Amount);
//    decimal otherSourceIncreaseTarget = enumerableZoneFinanceDatas.Sum(o => o.OtherSourceIncreaseTarget.Amount) + enumerableUnitFinanceDatas.Sum(o => o.OtherSourceIncreaseTarget.Amount);

//    return new FinanceData(null,
//        new Money(workerPromiseIncreaseTarget),
//        null,
//        new Money(otherSourceIncreaseTarget),
//        new Money(workerPromiseLastPeriod),
//        new Money(lastPeriod),
//        new Money(collection),
//        new Money(expenses),
//        new Money(nisabPaidToCentral),
//        new Money(workerPromiseIncreased),
//        new Money(workerPromiseDecreased),
//        null
//    );
//}

//[SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
//private SocialWelfareData GetCalculatedSocialWelfareData(IEnumerable<SocialWelfareData> zoneSocialWelfareDatas, IEnumerable<SocialWelfareData> unitSocialWelfareDatas)
//{
//    if (unitSocialWelfareDatas == null)
//        return SocialWelfareData.Default();

//    var enumerableZoneMemberDatas = zoneSocialWelfareDatas as SocialWelfareData[] ?? zoneSocialWelfareDatas.ToArray();
//    var enumerableUnitMemberDatas = unitSocialWelfareDatas as SocialWelfareData[] ?? unitSocialWelfareDatas.ToArray();
//    int target = enumerableZoneMemberDatas.Sum(o => o.Target) + enumerableUnitMemberDatas.Sum(o => o.Target);
//    int actual = enumerableZoneMemberDatas.Sum(o => o.Actual) + enumerableUnitMemberDatas.Sum(o => o.Actual);

//    return new SocialWelfareData(target, null, actual, null);
//}

//Update this only when Zone data related work done
/*
 *public ReportData GetGeneratedDataZoneAndUnit(int organizationId, ReportingPeriod reportingPeriod)
{
    var managedOrganizations = _organizationService.GetManagedOrganizations(organizationId);
    var organizations = managedOrganizations as Organization[] ?? managedOrganizations.ToArray();
    var stateReports = organizations
        .Where(managedOrganization => managedOrganization.OrganizationType == OrganizationType.Zone)
        .Select(managedOrganization =>
            _stateReportService.GetLastSubmittedState  }
}
*/
