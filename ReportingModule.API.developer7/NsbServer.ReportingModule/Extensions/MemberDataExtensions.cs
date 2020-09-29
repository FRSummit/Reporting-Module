using ReportingModule.ValueObjects;

namespace ReportingModule.Extensions
{
    public static class MemberDataExtensions
    {
        public static MemberData ToMemberData(this MemberData data, MemberPlanData planData)
        {
            return new MemberData(planData.NameAndContactNumber,
                planData.Action,
                data.LastPeriod,
                planData.UpgradeTarget,
                data.Increased,
                data.Decreased,
                data.Comment,
                data.PersonalContact);
        }

        public static MemberData ToMemberData(this MemberData data, MemberReportData reportData)
        {
            return new MemberData(data.NameAndContactNumber,
                data.Action,
                reportData.LastPeriod,
                data.UpgradeTarget,
                reportData.Increased,
                reportData.Decreased,
                reportData.Comment,
                reportData.PersonalContact);
        }

        
    }
}
