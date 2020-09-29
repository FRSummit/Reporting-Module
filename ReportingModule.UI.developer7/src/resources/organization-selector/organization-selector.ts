import { containerless, bindable, bindingMode } from "aurelia-framework";
import { OrganizationReference } from "models/OrganizationReference";
import { OrganizationService } from "services/OrganizationService";
import { OrganizationViewModelDto } from "models/OrganizationViewModelDto";

@containerless
export class OrganizationSelectorCustomElement{
    organizations:OrganizationViewModelDto[] = [];
    constructor(public organizationService: OrganizationService){
        this.organizationService.myorganizations().then(orgs => { 
            orgs.forEach(o => this.organizations.push(o));
        });
    }

    @bindable({ defaultBindingMode: bindingMode.twoWay }) excludeChooseOption: boolean;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) selectedOrganization: OrganizationReference;
}
