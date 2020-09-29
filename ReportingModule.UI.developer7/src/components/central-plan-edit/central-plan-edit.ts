import { autoinject } from "aurelia-framework";
import * as toastr from "toastr";
import { SignalrWrapper } from "signalrwrapper";
import { PlanData } from "models/PlanData";
import { MemberPlanData } from "models/MemberPlanData";
import { MeetingProgramPlanData } from "models/MeetingProgramPlanData";
import { AppRouter } from "aurelia-router";
import { TeachingLearningProgramPlanData } from "models/TeachingLearningProgramPlanData";
import { MaterialPlanData } from "models/MaterialPlanData";
import { FinancePlanData } from "models/FinancePlanData";
import { SocialWelfarePlanData } from "models/SocialWelfarePlanData";
import { CentralPlanViewModelDto } from "models/CentralPlanViewModelDto";
import { CentralPlanReportService } from "services/CentralPlanReportService";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { EventAggregator, Subscription } from "aurelia-event-aggregator";
import { CentralReportUpdated } from "resources/plan-report-header/CentralReportUpdated";


@autoinject
export class CentralPlanEdit {
    planid: number;
    centralPlan: CentralPlanViewModelDto;
    isSaving = false;
    isSubmitting = false;
    isCancelling = false;
    afterSave: (() => Promise<void>)[] = [];
    initialJson = "";

    signalreventhandlers: any= {};
    subscription: Subscription;
    constructor(public service: CentralPlanReportService, public signalr: SignalrWrapper, public router: AppRouter, public ea?: EventAggregator) {
        this.signalreventhandlers = {
            "CentralPlanUpdated": this.onCentralPlanUpdated,
            "CentralPlanUpdateFailed": this.onCentralPlanUpdateFailed,
            "CentralPlanSubmitted": this.onCentralPlanSubmitted,
            "CentralPlanSubmitFailed": this.onCentralPlanSubmitFailed
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
        this.subscription = this.ea.subscribe(CentralReportUpdated, _ => this.loadPlan());
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
        const centralPlan = await this.service.getPlan(this.planid);
        this.centralPlan = centralPlan;
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getPlanData();
        this.initialJson = JSON.stringify(initialData);
    }

    getPlanData(): PlanData {
        return new PlanData(
            this.makeMemberPlanData(this.centralPlan.associateMemberPlanData),
            this.makeMemberPlanData(this.centralPlan.preliminaryMemberPlanData),
            this.makeMemberPlanData(this.centralPlan.supporterMemberPlanData),
            this.makeMemberPlanData(this.centralPlan.memberMemberPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.workerMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.cmsMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.smMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.memberMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.dawahMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.stateLeaderMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.stateOutingMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.iftarMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.learningMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.socialDawahMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.dawahGroupMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.nextGMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.tafsirMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.unitMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.bbqMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.gatheringMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.familyVisitMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.eidReunionMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.centralPlan.otherMeetingProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.groupStudyTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.studyCircleForAssociateMemberTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.studyCircleTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.practiceDarsTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.stateLearningCampTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.quranStudyTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.hadithTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.quranClassTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.weekendIslamicSchoolTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.memorizingAyatTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.memorizingHadithTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.memorizingDoaTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.stateLearningSessionTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.stateQiyamulLailTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.centralPlan.otherTeachingLearningProgramPlanData),
            this.makeSocialWelfarePlanData(this.centralPlan.qardeHasanaSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.centralPlan.patientVisitSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.centralPlan.socialVisitSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.centralPlan.transportSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.centralPlan.shiftingSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.centralPlan.shoppingSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.centralPlan.foodDistributionSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.centralPlan.cleanUpAustraliaSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.centralPlan.otherSocialWelfarePlanData),
            this.makeMaterialPlanData(this.centralPlan.bookSaleMaterialPlanData),
            this.makeMaterialPlanData(this.centralPlan.bookDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.centralPlan.vhsSaleMaterialPlanData),
            this.makeMaterialPlanData(this.centralPlan.vhsDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.centralPlan.emailDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.centralPlan.ipdcLeafletDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.centralPlan.otherSaleMaterialPlanData),
            this.makeMaterialPlanData(this.centralPlan.otherDistributionMaterialPlanData),
            this.makeFinancePlanData(this.centralPlan.baitulMalFinancePlanData),
            this.makeFinancePlanData(this.centralPlan.aDayMasjidProjectFinancePlanData),
            this.makeFinancePlanData(this.centralPlan.masjidTableBankFinancePlanData)
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
            await this.service.updatePlan(this.centralPlan.organization.id, this.planid, this.getPlanData());
            this.isSaving = true;
        } catch(error) {
            toastr.error(error, "Error Saving Plan");
        }
    }

    submitPlan = async () => {
      try {
          await this.service.submitPlan(this.centralPlan.organization.id, this.planid);
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

    onCentralPlanUpdated = async (id: number) => {
        this.isSaving = false;
        toastr.success("Plan Saved");
        this.setInitialData();
        if(this.afterSave.length === 0) return;
        await this.afterSave.pop()();
    }

    onCentralPlanUpdateFailed = (e: {$values: string[]}) => {
        this.isSaving = false;
        toastr.error(e.$values.join("\n"), "Error Saving Plan");
        if(this.afterSave.length === 0) return;
        this.afterSave.pop();
    }

  onCentralPlanSubmitted = (id: number) => {
      this.isSubmitting = false;
      toastr.success("Plan Submitted");
      this.router.navigate(`central-plan-view/${id}`);
  }

  onCentralPlanSubmitFailed = (e: {$values: string[]}) => {
      this.isSubmitting = false;
      toastr.error(e.$values.join("\n"), "Error Submitting Plan");
  }

  get headerData() {
    if(!this.centralPlan) return undefined;
    return new PlanReportHeaderData("Central Plan", this.planid, this.centralPlan.description, this.centralPlan.reportStatus, this.centralPlan.organization);
  }
}
