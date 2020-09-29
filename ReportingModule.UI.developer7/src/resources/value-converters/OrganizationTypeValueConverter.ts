import { OrganizationType } from "models/OrganizationType";

export class OrganizationTypeValueConverter {
    toView(value: OrganizationType) {
        return OrganizationType[value];
    }
}