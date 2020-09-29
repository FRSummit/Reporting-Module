import { OrganizationReference } from "models/OrganizationReference";
import { ReportStatus } from "models/ReportStatus";
export class PlanReportHeaderData {
    constructor(public title: string, public id: number, public identifier: string, public status: ReportStatus, public organization: OrganizationReference) { }

    get organizationDetails() {
        return this.organization.details;
    }
}
