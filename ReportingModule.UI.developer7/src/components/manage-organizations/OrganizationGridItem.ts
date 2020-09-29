import { OrganizationType } from "models/OrganizationType";
import { ReportingFrequency } from "models/ReportingFrequency";
import { EntityReference } from "models/EntityReference";

export class OrganizationGridItem {
    constructor(public id: number, 
        public organizationType: OrganizationType,
        public organizationTypeDescription: string,
        public description: string,
        public reportingFrequency: ReportingFrequency,
        public reportingFrequencyDescription: string,
        public parent: EntityReference,
        public parentDescription: string,
        public timestamp: Date,
        public isDeleting: boolean,
        public isSysAdmin: boolean,
        public details?: string) { }
}