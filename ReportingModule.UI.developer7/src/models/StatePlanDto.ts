import { ReportStatus } from "./ReportStatus";
import { ReportingPeriod } from "./ReportingPeriod";
import { ReopenedReportStatus } from "./ReopenedReportStatus";
import { OrganizationReference } from "./OrganizationReference";
import { MemberPlanData } from "./MemberPlanData";
import { MeetingProgramPlanData } from "./MeetingProgramPlanData";
export class UnitPlanDto {
    constructor(public id: number,
        public description: string,
        public organization: OrganizationReference,
        public reportingPeriod: ReportingPeriod,
        public reportStatus: ReportStatus,
        public reportStatusDescription: string,
        public reOpenedReportStatus: ReopenedReportStatus,
        public reOpenedReportStatusDescription: string,
        public associateMemberPlanData: MemberPlanData,
        public preliminaryMemberPlanData: MemberPlanData,
        public workerMeetingProgramPlanData: MeetingProgramPlanData,
        public timestamp: Date) { }
}
