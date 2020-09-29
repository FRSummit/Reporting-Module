import { autoinject } from "aurelia-framework";
import * as toastr from "toastr";
import { AppRouter } from "aurelia-router";
import { StatePlanReportService } from "services/StatePlanReportService";
import { StateReportViewModelDto } from "models/StateReportViewModelDto";
import { SignalrWrapper } from "signalrwrapper";
import { ReportData } from "models/ReportData";
import { MemberData } from "models/MemberData";
import { MeetingProgramData } from "models/MeetingProgramData";
import { TeachingLearningProgramData } from "models/TeachingLearningProgramData";
import { MaterialData } from "models/MaterialData";
import { LibraryStockData } from "models/LibraryStockData";
import { FinanceData } from "models/FinanceData";
import { SocialWelfareData } from "models/SocialWelfareData";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { Subscription, EventAggregator } from "aurelia-event-aggregator";
import { StateReportUpdated } from "resources/plan-report-header/StateReportUpdated";

@autoinject
export class StateReportEdit {
    reportid: number;
    stateReport: StateReportViewModelDto;
    isSaving = false;
    isSubmitting = false;
    isCancelling = false;
    afterSave: (() => Promise<void>)[] = [];

    initialJson = "";

    signalreventhandlers: any = {};
    subscription: Subscription;
    constructor(public service: StatePlanReportService, public signalr: SignalrWrapper, public router: AppRouter, public ea?: EventAggregator) {
        this.signalreventhandlers = {
            "StateReportUpdated": this.onStateReportUpdated,
            "StateReportUpdateFailed": this.onStateReportUpdateFailed,
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
        this.subscription = this.ea.subscribe(StateReportUpdated, _ => this.loadReport());
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
        this.stateReport = dto;
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getReportData();
        this.initialJson = JSON.stringify(initialData);
    }

    getReportData(): ReportData {
        return new ReportData(
            this.makeMemberData(this.stateReport.associateMemberData),
            this.makeMemberData(this.stateReport.preliminaryMemberData),
            this.makeMemberData(this.stateReport.supporterMemberData),
            this.makeMemberData(this.stateReport.memberMemberData),
            this.makeMeetingProgramData(this.stateReport.workerMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.cmsMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.smMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.memberMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.dawahMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.stateLeaderMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.stateOutingMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.iftarMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.learningMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.socialDawahMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.dawahGroupMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.nextGMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.tafsirMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.unitMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.bbqMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.gatheringMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.familyVisitMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.eidReunionMeetingProgramData),
            this.makeMeetingProgramData(this.stateReport.otherMeetingProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.groupStudyTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.studyCircleForAssociateMemberTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.studyCircleTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.practiceDarsTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.stateLearningCampTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.quranStudyTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.hadithTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.quranClassTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.weekendIslamicSchoolTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.memorizingAyatTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.memorizingHadithTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.memorizingDoaTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.stateLearningSessionTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.stateQiyamulLailTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.stateReport.otherTeachingLearningProgramData),
            this.makeMaterialData(this.stateReport.bookSaleMaterialData),
            this.makeMaterialData(this.stateReport.bookDistributionMaterialData),
            this.makeMaterialData(this.stateReport.vhsSaleMaterialData),
            this.makeMaterialData(this.stateReport.vhsDistributionMaterialData),
            this.makeMaterialData(this.stateReport.emailDistributionMaterialData),
            this.makeMaterialData(this.stateReport.ipdcLeafletDistributionMaterialData),
            this.makeMaterialData(this.stateReport.otherSaleMaterialData),
            this.makeMaterialData(this.stateReport.otherDistributionMaterialData),
            this.makeLibraryStockData(this.stateReport.bookLibraryStockData),
            this.makeLibraryStockData(this.stateReport.vhsLibraryStockData),
            this.makeLibraryStockData(this.stateReport.otherLibraryStockData),
            this.makeFinanceData(this.stateReport.baitulMalFinanceData),
            this.makeFinanceData(this.stateReport.aDayMasjidProjectFinanceData),
            this.makeFinanceData(this.stateReport.masjidTableBankFinanceData),
            this.makeSocialWelfareData(this.stateReport.qardeHasanaSocialWelfareData),
            this.makeSocialWelfareData(this.stateReport.patientVisitSocialWelfareData),
            this.makeSocialWelfareData(this.stateReport.socialVisitSocialWelfareData),
            this.makeSocialWelfareData(this.stateReport.transportSocialWelfareData),
            this.makeSocialWelfareData(this.stateReport.shiftingSocialWelfareData),
            this.makeSocialWelfareData(this.stateReport.shoppingSocialWelfareData),
            this.makeSocialWelfareData(this.stateReport.foodDistributionSocialWelfareData),
            this.makeSocialWelfareData(this.stateReport.cleanUpAustraliaSocialWelfareData),
            this.makeSocialWelfareData(this.stateReport.otherSocialWelfareData),
            this.stateReport.comment
        );
    }
    
    save = async () => {
        try {
            await this.service.updateReport(this.stateReport.organization.id, this.reportid, this.getReportData());
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

    onStateReportUpdated = async (id: number) => {
        this.isSaving = false;
        toastr.success("Report Saved");
        await this.loadReport();
        if(this.afterSave.length === 0) return;
        await this.afterSave.pop()();
    }

    onStateReportUpdateFailed = (e: {$values: string[]}) => {
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
            await this.service.submitReport(this.stateReport.organization.id, this.reportid);
        } catch(error) {
            toastr.error(error, "Error Submitting Report");
        }
        this.isSubmitting = true;
    }

    onReportSubmitted = (id: number) => {
        this.isSubmitting = false;
        toastr.success("Report Submitted");
        this.router.navigate(`state-report-view/${id}`);
    }

    onReportSubmitFailed = (e: {$values: string[]}) => {
        this.isSubmitting = false;
        toastr.error(e.$values.join("\n"), "Error Submitting Report");
    }
    
    get headerData() {
        if(!this.stateReport) return undefined;
        return new PlanReportHeaderData("State Report", this.reportid, this.stateReport.description, this.stateReport.reportStatus, this.stateReport.organization);
    }
}
