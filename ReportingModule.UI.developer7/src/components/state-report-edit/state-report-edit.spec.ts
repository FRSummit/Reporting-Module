import * as moment from "moment";
import { StateReportViewModelDto } from "models/StateReportViewModelDto";
import { StatePlanReportService } from "services/StatePlanReportService";
import { StateReportEdit } from "./state-report-edit";
import { MemberData } from "models/MemberData";
import { MeetingProgramData } from "models/MeetingProgramData";
import { ReportData } from "models/ReportData";
import { StatePlanEdit } from "components/state-plan-edit/state-plan-edit";
import { AppRouter } from "aurelia-router";
import { TeachingLearningProgramData } from "models/TeachingLearningProgramData";
import { MaterialData } from "models/MaterialData";
import { LibraryStockData } from "models/LibraryStockData";
import { FinanceData } from "models/FinanceData";
import { SocialWelfareData } from "models/SocialWelfareData";

describe("state report edit tests", () => {
    it("loadReport calls expected service", async () => {
        const dto = getStateReportDto();
        const svc = new StatePlanReportService();
        spyOn(svc, "getReport").and.returnValue(Promise.resolve(dto));
        const sut = new StateReportEdit(svc, undefined, undefined);
        sut.reportid = 11;

        await sut.loadReport();

        expect(svc.getReport).toHaveBeenCalledWith(11);
        expect(sut.stateReport).toEqual(dto);
        expect(sut.initialJson).toBeTruthy();
        expect(sut.isDirty).toBe(false);
        expect(sut.canSave).toBe(false);
        expect(sut.canCancel).toBe(true);
        expect(sut.canSubmit).toBe(true);
    });

    it("save calls expected service and sets flag", async () => {
        const dto = getStateReportDto();
        const svc = new StatePlanReportService();
        spyOn(svc, "updateReport").and.returnValue(Promise.resolve());
        const sut = new StateReportEdit(svc, undefined, undefined);
        sut.reportid = 11;
        sut.stateReport = dto;
        sut.stateReport.associateMemberData.increased = 45;
        const expectedReportData = getExpectedReportData(sut.stateReport);
        expect(sut.isSaving).toBe(false);

        await sut.save();

        expect(svc.updateReport).toHaveBeenCalledWith(2, 11, expectedReportData);
        expect(sut.isSaving).toBe(true);
    });

    it("cancelChanges calls expected service", async () => {
        const svc = new StatePlanReportService();
        spyOn(svc, "getReport").and.returnValue(Promise.resolve(getStateReportDto()));
        const sut = new StateReportEdit(svc, undefined, undefined);
        sut.reportid = 11;
        sut.stateReport = getStateReportDto();
        sut.stateReport.associateMemberData.decreased = 5;

        await sut.cancelChanges();

        expect(svc.getReport).toHaveBeenCalledWith(11);

        expect(sut.stateReport).toEqual(getStateReportDto());
    });

    it("saveAndSubmitReport calls expected service, sets flag and created expected afterSave", async () => {
        const dto = getStateReportDto();
        const svc = new StatePlanReportService();
        spyOn(svc, "updateReport").and.returnValue(Promise.resolve());
        const sut = new StateReportEdit(svc, undefined, undefined);
        sut.reportid = 11;
        sut.stateReport = dto;
        sut.setInitialData();
        sut.stateReport.associateMemberData.increased = 45;
        const expectedReportData = getExpectedReportData(sut.stateReport);
        expect(sut.isSaving).toBe(false);
        expect(sut.isDirty).toBe(true);

        await sut.saveAndSubmitReport();

        expect(svc.updateReport).toHaveBeenCalledWith(2, 11, expectedReportData);
        expect(sut.isSaving).toBe(true);
        expect(sut.afterSave).toEqual([sut.submitReport]);
    });

    it("onStateReportUpdated updates flag, calls expected service and does not call submit report when no afterSave", async () => {
        const svc = new StatePlanReportService();
        spyOn(svc, "getReport").and.returnValue(Promise.resolve(getStateReportDto()));
        const sut = new StateReportEdit(svc, undefined, undefined);
        sut.reportid = 11;
        sut.isSaving = true;

        await sut.onStateReportUpdated(11);

        expect(sut.isSaving).toBe(false);
        expect(sut.isSubmitting).toBe(false);
        expect(svc.getReport).toHaveBeenCalledWith(11);
        expect(sut.stateReport).toEqual(getStateReportDto());
    });

    it("onStateReportUpdated updates flag, calls expected service and calls submit report when afterSave", async () => {
        const svc = new StatePlanReportService();
        spyOn(svc, "getReport").and.returnValue(Promise.resolve(getStateReportDto()));
        spyOn(svc, "submitReport").and.returnValue(Promise.resolve());
        const sut = new StateReportEdit(svc, undefined, undefined);
        sut.reportid = 11;
        sut.isSaving = true;
        sut.afterSave.push(sut.submitReport);

        await sut.onStateReportUpdated(11);

        expect(sut.isSaving).toBe(false);
        expect(sut.isSubmitting).toBe(true);
        expect(svc.getReport).toHaveBeenCalledWith(11);
        expect(sut.stateReport).toEqual(getStateReportDto());
        expect(svc.submitReport).toHaveBeenCalledWith(2, 11);
        expect(sut.afterSave).toEqual([]);
    });

    it("onStateReportUpdateFailed clears flag and does nothing if no afterSave", () => {
        const sut = new StatePlanEdit(new StatePlanReportService(), undefined, undefined);
        sut.isSaving = true;

        sut.onStatePlanUpdateFailed({$values: ["error"]});

        expect(sut.isSaving).toBe(false);
    });

    it("onStateReportUpdateFailed clears flag and pops afterSave", () => {
        const sut = new StatePlanEdit(new StatePlanReportService(), undefined, undefined);
        sut.isSaving = true;
        sut.afterSave.push(sut.submitPlan);

        sut.onStatePlanUpdateFailed({$values: ["error"]});

        expect(sut.isSaving).toBe(false);
        expect(sut.afterSave).toEqual([]);
    });

    it("submitReport calls expected service and sets flag", async () => {
        const svc = new StatePlanReportService();
        spyOn(svc, "submitReport").and.returnValue(Promise.resolve());
        const sut = new StateReportEdit(svc, undefined, undefined);
        sut.reportid = 11;
        sut.stateReport = getStateReportDto();

        await sut.submitReport();

        expect(svc.submitReport).toHaveBeenCalledWith(2, 11);
        expect(sut.isSubmitting).toBe(true);
    });

    it("onReportSubmitted clears flag and routes to expected view", () => {
        const router = {
            navigate: () => {}
        } as any as AppRouter;
        spyOn(router, "navigate");
        const sut = new StateReportEdit(undefined, undefined, router);
        sut.isSubmitting = true;
        sut.reportid = 11;

        sut.onReportSubmitted(11);

        expect(sut.isSubmitting).toBe(false);
        expect(router.navigate).toHaveBeenCalledWith("state-report-view/11");
    });

    it("onReportSubmitFailed clears flag and does not call router naviagte", () => {
        const router = {
            navigate: () => {}
        } as any as AppRouter;
        spyOn(router, "navigate");
        const sut = new StateReportEdit(undefined, undefined, router);
        sut.isSubmitting = true;
        sut.reportid = 11;

        sut.onReportSubmitFailed({$values: ["error"]});

        expect(sut.isSubmitting).toBe(false);
        expect(router.navigate).not.toHaveBeenCalled();
    });
});

function getStateReportDto(): StateReportViewModelDto {
    return {
        "id":11,"description":"10001-VIC-JAN-MAR19",
        "organization":{"id":2,"organizationType":3,"description":"Victoria","reportingFrequency":3},
        "reportingPeriod":{"startDate":moment("2019-01-01T00:00:00").toDate(),"endDate":moment("2019-03-31T23:59:59").toDate(),"reportingFrequency":1,"reportingTerm":1,"year":2019},
        "reportStatus":3,"reportStatusDescription":"Submitted",
        "reOpenedReportStatus":0,"reOpenedReportStatusDescription":"None",
        "associateMemberData":{"nameAndContactNumber":"name 1","action":"action 1","lastPeriod":2,"upgradeTarget":2,"thisPeriod":3,"increased":1,"decreased":0,"comment":"comment11","personalContact":null},
        "associateMemberGeneratedData":{"nameAndContactNumber":"","action":"","lastPeriod":2,"upgradeTarget":2,"thisPeriod":2,"increased":0,"decreased":0,"comment":"","personalContact":null},
        "preliminaryMemberData":{"nameAndContactNumber":"name 2","action":"action 2","lastPeriod":4,"upgradeTarget":2,"thisPeriod":6,"increased":2,"decreased":0,"comment":"comment 2asd","personalContact":null},
        "preliminaryMemberGeneratedData":{"nameAndContactNumber":"","action":"","lastPeriod":4,"upgradeTarget":2,"thisPeriod":4,"increased":0,"decreased":0,"comment":"","personalContact":null},
        "supporterMemberData": {"nameAndContactNumber": ";l;j;lk","action": "khhjg","lastPeriod": 1,"upgradeTarget": 7,"thisPeriod": 1,"increased": 0,"decreased": 0,"comment": "", "personalContact": null},
        "supporterMemberGeneratedData": {"nameAndContactNumber": "","action": "","lastPeriod": 1,"upgradeTarget": 1,"thisPeriod": 1,"increased": 0,"decreased": 0,"comment": "","personalContact":null},
        "memberMemberData": {"nameAndContactNumber": "sadf","action": "';k","lastPeriod": 1,"upgradeTarget": 1,"thisPeriod": 1,"increased": 0,"decreased": 0,"comment": "","personalContact":null},
        "memberMemberGeneratedData": {"nameAndContactNumber": "","action": "","lastPeriod": 1,"upgradeTarget": 1,"thisPeriod": 1,"increased": 0,"decreased": 0,"comment": "","personalContact": null},
        "workerMeetingProgramData":{"target":2,"dateAndAction":"action 3","actual":6,"averageAttendance":22,"comment":""},
        "workerMeetingProgramGeneratedData":{"target":2,"dateAndAction":"","actual":2,"averageAttendance":12,"comment":""},
        "cmsMeetingProgramData":{"target":2,"dateAndAction":"action 3","actual":6,"averageAttendance":22,"comment":""},
        "cmsMeetingProgramGeneratedData":{"target":2,"dateAndAction":"","actual":2,"averageAttendance":12,"comment":""},
        "smMeetingProgramData":{"target":2,"dateAndAction":"action 3","actual":6,"averageAttendance":22,"comment":""},
        "smMeetingProgramGeneratedData":{"target":2,"dateAndAction":"","actual":2,"averageAttendance":12,"comment":""},
        "memberMeetingProgramData":{"target":2,"dateAndAction":"action 3","actual":6,"averageAttendance":22,"comment":""},
        "memberMeetingProgramGeneratedData":{"target":2,"dateAndAction":"","actual":2,"averageAttendance":12,"comment":""},
        "dawahMeetingProgramData": {"target": 2,"dateAndAction": "kljhljkh","actual": 0,"averageAttendance": 0,"comment": null},
        "dawahMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "stateLeaderMeetingProgramData": {"target": 4,"dateAndAction": "hjkgk","actual": 1,"averageAttendance": 6,"comment": ""},
        "stateLeaderMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "stateOutingMeetingProgramData": {"target": 1,"dateAndAction": "kghg","actual": 1,"averageAttendance": 6,"comment": ""},
        "stateOutingMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "iftarMeetingProgramData": {"target": 3,"dateAndAction": "hjkkh","actual": 1,"averageAttendance": 6,"comment": ""},
        "iftarMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "learningMeetingProgramData": {"target": 9,"dateAndAction": "jghjg","actual": 1,"averageAttendance": 6,"comment": ""},
        "learningMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "socialDawahMeetingProgramData": {"target": 8,"dateAndAction": "ghgkg","actual": 1,"averageAttendance": 6,"comment": ""},
        "socialDawahMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "dawahGroupMeetingProgramData": {"target": 4,"dateAndAction": "kjgkg","actual": 1,"averageAttendance": 6,"comment": ""},
        "dawahGroupMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "nextGMeetingProgramData": {"target": 5,"dateAndAction": "kjgkg","actual": 1,"averageAttendance": 6,"comment": ""},
        "nextGMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "tafsirMeetingProgramData": {"target": 5,"dateAndAction": "kjgkg","actual": 1,"averageAttendance": 6,"comment": ""},
        "tafsirMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "unitMeetingProgramData": {"target": 5,"dateAndAction": "kjgkg","actual": 1,"averageAttendance": 6,"comment": ""},
        "unitMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "bbqMeetingProgramData": {"target": 5,"dateAndAction": "kjgkg","actual": 1,"averageAttendance": 6,"comment": ""},
        "bbqMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "gatheringMeetingProgramData": {"target": 5,"dateAndAction": "kjgkg","actual": 1,"averageAttendance": 6,"comment": ""},
        "gatheringMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "familyVisitMeetingProgramData": {"target": 5,"dateAndAction": "kjgkg","actual": 1,"averageAttendance": 6,"comment": ""},
        "familyVisitMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "eidReunionMeetingProgramData": {"target": 5,"dateAndAction": "kjgkg","actual": 1,"averageAttendance": 6,"comment": ""},
        "eidReunionMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "otherMeetingProgramData": {"target": 5,"dateAndAction": "kjgkg","actual": 1,"averageAttendance": 6,"comment": ""},
        "otherMeetingProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 6,"comment": ""},
        "groupStudyTeachingLearningProgramData": {"target": 1,"dateAndAction": ";lkj","actual": 0,"averageAttendance": 0,"comment": null},
        "groupStudyTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "studyCircleForAssociateMemberTeachingLearningProgramData": {"target": 2,"dateAndAction": "hjkl","actual": 0,"averageAttendance": 0,"comment": null},
        "studyCircleForAssociateMemberTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "studyCircleTeachingLearningProgramData": {"target": 2,"dateAndAction": "hjkl","actual": 0,"averageAttendance": 0,"comment": null},
        "studyCircleTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "practiceDarsTeachingLearningProgramData": {"target": 3,"dateAndAction": ";lkj","actual": 0,"averageAttendance": 0,"comment": null},
        "practiceDarsTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "stateLearningCampTeachingLearningProgramData": {"target": 4,"dateAndAction": "l;jgh","actual": 0,"averageAttendance": 0,"comment": null},
        "stateLearningCampTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "quranStudyTeachingLearningProgramData": {"target": 5,"dateAndAction": "kjgh","actual": 0,"averageAttendance": 0,"comment": null},
        "quranStudyTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "hadithTeachingLearningProgramData": {"target": 5,"dateAndAction": "kjgh","actual": 0,"averageAttendance": 0,"comment": null},
        "hadithTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "quranClassTeachingLearningProgramData": {"target": 6,"dateAndAction": "kljh","actual": 0,"averageAttendance": 0,"comment": null},
        "quranClassTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "weekendIslamicSchoolTeachingLearningProgramData": {"target": 6,"dateAndAction": "kljh","actual": 0,"averageAttendance": 0,"comment": null},
        "weekendIslamicSchoolTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "memorizingAyatTeachingLearningProgramData": {"target": 7,"dateAndAction": "ytri","actual": 0,"averageAttendance": 0,"comment": null},
        "memorizingAyatTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "memorizingHadithTeachingLearningProgramData": {"target": 7,"dateAndAction": "ytri","actual": 0,"averageAttendance": 0,"comment": null},
        "memorizingHadithTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "memorizingDoaTeachingLearningProgramData": {"target": 7,"dateAndAction": "ytri","actual": 0,"averageAttendance": 0,"comment": null},
        "memorizingDoaTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "stateLearningSessionTeachingLearningProgramData": {"target": 78,"dateAndAction": "lkjh","actual": 0,"averageAttendance": 0,"comment": null},
        "stateLearningSessionTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "stateQiyamulLailTeachingLearningProgramData": {"target": 98,"dateAndAction": "ljkh","actual": 0,"averageAttendance": 0,"comment": null},
        "stateQiyamulLailTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "otherTeachingLearningProgramData": {"target": 98,"dateAndAction": "ljkh","actual": 0,"averageAttendance": 0,"comment": null},
        "otherTeachingLearningProgramGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"averageAttendance": 1,"comment": ""},
        "bookSaleMaterialData": {"target": 1,"dateAndAction": "lkjh","actual": 0,"comment": null},
        "bookSaleMaterialGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "bookDistributionMaterialData": {"target": 2,"dateAndAction": "gjkg","actual": 0,"comment": null},
        "bookDistributionMaterialGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "vhsSaleMaterialData": {"target": 3,"dateAndAction": "fgjio","actual": 0,"comment": null},
        "vhsSaleMaterialGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "vhsDistributionMaterialData": {"target": 4,"dateAndAction": "hjkhjk7","actual": 0,"comment": null},
        "vhsDistributionMaterialGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "emailDistributionMaterialData": {"target": 5,"dateAndAction": "kljhjkh9","actual": 0,"comment": null},
        "emailDistributionMaterialGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "ipdcLeafletDistributionMaterialData": {"target": 6,"dateAndAction": "hlhk6","actual": 0,"comment": null},
        "ipdcLeafletDistributionMaterialGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "otherSaleMaterialData": {"target": 3,"dateAndAction": "fgjio","actual": 0,"comment": null},
        "otherSaleMaterialGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "otherDistributionMaterialData": {"target": 4,"dateAndAction": "hjkhjk7","actual": 0,"comment": null},
        "otherDistributionMaterialGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "bookLibraryStockData": {"lastPeriod": 0,"thisPeriod": 0,"increased": 0,"decreased": 0,"comment": null},
        "bookLibraryStockGeneratedData": {"lastPeriod": 1,"thisPeriod": 0,"increased": 0,"decreased": 1,"comment": ""},
        "vhsLibraryStockData": {"lastPeriod": 0,"thisPeriod": 0,"increased": 0,"decreased": 0,"comment": null},
        "vhsLibraryStockGeneratedData": {"lastPeriod": 1,"thisPeriod": 0,"increased": 0,"decreased": 1,"comment": ""},
        "otherLibraryStockData": {"lastPeriod": 0,"thisPeriod": 0,"increased": 0,"decreased": 0,"comment": null},
        "otherLibraryStockGeneratedData": {"lastPeriod": 1,"thisPeriod": 0,"increased": 0,"decreased": 1,"comment": ""},
        "baitulMalFinanceData": {"workerPromiseIncreaseTarget": {"amount": 23.0,"currency": 8},"lastPeriod": {"amount": 23.0,"currency": 8},"action": "l;jkl;jjgklj","otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"totalIncreaseTarget": {"amount": 23.0,"currency": 8},"workerPromiseLastPeriod": {"amount": 0.0,"currency": 8},"workerPromiseThisPeriod": {"amount": 0.0,"currency": 8},"collection": {"amount": 0.0,"currency": 8},"expense": {"amount": 0.0,"currency": 8},"nisabPaidToCentral": {"amount": 0.0,"currency": 8},"balance": {"amount": 0.0,"currency": 8},"workerPromiseIncreased": {"amount": 0.0,"currency": 8},"workerPromiseDecreased": {"amount": 0.0,"currency": 8},"comment": null},
        "baitulMalFinanceGeneratedData": {"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"lastPeriod": {"amount": 23.0,"currency": 8},"action": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"totalIncreaseTarget": {"amount": 0.0,"currency": 8},"workerPromiseLastPeriod": {"amount": 0.0,"currency": 8},"workerPromiseThisPeriod": {"amount": 0.0,"currency": 8},"collection": {"amount": 0.0,"currency": 8},"expense": {"amount": 0.0,"currency": 8},"nisabPaidToCentral": {"amount": 0.0,"currency": 8},"balance": {"amount": 0.0,"currency": 8},"workerPromiseIncreased": {"amount": 0.0,"currency": 8},"workerPromiseDecreased": {"amount": 0.0,"currency": 8},"comment": null},
        "aDayMasjidProjectFinanceData": {"workerPromiseIncreaseTarget": {"amount": 45.0,"currency": 8},"lastPeriod": {"amount": 23.0,"currency": 8},"action": "hjgkhjg","otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"totalIncreaseTarget": {"amount": 45.0,"currency": 8},"workerPromiseLastPeriod": {"amount": 0.0,"currency": 8},"workerPromiseThisPeriod": {"amount": 0.0,"currency": 8},"collection": {"amount": 0.0,"currency": 8},"expense": {"amount": 0.0,"currency": 8},"nisabPaidToCentral": {"amount": 0.0,"currency": 8},"balance": {"amount": 0.0,"currency": 8},"workerPromiseIncreased": {"amount": 0.0,"currency": 8},"workerPromiseDecreased": {"amount": 0.0,"currency": 8},"comment": null},
        "aDayMasjidProjectFinanceGeneratedData": {"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"lastPeriod": {"amount": 23.0,"currency": 8},"action": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"totalIncreaseTarget": {"amount": 0.0,"currency": 8},"workerPromiseLastPeriod": {"amount": 0.0,"currency": 8},"workerPromiseThisPeriod": {"amount": 0.0,"currency": 8},"collection": {"amount": 0.0,"currency": 8},"expense": {"amount": 0.0,"currency": 8},"nisabPaidToCentral": {"amount": 0.0,"currency": 8},"balance": {"amount": 0.0,"currency": 8},"workerPromiseIncreased": {"amount": 0.0,"currency": 8},"workerPromiseDecreased": {"amount": 0.0,"currency": 8},"comment": null},
        "masjidTableBankFinanceData": {"workerPromiseIncreaseTarget": {"amount": 76.0,"currency": 8},"lastPeriod": {"amount": 23.0,"currency": 8},"action": "kgkjhg","otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"totalIncreaseTarget": {"amount": 76.0,"currency": 8},"workerPromiseLastPeriod": {"amount": 0.0,"currency": 8},"workerPromiseThisPeriod": {"amount": 0.0,"currency": 8},"collection": {"amount": 0.0,"currency": 8},"expense": {"amount": 0.0,"currency": 8},"nisabPaidToCentral": {"amount": 0.0,"currency": 8},"balance": {"amount": 0.0,"currency": 8},"workerPromiseIncreased": {"amount": 0.0,"currency": 8},"workerPromiseDecreased": {"amount": 0.0,"currency": 8},"comment": null},
        "masjidTableBankFinanceGeneratedData": {"workerPromiseIncreaseTarget": {"amount": 0.0,"currency": 8},"lastPeriod": {"amount": 23.0,"currency": 8},"action": null,"otherSourceIncreaseTarget": {"amount": 0.0,"currency": 8},"otherSourceAction": null,"totalIncreaseTarget": {"amount": 0.0,"currency": 8},"workerPromiseLastPeriod": {"amount": 0.0,"currency": 8},"workerPromiseThisPeriod": {"amount": 0.0,"currency": 8},"collection": {"amount": 0.0,"currency": 8},"expense": {"amount": 0.0,"currency": 8},"nisabPaidToCentral": {"amount": 0.0,"currency": 8},"balance": {"amount": 0.0,"currency": 8},"workerPromiseIncreased": {"amount": 0.0,"currency": 8},"workerPromiseDecreased": {                "amount": 0.0,"currency": 8},"comment": null},
        "qardeHasanaSocialWelfareData": {"target": 2,"dateAndAction": null,"actual": 0,"comment": null},
        "qardeHasanaSocialWelfareGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "patientVisitSocialWelfareData": {"target": 3,"dateAndAction": null,"actual": 0,"comment": null},
        "patientVisitSocialWelfareGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "socialVisitSocialWelfareData": {"target": 4,"dateAndAction": null,"actual": 0,"comment": null},
        "socialVisitSocialWelfareGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "transportSocialWelfareData": {"target": 5,"dateAndAction": null,"actual": 0,"comment": null},
        "transportSocialWelfareGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "shiftingSocialWelfareData": {"target": 2,"dateAndAction": null,"actual": 0,"comment": null},
        "shiftingSocialWelfareGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "shoppingSocialWelfareData": {"target": 7,"dateAndAction": null,"actual": 0,"comment": null},
        "shoppingSocialWelfareGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "foodDistributionSocialWelfareData": {"target": 7,"dateAndAction": null,"actual": 0,"comment": null},
        "foodDistributionSocialWelfareGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "cleanUpAustraliaSocialWelfareData": {"target": 7,"dateAndAction": null,"actual": 0,"comment": null},
        "cleanUpAustraliaSocialWelfareGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "otherSocialWelfareData": {"target": 7,"dateAndAction": null,"actual": 0,"comment": null},
        "otherSocialWelfareGeneratedData": {"target": 1,"dateAndAction": "","actual": 1,"comment": ""},
        "comment": "blah",
        "timestamp":moment("2019-08-10T22:16:17.433").toDate()
    }
}

function getExpectedReportData(data: StateReportViewModelDto): ReportData {
    return new ReportData(
        makeMemberData(data.associateMemberData),
        makeMemberData(data.preliminaryMemberData),
        makeMemberData(data.supporterMemberData),
        makeMemberData(data.memberMemberData),
        makeMeetingProgramData(data.workerMeetingProgramData),
        makeMeetingProgramData(data.cmsMeetingProgramData),
        makeMeetingProgramData(data.smMeetingProgramData),
        makeMeetingProgramData(data.memberMeetingProgramData),
        makeMeetingProgramData(data.dawahMeetingProgramData),
        makeMeetingProgramData(data.stateLeaderMeetingProgramData),
        makeMeetingProgramData(data.stateOutingMeetingProgramData),
        makeMeetingProgramData(data.iftarMeetingProgramData),
        makeMeetingProgramData(data.learningMeetingProgramData),
        makeMeetingProgramData(data.socialDawahMeetingProgramData),
        makeMeetingProgramData(data.dawahGroupMeetingProgramData),
        makeMeetingProgramData(data.nextGMeetingProgramData),
        makeMeetingProgramData(data.tafsirMeetingProgramData),
        makeMeetingProgramData(data.unitMeetingProgramData),
        makeMeetingProgramData(data.bbqMeetingProgramData),
        makeMeetingProgramData(data.gatheringMeetingProgramData),
        makeMeetingProgramData(data.familyVisitMeetingProgramData),
        makeMeetingProgramData(data.eidReunionMeetingProgramData),
        makeMeetingProgramData(data.otherMeetingProgramData),
        makeTeachingLearningProgramData(data.groupStudyTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.studyCircleForAssociateMemberTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.studyCircleTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.practiceDarsTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.stateLearningCampTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.quranStudyTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.hadithTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.quranClassTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.weekendIslamicSchoolTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.memorizingAyatTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.memorizingHadithTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.memorizingDoaTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.stateLearningSessionTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.stateQiyamulLailTeachingLearningProgramData),
        makeTeachingLearningProgramData(data.otherTeachingLearningProgramData),
        makeMaterialData(data.bookSaleMaterialData),
        makeMaterialData(data.bookDistributionMaterialData),
        makeMaterialData(data.vhsSaleMaterialData),
        makeMaterialData(data.vhsDistributionMaterialData),
        makeMaterialData(data.emailDistributionMaterialData),
        makeMaterialData(data.ipdcLeafletDistributionMaterialData),
        makeMaterialData(data.otherSaleMaterialData),
        makeMaterialData(data.otherDistributionMaterialData),
        makeLibraryStockData(data.bookLibraryStockData),
        makeLibraryStockData(data.vhsLibraryStockData),
        makeLibraryStockData(data.otherLibraryStockData),
        makeFinanceData(data.baitulMalFinanceData),
        makeFinanceData(data.aDayMasjidProjectFinanceData),
        makeFinanceData(data.masjidTableBankFinanceData),
        makeSocialWelfareData(data.qardeHasanaSocialWelfareData),
        makeSocialWelfareData(data.patientVisitSocialWelfareData),
        makeSocialWelfareData(data.socialVisitSocialWelfareData),
        makeSocialWelfareData(data.transportSocialWelfareData),
        makeSocialWelfareData(data.shiftingSocialWelfareData),
        makeSocialWelfareData(data.shoppingSocialWelfareData),
        makeSocialWelfareData(data.foodDistributionSocialWelfareData),
        makeSocialWelfareData(data.cleanUpAustraliaSocialWelfareData),
        makeSocialWelfareData(data.otherSocialWelfareData),
        data.comment
    );
}

function makeMemberData(dto: MemberData): MemberData {
    return new MemberData(dto.nameAndContactNumber, dto.action, dto.lastPeriod, 
        dto.upgradeTarget, dto.thisPeriod, dto.increased, dto.decreased, 
        dto.comment, dto.personalContact);
}

function makeMeetingProgramData(dto: MeetingProgramData) {
    return new MeetingProgramData(dto.target, dto.dateAndAction, dto.actual, dto.averageAttendance, dto.comment);
}

function makeTeachingLearningProgramData(dto: TeachingLearningProgramData) {
    return new TeachingLearningProgramData(dto.target, dto.dateAndAction, dto.actual, dto.averageAttendance, dto.comment);
}

function makeMaterialData(dto: MaterialData) {
    return new MaterialData(dto.target, dto.dateAndAction, dto.actual, dto.comment);
}

function makeLibraryStockData(dto: LibraryStockData) {
    return new LibraryStockData(dto.lastPeriod, dto.thisPeriod, dto.increased, dto.decreased, dto.comment);
}

function makeFinanceData(dto: FinanceData) {
    return new FinanceData(dto.workerPromiseLastPeriod,dto.lastPeriod, dto.workerPromiseIncreaseTarget, dto.workerPromiseIncreased, dto.workerPromiseDecreased, 
        dto.workerPromiseThisPeriod, dto.otherSourceIncreaseTarget, dto.totalIncreaseTarget, dto.collection, dto.expense, dto.nisabPaidToCentral, 
        dto.balance, dto.comment, dto.action, dto.otherSourceAction);
}

function makeSocialWelfareData(dto: SocialWelfareData) {
    return new SocialWelfareData(dto.target, dto.dateAndAction, dto.actual, dto.comment);
}