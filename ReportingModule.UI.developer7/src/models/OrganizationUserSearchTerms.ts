import { PagedSearchTerms } from "./PagedSearchTerms";
import { OrganizationType } from "./OrganizationType";

export class OrganizationUserSearchTerms extends PagedSearchTerms {
    constructor(public quickSearch?: string,
        page: number = 1,
        pageSize: number = 10) {
        super(page, pageSize);
    }
    toQry(): string {
        const terms = [];
        if (this.quickSearch) {
            terms.push(`quickSearch=${encodeURIComponent(this.quickSearch)}`);
        }
        terms.push(super.toQry());
        return terms.join("&");
    }
}
