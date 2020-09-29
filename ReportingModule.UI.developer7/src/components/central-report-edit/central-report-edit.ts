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
import { CentralReportViewModelDto } from "models/CentralReportViewModelDto";
import { CentralPlanReportService } from "services/CentralPlanReportService";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { EventAggregator, Subscription } from "aurelia-event-aggregator";
import { CentralReportUpdated } from "resources/plan-report-header/CentralReportUpdated";

@autoinject
export class CentralReportEdit {
    reportid: number;
    centralReport: CentralReportViewModelDto;
    isSaving = false;
    isSubmitting = false;
    isCancelling = false;
    afterSave: (() => Promise<void>)[] = [];

    initialJson = "";

    signalreventhandlers: any = {};
    subscription: Subscription;
    constructor(public service: CentralPlanReportService, public signalr: SignalrWrapper, public router: AppRouter, public ea?: EventAggregator) {
        this.signalreventhandlers = {
            "CentralReportUpdated": this.onCentralReportUpdated,
            "CentralReportUpdateFailed": this.onCentralReportUpdateFailed,
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
        this.subscription = this.ea.subscribe(CentralReportUpdated, _ => this.loadReport());
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
        this.centralReport = dto;
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getReportData();
        this.initialJson = JSON.stringify(initialData);
    }

    getReportData(): ReportData {
        return new ReportData(
            this.makeMemberData(this.centralReport.associateMemberData),
            this.makeMemberData(this.centralReport.preliminaryMemberData),
            this.makeMemberData(this.centralReport.supporterMemberData),
            this.makeMemberData(this.centralReport.memberMemberData),
            this.makeMeetingProgramData(this.centralReport.workerMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.cmsMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.smMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.memberMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.dawahMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.stateLeaderMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.stateOutingMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.iftarMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.learningMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.socialDawahMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.dawahGroupMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.nextGMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.tafsirMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.unitMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.bbqMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.gatheringMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.familyVisitMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.eidReunionMeetingProgramData),
            this.makeMeetingProgramData(this.centralReport.otherMeetingProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.groupStudyTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.studyCircleForAssociateMemberTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.studyCircleTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.practiceDarsTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.stateLearningCampTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.quranStudyTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.hadithTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.quranClassTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.weekendIslamicSchoolTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.memorizingAyatTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.memorizingHadithTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.memorizingDoaTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.stateLearningSessionTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.stateQiyamulLailTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.centralReport.otherTeachingLearningProgramData),
            this.makeMaterialData(this.centralReport.bookSaleMaterialData),
            this.makeMaterialData(this.centralReport.bookDistributionMaterialData),
            this.makeMaterialData(this.centralReport.vhsSaleMaterialData),
            this.makeMaterialData(this.centralReport.vhsDistributionMaterialData),
            this.makeMaterialData(this.centralReport.emailDistributionMaterialData),
            this.makeMaterialData(this.centralReport.ipdcLeafletDistributionMaterialData),
            this.makeMaterialData(this.centralReport.otherSaleMaterialData),
            this.makeMaterialData(this.centralReport.otherDistributionMaterialData),
            this.makeLibraryStockData(this.centralReport.bookLibraryStockData),
            this.makeLibraryStockData(this.centralReport.vhsLibraryStockData),
            this.makeLibraryStockData(this.centralReport.otherLibraryStockData),
            this.makeFinanceData(this.centralReport.baitulMalFinanceData),
            this.makeFinanceData(this.centralReport.aDayMasjidProjectFinanceData),
            this.makeFinanceData(this.centralReport.masjidTableBankFinanceData),
            this.makeSocialWelfareData(this.centralReport.qardeHasanaSocialWelfareData),
            this.makeSocialWelfareData(this.centralReport.patientVisitSocialWelfareData),
            this.makeSocialWelfareData(this.centralReport.socialVisitSocialWelfareData),
            this.makeSocialWelfareData(this.centralReport.transportSocialWelfareData),
            this.makeSocialWelfareData(this.centralReport.shiftingSocialWelfareData),
            this.makeSocialWelfareData(this.centralReport.shoppingSocialWelfareData),
            this.makeSocialWelfareData(this.centralReport.foodDistributionSocialWelfareData),
            this.makeSocialWelfareData(this.centralReport.cleanUpAustraliaSocialWelfareData),
            this.makeSocialWelfareData(this.centralReport.otherSocialWelfareData),
            this.centralReport.comment
        );
    }
    
    save = async () => {
        try {
            await this.service.updateReport(this.centralReport.organization.id, this.reportid, this.getReportData());
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

    onCentralReportUpdated = async (id: number) => {
        this.isSaving = false;
        toastr.success("Report Saved");
        await this.loadReport();
        if(this.afterSave.length === 0) return;
        await this.afterSave.pop()();
    }

    onCentralReportUpdateFailed = (e: {$values: string[]}) => {
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
            await this.service.submitReport(this.centralReport.organization.id, this.reportid);
        } catch(error) {
            toastr.error(error, "Error Submitting Report");
        }
        this.isSubmitting = true;
    }

    onReportSubmitted = (id: number) => {
        this.isSubmitting = false;
        toastr.success("Report Submitted");
        this.router.navigate(`central-report-view/${id}`);
    }

    onReportSubmitFailed = (e: {$values: string[]}) => {
        this.isSubmitting = false;
        toastr.error(e.$values.join("\n"), "Error Submitting Report");
    }
    
    get headerData() {
        if(!this.centralReport) return undefined;
        return new PlanReportHeaderData("Central Report", this.reportid, this.centralReport.description, this.centralReport.reportStatus, this.centralReport.organization);
    }
}
