using System;
using System.Linq;
using NHibernate;
using ReportingModule.Core;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.Tests.Builders;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.Helpers
{
    public class IntegrationTestZoneReportHelper
    {
        public static UnitReport BuildAndPersistUnitReport(bool submitted, Organization organization,
            ReportingPeriod reportingPeriod, ISession s)
        {
            string description = DataProvider.Get<string>();
            var reportingData = new ReportDataBuilder().Build();
            var report =
                new UnitReport(description, organization, reportingPeriod, reportingData);
            if (submitted)
            {
                report.MarkStatusAsSubmitted();
            }

            s.Save(report);
            return report;
        }

        public static UnitReport[] GetSubmittedReports(UnitReport[] unitReports, ReportingPeriod reportingPeriod)
        {
            return unitReports.Where(o => o.ReportStatus == ReportStatus.Submitted
                                          &&
                                          o.ReportingPeriod.EndDate <= reportingPeriod.EndDate &&
                                          o.ReportingPeriod.StartDate >=
                                          reportingPeriod.StartDate).ToArray();
        }

        public static UnitReport GetLastSubmittedReport(UnitReport[] unitReports, ReportingPeriod reportingPeriod)
        {
            return unitReports.Where(o => o.ReportStatus == ReportStatus.Submitted
                                          &&
                                          o.ReportingPeriod.EndDate <= reportingPeriod.EndDate &&
                                          o.ReportingPeriod.StartDate >=
                                          reportingPeriod.StartDate).OrderByDescending(o => o.ReportingPeriod.EndDate)
                .Select(o => o)
                .FirstOrDefault();
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName)?.GetValue(src, null);
        }

        public static MemberData GetExpectedMemberData(UnitReport[] submittedReports, string dataPropertyName)
        {
            var lastPeriod = submittedReports.Sum(o => ((MemberData)GetPropValue(o, dataPropertyName)).LastPeriod);
            var upgradeTarget = submittedReports.Sum(o => ((MemberData)GetPropValue(o, dataPropertyName)).UpgradeTarget);
            var increased = submittedReports.Sum(o => ((MemberData)GetPropValue(o, dataPropertyName)).Increased);
            var decreased = submittedReports.Sum(o => ((MemberData)GetPropValue(o, dataPropertyName)).Decreased);

            return new MemberData(null, null, lastPeriod, upgradeTarget, increased, decreased, null, 0);

        }

        public static MeetingProgramData GetExpectedMeetingProgramData(UnitReport[] submittedReports, string dataPropertyName)
        {
            var target = submittedReports.Sum(o => ((MeetingProgramData)GetPropValue(o, dataPropertyName)).Target);
            var actual = submittedReports.Sum(o => ((MeetingProgramData)GetPropValue(o, dataPropertyName)).Actual);
            var averageAttendance = GetAverageMeetingProgramData(submittedReports, dataPropertyName);

            return new MeetingProgramData(target, null, actual, averageAttendance, null);
        }
        private static int GetAverageMeetingProgramData(UnitReport[] submittedReports, string dataPropertyName)
        {
            double averageInUnit = 0;
            if (submittedReports.Length > 0)
                averageInUnit = submittedReports
                    .Select(o =>
                    {
                        var field = ((MeetingProgramData)GetPropValue(o, dataPropertyName));
                        return field;
                    })
                    .ToArray()
                    .Average(o => o.AverageAttendance);
            return Convert.ToInt32(averageInUnit);
        }

        public static SocialWelfareData GetExpectedSocialWelfareData(UnitReport[] submittedReports, string dataPropertyName)
        {
            var target = submittedReports.Sum(o => ((SocialWelfareData)GetPropValue(o, dataPropertyName)).Target);
            var actual = submittedReports.Sum(o => ((SocialWelfareData)GetPropValue(o, dataPropertyName)).Actual);

            return new SocialWelfareData(target, null, actual, null);
        }

        public static MaterialData GetExpectedMaterialData(UnitReport[] submittedReports, string dataPropertyName)
        {
            var target = submittedReports.Sum(o => ((MaterialData)GetPropValue(o, dataPropertyName)).Target);
            var actual = submittedReports.Sum(o => ((MaterialData)GetPropValue(o, dataPropertyName)).Actual);

            return new MaterialData(target, null, actual, null);
        }

        public static LibraryStockData GetExpectedLibraryStockData(UnitReport[] submittedReports, string dataPropertyName)
        {
            var lastPeriod = submittedReports.Sum(o => ((LibraryStockData)GetPropValue(o, dataPropertyName)).LastPeriod);
            var increased = submittedReports.Sum(o => ((LibraryStockData)GetPropValue(o, dataPropertyName)).Increased);
            var decreased = submittedReports.Sum(o => ((LibraryStockData)GetPropValue(o, dataPropertyName)).Decreased);

            return new LibraryStockData(lastPeriod, increased, decreased, null);

        }

        public static FinanceData GetExpectedFinanceData(UnitReport[] submittedReports, string dataPropertyName)
        {
            var workerPromiseLastPeriod = submittedReports.Sum(o => ((FinanceData)GetPropValue(o, dataPropertyName)).WorkerPromiseLastPeriod.Amount);
            var workerPromiseIncreaseTarget = submittedReports.Sum(o => ((FinanceData)GetPropValue(o, dataPropertyName)).WorkerPromiseIncreaseTarget.Amount);
            var otherSourceIncreaseTarget = submittedReports.Sum(o => ((FinanceData)GetPropValue(o, dataPropertyName)).OtherSourceIncreaseTarget.Amount);
            var workerPromiseIncreased = submittedReports.Sum(o => ((FinanceData)GetPropValue(o, dataPropertyName)).WorkerPromiseIncreased.Amount);
            var workerPromiseDecreased = submittedReports.Sum(o => ((FinanceData)GetPropValue(o, dataPropertyName)).WorkerPromiseDecreased.Amount);
            var lastPeriod = submittedReports.Sum(o => ((FinanceData)GetPropValue(o, dataPropertyName)).LastPeriod.Amount);
            var collection = submittedReports.Sum(o => ((FinanceData)GetPropValue(o, dataPropertyName)).Collection.Amount);
            var expense = submittedReports.Sum(o => ((FinanceData)GetPropValue(o, dataPropertyName)).Expense.Amount);
            var nisabPaidToCentral = submittedReports.Sum(o => ((FinanceData)GetPropValue(o, dataPropertyName)).NisabPaidToCentral.Amount);

            return new FinanceData(null,
                new Money(workerPromiseIncreaseTarget),
                null,
                new Money(otherSourceIncreaseTarget),
                new Money(workerPromiseLastPeriod),
                new Money(collection),
                new Money(lastPeriod),
                new Money(expense),
                new Money(nisabPaidToCentral),
                new Money(workerPromiseIncreased),
                new Money(workerPromiseDecreased),
                null);

        }

    }
}