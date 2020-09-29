using ReportingModule.ValueObjects;

namespace ReportingModule.Extensions
{
    public static class TeachingLearningProgramDataExtensions
    {
        public static TeachingLearningProgramData ToTeachingLearningProgramData(this TeachingLearningProgramData data, TeachingLearningProgramPlanData planData)
        {
            return new TeachingLearningProgramData(planData.Target,
                planData.DateAndAction,
                data.Actual,
                data.AverageAttendance,
                data.Comment);
        }

        public static TeachingLearningProgramData ToTeachingLearningProgramData(this TeachingLearningProgramData data, TeachingLearningProgramReportData reportData)
        {
            return new TeachingLearningProgramData(data.Target,
                data.DateAndAction,
                reportData.Actual,
                reportData.AverageAttendance,
                reportData.Comment);
        }
    }
}