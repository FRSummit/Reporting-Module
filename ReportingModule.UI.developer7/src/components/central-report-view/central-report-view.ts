import { autoinject } from "aurelia-framework";
import { CentralReportViewModelDto } from "models/CentralReportViewModelDto";
import { CentralPlanReportService } from "services/CentralPlanReportService";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { EventAggregator, Subscription } from "aurelia-event-aggregator";
import { CentralReportUpdated } from "resources/plan-report-header/CentralReportUpdated";

@autoinject
export class CentralReportView {
    reportid: number;
    centralReport: CentralReportViewModelDto;
    isDownloadingList = false;
    isDownloadingDetail = false;
    isResetting = false;
    isRecalculating = false;
    subscription: Subscription;
    constructor(public service: CentralPlanReportService, public ea?: EventAggregator) {}

    activate(params: {reportid: number}) {
        this.reportid = params.reportid;
    }

    async attached() {
        this.subscription = this.ea.subscribe(CentralReportUpdated, _ => this.loadReport());
        await this.loadReport();
    }

    detached() {
        this.subscription.dispose();
    }

    async loadReport() {
        this.centralReport = await this.service.getReport(this.reportid);
    }
    
    get headerData() {
        if(!this.centralReport) return undefined;
        return new PlanReportHeaderData("Central Report", this.reportid, this.centralReport.description, this.centralReport.reportStatus, this.centralReport.organization);
    }
}