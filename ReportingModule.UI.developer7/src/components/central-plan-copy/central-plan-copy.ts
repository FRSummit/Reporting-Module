import { autoinject } from "aurelia-framework";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { ReportingPeriodViewModel } from "models/ReportingPeriodViewModel";
import { AppRouter } from "aurelia-router";
import { SignalrWrapper } from "signalrwrapper";
import { CentralPlanViewModelDto } from "models/CentralPlanViewModelDto";
import { CentralPlanReportService } from "services/CentralPlanReportService";
import { EventAggregator, Subscription } from "aurelia-event-aggregator";
import { CentralReportUpdated } from "resources/plan-report-header/CentralReportUpdated";
import { ReportingPeriodService } from "services/ReportingPeriodService";
import { AuthService } from "auth-service";

@autoinject
export class CentralPlanCopy {
    planid: number;
    centralPlan: CentralPlanViewModelDto;
    reportingPeriods: ReportingPeriodViewModel[] = [];
    selectedReportingPeriod: ReportingPeriodViewModel;
    isCopyingPlan: boolean;

    signalreventhandlers: any = {};
    subscription: Subscription;
    constructor(public service: CentralPlanReportService, public reportingPeriodService: ReportingPeriodService, public signalr: SignalrWrapper, 
        public router: AppRouter, public auth: AuthService, public ea: EventAggregator) {
        this.signalreventhandlers = {
            "CentralPlanCopied": this.onCentralPlanCopied,
            "CentralPlanCopyFailed": this.onCentralPlanCopyFailed
        };
    }
    
    activate(params: {planid: number}) {
        this.planid = params.planid;
    }

    async attached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.on(key, this.signalreventhandlers[key]);
            }
        }
        this.subscription = this.ea.subscribe(CentralReportUpdated, _ => this.loadPlan());
        await this.loadPlan();
    }

    detached() {
        for(const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
        this.subscription.dispose();
    }

    async loadPlan() {
        this.centralPlan = await this.service.getPlan(this.planid);
        if(this.auth.isSystemAdmin) {
            const allReportingPeriods = await this.reportingPeriodService.getReportingPeriodsToCreatePlan(this.centralPlan.organization.id);
            this.reportingPeriods = allReportingPeriods.filter(r => r.reportingFrequency === this.centralPlan.reportingPeriod.reportingFrequency);
        } else {
            const nextReportingPeriod = await this.reportingPeriodService.getNextReportingPeriod(this.centralPlan.id);
            this.reportingPeriods = [nextReportingPeriod];
        }
    }

    get headerData() {
        if(!this.centralPlan) return undefined;
        return new PlanReportHeaderData("Central Plan", this.planid, this.centralPlan.description, this.centralPlan.reportStatus, this.centralPlan.organization);
    }

    copyPlan = async () => {
        try {
            await this.service.copy(this.centralPlan.id, this.centralPlan.organization, 
                this.selectedReportingPeriod.year, this.selectedReportingPeriod.reportingTerm, this.selectedReportingPeriod.reportingFrequency);
        } catch(error) {
            toastr.error(error);
            return;
        }
        this.isCopyingPlan = true;
    }

    onCentralPlanCopied = (planid: number) => {
        toastr.success("Plan Copied");
        this.router.navigate(`central-plan-edit/${planid}`);
    }

    onCentralPlanCopyFailed = (e: {$values: string[]}) => {
        this.isCopyingPlan = false;
        toastr.error(e.$values.join(", "));
    }
}