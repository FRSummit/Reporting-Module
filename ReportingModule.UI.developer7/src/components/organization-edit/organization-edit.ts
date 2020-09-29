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
export class OrganizationEdit { 
    organizationId: number;
    organization: OrganizationViewModelDto;
    description: string;
    details: string;
    selectedOrganizationType: OrganizationType;
    selectedReportingFrequency: ReportingFrequency;
    selectedOrganization: OrganizationViewModelDto;
    
    isUpdatingOrganization = false;
    signalreventhandlers: any = {};
    
    isSearching = false;
    items: OrganizationViewModelDto[] = [];
    nodatafound = false;

    constructor(public organizationService: OrganizationService,
        public signalr: SignalrWrapper,
        public router: AppRouter) {
            this.signalreventhandlers = {
                "OrganizationUpdated": this.onOrganizationUpdated,
                "OrganizationUpdateFailed": this.onOrganizationUpdateFailed,
            };
        }

          
    activate(params: {organizationId: number}) {
         this.organizationId = params.organizationId;
    }

    async attached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.on(key, this.signalreventhandlers[key]);
            }
        }
        await this.search();
        await this.loadOrganization();
        
    }

    detached() {
        for(const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
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

    async loadOrganization() {
        const organization = await this.organizationService.getOrganization(this.organizationId);
        const parent = await this.organizationService.getOrganization(organization.parent.id);
        this.organization = organization;
        this.description = organization.description;
        this.details = organization.details;
        this.selectedOrganizationType= organization.organizationType;
        this.selectedReportingFrequency= organization.reportingFrequency;
        this.selectedOrganization = parent;    
    }

    async reload() {
        await this.search();
        await this.loadOrganization();    
    }

    async save() {
          try {
            await this.organizationService.update(this.organization.id, this.description, this.details, this.selectedOrganizationType, this.selectedReportingFrequency, this.getOrganizationReference(this.selectedOrganization));
        
          } catch(error) {
              toastr.error(error, "Error Saving Organization");
              return;
          }

          this.isUpdatingOrganization = true;
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

    onOrganizationUpdated = (organizationId: number) => {
        this.isUpdatingOrganization = false;
        toastr.success("Organization Updated");
        this.reload();
    }

    onOrganizationUpdateFailed = (e: {$values: string[]}) => {
        this.isUpdatingOrganization = false;
        toastr.error(e.$values.join(", "));
    }
}
