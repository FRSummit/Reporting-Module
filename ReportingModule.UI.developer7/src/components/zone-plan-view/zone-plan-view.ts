import { autoinject } from "aurelia-framework";
import { ZonePlanViewModelDto } from "models/ZonePlanViewModelDto";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { Subscription, EventAggregator } from "aurelia-event-aggregator";
import { ZoneReportUpdated } from "resources/plan-report-header/ZoneReportUpdated";

@autoinject
export class ZonePlanView {
    planid: number;
    zonePlan: ZonePlanViewModelDto;
    subscription: Subscription;
    constructor(public service: ZonePlanReportService, public ea?: EventAggregator) {}
    
    activate(params: {planid: number}) {
        this.planid = params.planid;
    }

    async attached() {
        this.subscription = this.ea.subscribe(ZoneReportUpdated, _ => this.loadPlan());
        await this.loadPlan();
    }

    detached() {
        this.subscription.dispose();
    }
    
    async loadPlan() {
        this.zonePlan = await this.service.getPlan(this.planid);
    }

    get headerData() {
        if(!this.zonePlan) return undefined;
        return new PlanReportHeaderData("Zone Plan", this.planid, this.zonePlan.description, this.zonePlan.reportStatus, this.zonePlan.organization);
    }
}
