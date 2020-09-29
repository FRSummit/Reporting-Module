import { OrganizationReference } from "models/OrganizationReference";
import { ReportingPeriod } from "models/ReportingPeriod";
import { ReportStatus } from "models/ReportStatus";
import { ReopenedReportStatus } from "models/ReopenedReportStatus";

export class ReportGridItem {
    constructor(public id: number, 
        public description: string, 
        public organization: OrganizationReference, 
        public reportingPeriod: ReportingPeriod,
        public reportStatus: ReportStatus,
        public reportStatusDescription: string,
        public reOpenedReportStatus: ReopenedReportStatus,
        public reOpenedReportStatusDescription: string,
        public timestamp: Date,
        public isDeleting: boolean,
        public isSysAdmin: boolean,
        public isUnSubmitting: boolean = false) { }

    get canCopy() {
        return this.isSysAdmin || this.reportStatus === ReportStatus.Submitted;
    }

    get canUnSubmit() {
        return this.isSysAdmin && this.reportStatus !== ReportStatus.Draft;
    }
}
