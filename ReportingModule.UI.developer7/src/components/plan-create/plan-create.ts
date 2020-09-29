import {autoinject} from "aurelia-framework";
import {AppRouter} from "aurelia-router";
import * as toastr from "toastr";
import {OrganizationType} from "models/OrganizationType";
import {OrganizationService} from "services/OrganizationService";
import {OrganizationViewModelDto} from "models/OrganizationViewModelDto";
import {StatePlanReportService} from "services/StatePlanReportService";
import {UnitPlanReportService} from "services/UnitPlanReportService";
import {SignalrWrapper} from "signalrwrapper";
import {OrganizationReference} from "models/OrganizationReference";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { CentralPlanReportService } from "services/CentralPlanReportService";
import { ReportingPeriodViewModel } from "models/ReportingPeriodViewModel";
import { ReportingPeriodService } from "services/ReportingPeriodService";

@autoinject
export class PlanCreate { 
    selectedOrganization: OrganizationViewModelDto;
    reportingPeriods: ReportingPeriodViewModel[] = [];
    selectedReportingPeriod: ReportingPeriodViewModel;

    isCreatingPlan = false;
    signalreventhandlers: any = {};
    
    isSearching = false;
    items: OrganizationViewModelDto[] = [];
    nodatafound = false;

    constructor(public organizationService: OrganizationService,
        public unitPlanReportService: UnitPlanReportService,
        public statePlanReportService: StatePlanReportService,
        public zonePlanReportService: ZonePlanReportService,
        public centralPlanReportService: CentralPlanReportService,
        public reportingPeriodService: ReportingPeriodService,
        public signalr: SignalrWrapper,
        public router: AppRouter) {
            this.signalreventhandlers = {
                "UnitPlanCreated": this.onUnitPlanCreated,
                "UnitPlanCreateFailed": this.onUnitPlanCreateFailed,
                "ZonePlanCreated": this.onZonePlanCreated,
                "ZonePlanCreateFailed": this.onZonePlanCreateFailed,
                "StatePlanCreated": this.onStatePlanCreated,
                "StatePlanCreateFailed": this.onStatePlanCreateFailed,
                "CentralPlanCreated": this.onCentralPlanCreated,
                "CentralPlanCreateFailed": this.onCentralPlanCreateFailed
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
    
    getOrganizationServiceForSelectedOrganization() : UnitPlanReportService | StatePlanReportService | ZonePlanReportService | CentralPlanReportService {
        if(this.selectedOrganization.organizationType === OrganizationType.State) {
            return this.statePlanReportService;
        }
        else if(this.selectedOrganization.organizationType == OrganizationType.Unit)
        {
            return this.unitPlanReportService;
        }
        else if(this.selectedOrganization.organizationType == OrganizationType.Zone)
        {
            return this.zonePlanReportService;
        }
        else if(this.selectedOrganization.organizationType == OrganizationType.Central)
        {
            return this.centralPlanReportService;
        }
        else throw new Error("Not Implemented");
    }

    createPlan = async () => {
        try {
            const orgService = this.getOrganizationServiceForSelectedOrganization();
            await orgService.createPlan2(this.getOrganizationReference(this.selectedOrganization, this.selectedReportingPeriod), 
                this.selectedReportingPeriod.year, this.selectedReportingPeriod.reportingTerm, this.selectedReportingPeriod.reportingFrequency);
        } catch(error) {
            toastr.error(error);
            return;
        }
        this.isCreatingPlan = true;
    }

    selectOrganization = async (item: OrganizationViewModelDto) => {
        this.reportingPeriods = [];
        this.selectedOrganization = item;
        await this.loadOrganizationReportingPeriods();
    }

    loadOrganizationReportingPeriods = async () => {
        if(!this.selectedOrganization) return;
        this.reportingPeriods = await this.reportingPeriodService.getReportingPeriodsToCreatePlan(this.selectedOrganization.id);
        console.log('reportingPeriods');
        console.log(this.reportingPeriods);
    }

    getOrganizationReference(org: OrganizationViewModelDto, selectedReportingPeriod: ReportingPeriodViewModel) {
        return new OrganizationReference(org.id, org.organizationType, org.description, selectedReportingPeriod.reportingFrequency, org.details);
    }

    onUnitPlanCreated = (planid: number) => {
        toastr.success("Plan Created");
        this.router.navigate(`unit-plan-edit/${planid}`);
    }

    onUnitPlanCreateFailed = (e: {$values: string[]}) => {
        this.isCreatingPlan = false;
        toastr.error(e.$values.join(", "));
    }

    onZonePlanCreated = (planid: number) => {
        toastr.success("Plan Created");
        this.router.navigate(`zone-plan-edit/${planid}`);
    }

    onZonePlanCreateFailed = (e: {$values: string[]}) => {
        this.isCreatingPlan = false;
        toastr.error(e.$values.join(", "));
    }

    onStatePlanCreated = (planid: number) => {
        toastr.success("Plan created");
        this.router.navigate(`state-plan-edit/${planid}`);
    }

    onStatePlanCreateFailed = (e: {$values: string[]}) => {
        this.isCreatingPlan = false;
        toastr.error(e.$values.join(", "));
    }

    onCentralPlanCreated = (planid: number) => {
        toastr.success("Plan created");
        this.router.navigate(`central-plan-edit/${planid}`);
    }

    onCentralPlanCreateFailed = (e: {$values: string[]}) => {
        this.isCreatingPlan = false;
        toastr.error(e.$values.join(", "));
    }
}
