import { inject, autoinject, NewInstance } from "aurelia-framework";
import $ from "jquery";
import * as moment from "moment";
import * as toastr from "toastr";
import { saveAs } from "file-saver";
import { AllReportService } from "../../services/AllReportsService";
import { ReportSearchTerms } from "models/ReportSearchTerms";
import { ReportViewModelDto } from "models/ReportViewModelDto";
import { Grid } from "resources/grid/grid";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { StatePlanReportService } from "services/StatePlanReportService";
import { CentralPlanReportService } from "services/CentralPlanReportService";
import { OrganizationType } from "models/OrganizationType";
import { SignalrWrapper } from "signalrwrapper";
import { ReportGridItem } from "./ReportGridItem";
import { AuthService } from "auth-service";
import { BrowserStorage } from "../../utils/browserStorage";



@inject(
    AllReportService,
    UnitPlanReportService,
    ZonePlanReportService,
    StatePlanReportService,
    CentralPlanReportService,
    SignalrWrapper,
    AuthService,
    NewInstance.of(BrowserStorage, ["PlansAndReports"]))
export class PlansAndReports {
    private storage: BrowserStorage;
    private searchStorageKey: string = "searchTerms";
    private reportSearchTerms: ReportSearchTerms;
    grid: Grid<ReportViewModelDto, ReportGridItem>;

    timestampFromElement: HTMLElement;
    timestampToElement: HTMLElement;
    reportingPeriodStartDateFromElement: HTMLElement;
    reportingPeriodEndDateToElement: HTMLElement;

    isDownloading = false;
    isReset = false;
    signalreventhandlers: any = {};
    constructor(public allReportService: AllReportService,
        public unitPlanReportService: UnitPlanReportService,
        public zonePlanReportService: ZonePlanReportService,
        public statePlanReportService: StatePlanReportService,
        public centralPlanReportService: CentralPlanReportService,
        public signalr: SignalrWrapper,
        public authService: AuthService,
        storage: BrowserStorage) {
        this.signalreventhandlers = {
            "ReportDeleted": this.onReportDeleted,
            "ReportDeleteFailed": this.onReportDeleteFailed,
            "ReportUnSubmitted": this.onReportUnSubmitted,
            "ReportUnSubmitFailed": this.onReportUnSubmitFailed
        };

        this.storage = storage;
        this.reportSearchTerms = new ReportSearchTerms(this.storage.get(this.searchStorageKey))

        this.grid = new Grid<ReportViewModelDto, ReportGridItem>(this.reportSearchTerms,
            this.allReportService.search, this.mapDtoToGridItem);

    }

    mapDtoToGridItem = (dto: ReportViewModelDto) => {
        return new ReportGridItem(
            dto.id,
            dto.description,
            dto.organization,
            dto.reportingPeriod,
            dto.reportStatus,
            dto.reportStatusDescription,
            dto.reOpenedReportStatus,
            dto.reOpenedReportStatusDescription,
            dto.timestamp,
            false,
            this.authService ? this.authService.isSystemAdmin : false
        );
    }

    async attached() {
        const options: any = {
            locale: {
                format: 'DD/M/YYYY hh:mm:ss A'
            },
            minYear: 2019,
            autoUpdateInput: false, // initially empty
            showDropdowns: true,
            timePicker: true,
            timePickerSeconds: true,
            singleDatePicker: true
        };
        $(this.timestampFromElement).daterangepicker(options, this.setFromDate);
        $(this.timestampToElement).daterangepicker(options, this.setToDate);

        $(this.reportingPeriodStartDateFromElement).daterangepicker(options, this.setReportingPeriodStartDateFrom);
        $(this.reportingPeriodEndDateToElement).daterangepicker(options, this.setReportingPeriodEndDateTo);
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.on(key, this.signalreventhandlers[key]);
            }
        }
        await this.grid.search();
    }

    detached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
    }

    setFromDate = (timestamp: moment.Moment) => {
        this.reportSearchTerms.timestampFrom = timestamp.toDate();
        $(this.timestampFromElement).val(timestamp.format('DD/M/YYYY hh:mm:ss A'));
    }

    timestampFromInputChanged = (value: string) => {
        if (!value) {
            this.reportSearchTerms.timestampFrom = undefined;
        }
    }

    timestampToInputChanged = (value: string) => {
        if (!value) {
            this.reportSearchTerms.timestampTo = undefined;
        }
    }

    setToDate = (timestamp: moment.Moment) => {
        this.reportSearchTerms.timestampTo = timestamp.toDate();
        $(this.timestampToElement).val(timestamp.format('DD/M/YYYY hh:mm:ss A'));
    }

    setReportingPeriodStartDateFrom = (timestamp: moment.Moment) => {
        this.reportSearchTerms.reportingPeriodStartDateFrom = timestamp.toDate();
        $(this.reportingPeriodStartDateFromElement).val(timestamp.format('DD/M/YYYY hh:mm:ss A'));
    }

    reportingPeriodStartDateFromInputChanged = (value: string) => {
        if (!value) {
            this.reportSearchTerms.reportingPeriodStartDateFrom = undefined;
        }
    }

    reportingPeriodEndDateToInputChanged = (value: string) => {
        if (!value) {
            this.reportSearchTerms.reportingPeriodEndDateTo = undefined;
        }
    }

    setReportingPeriodEndDateTo = (timestamp: moment.Moment) => {
        this.reportSearchTerms.reportingPeriodEndDateTo = timestamp.toDate();
        $(this.reportingPeriodEndDateToElement).val(timestamp.format('DD/M/YYYY hh:mm:ss A'));
    }

    async downloadReports() {
        this.isDownloading = true;
        const blob = await this.allReportService.download(this.reportSearchTerms);
        this.isDownloading = false;
        if (!blob) {
            toastr.error("Error downloading report");
            return;
        }
        saveAs(blob, "AllReports.xlsx");
    }

    async search(){
        await this.grid.search();
        this.storage.set("searchTerms", this.reportSearchTerms);
    }

    async reset() {
        this.isReset = true;
        $(this.timestampFromElement).val(undefined);
        $(this.timestampToElement).val(undefined);
        $(this.reportingPeriodStartDateFromElement).val(undefined);
        $(this.reportingPeriodEndDateToElement).val(undefined);
        this.reportSearchTerms.resetToDefault();
        this.isReset = false;
    }

    async delete(item: ReportGridItem) {
        if (item.organization.organizationType === OrganizationType.Unit) {
            await this.unitPlanReportService.delete(item.organization.id, item.id);
            item.isDeleting = true;
            return;
        }
        if (item.organization.organizationType === OrganizationType.Zone) {
            await this.zonePlanReportService.delete(item.organization.id, item.id);
            item.isDeleting = true;
            return;
        }
        if (item.organization.organizationType === OrganizationType.State) {
            await this.statePlanReportService.delete(item.organization.id, item.id);
            item.isDeleting = true;
            return;
        }
        if (item.organization.organizationType === OrganizationType.Central) {
            await this.centralPlanReportService.delete(item.organization.id, item.id);
            item.isDeleting = true;
            return;
        }
        throw new Error("Not Implemented");
    }

    async unSubmit(item: ReportGridItem) {
        if (item.organization.organizationType === OrganizationType.Unit) {
            await this.unitPlanReportService.unsubmitReport(item.organization.id, item.id);
            item.isUnSubmitting = true;
            return;
        }
        if (item.organization.organizationType === OrganizationType.Zone) {
            await this.zonePlanReportService.unsubmitReport(item.organization.id, item.id);
            item.isUnSubmitting = true;
            return;
        }
        if (item.organization.organizationType === OrganizationType.State) {
            await this.statePlanReportService.unsubmitReport(item.organization.id, item.id);
            item.isUnSubmitting = true;
            return;
        }
        if (item.organization.organizationType === OrganizationType.Central) {
            await this.centralPlanReportService.unsubmitReport(item.organization.id, item.id);
            item.isUnSubmitting = true;
            return;
        }
        throw new Error("Not Implemented");
    }

    onReportDeleted = (reportId: number) => {
        const deletedItemIndex = this.grid.items.findIndex(item => item.id === reportId);
        if (deletedItemIndex !== -1) {
            this.grid.items[deletedItemIndex].isDeleting = false;
            this.grid.items.splice(deletedItemIndex, 1);
        }
        toastr.success("Deleted successfully");

    }

    onReportUnSubmitted = (reportId: number) => {
        const unSubmittedItemIndex = this.grid.items.findIndex(item => item.id === reportId);
        if (unSubmittedItemIndex !== -1) {
            const item = this.grid.items[unSubmittedItemIndex];
            item.isUnSubmitting = false;
            item.reportStatus = item.reportStatus - 1;
        }
        toastr.success("Unsubmitted successfully");

    }

    get canDelete() {
        return this.authService.isSystemAdmin == true;
    }

    get canUnSubmit() {
        return this.authService.isSystemAdmin == true;
    }

    onReportDeleteFailed = (e: { $values: string[] }) => {
        toastr.error(e.$values.join(", "));
    }

    onReportUnSubmitFailed = (e: { $values: string[] }) => {
        toastr.error(e.$values.join(", "));
    }

    get canSearch() {
        return !this.grid.isSearching && !this.isDownloading;
    }

    get canCreatePlan() {
        return !this.grid.isSearching && !this.isDownloading;
    }

    get canDownload() {
        return !this.grid.isSearching && !this.isDownloading && !this.grid.nodatafound;
    }

    get canReset() {
        return !this.grid.isSearching && !this.isDownloading;
    }

}
