using FluentNHibernate.Mapping;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class TeachingLearningProgramPlanDataMap : ComponentMap<TeachingLearningProgramPlanData>
    {
        public TeachingLearningProgramPlanDataMap()
        {
            Map(x => x.Target);
            Map(x => x.DateAndAction);
        }
    }
}