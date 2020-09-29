import { autoinject } from "aurelia-framework";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { UnitPlanViewModelDto } from "models/UnitPlanViewModelDto";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { ReportingPeriodViewModel } from "models/ReportingPeriodViewModel";
import { AppRouter } from "aurelia-router";
import { SignalrWrapper } from "signalrwrapper";
import { ReportingPeriodService } from "services/ReportingPeriodService";
import { AuthService } from "auth-service";

@autoinject
export class UnitPlanCopy {
    planid: number;
    unitPlan: UnitPlanViewModelDto;
    reportingPeriods: ReportingPeriodViewModel[] = [];
    selectedReportingPeriod: ReportingPeriodViewModel;
    isCopyingPlan: boolean;

    signalreventhandlers: any = {};

    constructor(public service: UnitPlanReportService, public reportingPeriodService: ReportingPeriodService, 
        public signalr: SignalrWrapper, public router: AppRouter, public auth: AuthService) {
        this.signalreventhandlers = {
            "UnitPlanCopied": this.onUnitPlanCopied,
            "UnitPlanCopyFailed": this.onUnitPlanCopyFailed
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
        await this.loadPlan();
    }

    detached() {
        for(const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
    }

    async loadPlan() {
        this.unitPlan = await this.service.getPlan(this.planid);
        if (this.auth.isSystemAdmin) {
            const allReportingPeriods = await this.reportingPeriodService.getReportingPeriodsToCreatePlan(this.unitPlan.organization.id);
            this.reportingPeriods = allReportingPeriods.filter(r => r.reportingFrequency === this.unitPlan.reportingPeriod.reportingFrequency);
        } else {
            const nextReportingPeriod = await this.reportingPeriodService.getNextReportingPeriod(this.unitPlan.id);
            this.reportingPeriods = [nextReportingPeriod];
        }
    }

    get headerData() {
        if(!this.unitPlan) return undefined;
        return new PlanReportHeaderData("Unit Plan", this.planid, this.unitPlan.description, this.unitPlan.reportStatus, this.unitPlan.organization);
    }

    copyPlan = async () => {
        try {
            await this.service.copy(this.unitPlan.id, this.unitPlan.organization, 
                this.selectedReportingPeriod.year, this.selectedReportingPeriod.reportingTerm, this.selectedReportingPeriod.reportingFrequency);
        } catch(error) {
            toastr.error(error);
            return;
        }
        this.isCopyingPlan = true;
    }

    onUnitPlanCopied = (planid: number) => {
        toastr.success("Plan Copied");
        this.router.navigate(`unit-plan-edit/${planid}`);
    }

    onUnitPlanCopyFailed = (e: {$values: string[]}) => {
        this.isCopyingPlan = false;
        toastr.error(e.$values.join(", "));
    }
}