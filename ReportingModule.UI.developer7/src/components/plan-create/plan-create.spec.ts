import * as moment from "moment";
import { AppRouter } from "aurelia-router";
import { OrganizationViewModelDto } from "models/OrganizationViewModelDto";
import { OrganizationService } from "services/OrganizationService";
import { PlanCreate } from "./plan-create";
import { ReportingPeriodService } from "services/ReportingPeriodService";

describe("unit-plan-create tests", () => {
    it("search calls expected method", async () => {
        const dto: OrganizationViewModelDto[] = [
            { "id": 3, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Footscray Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 4, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Sunshine Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },

        ];

        const organizationService = new OrganizationService();
        spyOn(organizationService, "myorganizations").and.returnValue(Promise.resolve(dto));

        const sut = new PlanCreate(organizationService, undefined, undefined, undefined, undefined, undefined, undefined, undefined);

        await sut.search();

        expect(organizationService.myorganizations).toHaveBeenCalled();
        expect(sut.items).toEqual(dto);
        expect(sut.selectedOrganization).toBe(undefined);
        expect(sut.isSearching).toBe(false);
        expect(sut.nodatafound).toBe(false);
    });

    it("selected by default when single organization in search result", async () => {
        const dto: OrganizationViewModelDto[] = [
            { "id": 3, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Footscray Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
        ];

        const organizationService = new OrganizationService();
        spyOn(organizationService, "myorganizations").and.returnValue(Promise.resolve(dto));
        const reportingPeriodService = new ReportingPeriodService();
        spyOn(reportingPeriodService, "getReportingPeriodsToCreatePlan").and.returnValue(Promise.resolve([]));

        const sut = new PlanCreate(organizationService, undefined, undefined, undefined, undefined, reportingPeriodService, undefined, undefined);

        await sut.search();

        expect(sut.selectedOrganization).toBe(dto[0]);
        expect(sut.isSearching).toBe(false);
        expect(sut.nodatafound).toBe(false);
    });

    it("search sets flag when no data returned", async () => {
        const dto: OrganizationViewModelDto[] = [
            { "id": 3, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Footscray Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },

        ];

        const organizationService = new OrganizationService();
        spyOn(organizationService, "myorganizations").and.returnValue(Promise.resolve([]));
        const reportingPeriodService = new ReportingPeriodService();
        spyOn(reportingPeriodService, "getReportingPeriodsToCreatePlan").and.returnValue(Promise.resolve([]));

        const sut = new PlanCreate(organizationService, undefined, undefined, undefined, undefined, reportingPeriodService, undefined, undefined);
        sut.selectOrganization(dto[0]);

        await sut.search();

        expect(sut.selectedOrganization).not.toBeDefined();
        expect(sut.isSearching).toBe(false);
        expect(sut.nodatafound).toBe(true);
    });

    it("central is selected if returned in search result", async () => {
        const dto: OrganizationViewModelDto[] = [

            { "id": 1, "organizationType": 5, "organizationTypeDescription": "Central", "description": "Central", "reportingFrequency": 12, "reportingFrequencyDescription": "Anual", "parent": { "id": 0, "description": "Root" }, "parentDescription": "", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 2, "organizationType": 3, "organizationTypeDescription": "State", "description": "Victoria", "reportingFrequency": 3, "reportingFrequencyDescription": "Quarterly", "parent": { "id": 1, "description": "Central" }, "parentDescription": "Central", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 3, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Footscray Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 4, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Sunshine Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 5, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Truganina North Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 6, "organizationType": 3, "organizationTypeDescription": "State", "description": "NSW", "reportingFrequency": 3, "reportingFrequencyDescription": "Quarterly", "parent": { "id": 1, "description": "Central" }, "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "parentDescription": "Central", "managedOrganizations": [] },
            { "id": 7, "organizationType": 2, "organizationTypeDescription": "Zone", "description": "NSW Zone One", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 6, "description": "NSW" }, "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "parentDescription": "NSW", "managedOrganizations": [] },
            { "id": 8, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Lakemba Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 7, "description": "NSW Zone One" }, "parentDescription": "NSW Zone One", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] }

        ];

        const organizationService = new OrganizationService();
        spyOn(organizationService, "myorganizations").and.returnValue(Promise.resolve(dto));
        const reportingPeriodService = new ReportingPeriodService();
        spyOn(reportingPeriodService, "getReportingPeriodsToCreatePlan").and.returnValue(Promise.resolve([]));

        const sut = new PlanCreate(organizationService, undefined, undefined, undefined, undefined, reportingPeriodService, undefined, undefined);

        await sut.search();

        expect(sut.selectedOrganization).toEqual(dto[0]);
    });

    it("first state is selected if returned in search result", async () => {
        const dto: OrganizationViewModelDto[] = [

            { "id": 2, "organizationType": 3, "organizationTypeDescription": "State", "description": "Victoria", "reportingFrequency": 3, "reportingFrequencyDescription": "Quarterly", "parent": { "id": 1, "description": "Central" }, "parentDescription": "Central", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 3, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Footscray Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 4, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Sunshine Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 5, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Truganina North Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 6, "organizationType": 3, "organizationTypeDescription": "State", "description": "NSW", "reportingFrequency": 3, "reportingFrequencyDescription": "Quarterly", "parent": { "id": 1, "description": "Central" }, "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "parentDescription": "Central", "managedOrganizations": [] },
            { "id": 7, "organizationType": 2, "organizationTypeDescription": "Zone", "description": "NSW Zone One", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 6, "description": "NSW" }, "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "parentDescription": "NSW", "managedOrganizations": [] },
            { "id": 8, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Lakemba Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 7, "description": "NSW Zone One" }, "parentDescription": "NSW Zone One", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] }
        ];

        const organizationService = new OrganizationService();
        spyOn(organizationService, "myorganizations").and.returnValue(Promise.resolve(dto));
        const reportingPeriodService = new ReportingPeriodService();
        spyOn(reportingPeriodService, "getReportingPeriodsToCreatePlan").and.returnValue(Promise.resolve([]));

        const sut = new PlanCreate(organizationService, undefined, undefined, undefined, undefined, reportingPeriodService, undefined, undefined);

        await sut.search();

        expect(sut.selectedOrganization).toEqual(dto[0]);
    });

    it("zone is selected if returned in search result", async () => {
        const dto: OrganizationViewModelDto[] = [

            { "id": 3, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Footscray Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 4, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Sunshine Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 5, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Truganina North Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 7, "organizationType": 2, "organizationTypeDescription": "Zone", "description": "NSW Zone One", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 6, "description": "NSW" }, "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "parentDescription": "NSW", "managedOrganizations": [] },
            { "id": 8, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Lakemba Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 7, "description": "NSW Zone One" }, "parentDescription": "NSW Zone One", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] }

        ];

        const organizationService = new OrganizationService();
        spyOn(organizationService, "myorganizations").and.returnValue(Promise.resolve(dto));
        const reportingPeriodService = new ReportingPeriodService();
        spyOn(reportingPeriodService, "getReportingPeriodsToCreatePlan").and.returnValue(Promise.resolve([]));

        const sut = new PlanCreate(organizationService, undefined, undefined, undefined, undefined, reportingPeriodService, undefined, undefined);

        await sut.search();

        expect(sut.selectedOrganization).toEqual(dto[3]);
    });

    it("no organization is selected if no central/state/zone and more than 1 unit in search result", async () => {
        const dto: OrganizationViewModelDto[] = [
            { "id": 3, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Footscray Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 4, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Sunshine Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 5, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Truganina North Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 8, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Lakemba Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 7, "description": "NSW Zone One" }, "parentDescription": "NSW Zone One", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] }
        ];

        const organizationService = new OrganizationService();
        spyOn(organizationService, "myorganizations").and.returnValue(Promise.resolve(dto));
        const reportingPeriodService = new ReportingPeriodService();
        spyOn(reportingPeriodService, "getReportingPeriodsToCreatePlan").and.returnValue(Promise.resolve([]));

        const sut = new PlanCreate(organizationService, undefined, undefined, undefined, undefined, reportingPeriodService, undefined, undefined);

        await sut.search();

        expect(sut.selectedOrganization).toBeUndefined();
    });

    it("onUnitPlanCreated calls expected router method", () => {
        const router = {
            navigate: (href: string) => { }
        } as any as AppRouter;
        spyOn(router, "navigate").and.returnValue(undefined);

        const sut = new PlanCreate(undefined, undefined, undefined, undefined, undefined, undefined, undefined, router);

        sut.onUnitPlanCreated(1);

        expect(router.navigate).toHaveBeenCalledWith("unit-plan-edit/1");
    })

    it("onUnitPlanCreateFailed reset creating flag", () => {
        const sut = new PlanCreate(undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined);

        sut.isCreatingPlan = true;

        sut.onUnitPlanCreateFailed({ $values: ["error"] });

        expect(sut.isCreatingPlan).toBe(false);
    });

    it("onStatePlanCreated calls expected router method", () => {
        const router = {
            navigate: (href: string) => { }
        } as any as AppRouter;
        spyOn(router, "navigate").and.returnValue(undefined);

        const sut = new PlanCreate(undefined, undefined, undefined, undefined, undefined, undefined, undefined, router);

        sut.onStatePlanCreated(1);

        expect(router.navigate).toHaveBeenCalledWith("state-plan-edit/1");
    });

    it("onStatePlanCreateFailed resets creating flag", () => {
        const sut = new PlanCreate(undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined);

        sut.isCreatingPlan = true;

        sut.onStatePlanCreateFailed({ $values: ["error"] });

        expect(sut.isCreatingPlan).toBe(false);
    });
});
