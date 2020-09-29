import { containerless, bindable, bindingMode } from "aurelia-framework";
import { OrganizationRoleType } from "models/OrganizationRoleType";

@containerless
export class OrganizationRoleTypeSelectorCustomElement {
    roleTypeOptions = [
        { id: OrganizationRoleType.Admin, name: "Admin" },
        { id: OrganizationRoleType.User, name: "User" },

    ];

    @bindable({ defaultBindingMode: bindingMode.twoWay }) excludeChooseOption: boolean;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) selectedRoleType: OrganizationRoleType;
}
