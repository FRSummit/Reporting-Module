import {autoinject} from "aurelia-framework";
import {AppRouter} from "aurelia-router";
import * as toastr from "toastr";
import {OrganizationType} from "models/OrganizationType";
import {OrganizationRoleType} from "models/OrganizationRoleType";
import {OrganizationService} from "services/OrganizationService";
import {OrganizationViewModelDto} from "models/OrganizationViewModelDto";
import {SignalrWrapper} from "signalrwrapper";
import {EntityReference} from "models/EntityReference";
import { OrganizationUserService } from "services/OrganizationUserService";

@autoinject
export class OrganizationUserCreate { 
    username: string;
    selectedOrganizationRoleType: OrganizationRoleType;
    selectedOrganization: OrganizationViewModelDto;
    
    isCreatingOrganizationUser = false;
    signalreventhandlers: any = {};
    
    isSearching = false;
    items: OrganizationViewModelDto[] = [];
    nodatafound = false;

    constructor(public organizationService: OrganizationService,
        public organizationUserService: OrganizationUserService,
        public signalr: SignalrWrapper,
        public router: AppRouter) {
            this.signalreventhandlers = {
                "OrganizationUserCreated": this.onOrganizationUserCreated,
                "OrganizationUserCreateFailed": this.onOrganizationUserCreateFailed,
            };
        }

    async attached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.on(key, this.signalreventhandlers[key]);
            }
        }
        await this.search();
    }

    search = async () => {
        this.isSearching = true;
        const organizations  = await this.organizationService.myorganizations();
        this.isSearching = false;
        this.nodatafound = organizations.length == 0;
        this.items.splice(0, this.items.length);
        organizations.forEach(org => this.items.push(org));
        await this.afterSearching();
    }

    async afterSearching() {
        this.selectOrganization(undefined);
        let itemindex=-1;
        if(this.items.length === 1) {
          await this.selectOrganization(this.items[0]);
          return;
        }

        if((itemindex = this.items.findIndex(item => item.organizationType === OrganizationType.Central)) !== -1){
          await this.selectOrganization(this.items[itemindex]);
          return;
        }
        else if((itemindex = this.items.findIndex(item => item.organizationType === OrganizationType.State)) !== -1){
          await this.selectOrganization(this.items[itemindex]);
          return;
        }
        else if((itemindex = this.items.findIndex(item => item.organizationType === OrganizationType.Zone)) !== -1){
          await this.selectOrganization(this.items[itemindex]);
          return;
        }
        else if(this.items.length === 1) {
          await this.selectOrganization(this.items[0]);
          return;
        }
    }

    detached() {
        for(const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
    }

    createOrganizationUser = async () => {
        try {
            await this.organizationUserService.create(this.username, this.selectedOrganizationRoleType, this.getOrganizationReference(this.selectedOrganization));
        } catch(error) {
            toastr.error(error);
            return;
        }
        this.isCreatingOrganizationUser = true;
    }

    selectOrganization = async (item: OrganizationViewModelDto) => {
        this.selectedOrganization = item;
        await this.loadOrganizations();
    }

    loadOrganizations = async () => {
        if(!this.selectedOrganization) return;
    }

    getOrganizationReference(org: OrganizationViewModelDto) {
        return new EntityReference(org.id, org.description);
    }

    onOrganizationUserCreated = (organizationid: number) => {
        this.isCreatingOrganizationUser = false;
        toastr.success("Organization User Created");
        this.router.navigate(`manage-organization-users`);
    }

    onOrganizationUserCreateFailed = (e: {$values: string[]}) => {
        this.isCreatingOrganizationUser = false;
        toastr.error(e.$values.join(", "));
    }
}
