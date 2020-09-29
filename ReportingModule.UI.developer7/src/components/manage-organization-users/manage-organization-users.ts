import { inject, autoinject } from "aurelia-framework";
import $ from "jquery";
import moment from "moment";
import { OrganizationUserService } from "../../services/OrganizationUserService";
import { OrganizationUserSearchTerms } from "models/OrganizationUserSearchTerms";
import { OrganizationUserViewModelDto } from "models/OrganizationUserViewModelDto";
import { Grid } from "resources/grid/grid";
import { EntityReference } from "models/EntityReference";
import { AuthService } from "auth-service";
import { SignalrWrapper } from "signalrwrapper";

@autoinject
export class ManageOrganizationUsers {
    organizationUserSearchTerms = new OrganizationUserSearchTerms(undefined, 1, 10);
    grid: Grid<OrganizationUserViewModelDto, OrganizationUserGridItem>;
    signalreventhandlers: any = {};


    constructor(public organizationUserService: OrganizationUserService,
        public signalr: SignalrWrapper,
        public authService: AuthService) {
        
        this.signalreventhandlers = {
            "OrganizationUserDeleted": this.onOrganizationUserDeleted,
            "OrganizationUserDeleteFailed": this.onOrganizationUserDeleteFailed
        };

        this.grid = new Grid<OrganizationUserViewModelDto, OrganizationUserGridItem>(this.organizationUserSearchTerms,
            this.organizationUserService.search,  this.mapDtoToGridItem);
            
    }

    async attached() {
        const options: any = {
            locale: {
                format: 'DD/M/YYYY hh:mm:ss A'
            },
            minYear: 2019,
            autoUpdateInput: false, // initially empty
            showDropdowns: true,
            timePicker: true,
            timePickerSeconds: true,
            singleDatePicker: true
        };

        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.on(key, this.signalreventhandlers[key]);
            }
        }
        
        await this.grid.search();
    }

    detached() {
        for(const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
    }

    mapDtoToGridItem = (dto: OrganizationUserViewModelDto) => {
        return new OrganizationUserGridItem(
            dto.id,
            dto.username,
            dto.role,
            dto.organization,
            dto.timestamp,
            false,
            this.authService ? this.authService.isSystemAdmin : false
        );

    }

    get canDelete() {
        return this.authService.isSystemAdmin == true;
    }

    async delete(item: OrganizationUserGridItem) {
        await this.organizationUserService.delete(item.id);
        item.isDeleting = true;
        return;
    }

    onOrganizationUserDeleted = (organizationUserId: number) => {
        const deletedItemIndex = this.grid.items.findIndex(item => item.id === organizationUserId);
        if (deletedItemIndex !== -1) {
            this.grid.items[deletedItemIndex].isDeleting = false;
            this.grid.items.splice(deletedItemIndex, 1);
        }
        toastr.success("Deleted successfully");
    }

    onOrganizationUserDeleteFailed = (e: { $values: string[] }) => {
        toastr.error(e.$values.join(", "));
    }
}

export class OrganizationUserGridItem {
    constructor(public id: number, 
        public username: string,
        public role: string,
        public organization: EntityReference,
        public timestamp: Date,
        public isDeleting: boolean,
        public isSysAdmin: boolean) { }
}
