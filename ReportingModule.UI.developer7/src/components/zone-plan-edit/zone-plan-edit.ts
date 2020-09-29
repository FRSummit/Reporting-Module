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
import { ZonePlanViewModelDto } from "models/ZonePlanViewModelDto";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { PlanReportHeaderData } from "resources/plan-report-header/PlanReportHeaderData";
import { Subscription, EventAggregator } from "aurelia-event-aggregator";
import { ZoneReportUpdated } from "resources/plan-report-header/ZoneReportUpdated";

@autoinject
export class ZonePlanEdit {
    planid: number;
    zonePlan: ZonePlanViewModelDto;
    isSaving = false;
    isSubmitting = false;
    isCancelling = false;
    afterSave: (() => Promise<void>)[] = [];
    initialJson = "";

    signalreventhandlers: any= {};
    subscription: Subscription;
    constructor(public service: ZonePlanReportService, public signalr: SignalrWrapper, public router: AppRouter, public ea?: EventAggregator) {
        this.signalreventhandlers = {
            "ZonePlanUpdated": this.onZonePlanUpdated,
            "ZonePlanUpdateFailed": this.onZonePlanUpdateFailed,
            "ZonePlanSubmitted": this.onZonePlanSubmitted,
            "ZonePlanSubmitFailed": this.onZonePlanSubmitFailed
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
        this.subscription = this.ea.subscribe(ZoneReportUpdated, _ => this.loadPlan());
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
        const zonePlan = await this.service.getPlan(this.planid);
        this.zonePlan = zonePlan;
        this.setInitialData();
    }

    setInitialData() {
        const initialData = this.getPlanData();
        this.initialJson = JSON.stringify(initialData);
    }

    getPlanData(): PlanData {
        return new PlanData(
            this.makeMemberPlanData(this.zonePlan.associateMemberPlanData),
            this.makeMemberPlanData(this.zonePlan.preliminaryMemberPlanData),
            this.makeMemberPlanData(this.zonePlan.supporterMemberPlanData),
            this.makeMemberPlanData(this.zonePlan.memberMemberPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.workerMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.cmsMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.smMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.memberMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.dawahMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.stateLeaderMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.stateOutingMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.iftarMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.learningMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.socialDawahMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.dawahGroupMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.nextGMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.tafsirMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.unitMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.bbqMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.gatheringMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.familyVisitMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.eidReunionMeetingProgramPlanData),
            this.makeMeetingProgramPlanData(this.zonePlan.otherMeetingProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.groupStudyTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.studyCircleForAssociateMemberTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.studyCircleTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.practiceDarsTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.stateLearningCampTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.quranStudyTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.hadithTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.quranClassTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.weekendIslamicSchoolTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.memorizingAyatTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.memorizingHadithTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.memorizingDoaTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.stateLearningSessionTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.stateQiyamulLailTeachingLearningProgramPlanData),
            this.makeTeachingLearningProgramPlanData(this.zonePlan.otherTeachingLearningProgramPlanData),
            this.makeSocialWelfarePlanData(this.zonePlan.qardeHasanaSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.zonePlan.patientVisitSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.zonePlan.socialVisitSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.zonePlan.transportSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.zonePlan.shiftingSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.zonePlan.shoppingSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.zonePlan.foodDistributionSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.zonePlan.cleanUpAustraliaSocialWelfarePlanData),
            this.makeSocialWelfarePlanData(this.zonePlan.otherSocialWelfarePlanData),
            this.makeMaterialPlanData(this.zonePlan.bookSaleMaterialPlanData),
            this.makeMaterialPlanData(this.zonePlan.bookDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.zonePlan.vhsSaleMaterialPlanData),
            this.makeMaterialPlanData(this.zonePlan.vhsDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.zonePlan.emailDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.zonePlan.ipdcLeafletDistributionMaterialPlanData),
            this.makeMaterialPlanData(this.zonePlan.otherSaleMaterialPlanData),
            this.makeMaterialPlanData(this.zonePlan.otherDistributionMaterialPlanData),
            this.makeFinancePlanData(this.zonePlan.baitulMalFinancePlanData),
            this.makeFinancePlanData(this.zonePlan.aDayMasjidProjectFinancePlanData),
            this.makeFinancePlanData(this.zonePlan.masjidTableBankFinancePlanData)
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
            await this.service.updatePlan(this.zonePlan.organization.id, this.planid, this.getPlanData());
            this.isSaving = true;
        } catch(error) {
            toastr.error(error, "Error Saving Plan");
        }
    }

    submitPlan = async () => {
      try {
          await this.service.submitPlan(this.zonePlan.organization.id, this.planid);
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

    onZonePlanUpdated = async (id: number) => {
        this.isSaving = false;
        toastr.success("Plan Saved");
        this.setInitialData();
        if(this.afterSave.length === 0) return;
        await this.afterSave.pop()();
    }

    onZonePlanUpdateFailed = (e: {$values: string[]}) => {
        this.isSaving = false;
        toastr.error(e.$values.join("\n"), "Error Saving Plan");
        if(this.afterSave.length === 0) return;
        this.afterSave.pop();
    }

  onZonePlanSubmitted = (id: number) => {
      this.isSubmitting = false;
      toastr.success("Plan Submitted");
      this.router.navigate(`zone-plan-view/${id}`);
  }

  onZonePlanSubmitFailed = (e: {$values: string[]}) => {
      this.isSubmitting = false;
      toastr.error(e.$values.join("\n"), "Error Submitting Plan");
  }

  get headerData() {
    if(!this.zonePlan) return undefined;
    return new PlanReportHeaderData("Zone Plan", this.planid, this.zonePlan.description, this.zonePlan.reportStatus, this.zonePlan.organization);
  }
}
