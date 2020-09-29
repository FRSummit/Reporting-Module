import { autoinject } from "aurelia-framework";
import { ZoneReportViewModelDto } from "models/ZoneReportViewModelDto";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { Subscription, EventAggregator } from "aurelia-event-aggregator";
import { ZoneReportUpdated } from "resources/plan-report-header/ZoneReportUpdated";

@autoinject
export class ZoneReportView {
    reportid: number;
    zoneReport: ZoneReportViewModelDto;
    isDownloadingList = false;
    isDownloadingDetail = false;
    isResetting = false;
    isRecalculating = false;
    subscription: Subscription;
    constructor(public service: ZonePlanReportService, public ea?: EventAggregator) { }

    activate(params: {reportid: number}) {
        this.reportid = params.reportid;
    }

    async attached() {
        this.subscription = this.ea.subscribe(ZoneReportUpdated, _ => this.loadReport());;
        await this.loadReport();
    }

    detached() {
        this.subscription.dispose();
    }

    async loadReport() {
        this.zoneReport = await this.service.getReport(this.reportid);
    }

    get headerData() {
        if(!this.zoneReport) return undefined;
        return new PlanReportHeaderData("Zone Report", this.reportid, this.zoneReport.description, this.zoneReport.reportStatus, this.zoneReport.organization);
    }
}