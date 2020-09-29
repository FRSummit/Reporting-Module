import { inject, autoinject } from "aurelia-framework";
import $ from "jquery";
import moment from "moment";
import { OrganizationService } from "../../services/OrganizationService";
import { OrganizationSearchTerms } from "models/OrganizationSearchTerms";
import { OrganizationViewModelDto } from "models/OrganizationViewModelDto";
import { OrganizationGridItem } from "./OrganizationGridItem";
import { Grid } from "resources/grid/grid";
import { AuthService } from "auth-service";
import { SignalrWrapper } from "signalrwrapper";


@autoinject
export class ManageOrganizations {
    organizationSearchTerms = new OrganizationSearchTerms(undefined, undefined, 1, 10);
    grid: Grid<OrganizationViewModelDto, OrganizationGridItem>;
    signalreventhandlers: any = {};

    constructor(public organizationService: OrganizationService,
        public signalr: SignalrWrapper,
        public authService: AuthService) {
        this.signalreventhandlers = {
            "OrganizationDeleted": this.onOrganizationDeleted,
            "OrganizationDeleteFailed": this.onOrganizationDeleteFailed
        };

        this.grid = new Grid<OrganizationViewModelDto, OrganizationGridItem>(this.organizationSearchTerms,
            this.organizationService.search, this.mapDtoToGridItem);
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

    mapDtoToGridItem = (dto: OrganizationViewModelDto) => {
        return new OrganizationGridItem(
            dto.id,
            dto.organizationType,
            dto.organizationTypeDescription,
            dto.description,
            dto.reportingFrequency,
            dto.reportingFrequencyDescription,
            dto.parent,
            dto.parentDescription,
            dto.timestamp,
            false,
            this.authService ? this.authService.isSystemAdmin : false,
            dto.details
        );
    }
    
    get canDelete() {
        return this.authService.isSystemAdmin == true;
    }

    async delete(item: OrganizationGridItem) {
        await this.organizationService.delete(item.id);
        item.isDeleting = true;
        return;
    }

    onOrganizationDeleted = (organizationId: number) => {
        const deletedItemIndex = this.grid.items.findIndex(item => item.id === organizationId);
        if (deletedItemIndex !== -1) {
            this.grid.items[deletedItemIndex].isDeleting = false;
            this.grid.items.splice(deletedItemIndex, 1);
        }
        toastr.success("Deleted successfully");
    }

    onOrganizationDeleteFailed = (e: { $values: string[] }) => {
        toastr.error(e.$values.join(", "));
    }
}
