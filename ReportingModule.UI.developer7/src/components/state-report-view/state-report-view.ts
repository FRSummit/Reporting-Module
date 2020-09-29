import { autoinject } from "aurelia-framework";
import { StatePlanReportService } from "services/StatePlanReportService";
import { StateReportViewModelDto } from "models/StateReportViewModelDto";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { Subscription, EventAggregator } from "aurelia-event-aggregator";
import { StateReportUpdated } from "resources/plan-report-header/StateReportUpdated";

@autoinject
export class StateReportView {
    reportid: number;
    stateReport: StateReportViewModelDto;
    isDownloadingList = false;
    isDownloadingDetail = false;
    isResetting = false;
    isRecalculating = false;
    subscription: Subscription;
    constructor(public service: StatePlanReportService, public ea?: EventAggregator) { }

    activate(params: {reportid: number}) {
        this.reportid = params.reportid;
    }

    async attached() {
        this.subscription = this.ea.subscribe(StateReportUpdated, _ => this.loadReport());
        await this.loadReport();
    }

    detached() {
        this.subscription.dispose();
    }

    async loadReport() {
        this.stateReport = await this.service.getReport(this.reportid);
    }

    get headerData() {
        if(!this.stateReport) return undefined;
        return new PlanReportHeaderData("State Report", this.reportid, this.stateReport.description, this.stateReport.reportStatus, this.stateReport.organization);
    }
}