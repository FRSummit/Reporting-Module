import { autoinject } from "aurelia-framework";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { UnitPlanViewModelDto } from "models/UnitPlanViewModelDto";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";

@autoinject
export class UnitPlanView {
    planid: number;
    unitPlan: UnitPlanViewModelDto;
    constructor(public service: UnitPlanReportService) {}
    
    activate(params: {planid: number}) {
        this.planid = params.planid;
    }

    async attached() {
        await this.loadPlan();
    }

    async loadPlan() {
        this.unitPlan = await this.service.getPlan(this.planid);
    }

    get headerData() {
        if(!this.unitPlan) return undefined;
        return new PlanReportHeaderData("Unit Plan", this.planid, this.unitPlan.description, this.unitPlan.reportStatus, this.unitPlan.organization);
    }
}