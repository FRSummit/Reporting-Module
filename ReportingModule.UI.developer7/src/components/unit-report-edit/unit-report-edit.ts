import { autoinject } from "aurelia-framework";
import { AppRouter } from "aurelia-router";
import * as toastr from "toastr";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { UnitReportViewModelDto } from "models/UnitReportViewModelDto";
import { SignalrWrapper } from "signalrwrapper";
import { MemberReportData } from "models/MemberReportData";
import { ReportUpdateData } from "models/ReportUpdateData";
import { MeetingProgramData } from "models/MeetingProgramData";
import { MeetingProgramReportData } from "models/MeetingProgramReportData";
import { SocialWelfareData } from "models/SocialWelfareData";
import { TeachingLearningProgramData } from "models/TeachingLearningProgramData";
import { LibraryStockData } from "models/LibraryStockData";
import { MaterialData } from "models/MaterialData";
import { SocialWelfareReportData } from "models/SocialWelfareReportData";
import { FinanceReportData } from "models/FinanceReportData";
import { FinanceData } from "models/FinanceData";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";

@autoinject
export class UnitReportEdit {
    reportid: number;
    unitReport: UnitReportViewModelDto;
    isSaving = false;
    isSubmitting = false;
    isCancelling = false;
    initialJson = "";
    afterSave: (() => Promise<void>)[] = [];

    signalreventhandlers: any = {};
    constructor(public service: UnitPlanReportService, public signalr: SignalrWrapper, public router: AppRouter) {
        this.signalreventhandlers = {
            "UnitReportUpdated": this.onUnitReportUpdated,
            "UnitReportUpdateFailed": this.onUnitReportUpdateFailed,
            "ReportSubmitted": this.onUnitReportSubmitted,
            "ReportSubmitFailed": this.onUnitReportSubmitFailed
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
        const initialData = this.getMemberReportData();
        this.initialJson = JSON.stringify(initialData);
    }

    getMemberReportData(): ReportUpdateData {
        return new ReportUpdateData(
            this.makeMemberData(this.unitReport.associateMemberData),
            this.makeMemberData(this.unitReport.preliminaryMemberData),
            this.makeMemberData(this.unitReport.supporterMemberData),
            this.makeMemberData(this.unitReport.memberMemberData),
            this.makeMeetingProgramData(this.unitReport.workerMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.cmsMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.smMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.memberMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.dawahMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.stateLeaderMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.stateOutingMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.iftarMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.learningMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.socialDawahMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.dawahGroupMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.nextGMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.tafsirMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.unitMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.bbqMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.gatheringMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.familyVisitMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.eidReunionMeetingProgramData),
            this.makeMeetingProgramData(this.unitReport.otherMeetingProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.groupStudyTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.studyCircleForAssociateMemberTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.studyCircleTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.practiceDarsTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.stateLearningCampTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.quranStudyTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.hadithTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.quranClassTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.weekendIslamicSchoolTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.memorizingAyatTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.memorizingHadithTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.memorizingDoaTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.stateLearningSessionTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.stateQiyamulLailTeachingLearningProgramData),
            this.makeTeachingLearningProgramData(this.unitReport.otherTeachingLearningProgramData),
            this.makeSocialWelfareReportData(this.unitReport.qardeHasanaSocialWelfareData),
            this.makeSocialWelfareReportData(this.unitReport.patientVisitSocialWelfareData),
            this.makeSocialWelfareReportData(this.unitReport.socialVisitSocialWelfareData),
            this.makeSocialWelfareReportData(this.unitReport.transportSocialWelfareData),
            this.makeSocialWelfareReportData(this.unitReport.shiftingSocialWelfareData),
            this.makeSocialWelfareReportData(this.unitReport.shoppingSocialWelfareData),
            this.makeSocialWelfareReportData(this.unitReport.foodDistributionSocialWelfareData),
            this.makeSocialWelfareReportData(this.unitReport.cleanUpAustraliaSocialWelfareData),
            this.makeSocialWelfareReportData(this.unitReport.otherSocialWelfareData),
            this.makeMaterialData(this.unitReport.bookSaleMaterialData),
            this.makeMaterialData(this.unitReport.bookDistributionMaterialData),
            this.makeMaterialData(this.unitReport.vhsSaleMaterialData),
            this.makeMaterialData(this.unitReport.vhsDistributionMaterialData),
            this.makeMaterialData(this.unitReport.emailDistributionMaterialData),
            this.makeMaterialData(this.unitReport.ipdcLeafletDistributionMaterialData),
            this.makeMaterialData(this.unitReport.otherSaleMaterialData),
            this.makeMaterialData(this.unitReport.otherDistributionMaterialData),
            this.makeLibraryStockData(this.unitReport.bookLibraryStockData),
            this.makeLibraryStockData(this.unitReport.vhsLibraryStockData),
            this.makeLibraryStockData(this.unitReport.otherLibraryStockData),
            this.makeFinanceReportData(this.unitReport.baitulMalFinanceData),
            this.makeFinanceReportData(this.unitReport.aDayMasjidProjectFinanceData),
            this.makeFinanceReportData(this.unitReport.masjidTableBankFinanceData),
            this.unitReport.comment
        );
    }

    save = async () => {
      if (!this.isDirty) return;
        try {
            await this.service.updateReport(this.unitReport.organization.id, this.reportid, this.getMemberReportData());
        } catch (error) {
            toastr.error(error, "Error Saving Report");
            return;
        }
        this.isSaving = true;
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
          await this.service.submitReport(this.unitReport.organization.id, this.reportid);
      } catch(error) {
          toastr.error(error, "Error Submitting Report");
      }
      this.isSubmitting = true;
    }

    private makeMeetingProgramData(original: MeetingProgramData): MeetingProgramReportData {
        return new MeetingProgramReportData(original.actual, original.averageAttendance, original.comment);
    }

    private makeMemberData(original: MemberReportData): MemberReportData {
        return new MemberReportData(original.lastPeriod, original.increased, original.decreased, original.comment, original.personalContact);
    }

    private makeTeachingLearningProgramData(original: TeachingLearningProgramData): TeachingLearningProgramData {
        return new TeachingLearningProgramData(original.target, original.dateAndAction, original.actual, original.averageAttendance, original.comment);
    }
    
    private makeSocialWelfareReportData(original: SocialWelfareData): SocialWelfareReportData {
        return new SocialWelfareReportData(original.actual, original.comment);
    }

    private makeMaterialData(original: MaterialData): MaterialData {
        return new MaterialData(original.target, original.dateAndAction, original.actual, original.comment);
    }

    private makeLibraryStockData(original: LibraryStockData): LibraryStockData {
        return new LibraryStockData(original.lastPeriod, original.thisPeriod, original.increased, original.decreased, original.comment);
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
        const latestJson = JSON.stringify(this.getMemberReportData());
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

    onUnitReportUpdated = async(id: number) => {
        this.isSaving = false;
        toastr.success("Report Saved");
        await this.loadReport();
        if(this.afterSave.length === 0) return;
        await this.afterSave.pop()();
    }

    onUnitReportUpdateFailed = (e: {$values: string[]}) => {
        this.isSaving = false;
        toastr.error(e.$values.join("\n"), "Error Saving Report");
        if(this.afterSave.length === 0) return;
        this.afterSave.pop();
    }

    onUnitReportSubmitted = (id: number) => {
        this.isSubmitting = false;
        toastr.success("Report Submitted");
        this.router.navigate(`unit-report-view/${id}`);
    }

    onUnitReportSubmitFailed = (e: {$values: string[]}) => {
        this.isSubmitting = false;
        toastr.error(e.$values.join("\n"), "Error Submitting Report");
    }

    get headerData() {
        if(!this.unitReport) return undefined;
        return new PlanReportHeaderData("Unit Report", this.reportid, this.unitReport.description, this.unitReport.reportStatus, this.unitReport.organization);
    }
}
