import { autoinject } from "aurelia-framework";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { ReportingPeriodViewModel } from "models/ReportingPeriodViewModel";
import { AppRouter } from "aurelia-router";
import { SignalrWrapper } from "signalrwrapper";
import { StatePlanViewModelDto } from "models/StatePlanViewModelDto";
import { StatePlanReportService } from "services/StatePlanReportService";
import { Subscription, EventAggregator } from "aurelia-event-aggregator";
import { StateReportUpdated } from "resources/plan-report-header/StateReportUpdated";
import { ReportingPeriodService } from "services/ReportingPeriodService";
import { AuthService } from "auth-service";

@autoinject
export class StatePlanCopy {
    planid: number;
    statePlan: StatePlanViewModelDto;
    reportingPeriods: ReportingPeriodViewModel[] = [];
    selectedReportingPeriod: ReportingPeriodViewModel;
    isCopyingPlan: boolean;

    signalreventhandlers: any = {};
    subscription: Subscription;
    constructor(public service: StatePlanReportService, public reportingPeriodService: ReportingPeriodService, public signalr: SignalrWrapper, 
        public router: AppRouter, public auth: AuthService, public ea?: EventAggregator) {
        this.signalreventhandlers = {
            "StatePlanCopied": this.onStatePlanCopied,
            "StatePlanCopyFailed": this.onStatePlanCopyFailed
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
        this.subscription = this.ea.subscribe(StateReportUpdated, _ => this.loadPlan());
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
        this.statePlan = await this.service.getPlan(this.planid);
        if(this.auth.isSystemAdmin) {
            const allReportingPeriods = await this.reportingPeriodService.getReportingPeriodsToCreatePlan(this.statePlan.organization.id);
            this.reportingPeriods = allReportingPeriods.filter(r => r.reportingFrequency === this.statePlan.reportingPeriod.reportingFrequency);
        } else {
            const nextReportingPeriod = await this.reportingPeriodService.getNextReportingPeriod(this.statePlan.id);
            this.reportingPeriods = [nextReportingPeriod];
        }
    }

    get headerData() {
        if(!this.statePlan) return undefined;
        return new PlanReportHeaderData("State Plan", this.planid, this.statePlan.description, this.statePlan.reportStatus, this.statePlan.organization);
    }

    copyPlan = async () => {
        try {
            await this.service.copy(this.statePlan.id, this.statePlan.organization, 
                this.selectedReportingPeriod.year, this.selectedReportingPeriod.reportingTerm, this.selectedReportingPeriod.reportingFrequency);
        } catch(error) {
            toastr.error(error);
            return;
        }
        this.isCopyingPlan = true;
    }

    onStatePlanCopied = (planid: number) => {
        toastr.success("Plan Copied");
        this.router.navigate(`state-plan-edit/${planid}`);
    }

    onStatePlanCopyFailed = (e: {$values: string[]}) => {
        this.isCopyingPlan = false;
        toastr.error(e.$values.join(", "));
    }
}