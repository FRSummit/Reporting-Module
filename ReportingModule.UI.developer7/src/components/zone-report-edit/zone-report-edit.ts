import { autoinject } from "aurelia-framework";
import * as toastr from "toastr";
import { AppRouter } from "aurelia-router";
import { SignalrWrapper } from "signalrwrapper";
import { ReportData } from "models/ReportData";
import { MemberData } from "models/MemberData";
import { MeetingProgramData } from "models/MeetingProgramData";
import { TeachingLearningProgramData } from "models/TeachingLearningProgramData";
import { MaterialData } from "models/MaterialData";
import { LibraryStockData } from "models/LibraryStockData";
import { FinanceData } from "models/FinanceData";
import { SocialWelfareData } from "models/SocialWelfareData";
import { ZoneReportViewModelDto } from "models/ZoneReportViewModelDto";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { Subscription, EventAggregator } from "aurelia-event-aggregator";
import { ZoneReportUpdated } from "resources/plan-report-header/ZoneReportUpdated";

@autoinject
export class ZoneReportEdit {
    reportid: number;
    zoneReport: ZoneReportViewModelDto;
    isSaving = false;
    isSubmitting = false;
    isCancelling = false;
    afterSave: (() => Promise<void>)[] = [];

    initialJson = "";

    signalreventhandlers: any = {};
    subscription: Subscription;
    constructor(public service: ZonePlanReportService, public signalr: SignalrWrapper, public router: AppRouter, public ea?: EventAggregator) {
        this.signalreventhandlers = {
            "ZoneReportUpdated": this.onZoneReportUpdated,
            "ZoneReportUpdateFailed": this.onZoneReportUpdateFailed,
            "ReportSubmitted": this.onReportSubmitted,
            "ReportSubmitFailed": this.onReportSubmitFailed
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
        this.subscription = this.ea.subscribe(ZoneReportUpdated, _ => this.loadReport());;
        await this.loadReport();
    }

    detached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
        this.subscription.dispose();
    }

    async loadReport() {
        const dto = await this.service.getReport(this.reportid);
        this.zoneReport = dto;
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getReportData();
        this.initialJson = JSON.stringify(initialData);
    }

    getReportData(): ReportData {
        return new ReportData(
            this.makeMemberData(this.zoneReport.associateMemberData),
            this.makeMemberData(this.zoneReport.preliminaryMemberData),
            this.makeMemberData(this.zoneReport.supporterMemberData),
            this.makeMemberData(this.zoneReport.memberMemberData),
            this.makeMeetingProgramData(this.zoneReport.workerMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.cmsMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.smMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.memberMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.dawahMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.stateLeaderMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.stateOutingMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.iftarMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.learningMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.socialDawahMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.dawahGroupMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.nextGMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.tafsirMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.unitMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.bbqMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.gatheringMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.familyVisitMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.eidReunionMeetingProgramData),
            this.makeMeetingProgramData(this.zoneReport.otherMeetingProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.groupStudyTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.studyCircleForAssociateMemberTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.studyCircleTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.practiceDarsTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.stateLearningCampTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.quranStudyTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.hadithTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.quranClassTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.weekendIslamicSchoolTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.memorizingAyatTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.memorizingHadithTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.memorizingDoaTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.stateLearningSessionTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.stateQiyamulLailTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.zoneReport.otherTeachingLearningProgramData),
            this.makeMaterialData(this.zoneReport.bookSaleMaterialData),
            this.makeMaterialData(this.zoneReport.bookDistributionMaterialData),
            this.makeMaterialData(this.zoneReport.vhsSaleMaterialData),
            this.makeMaterialData(this.zoneReport.vhsDistributionMaterialData),
            this.makeMaterialData(this.zoneReport.emailDistributionMaterialData),
            this.makeMaterialData(this.zoneReport.ipdcLeafletDistributionMaterialData),
            this.makeMaterialData(this.zoneReport.otherSaleMaterialData),
            this.makeMaterialData(this.zoneReport.otherDistributionMaterialData),
            this.makeLibraryStockData(this.zoneReport.bookLibraryStockData),
            this.makeLibraryStockData(this.zoneReport.vhsLibraryStockData),
            this.makeLibraryStockData(this.zoneReport.otherLibraryStockData),
            this.makeFinanceData(this.zoneReport.baitulMalFinanceData),
            this.makeFinanceData(this.zoneReport.aDayMasjidProjectFinanceData),
            this.makeFinanceData(this.zoneReport.masjidTableBankFinanceData),
            this.makeSocialWelfareData(this.zoneReport.qardeHasanaSocialWelfareData),
            this.makeSocialWelfareData(this.zoneReport.patientVisitSocialWelfareData),
            this.makeSocialWelfareData(this.zoneReport.socialVisitSocialWelfareData),
            this.makeSocialWelfareData(this.zoneReport.transportSocialWelfareData),
            this.makeSocialWelfareData(this.zoneReport.shiftingSocialWelfareData),
            this.makeSocialWelfareData(this.zoneReport.shoppingSocialWelfareData),
            this.makeSocialWelfareData(this.zoneReport.foodDistributionSocialWelfareData),
            this.makeSocialWelfareData(this.zoneReport.cleanUpAustraliaSocialWelfareData),
            this.makeSocialWelfareData(this.zoneReport.otherSocialWelfareData),
            this.zoneReport.comment
        );
    }
    
    save = async () => {
        try {
            await this.service.updateReport(this.zoneReport.organization.id, this.reportid, this.getReportData());
        } catch (error) {
            toastr.error(error, "Error Saving Report");
            return;
        }
        this.isSaving = true;
    }

    private makeMemberData(dto: MemberData): MemberData {
        return new MemberData(dto.nameAndContactNumber, dto.action, dto.lastPeriod, 
            dto.upgradeTarget, dto.thisPeriod, dto.increased, dto.decreased, 
            dto.comment, dto.personalContact);
    }

    private makeMeetingProgramData(dto: MeetingProgramData) {
        return new MeetingProgramData(dto.target, dto.dateAndAction, dto.actual, dto.averageAttendance, dto.comment);
    }

    private makeTeachingLearningProgramData(dto: TeachingLearningProgramData) {
        return new TeachingLearningProgramData(dto.target, dto.dateAndAction, dto.actual, dto.averageAttendance, dto.comment);
    }

    private makeMaterialData(dto: MaterialData) {
        return new MaterialData(dto.target, dto.dateAndAction, dto.actual, dto.comment);
    }

    private makeLibraryStockData(dto: LibraryStockData) {
        return new LibraryStockData(dto.lastPeriod, dto.thisPeriod, dto.increased, dto.decreased, dto.comment);
    }

    private makeFinanceData(dto: FinanceData) {
        return new FinanceData(dto.workerPromiseLastPeriod, dto.lastPeriod,dto.workerPromiseIncreaseTarget, dto.workerPromiseIncreased, dto.workerPromiseDecreased, 
            dto.workerPromiseThisPeriod, dto.otherSourceIncreaseTarget, dto.totalIncreaseTarget, dto.collection, dto.expense, dto.nisabPaidToCentral, 
            dto.balance, dto.comment, dto.action, dto.otherSourceAction);
    }

    private makeSocialWelfareData(dto: SocialWelfareData) {
        return new SocialWelfareData(dto.target, dto.dateAndAction, dto.actual, dto.comment);
    }

    get isDirty() {
        const latestJson = JSON.stringify(this.getReportData());
        return latestJson !== this.initialJson;
    }

    async cancelChanges() {
        this.isCancelling = true;
        await this.loadReport();
        this.isCancelling = false;
    }

    get canSave() {
        return this.isDirty && !this.isCancelling && !this.isSaving && !this.isSubmitting;
    }

    get canCancel() {
        return !this.isCancelling && !this.isSaving && !this.isSubmitting;
    }

    get canSubmit() {
        return !this.isDirty && !this.isCancelling && !this.isSaving && !this.isSubmitting;
    }

    onZoneReportUpdated = async (id: number) => {
        this.isSaving = false;
        toastr.success("Report Saved");
        await this.loadReport();
        if(this.afterSave.length === 0) return;
        await this.afterSave.pop()();
    }

    onZoneReportUpdateFailed = (e: {$values: string[]}) => {
        this.isSaving = false;
        toastr.error(e.$values.join("\n"), "Error Saving Report");
        if(this.afterSave.length === 0) return;
        this.afterSave.pop();
    }

    saveAndSubmitReport = async () => {
        if (this.isDirty)
        {
          await this.save();
          this.afterSave.push(this.submitReport);
          return;
        } 
        await this.submitReport();
    }

    submitReport = async () => {
        try {
            await this.service.submitReport(this.zoneReport.organization.id, this.reportid);
        } catch(error) {
            toastr.error(error, "Error Submitting Report");
        }
        this.isSubmitting = true;
    }

    onReportSubmitted = (id: number) => {
        this.isSubmitting = false;
        toastr.success("Report Submitted");
        this.router.navigate(`zone-report-view/${id}`);
    }

    onReportSubmitFailed = (e: {$values: string[]}) => {
        this.isSubmitting = false;
        toastr.error(e.$values.join("\n"), "Error Submitting Report");
    } 
    
    get headerData() {
        if(!this.zoneReport) return undefined;
        return new PlanReportHeaderData("Zone Report", this.reportid, this.zoneReport.description, this.zoneReport.reportStatus, this.zoneReport.organization);
    }
}
