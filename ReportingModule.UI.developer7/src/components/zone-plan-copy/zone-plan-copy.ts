import { autoinject } from "aurelia-framework";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { ReportingPeriodViewModel } from "models/ReportingPeriodViewModel";
import { AppRouter } from "aurelia-router";
import { SignalrWrapper } from "signalrwrapper";
import { ZonePlanViewModelDto } from "models/ZonePlanViewModelDto";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { Subscription, EventAggregator } from "aurelia-event-aggregator";
import { ZoneReportUpdated } from "resources/plan-report-header/ZoneReportUpdated";
import { ReportingPeriodService } from "services/ReportingPeriodService";
import { AuthService } from "auth-service";

@autoinject
export class ZonePlanCopy {
    planid: number;
    zonePlan: ZonePlanViewModelDto;
    reportingPeriods: ReportingPeriodViewModel[] = [];
    selectedReportingPeriod: ReportingPeriodViewModel;
    isCopyingPlan: boolean;

    signalreventhandlers: any = {};
    subscription: Subscription;
    constructor(public service: ZonePlanReportService, public reportingPeriodService: ReportingPeriodService, public signalr: SignalrWrapper, 
        public router: AppRouter, public auth: AuthService, public ea?: EventAggregator) {
        this.signalreventhandlers = {
            "ZonePlanCopied": this.onZonePlanCopied,
            "ZonePlanCopyFailed": this.onZonePlanCopyFailed
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
        this.subscription = this.ea.subscribe(ZoneReportUpdated, _ => this.loadPlan());
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
        this.zonePlan = await this.service.getPlan(this.planid);
        if(this.auth.isSystemAdmin) {
        const allReportingPeriods = await this.reportingPeriodService.getReportingPeriodsToCreatePlan(this.zonePlan.organization.id);
        this.reportingPeriods = allReportingPeriods.filter(r => r.reportingFrequency === this.zonePlan.reportingPeriod.reportingFrequency);
        } else {
            const nextReportingPeriod = await this.reportingPeriodService.getNextReportingPeriod(this.zonePlan.id);
            this.reportingPeriods = [nextReportingPeriod];
        }
    }

    get headerData() {
        if(!this.zonePlan) return undefined;
        return new PlanReportHeaderData("Zone Plan", this.planid, this.zonePlan.description, this.zonePlan.reportStatus, this.zonePlan.organization);
    }

    copyPlan = async () => {
        try {
            await this.service.copy(this.zonePlan.id, this.zonePlan.organization, 
                this.selectedReportingPeriod.year, this.selectedReportingPeriod.reportingTerm, this.selectedReportingPeriod.reportingFrequency);
        } catch(error) {
            toastr.error(error);
            return;
        }
        this.isCopyingPlan = true;
    }

    onZonePlanCopied = (planid: number) => {
        toastr.success("Plan Copied");
        this.router.navigate(`zone-plan-edit/${planid}`);
    }

    onZonePlanCopyFailed = (e: {$values: string[]}) => {
        this.isCopyingPlan = false;
        toastr.error(e.$values.join(", "));
    }
}