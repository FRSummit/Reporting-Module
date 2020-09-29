import { containerless, bindable, bindingMode } from "aurelia-framework";
import { OrganizationType } from "models/OrganizationType";

@containerless
export class OrganizationTypeSelectorCustomElement{
    typeOptions = [
        { id: OrganizationType.Central, name: "Central"},
        { id: OrganizationType.State, name: "State"},
        { id: OrganizationType.Zone, name: "Zone"},
        { id: OrganizationType.Unit, name: "Unit"}
    ];

    @bindable({ defaultBindingMode: bindingMode.twoWay }) excludeChooseOption: boolean;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) selectedType: OrganizationType;
}
