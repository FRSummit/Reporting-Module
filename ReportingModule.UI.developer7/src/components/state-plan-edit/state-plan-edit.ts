import { autoinject } from "aurelia-framework";
import * as toastr from "toastr";
import { StatePlanReportService } from "services/StatePlanReportService";
import { StatePlanViewModelDto } from "models/StatePlanViewModelDto";
import { SignalrWrapper } from "signalrwrapper";
import { PlanData } from "models/PlanData";
import { MemberPlanData } from "models/MemberPlanData";
import { MeetingProgramPlanData } from "models/MeetingProgramPlanData";
import { AppRouter } from "aurelia-router";
import { TeachingLearningProgramPlanData } from "models/TeachingLearningProgramPlanData";
import { MaterialPlanData } from "models/MaterialPlanData";
import { FinancePlanData } from "models/FinancePlanData";
import { SocialWelfarePlanData } from "models/SocialWelfarePlanData";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { Subscription, EventAggregator } from "aurelia-event-aggregator";
import { StateReportUpdated } from "resources/plan-report-header/StateReportUpdated";

@autoinject
export class StatePlanEdit {
    planid: number;
    statePlan: StatePlanViewModelDto;
    isSaving = false;
    isSubmitting = false;
    isCancelling = false;
    afterSave: (() => Promise<void>)[] = [];
    initialJson = "";

    signalreventhandlers: any= {};
    subscription: Subscription;
    constructor(public service: StatePlanReportService, public signalr: SignalrWrapper, public router: AppRouter, public ea?: EventAggregator) {
        this.signalreventhandlers = {
            "StatePlanUpdated": this.onStatePlanUpdated,
            "StatePlanUpdateFailed": this.onStatePlanUpdateFailed,
            "StatePlanSubmitted": this.onStatePlanSubmitted,
            "StatePlanSubmitFailed": this.onStatePlanSubmitFailed
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
        this.subscription = this.ea.subscribe(StateReportUpdated, _ => this.loadPlan());
        await this.loadPlan();
    }

    detached() {
        for (const key in this.signalreventhandlers) {
            if (this.signalreventhandlers.hasOwnProperty(key)) {
                this.signalr.off(key, this.signalreventhandlers[key]);
            }
        }
        this.subscription.dispose();
    }

    async loadPlan() {
        const statePlan = await this.service.getPlan(this.planid);
        this.statePlan = statePlan;
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getPlanData();
        this.initialJson = JSON.stringify(initialData);
    }

    getPlanData(): PlanData {
        return new PlanData(
            this.makeMemberPlanData(this.statePlan.associateMemberPlanData),
            this.makeMemberPlanData(this.statePlan.preliminaryMemberPlanData),
            this.makeMemberPlanData(this.statePlan.supporterMemberPlanData),
            this.makeMemberPlanData(this.statePlan.memberMemberPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.workerMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.cmsMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.smMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.memberMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.dawahMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.stateLeaderMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.stateOutingMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.iftarMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.learningMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.socialDawahMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.dawahGroupMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.nextGMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.tafsirMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.unitMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.bbqMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.gatheringMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.familyVisitMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.eidReunionMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.statePlan.otherMeetingProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.groupStudyTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.studyCircleForAssociateMemberTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.studyCircleTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.practiceDarsTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.stateLearningCampTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.quranStudyTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.hadithTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.quranClassTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.weekendIslamicSchoolTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.memorizingAyatTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.memorizingHadithTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.memorizingDoaTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.stateLearningSessionTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.stateQiyamulLailTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.statePlan.otherTeachingLearningProgramPlanData),
            this.makeSocialWelfarePlanData(this.statePlan.qardeHasanaSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.statePlan.patientVisitSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.statePlan.socialVisitSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.statePlan.transportSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.statePlan.shiftingSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.statePlan.shoppingSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.statePlan.foodDistributionSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.statePlan.cleanUpAustraliaSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.statePlan.otherSocialWelfarePlanData),
            this.makeMaterialPlanData(this.statePlan.bookSaleMaterialPlanData),
            this.makeMaterialPlanData(this.statePlan.bookDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.statePlan.vhsSaleMaterialPlanData),
            this.makeMaterialPlanData(this.statePlan.vhsDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.statePlan.emailDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.statePlan.ipdcLeafletDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.statePlan.otherSaleMaterialPlanData),
            this.makeMaterialPlanData(this.statePlan.otherDistributionMaterialPlanData),
            this.makeFinancePlanData(this.statePlan.baitulMalFinancePlanData),
            this.makeFinancePlanData(this.statePlan.aDayMasjidProjectFinancePlanData),
            this.makeFinancePlanData(this.statePlan.masjidTableBankFinancePlanData)
        );
    }

    private makeMeetingProgramPlanData(original: MeetingProgramPlanData): MeetingProgramPlanData {
        return new MeetingProgramPlanData(original.target, original.dateAndAction);
    }

    private makeMemberPlanData(original: MemberPlanData): MemberPlanData {
        return new MemberPlanData(original.nameAndContactNumber, original.action, original.upgradeTarget);
    }

    private makeTeachingLearningProgramPlanData(original: TeachingLearningProgramPlanData): TeachingLearningProgramPlanData {
        return new TeachingLearningProgramPlanData(original.target, original.dateAndAction);
    }

    private makeMaterialPlanData(original: MaterialPlanData): MaterialPlanData {
        return new MaterialPlanData(original.target, original.dateAndAction);
    }

    private makeFinancePlanData(original: FinancePlanData): FinancePlanData {
        return new FinancePlanData(original.action, original.workerPromiseIncreaseTarget, original.otherSourceAction, original.otherSourceIncreaseTarget);
    }

    private makeSocialWelfarePlanData(original: SocialWelfarePlanData): SocialWelfarePlanData {
        return new SocialWelfarePlanData(original.target, original.dateAndAction);
    }

    save = async () => {
        if (!this.isDirty) return;
        try {
            await this.service.updatePlan(this.statePlan.organization.id, this.planid, this.getPlanData());
            this.isSaving = true;
        } catch(error) {
            toastr.error(error, "Error Saving Plan");
        }
    }

    submitPlan = async () => {
      try {
          await this.service.submitPlan(this.statePlan.organization.id, this.planid);
          this.isSubmitting = true;
      } catch(error) {
          toastr.error(error, "Error Submitting Plan");
      }
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

    onStatePlanUpdated = async (id: number) => {
        this.isSaving = false;
        toastr.success("Plan Saved");
        this.setInitialData();
        if(this.afterSave.length === 0) return;
        await this.afterSave.pop()();
    }

    onStatePlanUpdateFailed = (e: {$values: string[]}) => {
        this.isSaving = false;
        toastr.error(e.$values.join("\n"), "Error Saving Plan");
        if(this.afterSave.length === 0) return;
        this.afterSave.pop();
    }

  onStatePlanSubmitted = (id: number) => {
      this.isSubmitting = false;
      toastr.success("Plan Submitted");
      this.router.navigate(`state-plan-view/${id}`);
  }

  onStatePlanSubmitFailed = (e: {$values: string[]}) => {
      this.isSubmitting = false;
      toastr.error(e.$values.join("\n"), "Error Submitting Plan");
  }

  get headerData() {
      if(!this.statePlan) return undefined;
      return new PlanReportHeaderData("State Plan", this.planid, this.statePlan.description, this.statePlan.reportStatus, this.statePlan.organization);
  }

}
