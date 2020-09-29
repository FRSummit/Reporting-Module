import {autoinject} from "aurelia-framework";
import {AppRouter} from "aurelia-router";
import * as toastr from "toastr";
import {OrganizationType} from "models/OrganizationType";
import {OrganizationService} from "services/OrganizationService";
import {OrganizationViewModelDto} from "models/OrganizationViewModelDto";
import {SignalrWrapper} from "signalrwrapper";
import {EntityReference} from "models/EntityReference";
import { ReportingFrequency } from "models/ReportingFrequency";

@autoinject
export class OrganizationCreate { 
    description: string;
    details: string;
    selectedOrganizationType: OrganizationType;
    selectedReportingFrequency: ReportingFrequency;
    selectedOrganization: OrganizationViewModelDto;
    
    isCreatingOrganization = false;
    signalreventhandlers: any = {};
    
    isSearching = false;
    items: OrganizationViewModelDto[] = [];
    nodatafound = false;

    constructor(public organizationService: OrganizationService,
        public signalr: SignalrWrapper,
        public router: AppRouter) {
            this.signalreventhandlers = {
                "OrganizationCreated": this.onOrganizationCreated,
                "OrganizationCreateFailed": this.onOrganizationCreateFailed,
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

    createOrganization = async () => {
        try {
            await this.organizationService.create(this.description, this.details, this.selectedOrganizationType, this.selectedReportingFrequency, this.getOrganizationReference(this.selectedOrganization));
        } catch(error) {
            toastr.error(error);
            return;
        }
        this.isCreatingOrganization = true;
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

    onOrganizationCreated = (organizationid: number) => {
        this.isCreatingOrganization = false;
        toastr.success("Organization Created");
        this.router.navigate(`manage-organizations`);
    }

    onOrganizationCreateFailed = (e: {$values: string[]}) => {
        this.isCreatingOrganization = false;
        toastr.error(e.$values.join(", "));
    }
}
