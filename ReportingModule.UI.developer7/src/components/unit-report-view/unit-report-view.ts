import { autoinject } from "aurelia-framework";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { UnitReportViewModelDto } from "models/UnitReportViewModelDto";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";

@autoinject
export class UnitReportView {
    reportid: number;
    unitReport: UnitReportViewModelDto;
    isDownloadingList = false;
    isDownloadingDetail = false;
    constructor(public service: UnitPlanReportService) {}

    activate(params: {reportid: number}) {
        this.reportid = params.reportid;
    }

    async attached() {
        await this.loadReport();
    }

    async loadReport() {
        this.unitReport = await this.service.getReport(this.reportid);
    }

    get headerData() {
        if(!this.unitReport) return undefined;
        return new PlanReportHeaderData("Unit Report", this.reportid, this.unitReport.description, this.unitReport.reportStatus, this.unitReport.organization);
    }
}