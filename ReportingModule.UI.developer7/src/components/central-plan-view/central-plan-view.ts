import { autoinject } from "aurelia-framework";
import { CentralPlanViewModelDto } from "models/CentralPlanViewModelDto";
import { CentralPlanReportService } from "services/CentralPlanReportService";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { EventAggregator, Subscription } from "aurelia-event-aggregator";
import { CentralReportUpdated } from "resources/plan-report-header/CentralReportUpdated";


@autoinject
export class CentralPlanView {
    planid: number;
    centralPlan: CentralPlanViewModelDto;
    subscription: Subscription;
    constructor(public service: CentralPlanReportService, public ea: EventAggregator) {}
    
    activate(params: {planid: number}) {
        this.planid = params.planid;
    }

    async attached() {
        this.subscription = this.ea.subscribe(CentralReportUpdated, _ => this.loadPlan());
        await this.loadPlan();
    }

    detached() {
        this.subscription.dispose();
    }

    async loadPlan() {
        this.centralPlan = await this.service.getPlan(this.planid);
    }

    get headerData() {
        if(!this.centralPlan) return undefined;
        return new PlanReportHeaderData("Central Plan", this.planid, this.centralPlan.description, this.centralPlan.reportStatus, this.centralPlan.organization);
      }
}
