using ReportingModule.ValueObjects;

namespace ReportingModule.Extensions
{
    public static class MeetingProgramDataExtensions
    {
        public static MeetingProgramData ToMeetingProgramData(this MeetingProgramData data, MeetingProgramPlanData planData)
        {
            return new MeetingProgramData(planData.Target,
                planData.DateAndAction,
                data.Actual,
                data.AverageAttendance,
                data.Comment);
        }

        public static MeetingProgramData ToMeetingProgramData(this MeetingProgramData data, MeetingProgramReportData reportData)
        {
            return new MeetingProgramData(data.Target,
                data.DateAndAction,
                reportData.Actual,
                reportData.AverageAttendance,
                reportData.Comment);
        }
    }
}