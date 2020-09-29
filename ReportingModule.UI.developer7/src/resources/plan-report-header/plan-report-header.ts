import { bindable, bindingMode, containerless, autoinject, PLATFORM } from "aurelia-framework";
import { EventAggregator } from "aurelia-event-aggregator";
import { DialogService, DialogSettings } from "aurelia-dialog";
import { saveAs } from "file-saver";
import * as toastr from "toastr";
import { StatePlanReportService } from "services/StatePlanReportService";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { CentralPlanReportService } from "services/CentralPlanReportService";
import { OrganizationType } from "models/OrganizationType";
import { ExcelReportType } from "models/ExcelReportType";
import { PlanReportHeaderData } from "./PlanReportHeaderData";
import { SignalrWrapper } from "signalrwrapper";
import { CentralReportUpdated } from "./CentralReportUpdated";
import { StateReportUpdated } from "./StateReportUpdated";
import { ZoneReportUpdated } from "./ZoneReportUpdated";
import { YesNo } from "resources/yes-no-dialog/YesNo";

@containerless
@autoinject
export class PlanReportHeader {
    isDownloadingList = false;
    isDownloadingDetail = false;
    isResetting = false;
    isRecalculating = false;
    signalreventhandlers: any = {};

    @bindable({ defaultBindingMode: bindingMode.oneWay }) headerData: PlanReportHeaderData;

    constructor(public unitService: UnitPlanReportService,
        public stateService: StatePlanReportService,
        public zoneService: ZonePlanReportService,
        public centralService: CentralPlanReportService,
        public dialogService: DialogService,
        public signalr: SignalrWrapper,
        public ea: EventAggregator) { 
            this.signalreventhandlers = {
                "ZoneReportUpdated": this.onZoneReportUpdated,
                "ZoneReportUpdateFailed": this.onZoneReportUpdateFailed,
                "StateReportUpdated": this.onStateReportUpdated,
                "StateReportUpdateFailed": this.onStateReportUpdateFailed,
                "CentralReportUpdated": this.onCentralReportUpdated,
                "CentralReportUpdateFailed": this.onCentralReportUpdateFailed
            };
        }
    
    async attached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.on(key, this.signalreventhandlers[key]);
            }
        }
    }

    detached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
    }

    get copydownloadservice(): UnitPlanReportService | StatePlanReportService | ZonePlanReportService | CentralPlanReportService {
        switch(this.headerData.organization.organizationType) {
            case OrganizationType.Unit: return this.unitService;
            case OrganizationType.Zone: return this.zoneService;
            case OrganizationType.State: return this.stateService;
            case OrganizationType.Central: return this.centralService;
            default: throw new Error("Not Implemented");
        }
    }

    get resetrecalculateservice(): StatePlanReportService | ZonePlanReportService | CentralPlanReportService {
        switch(this.headerData.organization.organizationType) {
            case OrganizationType.Zone: return this.zoneService;
            case OrganizationType.State: return this.stateService;
            case OrganizationType.Central: return this.centralService;
            default: throw new Error("Not Implemented");
        }
    }

    async downloadAsList() {
        this.isDownloadingList = true;
        const blob = await this.copydownloadservice.downloadReport(this.headerData.id, ExcelReportType.List);
        this.isDownloadingList = false;
        if(!blob) {
            toastr.error("Error downloading")
            return;
        }
        saveAs(blob, `${this.headerData.id}.xlsx`);
    }

    async downloadAsDetail() {
        this.isDownloadingDetail = true;
        const blob = await this.copydownloadservice.downloadReport(this.headerData.id, ExcelReportType.Detail);
        this.isDownloadingDetail = false;
        if(!blob) {
            toastr.error("Error downloading")
            return;
        }
        saveAs(blob, `${this.headerData.id}.xlsx`);
    }

    async reset() {
        const shouldReset = await this.dialogService.open({
            viewModel: PLATFORM.moduleName("resources/yes-no-dialog/yes-no-dialog"),
            model: new YesNo("Please confirm reset"),
        })
        .whenClosed(response => {
            if(response.wasCancelled) return false;
            return true;
        });
        
        if(!shouldReset) return;
        this.isResetting = true;
        try {
            await this.resetrecalculateservice.resetReport(this.headerData.organization.id, this.headerData.id);
        } catch(error) {
            this.isResetting = false;
            console.log(error);
            toastr.error(error);
            return;
        }
        toastr.success("Reset submitted");  
    }

    async recalculate() {
        const shouldRecalculate = await this.dialogService.open({
            viewModel: PLATFORM.moduleName("resources/yes-no-dialog/yes-no-dialog"),
            model: new YesNo("Please confirm recalculate"),
        })
        .whenClosed(response => {
            if(response.wasCancelled) return false;
            return true;
        });
        if(!shouldRecalculate) return;

        this.isRecalculating = true;
        try {
            await this.resetrecalculateservice.recalculateReport(this.headerData.organization.id, this.headerData.id);
        } catch(error) {
            this.isRecalculating = false;
            console.log(error);
            toastr.error(error);
            return;
        }
        toastr.success("Recalculation submitted");
    }

    get canDownload() {
        return this.headerData && this.headerData.id && !this.isDownloadingList && !this.isDownloadingDetail && !this.isResetting && !this.isRecalculating;
    }

    get canReset() {
        return this.headerData && this.headerData.id && !this.isDownloadingList && !this.isDownloadingDetail && !this.isResetting && !this.isRecalculating;
    }

    get canRecalculate() {
        return this.headerData && this.headerData.id && !this.isDownloadingList && !this.isDownloadingDetail && !this.isResetting && !this.isRecalculating;
    }

    clearResetRecalculateFlags() {
        this.isResetting = false;
        this.isRecalculating = false;
    }

    onZoneReportUpdated = async (id: number) => {
        this.clearResetRecalculateFlags();
        this.ea.publish(new ZoneReportUpdated());
        toastr.success("Report Updated");
    }

    onZoneReportUpdateFailed = (e: {$values: string[]}) => {
        this.clearResetRecalculateFlags();
        toastr.error(e.$values.join("\n"));
    }

    onStateReportUpdated = async (id: number) => {
        this.clearResetRecalculateFlags();
        this.ea.publish(new StateReportUpdated());
        toastr.success("Report Updated");
    }

    onStateReportUpdateFailed = (e: {$values: string[]}) => {
        this.clearResetRecalculateFlags();
        toastr.error(e.$values.join("\n"));
    }

    onCentralReportUpdated = async (id: number) => {
        this.clearResetRecalculateFlags();
        this.ea.publish(new CentralReportUpdated());
        toastr.success("Report Updated");
    }

    onCentralReportUpdateFailed = (e: {$values: string[]}) => {
        this.clearResetRecalculateFlags();
        toastr.error(e.$values.join("\n"));
    }
}
