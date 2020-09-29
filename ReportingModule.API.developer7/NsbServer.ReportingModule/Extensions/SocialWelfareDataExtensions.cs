using ReportingModule.ValueObjects;

namespace ReportingModule.Extensions
{
    public static class SocialWelfareDataExtensions
    {
        public static SocialWelfareData ToSocialWelfareData(this SocialWelfareData data, SocialWelfarePlanData planData)
        {
            return new SocialWelfareData(planData.Target,
                planData.DateAndAction,
                data.Actual,
                data.Comment);
        }

        public static SocialWelfareData ToSocialWelfareData(this SocialWelfareData data, SocialWelfareReportData reportData)
        {
            return new SocialWelfareData(data.Target,
                data.DateAndAction,
                reportData.Actual,
                reportData.Comment);
        }
    }
}