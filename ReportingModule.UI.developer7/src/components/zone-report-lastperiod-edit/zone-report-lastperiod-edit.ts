import { autoinject } from "aurelia-framework";
import { AppRouter } from "aurelia-router";
import * as toastr from "toastr";
import { SignalrWrapper } from "signalrwrapper";
import { MemberReportData } from "models/MemberReportData";
import { LibraryStockData } from "models/LibraryStockData";
import { FinanceReportData } from "models/FinanceReportData";
import { FinanceData } from "models/FinanceData";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { LibraryStockReportData } from "models/LibraryStockReportData";
import { ReportLastPeriodUpdateData } from "models/ReportLastPeriodUpdateData";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { ZoneReportViewModelDto } from "models/ZoneReportViewModelDto";

@autoinject
export class ZoneReportLastPeriodEdit {
    reportid: number;
    zoneReport: ZoneReportViewModelDto;
    isSaving = false;
    isCancelling = false;
    initialJson = "";

    signalreventhandlers: any = {};
    constructor(public service: ZonePlanReportService, public signalr: SignalrWrapper, public router: AppRouter) {
        this.signalreventhandlers = {
            "ZoneReportUpdated": this.onZoneReportUpdated,
            "ZoneReportUpdateFailed": this.onZoneReportUpdateFailed,
        };
    }

    activate(params: { reportid: number }) {
        this.reportid = params.reportid;
    }

    async attached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.on(key, this.signalreventhandlers[key]);
            }
        }
        await this.loadReport();
    }

    detached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
    }

    async loadReport() {
        this.zoneReport = await this.service.getReport(this.reportid);
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getReportLastPeriodUpdateData();
        this.initialJson = JSON.stringify(initialData);
    }

    getReportLastPeriodUpdateData(): ReportLastPeriodUpdateData {
        return new ReportLastPeriodUpdateData(
            this.makeMemberData(this.zoneReport.memberMemberData),
            this.makeMemberData(this.zoneReport.associateMemberData),
            this.makeMemberData(this.zoneReport.preliminaryMemberData),
            this.makeMemberData(this.zoneReport.supporterMemberData),
            this.makeFinanceReportData(this.zoneReport.baitulMalFinanceData),
            this.makeFinanceReportData(this.zoneReport.aDayMasjidProjectFinanceData),
            this.makeFinanceReportData(this.zoneReport.masjidTableBankFinanceData),
            this.makeLibraryStockReportData(this.zoneReport.bookLibraryStockData),
            this.makeLibraryStockReportData(this.zoneReport.vhsLibraryStockData),
            this.makeLibraryStockReportData(this.zoneReport.otherLibraryStockData)
        );
    }

    save = async () => {
      if (!this.isDirty) return;
        try {
            await this.service.updateReportLastPeriod(this.zoneReport.organization.id, this.reportid, this.getReportLastPeriodUpdateData());
        } catch (error) {
            toastr.error(error, "Error Saving Report");
            return;
        }
        this.isSaving = true;
    }    

    private makeMemberData(original: MemberReportData): MemberReportData {
        return new MemberReportData(original.lastPeriod, original.increased, original.decreased, original.comment, original.personalContact);
    }

    private makeLibraryStockReportData(original: LibraryStockData): LibraryStockReportData {
        return new LibraryStockReportData(original.lastPeriod, original.increased, original.decreased, original.comment);
    }

    private makeFinanceReportData(original: FinanceData): FinanceReportData {
        return new FinanceReportData(original.workerPromiseLastPeriod,
            original.lastPeriod,
            original.workerPromiseIncreased,
            original.workerPromiseDecreased,
            original.collection,
            original.expense,
            original.nisabPaidToCentral,
            original.comment);
    }

    get isDirty() {
        const latestJson = JSON.stringify(this.getReportLastPeriodUpdateData());
        return latestJson !== this.initialJson;
    }

    async cancelChanges() {
        this.isCancelling = true;
        await this.loadReport();
        this.isCancelling = false;
    }

    get canSave() {
        return this.isDirty && !this.isCancelling && !this.isSaving;
    }

    get canCancel() {
        return !this.isCancelling && !this.isSaving;
    }

    onZoneReportUpdated = async (id: number) => {
        this.isSaving = false;
        toastr.success("Report Saved");
        await this.loadReport();
    }

    onZoneReportUpdateFailed = (e: {$values: string[]}) => {
        this.isSaving = false;
        toastr.error(e.$values.join("\n"), "Error Saving Report");
    }

    get headerData() {
        if(!this.zoneReport) return undefined;
        return new PlanReportHeaderData("Zone Report", this.reportid, this.zoneReport.description, this.zoneReport.reportStatus, this.zoneReport.organization);
    }
}
