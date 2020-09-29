import { autoinject } from "aurelia-framework";
import {StatePlanReportService} from "../../services/StatePlanReportService";
import {StatePlanViewModelDto} from "../../models/StatePlanViewModelDto";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { Subscription, EventAggregator } from "aurelia-event-aggregator";
import { StateReportUpdated } from "resources/plan-report-header/StateReportUpdated";

@autoinject
export class StatePlanView {
    planid: number;
    statePlan: StatePlanViewModelDto;
    subscription: Subscription;
    constructor(public service: StatePlanReportService, public ea?: EventAggregator) {}
    
    activate(params: {planid: number}) {
        this.planid = params.planid;
    }

    async attached() {
        this.subscription = this.ea.subscribe(StateReportUpdated, _ => this.loadPlan());
        await this.loadPlan();
    }

    detached() {
        this.subscription.dispose();
    }
    
    async loadPlan() {
        this.statePlan = await this.service.getPlan(this.planid);
    }

    get headerData() {
        if(!this.statePlan) return undefined;
        return new PlanReportHeaderData("State Plan", this.planid, this.statePlan.description, this.statePlan.reportStatus, this.statePlan.organization);
    }
}
