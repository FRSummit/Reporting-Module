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
import { CentralReportViewModelDto } from "models/CentralReportViewModelDto";
import { CentralPlanReportService } from "services/CentralPlanReportService";
import { MemberData } from "models/MemberData";

@autoinject
export class CentralReportLastPeriodEdit {
    reportid: number;
    centralReport: CentralReportViewModelDto;
    isSaving = false;
    isCancelling = false;
    initialJson = "";

    signalreventhandlers: any = {};
    constructor(public service: CentralPlanReportService, public signalr: SignalrWrapper, public router: AppRouter) {
        this.signalreventhandlers = {
            "CentralReportUpdated": this.onCentralReportUpdated,
            "CentralReportUpdateFailed": this.onCentralReportUpdateFailed
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
        this.centralReport = await this.service.getReport(this.reportid);
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getReportLastPeriodUpdateData();
        this.initialJson = JSON.stringify(initialData);
    }

    getReportLastPeriodUpdateData(): ReportLastPeriodUpdateData {
        return new ReportLastPeriodUpdateData(
            this.makeMemberData(this.centralReport.memberMemberData),
            this.makeMemberData(this.centralReport.associateMemberData),
            this.makeMemberData(this.centralReport.preliminaryMemberData),
            this.makeMemberData(this.centralReport.supporterMemberData),
            this.makeFinanceReportData(this.centralReport.baitulMalFinanceData),
            this.makeFinanceReportData(this.centralReport.aDayMasjidProjectFinanceData),
            this.makeFinanceReportData(this.centralReport.masjidTableBankFinanceData),
            this.makeLibraryStockReportData(this.centralReport.bookLibraryStockData),
            this.makeLibraryStockReportData(this.centralReport.vhsLibraryStockData),
            this.makeLibraryStockReportData(this.centralReport.otherLibraryStockData)
        );
    }

    save = async () => {
      if (!this.isDirty) return;
        try {
            await this.service.updateReportLastPeriod(this.centralReport.organization.id, this.reportid, this.getReportLastPeriodUpdateData());
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

    onCentralReportUpdated = async (id: number) => {
        this.isSaving = false;
        toastr.success("Report Saved");
        await this.loadReport();
    }

    onCentralReportUpdateFailed = (e: {$values: string[]}) => {
        this.isSaving = false;
        toastr.error(e.$values.join("\n"), "Error Saving Report");
    }

    get headerData() {
        if(!this.centralReport) return undefined;
        return new PlanReportHeaderData("Central Report", this.reportid, this.centralReport.description, this.centralReport.reportStatus, this.centralReport.organization);
    }
}
