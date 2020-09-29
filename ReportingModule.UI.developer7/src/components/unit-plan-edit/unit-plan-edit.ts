import { autoinject } from "aurelia-framework";
import { AppRouter } from "aurelia-router";
import * as toastr from "toastr";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { UnitPlanViewModelDto } from "models/UnitPlanViewModelDto";
import { SignalrWrapper } from "signalrwrapper";
import { PlanData } from "models/PlanData";
import { MemberPlanData } from "models/MemberPlanData";
import { MeetingProgramPlanData } from "models/MeetingProgramPlanData";
import { SocialWelfareData } from "models/SocialWelfareData";
import { SocialWelfarePlanData } from "models/SocialWelfarePlanData";
import { TeachingLearningProgramPlanData } from "models/TeachingLearningProgramPlanData";
import { MaterialPlanData } from "models/MaterialPlanData";
import { FinancePlanData } from "models/FinancePlanData";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";


@autoinject
export class UnitPlanEdit {
    planid: number;
    unitPlan: UnitPlanViewModelDto;
    isSaving = false;
    isSubmitting = false;
    isCancelling = false;
    initialJson = "";
    afterSave: (() => Promise<void>)[] = [];

    signalreventhandlers: any= {};
    constructor(public service: UnitPlanReportService, public signalr: SignalrWrapper, public router: AppRouter) {
        this.signalreventhandlers = {
            "UnitPlanUpdated": this.onUnitPlanUpdated,
            "UnitPlanUpdateFailed": this.onUnitPlanUpdateFailed,
            "UnitPlanSubmitted": this.onUnitPlanSubmitted,
            "UnitPlanSubmitFailed": this.onUnitPlanSubmitFailed
        };
    }
    
    activate(params: {planid: number}) {
        this.planid = params.planid;
    }

    async attached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.on(key, this.signalreventhandlers[key]);
            }
        }
        await this.loadPlan();
    }

    detached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
    }

    async loadPlan() {
        const unitPlan = await this.service.getPlan(this.planid);
        this.unitPlan = unitPlan;
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getPlanData();
        this.initialJson = JSON.stringify(initialData);
    }

    getPlanData(): PlanData {
        return new PlanData(
            this.makeMemberPlanData(this.unitPlan.associateMemberPlanData),
            this.makeMemberPlanData(this.unitPlan.preliminaryMemberPlanData),
            this.makeMemberPlanData(this.unitPlan.supporterMemberPlanData),
            this.makeMemberPlanData(this.unitPlan.memberMemberPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.workerMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.cmsMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.smMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.memberMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.dawahMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.stateLeaderMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.stateOutingMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.iftarMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.learningMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.socialDawahMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.dawahGroupMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.nextGMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.tafsirMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.unitMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.bbqMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.gatheringMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.familyVisitMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.eidReunionMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.unitPlan.otherMeetingProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.groupStudyTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.studyCircleForAssociateMemberTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.studyCircleTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.practiceDarsTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.stateLearningCampTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.quranStudyTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.hadithTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.quranClassTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.weekendIslamicSchoolTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.memorizingAyatTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.memorizingHadithTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.memorizingDoaTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.stateLearningSessionTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.stateQiyamulLailTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.unitPlan.otherTeachingLearningProgramPlanData),
            this.makeSocialWelfarePlanData(this.unitPlan.qardeHasanaSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.unitPlan.patientVisitSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.unitPlan.socialVisitSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.unitPlan.transportSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.unitPlan.shiftingSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.unitPlan.shoppingSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.unitPlan.foodDistributionSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.unitPlan.cleanUpAustraliaSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.unitPlan.otherSocialWelfarePlanData),
            this.makeMaterialPlanData(this.unitPlan.bookSaleMaterialPlanData),
            this.makeMaterialPlanData(this.unitPlan.bookDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.unitPlan.vhsSaleMaterialPlanData),
            this.makeMaterialPlanData(this.unitPlan.vhsDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.unitPlan.emailDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.unitPlan.ipdcLeafletDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.unitPlan.otherSaleMaterialPlanData),
            this.makeMaterialPlanData(this.unitPlan.otherDistributionMaterialPlanData),
            this.makeFinancePlanData(this.unitPlan.baitulMalFinancePlanData),
            this.makeFinancePlanData(this.unitPlan.aDayMasjidProjectFinancePlanData),
            this.makeFinancePlanData(this.unitPlan.masjidTableBankFinancePlanData));
    }

    private makeMemberPlanData(original: MemberPlanData): MemberPlanData {
        return new MemberPlanData(original.nameAndContactNumber, original.action, original.upgradeTarget);
    }

    private makeMeetingProgramPlanData(original: MeetingProgramPlanData): MeetingProgramPlanData {
        return new MeetingProgramPlanData(original.target, original.dateAndAction);
    }

    private makeTeachingLearningProgramPlanData(original: TeachingLearningProgramPlanData): TeachingLearningProgramPlanData {
        return new TeachingLearningProgramPlanData(original.target, original.dateAndAction);
    }
    
    private makeSocialWelfarePlanData(original: SocialWelfarePlanData) {
        return new SocialWelfarePlanData(original.target, original.dateAndAction);
    }

    private makeMaterialPlanData(original: MaterialPlanData) {
        return new MaterialPlanData(original.target, original.dateAndAction);
    }

    private makeFinancePlanData(original: FinancePlanData) {
        return new FinancePlanData(original.action, original.workerPromiseIncreaseTarget, original.otherSourceAction, original.otherSourceIncreaseTarget);
    }

    async save() {
      if (!this.isDirty) return;
        try {
            await this.service.updatePlan(this.unitPlan.organization.id, this.planid, this.getPlanData());
        } catch(error) {
            toastr.error(error, "Error Saving Plan");
            return;
        }
        this.isSaving = true;
    }

    get isDirty() {
        const latestJson = JSON.stringify(this.getPlanData());
        return latestJson !== this.initialJson;
    }

    async cancelChanges() {
        this.isCancelling = true;
        await this.loadPlan();
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

    onUnitPlanUpdated = async (id: number) => {
        this.isSaving = false;
        toastr.success("Plan Saved");
        this.setInitialData();
        if(this.afterSave.length === 0) return;
        await this.afterSave.pop()();  
    }

    onUnitPlanUpdateFailed = (e: {$values: string[]}) => {
        this.isSaving = false;
        toastr.error(e.$values.join("\n"), "Error Saving Plan");
        if(this.afterSave.length === 0) return;
        this.afterSave.pop();
    }

    submitPlan = async () => {
        try {
            await this.service.submitPlan(this.unitPlan.organization.id, this.planid);
        } catch(error) {
            toastr.error(error, "Error Submitting Plan");
        }
        this.isSubmitting = true;
    }

    saveAndSubmitPlan = async () => {
      if (this.isDirty)
      {
        await this.save();
        this.afterSave.push(this.submitPlan);
        return;
      } 
      await this.submitPlan();
  }

    onUnitPlanSubmitted = (id: number) => {
        this.isSubmitting = false;
        toastr.success("Plan Submitted");
        this.router.navigate(`unit-plan-view/${id}`);
    }

    onUnitPlanSubmitFailed = (e: {$values: string[]}) => {
        this.isSubmitting = false;
        toastr.error(e.$values.join("\n"), "Error Submitting Plan");
        if(this.afterSave.length === 0) return;
        this.afterSave.pop();
    }

    get headerData() {
        if(!this.unitPlan) return undefined;
        return new PlanReportHeaderData("Unit Plan", this.planid, this.unitPlan.description, this.unitPlan.reportStatus, this.unitPlan.organization);
    }
}
