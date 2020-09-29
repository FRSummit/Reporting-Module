import * as moment from "moment";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { UnitPlanViewModelDto } from "models/UnitPlanViewModelDto";
import { UnitPlanEdit } from "./unit-plan-edit";
import { SignalrWrapper } from "signalrwrapper";
import { PlanData } from "models/PlanData";
import { MemberPlanData } from "models/MemberPlanData";
import { MeetingProgramPlanData } from "models/MeetingProgramPlanData";
import { AppRouter } from "aurelia-router";
import { SocialWelfarePlanData } from "models/SocialWelfarePlanData";
import { TeachingLearningProgramPlanData } from "models/TeachingLearningProgramPlanData";
import { MaterialPlanData } from "models/MaterialPlanData";
import { FinanceData } from "models/FinanceData";
import { FinancePlanData } from "models/FinancePlanData";


describe("unit plan edit tests", () => {
    it("loadPlan calls expected service", async () => {
        const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();
        const uniPlanReportService = new UnitPlanReportService();
        spyOn(uniPlanReportService, "getPlan").and.returnValue(dto);
        
        const sut = new UnitPlanEdit(uniPlanReportService, new SignalrWrapper(), undefined);
        sut.planid = 13;
        
        await sut.loadPlan();

        expect(uniPlanReportService.getPlan).toHaveBeenCalledWith(13);
        expect(sut.unitPlan).toBe(dto);
        expect(sut.isDirty).toBe(false);
        expect(sut.canSave).toBe(false);
        expect(sut.canCancel).toBe(true);
        expect(sut.canSubmit).toBe(true);
    });

    it("save does nothin when not dirty", async () => {
      // Arrange
      const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();
      const unitPlanReportService = new UnitPlanReportService();
      spyOn(unitPlanReportService, "updatePlan").and.returnValue(Promise.resolve());
      const sut = new UnitPlanEdit(unitPlanReportService, new SignalrWrapper(), undefined);
      sut.planid = 13;
      sut.unitPlan = dto;
      sut.setInitialData();
  
      //Act
      await sut.save();
  
      //Assert
      expect(sut.isSaving).toBe(false);
      expect(unitPlanReportService.updatePlan).not.toHaveBeenCalled();
      expect(sut.afterSave).toEqual([]);
    });
  

    it("save calls expected service when dirty", async () => {
        const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();
        const uniPlanReportService = new UnitPlanReportService();
        spyOn(uniPlanReportService, "updatePlan").and.returnValue(Promise.resolve());
        const sut = new UnitPlanEdit(uniPlanReportService, new SignalrWrapper(), undefined);
        sut.planid = 13;
        sut.unitPlan = dto;

        sut.unitPlan.preliminaryMemberPlanData.upgradeTarget = 45;
        await sut.save();

        const expectedPlanData = getExpectedPlanData(sut.unitPlan);
        expect(sut.isSaving).toBe(true);
        expect(uniPlanReportService.updatePlan).toHaveBeenCalledWith(3, 13, expectedPlanData);
        expect(sut.afterSave).toEqual([]);
    
    });

    it("saveAndSubmit calls expected service when dirty and set expected afterSave", async () => {
      // Arrange
      const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();
      const unitPlanReportService = new UnitPlanReportService();
      spyOn(unitPlanReportService, "updatePlan").and.returnValue(Promise.resolve());
      const sut = new UnitPlanEdit(unitPlanReportService, new SignalrWrapper(), undefined);
      sut.planid = 13;
      sut.unitPlan = dto;
      sut.setInitialData();
  
      //Act
      sut.unitPlan.associateMemberPlanData.upgradeTarget = 15;
      await sut.saveAndSubmitPlan();
  
      //Assert
      const expectedPlanData = getExpectedPlanData(sut.unitPlan);
      expect(sut.isSaving).toBe(true);
      expect(unitPlanReportService.updatePlan).toHaveBeenCalledWith(3, 13, expectedPlanData);
      expect(sut.afterSave).toEqual([sut.submitPlan]);
    });
  
    it("onUnitPlanUpdated sets flag and calls afterSave", async () => {
      // Arrange
      const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();
      const unitPlanReportService = new UnitPlanReportService();
      spyOn(unitPlanReportService, "submitPlan").and.returnValue(Promise.resolve());
      const sut = new UnitPlanEdit(unitPlanReportService, new SignalrWrapper(), undefined);
      sut.planid = 13;
      sut.unitPlan = dto;
      sut.setInitialData();
      sut.unitPlan.associateMemberPlanData.upgradeTarget = 15;
      expect(sut.isDirty).toBe(true);
      sut.afterSave.push(sut.submitPlan);
  
      // Act
      await sut.onUnitPlanUpdated(13);
  
      expect(sut.isSaving).toBe(false);
      expect(sut.isSubmitting).toBe(true);
      expect(unitPlanReportService.submitPlan).toHaveBeenCalledWith(3, 13);
    });  

    it("onStatePlanUpdated sets flag and does nothing if no afterSave", async () => {
      // Arrange
      const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();
      const unitPlanReportService = new UnitPlanReportService();
      spyOn(unitPlanReportService, "submitPlan").and.returnValue(Promise.resolve());
      const sut = new UnitPlanEdit(unitPlanReportService, new SignalrWrapper(), undefined);
      sut.planid = 13;
      sut.unitPlan = dto;
      sut.setInitialData();
      sut.unitPlan.associateMemberPlanData.upgradeTarget = 45;
      expect(sut.isDirty).toBe(true);
      sut.afterSave = [];
  
      // Act
      await sut.onUnitPlanUpdated(1007);
  
      expect(sut.isSaving).toBe(false);
      expect(sut.isSubmitting).toBe(false);
      expect(unitPlanReportService.submitPlan).not.toHaveBeenCalled();
    });
  
    it("onUnitPlanUpdateFailed sets flag and does nothing if no afterSave", () => {
      // Arrange
      const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();
      const svc = new UnitPlanReportService();
      spyOn(svc, "submitPlan").and.returnValue(Promise.resolve());
      const sut = new UnitPlanEdit(svc, new SignalrWrapper(), undefined);
      sut.planid = 13;
      sut.unitPlan = dto;
      sut.setInitialData();
      sut.unitPlan.associateMemberPlanData.upgradeTarget = 15;
      expect(sut.isDirty).toBe(true);
      sut.afterSave = [];
  
      // Act
      sut.onUnitPlanUpdateFailed({$values: ["error"]});
  
      expect(sut.isSaving).toBe(false);
      expect(sut.isSubmitting).toBe(false);
      expect(sut.afterSave).toEqual([]);
    });
  
    it("onUnitPlanUpdateFailed sets flag and clears afterSave", () => {
      // Arrange
      const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();
      const svc = new UnitPlanReportService();
      spyOn(svc, "submitPlan").and.returnValue(Promise.resolve());
      const sut = new UnitPlanEdit(svc, new SignalrWrapper(), undefined);
      sut.planid = 13;
      sut.unitPlan = dto;
      sut.setInitialData();
      sut.unitPlan.associateMemberPlanData.upgradeTarget = 15;
      expect(sut.isDirty).toBe(true);
      sut.afterSave = [sut.submitPlan];
  
      // Act
      sut.onUnitPlanUpdateFailed({$values: ["error"]});
  
      expect(sut.isSaving).toBe(false);
      expect(sut.isSubmitting).toBe(false);
      expect(sut.afterSave).toEqual([]);
    });
  


    it("onUnitPlanUpdated resets saving flag and dirty state", () => {
      const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();  
        const sut = new UnitPlanEdit(new UnitPlanReportService(), new SignalrWrapper(), undefined);
        sut.unitPlan = dto;
        sut.setInitialData();
        sut.unitPlan.associateMemberPlanData.upgradeTarget = 7;

        expect(sut.isDirty).toBe(true);
        sut.isSaving = true;
        
        sut.onUnitPlanUpdated(13);

        expect(sut.isSaving).toBe(false);
        expect(sut.isDirty).toBe(false);
    });

    it("onUnitPlanUpdateFailed resets saving flag", () => {
        const sut = new UnitPlanEdit(new UnitPlanReportService(), new SignalrWrapper(), undefined);
        sut.isSaving = true;

        sut.onUnitPlanUpdateFailed({$values: ["error"]});

        expect(sut.isSaving).toBe(false);
    });

    it("isDirty tracks changes", () => {
        const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();

        const sut = new UnitPlanEdit(new UnitPlanReportService(), new SignalrWrapper(), undefined);
        sut.unitPlan = dto;

        sut.setInitialData();

        expect(sut.isDirty).toBe(false);

        sut.unitPlan.workerMeetingProgramPlanData.target = 5;
        expect(sut.isDirty).toBe(true);
    });

    it("cancelChanges calls expected method", async () => {

        const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();
        const svc = new UnitPlanReportService();
        spyOn(svc, "getPlan").and.returnValue(dto);
        const sut = new UnitPlanEdit(svc, new SignalrWrapper(), undefined);
        sut.planid = 13;
        sut.unitPlan = dto;

        await sut.cancelChanges();

        expect(svc.getPlan).toHaveBeenCalledWith(13);
    });

    it("submitPlan calls expected service", async () => {
        const dto: UnitPlanViewModelDto = getUnitPlanViewModelDto();        
        const uniPlanReportService = new UnitPlanReportService();
        spyOn(uniPlanReportService, "submitPlan").and.returnValue(Promise.resolve());
        const sut = new UnitPlanEdit(uniPlanReportService, new SignalrWrapper(), undefined);
        sut.planid = 13;
        sut.unitPlan = dto;

        await sut.submitPlan();

        expect(sut.isSubmitting).toBe(true);
        expect(uniPlanReportService.submitPlan).toHaveBeenCalledWith(
            3, 13);
    });

    it("onUnitPlanSubmitted resets flag and calls expected method on router", () => {
        const svc = new UnitPlanReportService();
        spyOn(svc, "submitPlan").and.returnValue(Promise.resolve());
        const router = {
            navigate: () => {}
        } as any as AppRouter;
        spyOn(router, "navigate");
        const sut = new UnitPlanEdit(svc, new SignalrWrapper(), router);
        sut.isSubmitting = true;

        sut.onUnitPlanSubmitted(1);
        
        expect(sut.isSubmitting).toBe(false);
        expect(router.navigate).toHaveBeenCalledWith("unit-plan-view/1");
    });

    it("onUnitPlanSubmitFailed resets flag", () => {
        const sut = new UnitPlanEdit(new UnitPlanReportService(), new SignalrWrapper(), undefined);
        sut.isSubmitting = true;

        sut.onUnitPlanSubmitFailed({$values: ["error"]});

        expect(sut.isSubmitting).toBe(false);
    });


    function getUnitPlanViewModelDto(): UnitPlanViewModelDto {
      return {
        "id":13,"description":"TBD",
        "organization":{"id":3,"organizationType":1,"description":"Footscray Unit","reportingFrequency":1},
        "reportingPeriod":{
            "startDate":moment("2019-01-01T00:00:00").toDate(),
            "endDate":moment("2019-01-31T00:00:00").toDate(),
            "reportingFrequency":1,"reportingTerm":1,"year":2019},
        "reportStatus":1,"reportStatusDescription":"Draft",
        "reOpenedReportStatus":0,"reOpenedReportStatusDescription":"None",
        "associateMemberPlanData":{"nameAndContactNumber":null,"action":null,"upgradeTarget":0},
        "preliminaryMemberPlanData":{"nameAndContactNumber":null,"action":null,"upgradeTarget":0},
        "supporterMemberPlanData": {"nameAndContactNumber": "asdf", "action": "asdf", "upgradeTarget": 2},
        "workerMeetingProgramPlanData":{"target":0,"dateAndAction":null},
        "cmsMeetingProgramPlanData":{"target":0,"dateAndAction":null},
        "smMeetingProgramPlanData":{"target":0,"dateAndAction":null},
        "memberMeetingProgramPlanData":{"target":0,"dateAndAction":null},
        "dawahMeetingProgramPlanData": {"target": 6,"dateAndAction": ";lkj;lkj"},
        "stateLeaderMeetingProgramPlanData": {"target": 3,"dateAndAction": "l;kj"},
        "stateOutingMeetingProgramPlanData": {"target": 4,"dateAndAction": "jklhjk"},
        "iftarMeetingProgramPlanData": {"target": 5,"dateAndAction": ",mb"},
        "learningMeetingProgramPlanData": {"target": 6,"dateAndAction": ",mb"},
        "socialDawahMeetingProgramPlanData": {"target": 45,"dateAndAction": ";l;"},
        "dawahGroupMeetingProgramPlanData": {"target": 6,"dateAndAction": ";lkj;lkj"},
        "nextGMeetingProgramPlanData": {"target": 89,"dateAndAction": "k;lhkl;j"},
        "tafsirMeetingProgramPlanData": {"target": 89,"dateAndAction": "k;lhkl;j"},
        "unitMeetingProgramPlanData": {"target": 89,"dateAndAction": "k;lhkl;j"},
        "bbqMeetingProgramPlanData": {"target": 89,"dateAndAction": "k;lhkl;j"},
        "gatheringMeetingProgramPlanData": {"target": 89,"dateAndAction": "k;lhkl;j"},
        "familyVisitMeetingProgramPlanData": {"target": 89,"dateAndAction": "k;lhkl;j"},
        "eidReunionMeetingProgramPlanData": {"target": 89,"dateAndAction": "k;lhkl;j"},
        "otherMeetingProgramPlanData": {"target": 89,"dateAndAction": "k;lhkl;j"},
        "memberMemberPlanData": {"nameAndContactNumber": "fdas","action": "fdsa","upgradeTarget": 2},
        "groupStudyTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "studyCircleForAssociateMemberTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "studyCircleTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "practiceDarsTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "stateLearningCampTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "quranStudyTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "hadithTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "quranClassTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "weekendIslamicSchoolTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "memorizingAyatTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "memorizingHadithTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "memorizingDoaTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "stateLearningSessionTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "stateQiyamulLailTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "otherTeachingLearningProgramPlanData": {"target": 1,"dateAndAction": ""},
        "baitulMalFinancePlanData": {"action": null,"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8}},
        "aDayMasjidProjectFinancePlanData": {"action": null,"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8}},
        "masjidTableBankFinancePlanData": {"action": null,"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8}},
        "qardeHasanaSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
        "patientVisitSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
        "socialVisitSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
        "transportSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
        "shiftingSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
        "shoppingSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
        "foodDistributionSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
        "cleanUpAustraliaSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
        "otherSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
        "bookSaleMaterialPlanData": {"target": 1,"dateAndAction": "kj"},
        "bookDistributionMaterialPlanData": {"target": 2,"dateAndAction": "kjh"},
        "vhsSaleMaterialPlanData": {"target": 3,"dateAndAction": "hjk"},
        "vhsDistributionMaterialPlanData": {"target": 4,"dateAndAction": "bnm"},
        "emailDistributionMaterialPlanData": {"target": 5,"dateAndAction": "vb"},
        "ipdcLeafletDistributionMaterialPlanData": {"target": 6,"dateAndAction": ",nm"},
        "otherSaleMaterialPlanData": {"target": 3,"dateAndAction": "hjk"},
        "otherDistributionMaterialPlanData": {"target": 4,"dateAndAction": "bnm"},
        "timestamp":moment("2019-07-25T09:56:42.25").toDate()};
    }
  
    function getExpectedPlanData(dto: UnitPlanViewModelDto): PlanData {
      return new PlanData(
        makeMemberPlanData(dto.associateMemberPlanData),
        makeMemberPlanData(dto.preliminaryMemberPlanData),
        makeMemberPlanData(dto.supporterMemberPlanData),
        makeMemberPlanData(dto.memberMemberPlanData),
        makeMeetingProgramPlanData(dto.workerMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.cmsMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.smMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.memberMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.dawahMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.stateLeaderMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.stateOutingMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.iftarMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.learningMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.socialDawahMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.dawahGroupMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.nextGMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.tafsirMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.unitMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.bbqMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.gatheringMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.familyVisitMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.eidReunionMeetingProgramPlanData),
        makeMeetingProgramPlanData(dto.otherMeetingProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.groupStudyTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.studyCircleForAssociateMemberTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.studyCircleTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.practiceDarsTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.stateLearningCampTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.quranStudyTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.hadithTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.quranClassTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.weekendIslamicSchoolTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.memorizingAyatTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.memorizingHadithTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.memorizingDoaTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.stateLearningSessionTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.stateQiyamulLailTeachingLearningProgramPlanData),
        makeTeachingLearningProgramPlanData(dto.otherTeachingLearningProgramPlanData),
        makeSocialWelfarePlanData(dto.qardeHasanaSocialWelfarePlanData),
        makeSocialWelfarePlanData(dto.patientVisitSocialWelfarePlanData),
        makeSocialWelfarePlanData(dto.socialVisitSocialWelfarePlanData),
        makeSocialWelfarePlanData(dto.transportSocialWelfarePlanData),
        makeSocialWelfarePlanData(dto.shiftingSocialWelfarePlanData),
        makeSocialWelfarePlanData(dto.shoppingSocialWelfarePlanData),
        makeSocialWelfarePlanData(dto.foodDistributionSocialWelfarePlanData),
        makeSocialWelfarePlanData(dto.cleanUpAustraliaSocialWelfarePlanData),
        makeSocialWelfarePlanData(dto.otherSocialWelfarePlanData),
        makeMaterialPlanData(dto.bookSaleMaterialPlanData),
        makeMaterialPlanData(dto.bookDistributionMaterialPlanData),
        makeMaterialPlanData(dto.vhsSaleMaterialPlanData),
        makeMaterialPlanData(dto.vhsDistributionMaterialPlanData),
        makeMaterialPlanData(dto.emailDistributionMaterialPlanData),
        makeMaterialPlanData(dto.ipdcLeafletDistributionMaterialPlanData),
        makeMaterialPlanData(dto.otherSaleMaterialPlanData),
        makeMaterialPlanData(dto.otherDistributionMaterialPlanData),
        makeFinancePlanData(dto.baitulMalFinancePlanData),
        makeFinancePlanData(dto.aDayMasjidProjectFinancePlanData),
        makeFinancePlanData(dto.masjidTableBankFinancePlanData));
    }
    
    function makeMeetingProgramPlanData(original: MeetingProgramPlanData): MeetingProgramPlanData {
        return new MeetingProgramPlanData(original.target, original.dateAndAction);
    }
  
    function makeMemberPlanData(original: MemberPlanData): MemberPlanData {
        return new MemberPlanData(original.nameAndContactNumber, original.action, original.upgradeTarget);
    }

    function makeTeachingLearningProgramPlanData(original: TeachingLearningProgramPlanData): TeachingLearningProgramPlanData {
      return new TeachingLearningProgramPlanData(original.target, original.dateAndAction);
    }

    function makeSocialWelfarePlanData(original: SocialWelfarePlanData) {
      return new SocialWelfarePlanData(original.target, original.dateAndAction);
    }

    function makeMaterialPlanData(original: MaterialPlanData) {
      return new MaterialPlanData(original.target, original.dateAndAction);
    }

    function makeFinancePlanData(original: FinancePlanData) {
      return new FinancePlanData(original.action, original.workerPromiseIncreaseTarget, original.otherSourceAction, original.otherSourceIncreaseTarget);
    }
});
