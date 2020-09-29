import * as moment from "moment";
import { SignalrWrapper } from './../../signalrwrapper';
import { MemberPlanData } from "models/MemberPlanData";
import { MeetingProgramPlanData } from "models/MeetingProgramPlanData";
import { PlanData } from "models/PlanData";
import { TeachingLearningProgramPlanData } from "models/TeachingLearningProgramPlanData";
import { MaterialPlanData } from "models/MaterialPlanData";
import { FinancePlanData } from "models/FinancePlanData";
import { SocialWelfarePlanData } from "models/SocialWelfarePlanData";
import { ZonePlanViewModelDto } from "models/ZonePlanViewModelDto";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { ZonePlanEdit } from "./zone-plan-edit";


describe("zone plan edit tests", () => {
    it("loadPlan calls expectedservice and sets initial data", async () => {
      // Arrange
      const dto: ZonePlanViewModelDto = getZonePlanViewModelDto();
      const svc = new ZonePlanReportService();
      spyOn(svc, "getPlan").and.returnValue(Promise.resolve(dto));
      const sut = new ZonePlanEdit(svc, new SignalrWrapper(), undefined);
      sut.planid = 2;

      // Act
      await sut.loadPlan();

      // Assert
      expect(svc.getPlan).toHaveBeenCalledWith(2);
      expect(sut.initialJson).toBeTruthy();
      expect(sut.canSave).toBe(false);
      expect(sut.canCancel).toBe(true);
      expect(sut.canSubmit).toBe(true);
    });

    // Arrange
    it("submitPlan calls expected service", async () => {
      const dto: ZonePlanViewModelDto = getZonePlanViewModelDto();
      
      const zonePlanReportService = new ZonePlanReportService();
      spyOn(zonePlanReportService, "submitPlan").and.returnValue(Promise.resolve());
      const sut = new ZonePlanEdit(zonePlanReportService, new SignalrWrapper(), undefined);
      sut.planid = 13;
      sut.zonePlan = dto;

      //Act
      await sut.submitPlan();

      //Assert
      expect(sut.isSubmitting).toBe(true);
      expect(zonePlanReportService.submitPlan).toHaveBeenCalledWith(2, 13);
  });
  it("save does nothin when not dirty", async () => {
    // Arrange
    const dto: ZonePlanViewModelDto = getZonePlanViewModelDto();
    const zonePlanReportService = new ZonePlanReportService();
    spyOn(zonePlanReportService, "updatePlan").and.returnValue(Promise.resolve());
    const sut = new ZonePlanEdit(zonePlanReportService, new SignalrWrapper(), undefined);
    sut.planid = 1007;
    sut.zonePlan = dto;
    sut.setInitialData();

    //Act
    await sut.save();

    //Assert
    expect(sut.isSaving).toBe(false);
    expect(zonePlanReportService.updatePlan).not.toHaveBeenCalled();
    expect(sut.afterSave).toEqual([]);
  });

  it("save calls expected service when dirty", async () => {
    // Arrange
    const dto: ZonePlanViewModelDto = getZonePlanViewModelDto();
    const zonePlanReportService = new ZonePlanReportService();
    spyOn(zonePlanReportService, "updatePlan").and.returnValue(Promise.resolve());
    const sut = new ZonePlanEdit(zonePlanReportService, new SignalrWrapper(), undefined);
    sut.planid = 1007;
    sut.zonePlan = dto;
    sut.setInitialData();

    //Act
    sut.zonePlan.preliminaryMemberPlanData.upgradeTarget = 45;
    await sut.save();

    //Assert
    const expectedPlanData = getExpectedPlanData(sut.zonePlan);
    expect(sut.isSaving).toBe(true);
    expect(zonePlanReportService.updatePlan).toHaveBeenCalledWith(2, 1007, expectedPlanData);
    expect(sut.afterSave).toEqual([]);
  });

  it("saveAndSubmit calls expected service when dirty and set expected afterSave", async () => {
    // Arrange
    const dto: ZonePlanViewModelDto = getZonePlanViewModelDto();
    const zonePlanReportService = new ZonePlanReportService();
    spyOn(zonePlanReportService, "updatePlan").and.returnValue(Promise.resolve());
    const sut = new ZonePlanEdit(zonePlanReportService, new SignalrWrapper(), undefined);
    sut.planid = 1007;
    sut.zonePlan = dto;
    sut.setInitialData();

    //Act
    sut.zonePlan.preliminaryMemberPlanData.upgradeTarget = 67;
    await sut.saveAndSubmitPlan();

    //Assert
    const expectedPlanData = getExpectedPlanData(sut.zonePlan);
    expect(sut.isSaving).toBe(true);
    expect(zonePlanReportService.updatePlan).toHaveBeenCalledWith(2, 1007, expectedPlanData);
    expect(sut.afterSave).toEqual([sut.submitPlan]);
  });

  it("onzonePlanUpdated sets flag and calls afterSave", async () => {
    // Arrange
    const dto: ZonePlanViewModelDto = getZonePlanViewModelDto();
    const svc = new ZonePlanReportService();
    spyOn(svc, "submitPlan").and.returnValue(Promise.resolve());
    const sut = new ZonePlanEdit(svc, new SignalrWrapper(), undefined);
    sut.planid = 1007;
    sut.zonePlan = dto;
    sut.setInitialData();
    sut.zonePlan.preliminaryMemberPlanData.upgradeTarget = 45;
    expect(sut.isDirty).toBe(true);
    sut.afterSave.push(sut.submitPlan);

    // Act
    await sut.onZonePlanUpdated(1007);

    expect(sut.isSaving).toBe(false);
    expect(sut.isSubmitting).toBe(true);
    expect(svc.submitPlan).toHaveBeenCalledWith(2, 1007);
  });

  it("onzonePlanUpdated sets flag and does nothing if no afterSave", async () => {
    // Arrange
    const dto: ZonePlanViewModelDto = getZonePlanViewModelDto();
    const svc = new ZonePlanReportService();
    spyOn(svc, "submitPlan").and.returnValue(Promise.resolve());
    const sut = new ZonePlanEdit(svc, new SignalrWrapper(), undefined);
    sut.planid = 1007;
    sut.zonePlan = dto;
    sut.setInitialData();
    sut.zonePlan.preliminaryMemberPlanData.upgradeTarget = 45;
    expect(sut.isDirty).toBe(true);
    sut.afterSave = [];

    // Act
    await sut.onZonePlanUpdated(1007);

    expect(sut.isSaving).toBe(false);
    expect(sut.isSubmitting).toBe(false);
    expect(svc.submitPlan).not.toHaveBeenCalled();
  });

  it("onzonePlanUpdateFailed sets flag and does nothing if no afterSave", () => {
    // Arrange
    const dto: ZonePlanViewModelDto = getZonePlanViewModelDto();
    const svc = new ZonePlanReportService();
    spyOn(svc, "submitPlan").and.returnValue(Promise.resolve());
    const sut = new ZonePlanEdit(svc, new SignalrWrapper(), undefined);
    sut.planid = 1007;
    sut.zonePlan = dto;
    sut.setInitialData();
    sut.zonePlan.preliminaryMemberPlanData.upgradeTarget = 45;
    expect(sut.isDirty).toBe(true);
    sut.afterSave = [];

    // Act
    sut.onZonePlanUpdateFailed({$values: ["error"]});

    expect(sut.isSaving).toBe(false);
    expect(sut.isSubmitting).toBe(false);
    expect(sut.afterSave).toEqual([]);
  });

  it("onzonePlanUpdateFailed sets flag and clears afterSave", () => {
    // Arrange
    const dto: ZonePlanViewModelDto = getZonePlanViewModelDto();
    const svc = new ZonePlanReportService();
    spyOn(svc, "submitPlan").and.returnValue(Promise.resolve());
    const sut = new ZonePlanEdit(svc, new SignalrWrapper(), undefined);
    sut.planid = 1007;
    sut.zonePlan = dto;
    sut.setInitialData();
    sut.zonePlan.preliminaryMemberPlanData.upgradeTarget = 45;
    expect(sut.isDirty).toBe(true);
    sut.afterSave = [sut.submitPlan];

    // Act
    sut.onZonePlanUpdateFailed({$values: ["error"]});

    expect(sut.isSaving).toBe(false);
    expect(sut.isSubmitting).toBe(false);
    expect(sut.afterSave).toEqual([]);
  });

  function getZonePlanViewModelDto(): ZonePlanViewModelDto {
    return {
      "id": 1007, "description": "2019_Oct-Dec_State_Victoria",
      "organization": { "id": 2, "organizationType": 3, "description": "Victoria", "reportingFrequency": 3 },
      "reportingPeriod": { "startDate": moment("2019-10-01T00:00:00").toDate(), "endDate": moment("2019-12-31T23:59:59").toDate(), "reportingFrequency": 3, "reportingTerm": 4, "year": 2019 },
      "reportStatus": 1, "reportStatusDescription": "Draft",
      "reOpenedReportStatus": 0, "reOpenedReportStatusDescription": "None",
      "associateMemberPlanData": { "nameAndContactNumber": "asdf", "action": "asdf", "upgradeTarget": 51 },
      "associateMemberPlanGeneratedData": { "nameAndContactNumber": null, "action": null, "upgradeTarget": 0 },
      "preliminaryMemberPlanData": { "nameAndContactNumber": "asdf", "action": "asdf", "upgradeTarget": 90 },
      "preliminaryMemberPlanGeneratedData": { "nameAndContactNumber": null, "action": null, "upgradeTarget": 0 },
      "supporterMemberPlanData": {"nameAndContactNumber": "","action": "","upgradeTarget": 1},
      "supporterMemberPlanGeneratedData": {"nameAndContactNumber": "","action": "","upgradeTarget": 1},
      "memberMemberPlanData": {"nameAndContactNumber": "","action": "","upgradeTarget": 1},
      "memberMemberPlanGeneratedData": {"nameAndContactNumber": "","action": "","upgradeTarget": 1},
      "workerMeetingProgramPlanData": { "target": 90, "dateAndAction": "asdf" },
      "workerMeetingProgramPlanGeneratedData": { "target": 0, "dateAndAction": null },
      "cmsMeetingProgramPlanData": { "target": 90, "dateAndAction": "asdf" },
      "cmsMeetingProgramPlanGeneratedData": { "target": 0, "dateAndAction": null },
      "smMeetingProgramPlanData": { "target": 90, "dateAndAction": "asdf" },
      "smMeetingProgramPlanGeneratedData": { "target": 0, "dateAndAction": null },
      "memberMeetingProgramPlanData": { "target": 90, "dateAndAction": "asdf" },
      "memberMeetingProgramPlanGeneratedData": { "target": 0, "dateAndAction": null },
      "dawahMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "dawahMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "stateLeaderMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "stateLeaderMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "stateOutingMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "stateOutingMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "iftarMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "iftarMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "learningMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "learningMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "socialDawahMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "socialDawahMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "dawahGroupMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "dawahGroupMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "nextGMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "nextGMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "tafsirMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "tafsirMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "unitMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "unitMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "bbqMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "bbqMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "gatheringMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "gatheringMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "familyVisitMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "familyVisitMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "eidReunionMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "eidReunionMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "otherMeetingProgramPlanData": {"target": 0,"dateAndAction": null},
      "otherMeetingProgramPlanGeneratedData": {"target": 0,"dateAndAction": null},
      "groupStudyTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "groupStudyTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "studyCircleForAssociateMemberTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "studyCircleForAssociateMemberTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "studyCircleTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "studyCircleTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "practiceDarsTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "practiceDarsTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "stateLearningCampTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "stateLearningCampTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "quranStudyTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "quranStudyTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "hadithTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "hadithTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "quranClassTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "quranClassTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "weekendIslamicSchoolTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "weekendIslamicSchoolTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "memorizingAyatTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "memorizingAyatTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "memorizingHadithTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "memorizingHadithTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "memorizingDoaTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "memorizingDoaTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "stateLearningSessionTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "stateLearningSessionTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "stateQiyamulLailTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "stateQiyamulLailTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "otherTeachingLearningProgramPlanData": {"target": 0,"dateAndAction": null},
      "otherTeachingLearningProgramPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "bookSaleMaterialPlanData": {"target": 0,"dateAndAction": null},
      "bookSaleMaterialPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "bookDistributionMaterialPlanData": {"target": 0,"dateAndAction": null},
      "bookDistributionMaterialPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "vhsSaleMaterialPlanData": {"target": 0,"dateAndAction": null},
      "vhsSaleMaterialPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "vhsDistributionMaterialPlanData": {"target": 0,"dateAndAction": null},
      "vhsDistributionMaterialPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "emailDistributionMaterialPlanData": {"target": 0,"dateAndAction": null},
      "emailDistributionMaterialPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "ipdcLeafletDistributionMaterialPlanData": {"target": 0,"dateAndAction": null},
      "ipdcLeafletDistributionMaterialPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "otherSaleMaterialPlanData": {"target": 0,"dateAndAction": null},
      "otherSaleMaterialPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "otherDistributionMaterialPlanData": {"target": 0,"dateAndAction": null},
      "otherDistributionMaterialPlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "baitulMalFinancePlanData": {"action": null,"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8}},
      "baitulMalFinancePlanGeneratedData": {"action": null,"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8}},
      "aDayMasjidProjectFinancePlanData": {"action": null,"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8}},
      "aDayMasjidProjectFinancePlanGeneratedData": {"action": null,"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8}},
      "masjidTableBankFinancePlanData": {"action": null,"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8}},
      "masjidTableBankFinancePlanGeneratedData": {"action": null,"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8}},
      "qardeHasanaSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
      "qardeHasanaSocialWelfarePlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "patientVisitSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
      "patientVisitSocialWelfarePlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "socialVisitSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
      "socialVisitSocialWelfarePlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "transportSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
      "transportSocialWelfarePlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "shiftingSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
      "shiftingSocialWelfarePlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "shoppingSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
      "shoppingSocialWelfarePlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "foodDistributionSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
      "foodDistributionSocialWelfarePlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "cleanUpAustraliaSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
      "cleanUpAustraliaSocialWelfarePlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "otherSocialWelfarePlanData": {"target": 0,"dateAndAction": null},
      "otherSocialWelfarePlanGeneratedData": {"target": 1,"dateAndAction": ""},
      "timestamp": moment("2019-07-31T09:15:30.78").toDate()
    };
  }

  function getExpectedPlanData(dto: ZonePlanViewModelDto): PlanData {
    return new PlanData(
      new MemberPlanData(dto.associateMemberPlanData.nameAndContactNumber, dto.associateMemberPlanData.action, dto.associateMemberPlanData.upgradeTarget),
      new MemberPlanData(dto.preliminaryMemberPlanData.nameAndContactNumber, dto.preliminaryMemberPlanData.action, dto.preliminaryMemberPlanData.upgradeTarget),
      new MemberPlanData(dto.supporterMemberPlanData.nameAndContactNumber, dto.supporterMemberPlanData.action, dto.supporterMemberPlanData.upgradeTarget),
      new MemberPlanData(dto.memberMemberPlanData.nameAndContactNumber, dto.memberMemberPlanData.action, dto.memberMemberPlanData.upgradeTarget),
      new MeetingProgramPlanData(dto.workerMeetingProgramPlanData.target, dto.workerMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.cmsMeetingProgramPlanData.target, dto.cmsMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.smMeetingProgramPlanData.target, dto.smMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.memberMeetingProgramPlanData.target, dto.memberMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.dawahMeetingProgramPlanData.target, dto.dawahMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.stateLeaderMeetingProgramPlanData.target, dto.stateLeaderMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.stateOutingMeetingProgramPlanData.target, dto.stateOutingMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.iftarMeetingProgramPlanData.target, dto.iftarMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.learningMeetingProgramPlanData.target, dto.learningMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.socialDawahMeetingProgramPlanData.target, dto.socialDawahMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.dawahGroupMeetingProgramPlanData.target, dto.dawahGroupMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.nextGMeetingProgramPlanData.target, dto.nextGMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.tafsirMeetingProgramPlanData.target, dto.tafsirMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.unitMeetingProgramPlanData.target, dto.unitMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.bbqMeetingProgramPlanData.target, dto.bbqMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.gatheringMeetingProgramPlanData.target, dto.gatheringMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.familyVisitMeetingProgramPlanData.target, dto.familyVisitMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.eidReunionMeetingProgramPlanData.target, dto.eidReunionMeetingProgramPlanData.dateAndAction),
      new MeetingProgramPlanData(dto.otherMeetingProgramPlanData.target, dto.otherMeetingProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.groupStudyTeachingLearningProgramPlanData.target, dto.groupStudyTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.studyCircleForAssociateMemberTeachingLearningProgramPlanData.target, dto.studyCircleForAssociateMemberTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.studyCircleTeachingLearningProgramPlanData.target, dto.studyCircleTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.practiceDarsTeachingLearningProgramPlanData.target, dto.practiceDarsTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.stateLearningCampTeachingLearningProgramPlanData.target, dto.stateLearningCampTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.quranStudyTeachingLearningProgramPlanData.target, dto.quranStudyTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.hadithTeachingLearningProgramPlanData.target, dto.hadithTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.quranClassTeachingLearningProgramPlanData.target, dto.quranClassTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.weekendIslamicSchoolTeachingLearningProgramPlanData.target, dto.weekendIslamicSchoolTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.memorizingAyatTeachingLearningProgramPlanData.target, dto.memorizingAyatTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.memorizingHadithTeachingLearningProgramPlanData.target, dto.memorizingHadithTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.memorizingDoaTeachingLearningProgramPlanData.target, dto.memorizingDoaTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.stateLearningSessionTeachingLearningProgramPlanData.target, dto.stateLearningSessionTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.stateQiyamulLailTeachingLearningProgramPlanData.target, dto.stateQiyamulLailTeachingLearningProgramPlanData.dateAndAction),
      new TeachingLearningProgramPlanData(dto.otherTeachingLearningProgramPlanData.target, dto.otherTeachingLearningProgramPlanData.dateAndAction),
      new SocialWelfarePlanData(dto.qardeHasanaSocialWelfarePlanData.target, dto.qardeHasanaSocialWelfarePlanData.dateAndAction),
      new SocialWelfarePlanData(dto.patientVisitSocialWelfarePlanData.target, dto.patientVisitSocialWelfarePlanData.dateAndAction),
      new SocialWelfarePlanData(dto.socialVisitSocialWelfarePlanData.target, dto.socialVisitSocialWelfarePlanData.dateAndAction),
      new SocialWelfarePlanData(dto.transportSocialWelfarePlanData.target, dto.transportSocialWelfarePlanData.dateAndAction),
      new SocialWelfarePlanData(dto.shiftingSocialWelfarePlanData.target, dto.shiftingSocialWelfarePlanData.dateAndAction),
      new SocialWelfarePlanData(dto.shoppingSocialWelfarePlanData.target, dto.shoppingSocialWelfarePlanData.dateAndAction),
      new SocialWelfarePlanData(dto.foodDistributionSocialWelfarePlanData.target, dto.foodDistributionSocialWelfarePlanData.dateAndAction),
      new SocialWelfarePlanData(dto.cleanUpAustraliaSocialWelfarePlanData.target, dto.cleanUpAustraliaSocialWelfarePlanData.dateAndAction),
      new SocialWelfarePlanData(dto.otherSocialWelfarePlanData.target, dto.otherSocialWelfarePlanData.dateAndAction),
      new MaterialPlanData(dto.bookSaleMaterialPlanData.target, dto.bookDistributionMaterialPlanData.dateAndAction),
      new MaterialPlanData(dto.bookDistributionMaterialPlanData.target, dto.bookDistributionMaterialPlanData.dateAndAction),
      new MaterialPlanData(dto.vhsSaleMaterialPlanData.target, dto.vhsSaleMaterialPlanData.dateAndAction),
      new MaterialPlanData(dto.vhsDistributionMaterialPlanData.target, dto.vhsDistributionMaterialPlanData.dateAndAction),
      new MaterialPlanData(dto.emailDistributionMaterialPlanData.target, dto.emailDistributionMaterialPlanData.dateAndAction),
      new MaterialPlanData(dto.ipdcLeafletDistributionMaterialPlanData.target, dto.ipdcLeafletDistributionMaterialPlanData.dateAndAction),
      new MaterialPlanData(dto.otherSaleMaterialPlanData.target, dto.otherSaleMaterialPlanData.dateAndAction),
      new MaterialPlanData(dto.otherDistributionMaterialPlanData.target, dto.otherDistributionMaterialPlanData.dateAndAction),
      makeFinancePlanData(dto.baitulMalFinancePlanData),
      makeFinancePlanData(dto.aDayMasjidProjectFinancePlanData),
      makeFinancePlanData(dto.masjidTableBankFinancePlanData)
    );
  }

  function makeFinancePlanData(original: FinancePlanData): FinancePlanData {
    return new FinancePlanData(original.action, original.workerPromiseIncreaseTarget, original.otherSourceAction, original.otherSourceIncreaseTarget);
  }
});
