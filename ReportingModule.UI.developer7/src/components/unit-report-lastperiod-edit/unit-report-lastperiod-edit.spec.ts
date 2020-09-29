import { AppRouter } from "aurelia-router";
import * as moment from "moment";
import { UnitReportLastPeriodEdit } from "./unit-report-lastperiod-edit";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { SignalrWrapper } from "signalrwrapper";
import { UnitReportViewModelDto } from "models/UnitReportViewModelDto";
import { ReportUpdateData } from "models/ReportUpdateData";
import { MemberReportData } from "models/MemberReportData";
import { MeetingProgramData } from "models/MeetingProgramData";
import { MeetingProgramReportData } from 'models/MeetingProgramReportData';
import { SocialWelfareData } from 'models/SocialWelfareData';
import { TeachingLearningProgramData } from 'models/TeachingLearningProgramData';
import { MaterialData } from 'models/MaterialData';
import { LibraryStockData } from 'models/LibraryStockData';
import { SocialWelfareReportData } from 'models/SocialWelfareReportData';
import { FinanceReportData } from 'models/FinanceReportData';
import { FinanceData } from 'models/FinanceData';
import { LibraryStockReportData } from "models/LibraryStockReportData";
import { ReportLastPeriodUpdateData } from "models/ReportLastPeriodUpdateData";



describe("unit report lastperiod edit tests", () => {
    it("loadReport calls expected service method and sets data", async () => {
        const dto: UnitReportViewModelDto = getUnitReportViewModelDto();
        const svc = new UnitPlanReportService();
        spyOn(svc, "getReport").and.returnValue(Promise.resolve(dto));
        const sut = new UnitReportLastPeriodEdit(svc, new SignalrWrapper(), undefined);
        sut.reportid = 3;
        
        await sut.loadReport();

        expect(svc.getReport).toHaveBeenCalledWith(3);
        expect(sut.unitReport).toBe(dto);
        expect(sut.initialJson).toBeTruthy();
        expect(sut.canSave).toBe(false);
        expect(sut.canCancel).toBe(true);
    });

    it("save does nothing when not dirty", async () => {
      // Arrange
      const dto: UnitReportViewModelDto = getUnitReportViewModelDto();
      const unitPlanReportService = new UnitPlanReportService();
      spyOn(unitPlanReportService, "updateReportLastPeriod").and.returnValue(Promise.resolve());
      const sut = new UnitReportLastPeriodEdit(unitPlanReportService, new SignalrWrapper(), undefined);
      sut.reportid = 3;
      sut.unitReport = dto;
      sut.setInitialData();
  
      //Act
      await sut.save();
  
      //Assert
      expect(sut.isSaving).toBe(false);
      expect(unitPlanReportService.updateReportLastPeriod).not.toHaveBeenCalled();
    });

    it("save calls expected service when dirty", async () => {
      const dto: UnitReportViewModelDto = getUnitReportViewModelDto();
      const uniPlanReportService = new UnitPlanReportService();
      spyOn(uniPlanReportService, "updateReportLastPeriod").and.returnValue(Promise.resolve());
      const sut = new UnitReportLastPeriodEdit(uniPlanReportService, new SignalrWrapper(), undefined);
      sut.reportid = 3;
      sut.unitReport = dto;

      sut.unitReport.associateMemberData.increased = 25;
      await sut.save();

      const expectedReportData = getExpectedReportData(sut.unitReport);
      expect(sut.isSaving).toBe(true);
      expect(uniPlanReportService.updateReportLastPeriod).toHaveBeenCalledWith(5, 3, getExpectedReportData(dto));
  
  }); 


  it("onUnitReportUpdated sets flag", async () => {
    // Arrange
    const dto: UnitReportViewModelDto = getUnitReportViewModelDto();
    const unitPlanReportService = new UnitPlanReportService();
    spyOn(unitPlanReportService, "getReport").and.returnValue(Promise.resolve(dto));
    spyOn(unitPlanReportService, "submitReport").and.returnValue(Promise.resolve());
    const sut = new UnitReportLastPeriodEdit(unitPlanReportService, new SignalrWrapper(), undefined);
    sut.reportid = 5;
    sut.unitReport = dto;
    sut.setInitialData();
    sut.unitReport.associateMemberData.increased = 25;
    expect(sut.isDirty).toBe(true);

    // Act
    await sut.onUnitReportUpdated(3);

    expect(sut.isSaving).toBe(false);
    expect(unitPlanReportService.getReport).toHaveBeenCalled();
  });

  it("isDirty tracks dto state", async () => {
      const dto: UnitReportViewModelDto = getUnitReportViewModelDto();
      const sut = new UnitReportLastPeriodEdit(new UnitPlanReportService(), new SignalrWrapper(), undefined);
      sut.reportid = 3;
      sut.unitReport = dto;
      
      sut.setInitialData();

      expect(sut.initialJson).toBeTruthy();
      expect(sut.isDirty).toBe(false);

      sut.unitReport.associateMemberData.increased = 42;
      expect(sut.isDirty).toBe(true);

      sut.setInitialData();
      expect(sut.isDirty).toBe(false);
  });

  it("cancelChanges calls expected service method and resets dirty flag", async () => {
      const dto: UnitReportViewModelDto = getUnitReportViewModelDto();
      const svc = new UnitPlanReportService();
      spyOn(svc, "getReport").and.returnValue(Promise.resolve(dto));
      const sut = new UnitReportLastPeriodEdit(svc, new SignalrWrapper(), undefined);
      sut.reportid = 3,
      sut.unitReport = dto;
      
      sut.setInitialData();
      expect(sut.isDirty).toBe(false);
      sut.unitReport.associateMemberData.increased = 55;
      expect(sut.isDirty).toBe(true);

      await sut.cancelChanges();

      expect(svc.getReport).toHaveBeenCalledWith(3);

      expect(sut.unitReport).toEqual(dto);
      expect(sut.isDirty).toBe(false);
  });

  it("onUnitReportUpdated resets saving and calls expected method", () => {
      const dto: UnitReportViewModelDto = getUnitReportViewModelDto();
      const sut = new UnitReportLastPeriodEdit(new UnitPlanReportService(), new SignalrWrapper(), undefined);
      sut.reportid = 3;
      sut.unitReport = dto;
      spyOn(sut, "loadReport").and.returnValue(Promise.resolve());
      
      sut.unitReport.preliminaryMemberData.decreased = 34;
      sut.isSaving = true;
      expect(sut.isDirty).toBe(true);
      
      sut.onUnitReportUpdated(3);

      expect(sut.isSaving).toBe(false);
      expect(sut.loadReport).toHaveBeenCalled();
  });

  it("onUnitReportUpdateFailed only resets saving flag and not dirty flag", () => {
      const dto: UnitReportViewModelDto = getUnitReportViewModelDto();
      const sut = new UnitReportLastPeriodEdit(new UnitPlanReportService(), new SignalrWrapper(), undefined);
      sut.reportid = 3;
      sut.unitReport = dto;
      
      sut.unitReport.preliminaryMemberData.decreased = 34;
      sut.isSaving = true;
      expect(sut.isDirty).toBe(true);
      
      sut.onUnitReportUpdateFailed({$values: ["error"]});

      expect(sut.isSaving).toBe(false);
      expect(sut.isDirty).toBe(true);
  });
  
    function getUnitReportViewModelDto(): UnitReportViewModelDto {
      return {
        "id":3,"description":"10001-VIC-TGN-MAR19",
        "organization":{"id":5,"organizationType":1,"description":"Truganina North Unit","reportingFrequency":1},
        "reportingPeriod":{"startDate":moment("2019-03-01T00:00:00").toDate(),"endDate":moment("2019-03-31T23:59:59").toDate(),"reportingFrequency":1,"reportingTerm":3,"year":2019},"reportStatus":2,"reportStatusDescription":"PlanPromoted","reOpenedReportStatus":0,"reOpenedReportStatusDescription":"None",
        "associateMemberData":{"nameAndContactNumber":"","action":"","lastPeriod":2,"upgradeTarget":1,"thisPeriod":3,"increased":1,"decreased":0,"comment":"","personalContact":null},
        "preliminaryMemberData":{"nameAndContactNumber":"","action":"","lastPeriod":3,"upgradeTarget":1,"thisPeriod":4,"increased":1,"decreased":0,"comment":"","personalContact":null},
        "supporterMemberData": {"nameAndContactNumber": "asdf","action": "asdf","lastPeriod": 0,"upgradeTarget": 2,"thisPeriod": 1,"increased": 1,"decreased": 0,"comment": null,"personalContact": null},
        "workerMeetingProgramData":{"target":1,"dateAndAction":"","actual":1,"averageAttendance":6,"comment":""},
        "cmsMeetingProgramData":{"target":1,"dateAndAction":"","actual":1,"averageAttendance":6,"comment":""},
        "smMeetingProgramData":{"target":1,"dateAndAction":"","actual":1,"averageAttendance":6,"comment":""},
        "memberMeetingProgramData":{"target":1,"dateAndAction":"","actual":1,"averageAttendance":6,"comment":""},
        "dawahMeetingProgramData": {"target": 6,"dateAndAction": ";lkj;lkj","actual": 0,"averageAttendance": 0,"comment": null},
        "stateLeaderMeetingProgramData": {"target": 3,"dateAndAction": "l;kj","actual": 0,"averageAttendance": 0,"comment": null},
        "stateOutingMeetingProgramData": {"target": 4,"dateAndAction": "jklhjk","actual": 0,"averageAttendance": 0,"comment": null},
        "iftarMeetingProgramData": {"target": 5,"dateAndAction": ",mb","actual": 0,"averageAttendance": 0,"comment": null},
        "learningMeetingProgramData": {"target": 6,"dateAndAction": ",mb","actual": 0,"averageAttendance": 0,"comment": null},
        "socialDawahMeetingProgramData": {"target": 45,"dateAndAction": ";l;","actual": 0,"averageAttendance": 0,"comment": null},
        "dawahGroupMeetingProgramData": {"target": 6,"dateAndAction": ";lkj;lkj","actual": 0,"averageAttendance": 0,"comment": null},
        "nextGMeetingProgramData": {"target": 89,"dateAndAction": "k;lhkl;j","actual": 0,"averageAttendance": 0,"comment": null},
        "tafsirMeetingProgramData": {"target": 89,"dateAndAction": "k;lhkl;j","actual": 0,"averageAttendance": 0,"comment": null},
        "unitMeetingProgramData": {"target": 89,"dateAndAction": "k;lhkl;j","actual": 0,"averageAttendance": 0,"comment": null},
        "bbqMeetingProgramData": {"target": 89,"dateAndAction": "k;lhkl;j","actual": 0,"averageAttendance": 0,"comment": null},
        "gatheringMeetingProgramData": {"target": 89,"dateAndAction": "k;lhkl;j","actual": 0,"averageAttendance": 0,"comment": null},
        "familyVisitMeetingProgramData": {"target": 89,"dateAndAction": "k;lhkl;j","actual": 0,"averageAttendance": 0,"comment": null},
        "eidReunionMeetingProgramData": {"target": 89,"dateAndAction": "k;lhkl;j","actual": 0,"averageAttendance": 0,"comment": null},
        "otherMeetingProgramData": {"target": 89,"dateAndAction": "k;lhkl;j","actual": 0,"averageAttendance": 0,"comment": null},
        "memberMemberData": {"nameAndContactNumber": "fdas","action": "fdsa","lastPeriod": 1,"upgradeTarget": 2,"thisPeriod": 1,"increased": 1,"decreased": 1,"comment": "","personalContact":null},
        "groupStudyTeachingLearningProgramData": {"target": 23,"dateAndAction": "sfd","actual": 1,"averageAttendance": 1,"comment": ""},
        "studyCircleForAssociateMemberTeachingLearningProgramData": {"target": 34,"dateAndAction": "fd","actual": 1,"averageAttendance": 1,"comment": ""},
        "studyCircleTeachingLearningProgramData": {"target": 34,"dateAndAction": "fd","actual": 1,"averageAttendance": 1,"comment": ""},
        "practiceDarsTeachingLearningProgramData": {"target": 4,"dateAndAction": "edf","actual": 1,"averageAttendance": 1,"comment": ""},
        "stateLearningCampTeachingLearningProgramData": {"target": 8,"dateAndAction": "kh","actual": 1,"averageAttendance": 1,"comment": ""},
        "quranStudyTeachingLearningProgramData": {"target": 7,"dateAndAction": "kl","actual": 1,"averageAttendance": 1,"comment": ""},
        "hadithTeachingLearningProgramData": {"target": 7,"dateAndAction": "kl","actual": 1,"averageAttendance": 1,"comment": ""},
        "quranClassTeachingLearningProgramData": {"target": 9,"dateAndAction": "kl","actual": 1,"averageAttendance": 1,"comment": ""},
        "weekendIslamicSchoolTeachingLearningProgramData": {"target": 9,"dateAndAction": "kl","actual": 1,"averageAttendance": 1,"comment": ""},
        "memorizingAyatTeachingLearningProgramData": {"target": 0,"dateAndAction": "klj","actual": 1,"averageAttendance": 1,"comment": ""},
        "memorizingHadithTeachingLearningProgramData": {"target": 0,"dateAndAction": "klj","actual": 1,"averageAttendance": 1,"comment": ""},
        "memorizingDoaTeachingLearningProgramData": {"target": 0,"dateAndAction": "klj","actual": 1,"averageAttendance": 1,"comment": ""},
        "stateLearningSessionTeachingLearningProgramData": {"target": 7,"dateAndAction": "nl","actual": 1,"averageAttendance": 1,"comment": ""},
        "stateQiyamulLailTeachingLearningProgramData": {"target": 7,"dateAndAction": "lk","actual": 1,"averageAttendance": 1,"comment": ""},
        "otherTeachingLearningProgramData": {"target": 7,"dateAndAction": "lk","actual": 1,"averageAttendance": 1,"comment": ""},
        "baitulMalFinanceData": {
          "workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},
          "lastPeriod": {"amount": 23.0,"currency": 8},
          "action": null,
          "otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8},
          "otherSourceAction": null,
          "totalIncreaseTarget": {"amount": 0.0,"currency": 8},
          "workerPromiseLastPeriod": {"amount": 0.0,"currency": 8},
          "workerPromiseThisPeriod": {"amount": 0.0,"currency": 8},
          "collection": {"amount": 0.0,"currency": 8},
          "expense": {"amount": 0.0,"currency": 8},
          "nisabPaidToCentral": {"amount": 0.0,"currency": 8},
          "balance": {"amount": 0.0,"currency": 8},
          "workerPromiseIncreased": {"amount": 0.0,"currency": 8},
          "workerPromiseDecreased": {"amount": 0.0,"currency": 8},
          "comment": null
        },
        "aDayMasjidProjectFinanceData": {
          "workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},
          "lastPeriod": {"amount": 23.0,"currency": 8},
          "action": null,
          "otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8},
          "otherSourceAction": null,
          "totalIncreaseTarget": {"amount": 0.0,"currency": 8},
          "workerPromiseLastPeriod": {"amount": 0.0,"currency": 8},
          "workerPromiseThisPeriod": {"amount": 0.0,"currency": 8},
          "collection": {"amount": 0.0,"currency": 8},
          "expense": {"amount": 0.0,"currency": 8},
          "nisabPaidToCentral": {"amount": 0.0,"currency": 8},
          "balance": {"amount": 0.0,"currency": 8},
          "workerPromiseIncreased": {"amount": 0.0,"currency": 8},
          "workerPromiseDecreased": {"amount": 0.0,"currency": 8},
          "comment": null
        },
        "masjidTableBankFinanceData": {
          "workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},
          "lastPeriod": {"amount": 23.0,"currency": 8},
          "action": null,
          "otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8},
          "otherSourceAction": null,
          "totalIncreaseTarget": {"amount": 0.0,"currency": 8},
          "workerPromiseLastPeriod": {"amount": 0.0,"currency": 8},
          "workerPromiseThisPeriod": {"amount": 0.0,"currency": 8},
          "collection": {"amount": 0.0,"currency": 8},
          "expense": {"amount": 0.0,"currency": 8},
          "nisabPaidToCentral": {"amount": 0.0,"currency": 8},
          "balance": {"amount": 0.0,"currency": 8},
          "workerPromiseIncreased": {"amount": 0.0,"currency": 8},
          "workerPromiseDecreased": {"amount": 0.0,"currency": 8},
          "comment": null
        },
        "bookSaleMaterialData": {"target": 1,"dateAndAction": "kj","actual": 1,"comment": "lkj"},
        "bookDistributionMaterialData": {"target": 2,"dateAndAction": "kjh","actual": 2,"comment": "lj3"},
        "vhsSaleMaterialData": {"target": 3,"dateAndAction": "hjk","actual": 3,"comment": "jkl"},
        "vhsDistributionMaterialData": {"target": 4,"dateAndAction": "bnm","actual": 2,"comment": "kjhkjh"},
        "emailDistributionMaterialData": {"target": 5,"dateAndAction": "vb","actual": 2,"comment": "khlh"},
        "ipdcLeafletDistributionMaterialData": {"target": 6,"dateAndAction": ",nm","actual": 1,"comment": "lkjh"},
        "otherSaleMaterialData": {"target": 3,"dateAndAction": "hjk","actual": 3,"comment": "jkl"},
        "otherDistributionMaterialData": {"target": 4,"dateAndAction": "bnm","actual": 2,"comment": "kjhkjh"},
        "bookLibraryStockData": {"lastPeriod": 0,"thisPeriod": 0,"increased": 0,"decreased": 2,"comment": "lkjh"},
        "vhsLibraryStockData": {"lastPeriod": 0,"thisPeriod": 0,"increased": 0,"decreased": 1,"comment": "lkjh"},
        "otherLibraryStockData": {"lastPeriod": 0,"thisPeriod": 0,"increased": 0,"decreased": 1,"comment": "lkjh"},
        "qardeHasanaSocialWelfareData": {"target": 0,"dateAndAction": null,"actual": 0,"comment": null},
        "patientVisitSocialWelfareData": {"target": 0,"dateAndAction": null,"actual": 0,"comment": null},
        "socialVisitSocialWelfareData": {"target": 0,"dateAndAction": null,"actual": 0,"comment": null},
        "transportSocialWelfareData": {"target": 0,"dateAndAction": null,"actual": 0,"comment": null},
        "shiftingSocialWelfareData": {"target": 0,"dateAndAction": null,"actual": 0,"comment": null},
        "shoppingSocialWelfareData": {"target": 0,"dateAndAction": null,"actual": 0,"comment": null},
        "foodDistributionSocialWelfareData": {"target": 0,"dateAndAction": null,"actual": 0,"comment": null},
        "cleanUpAustraliaSocialWelfareData": {"target": 0,"dateAndAction": null,"actual": 0,"comment": null},
        "otherSocialWelfareData": {"target": 0,"dateAndAction": null,"actual": 0,"comment": null},
        "comment": "blah",
        "timestamp":moment("2019-07-31T07:21:51.66").toDate()};
      }

      function getExpectedReportData(dto: UnitReportViewModelDto): ReportLastPeriodUpdateData {
        return new ReportLastPeriodUpdateData(
            makeMemberData(dto.memberMemberData),
            makeMemberData(dto.associateMemberData),
            makeMemberData(dto.preliminaryMemberData),
            makeMemberData(dto.supporterMemberData),
            makeFinanceReportData(dto.baitulMalFinanceData),
            makeFinanceReportData(dto.aDayMasjidProjectFinanceData),
            makeFinanceReportData(dto.masjidTableBankFinanceData),
            makeLibraryStockReportData(dto.bookLibraryStockData),
            makeLibraryStockReportData(dto.vhsLibraryStockData),
            makeLibraryStockReportData(dto.otherLibraryStockData)
        );
    }

    function makeMemberData(original: MemberReportData): MemberReportData {
        return new MemberReportData(original.lastPeriod, original.increased, original.decreased, original.comment, original.personalContact);
      }

    function makeLibraryStockReportData(original: LibraryStockData): LibraryStockReportData {
        return new LibraryStockReportData(original.lastPeriod, original.increased, original.decreased, original.comment);
    }

    function makeFinanceReportData(original: FinanceData): FinanceReportData {
        return new FinanceReportData(original.workerPromiseLastPeriod,
            original.lastPeriod,
            original.workerPromiseIncreased,
            original.workerPromiseDecreased,
            original.collection,
            original.expense,
            original.nisabPaidToCentral,
            original.comment);
    }
});
