import { autoinject } from "aurelia-framework";
import { AppRouter } from "aurelia-router";
import * as toastr from "toastr";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { UnitReportViewModelDto } from "models/UnitReportViewModelDto";
import { SignalrWrapper } from "signalrwrapper";
import { MemberReportData } from "models/MemberReportData";
import { LibraryStockData } from "models/LibraryStockData";
import { FinanceReportData } from "models/FinanceReportData";
import { FinanceData } from "models/FinanceData";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { LibraryStockReportData } from "models/LibraryStockReportData";
import { ReportLastPeriodUpdateData } from "models/ReportLastPeriodUpdateData";

@autoinject
export class UnitReportLastPeriodEdit {
    reportid: number;
    unitReport: UnitReportViewModelDto;
    isSaving = false;
    isCancelling = false;
    initialJson = "";

    signalreventhandlers: any = {};
    constructor(public service: UnitPlanReportService, public signalr: SignalrWrapper, public router: AppRouter) {
        this.signalreventhandlers = {
            "UnitReportUpdated": this.onUnitReportUpdated,
            "UnitReportUpdateFailed": this.onUnitReportUpdateFailed
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
        this.unitReport = await this.service.getReport(this.reportid);
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getReportLastPeriodUpdateData();
        this.initialJson = JSON.stringify(initialData);
    }

    getReportLastPeriodUpdateData(): ReportLastPeriodUpdateData {
        return new ReportLastPeriodUpdateData(
            this.makeMemberData(this.unitReport.memberMemberData),
            this.makeMemberData(this.unitReport.associateMemberData),
            this.makeMemberData(this.unitReport.preliminaryMemberData),
            this.makeMemberData(this.unitReport.supporterMemberData),
            this.makeFinanceReportData(this.unitReport.baitulMalFinanceData),
            this.makeFinanceReportData(this.unitReport.aDayMasjidProjectFinanceData),
            this.makeFinanceReportData(this.unitReport.masjidTableBankFinanceData),
            this.makeLibraryStockReportData(this.unitReport.bookLibraryStockData),
            this.makeLibraryStockReportData(this.unitReport.vhsLibraryStockData),
            this.makeLibraryStockReportData(this.unitReport.otherLibraryStockData)
        );
    }

    save = async () => {
      if (!this.isDirty) return;
        try {
            await this.service.updateReportLastPeriod(this.unitReport.organization.id, this.reportid, this.getReportLastPeriodUpdateData());
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

    onUnitReportUpdated = async(id: number) => {
        this.isSaving = false;
        toastr.success("Report Saved");
        await this.loadReport();
    }

    onUnitReportUpdateFailed = (e: {$values: string[]}) => {
        this.isSaving = false;
        toastr.error(e.$values.join("\n"), "Error Saving Report");
    }

    get headerData() {
        if(!this.unitReport) return undefined;
        return new PlanReportHeaderData("Unit Report", this.reportid, this.unitReport.description, this.unitReport.reportStatus, this.unitReport.organization);
    }
}
