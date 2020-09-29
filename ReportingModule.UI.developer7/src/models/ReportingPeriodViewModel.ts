import { OrganizationReference } from "models/OrganizationReference";
import { ReportingFrequency } from "models/ReportingFrequency";
import { ReportingTerm } from "models/ReportingTerm";

export class ReportingPeriodViewModel {
    constructor(public organizationReference: OrganizationReference, 
        public year: number,
        public reportingFrequency: ReportingFrequency, 
        public reportingTerm: ReportingTerm, 
        public startDate: Date, 
        public endDate: Date, 
        public isActive: boolean) { }
}
