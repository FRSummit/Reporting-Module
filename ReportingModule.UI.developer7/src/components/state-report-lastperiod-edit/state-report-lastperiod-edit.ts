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
import { StatePlanReportService } from "services/StatePlanReportService";
import { StateReportViewModelDto } from "models/StateReportViewModelDto";
import { MemberData } from "models/MemberData";

@autoinject
export class StateReportLastPeriodEdit {
    reportid: number;
    stateReport: StateReportViewModelDto;
    isSaving = false;
    isCancelling = false;
    initialJson = "";

    signalreventhandlers: any = {};
    constructor(public service: StatePlanReportService, public signalr: SignalrWrapper, public router: AppRouter) {
        this.signalreventhandlers = {
            "StateReportUpdated": this.onStateReportUpdated,
            "StateReportUpdateFailed": this.onStateReportUpdateFailed,
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
        this.stateReport = await this.service.getReport(this.reportid);
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getReportLastPeriodUpdateData();
        this.initialJson = JSON.stringify(initialData);
    }

    getReportLastPeriodUpdateData(): ReportLastPeriodUpdateData {
        return new ReportLastPeriodUpdateData(
            this.makeMemberData(this.stateReport.memberMemberData),
            this.makeMemberData(this.stateReport.associateMemberData),
            this.makeMemberData(this.stateReport.preliminaryMemberData),
            this.makeMemberData(this.stateReport.supporterMemberData),
            this.makeFinanceReportData(this.stateReport.baitulMalFinanceData),
            this.makeFinanceReportData(this.stateReport.aDayMasjidProjectFinanceData),
            this.makeFinanceReportData(this.stateReport.masjidTableBankFinanceData),
            this.makeLibraryStockReportData(this.stateReport.bookLibraryStockData),
            this.makeLibraryStockReportData(this.stateReport.vhsLibraryStockData),
            this.makeLibraryStockReportData(this.stateReport.otherLibraryStockData)
        );
    }

    save = async () => {
      if (!this.isDirty) return;
        try {
            await this.service.updateReportLastPeriod(this.stateReport.organization.id, this.reportid, this.getReportLastPeriodUpdateData());
        } catch (error) {
            toastr.error(error, "Error Saving Report");
            return;
        }
        this.isSaving = true;
    }    

    private makeMemberData(original: MemberData): MemberReportData {
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

    onStateReportUpdated = async (id: number) => {
        this.isSaving = false;
        toastr.success("Report Saved");
        await this.loadReport();
    }

    onStateReportUpdateFailed = (e: {$values: string[]}) => {
        this.isSaving = false;
        toastr.error(e.$values.join("\n"), "Error Saving Report");
    }

    get headerData() {
        if(!this.stateReport) return undefined;
        return new PlanReportHeaderData("State Report", this.reportid, this.stateReport.description, this.stateReport.reportStatus, this.stateReport.organization);
    }
}
