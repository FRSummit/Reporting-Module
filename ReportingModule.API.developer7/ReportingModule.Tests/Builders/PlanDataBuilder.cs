//using ReportingModule.ValueObjects;
//using ReportingModule.Tests.Shared.Core.TestData;

//namespace ReportingModule.Tests.Builders
//{
//    public class PlanDataBuilder
//    {
//        private MemberPlanData _associateMemberPlanData = new TestObjectBuilder<MemberPlanData>().Build();

//        public PlanDataBuilder SetAssociateMemberPlanData(MemberPlanData associateMemberPlanData)
//        {
//            _associateMemberPlanData = associateMemberPlanData;
//            return this;
//        }

//        private MemberPlanData _preliminaryMemberPlanData = new TestObjectBuilder<MemberPlanData>().Build();

//        public PlanDataBuilder SetPreliminaryMemberPlanData(MemberPlanData preliminaryMemberPlanData)
//        {
//            _preliminaryMemberPlanData = preliminaryMemberPlanData;
//            return this;
//        }

//        private MeetingProgramPlanData _workerMeetingProgramPlanData = new TestObjectBuilder<MeetingProgramPlanData>().Build();

//        public PlanDataBuilder SetWorkerMeetingProgramPlanData(MeetingProgramPlanData workerMeetingPlanData)
//        {
//            _workerMeetingProgramPlanData = workerMeetingPlanData;
//            return this;
//        }

//        public PlanData Build()
//        {
//            var planData = new TestObjectBuilder<PlanData>()
//                .SetArgument(o => o.AssociateMemberPlanData, _associateMemberPlanData)
//                .SetArgument(o => o.PreliminaryMemberPlanData, _preliminaryMemberPlanData)
//                .SetArgument(o => o.WorkerMeetingProgramPlanData, _workerMeetingProgramPlanData)
//                .Build();
//            return planData;
//        }
//    }
//}