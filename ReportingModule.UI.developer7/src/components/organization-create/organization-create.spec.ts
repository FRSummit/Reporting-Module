import * as moment from "moment";
import { AppRouter } from "aurelia-router";
import { OrganizationViewModelDto } from "models/OrganizationViewModelDto";
import { OrganizationService } from "services/OrganizationService";
import { OrganizationCreate } from "./organization-create";

describe("organization-create tests", () => {
    it("search calls expected method", async () => {
        const dto: OrganizationViewModelDto[] = [
            { "id": 3, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Footscray Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },
            { "id": 4, "organizationType": 1, "organizationTypeDescription": "Unit", "description": "Sunshine Unit, President: Mohammad Mostadir, State: Victoria.", "reportingFrequency": 1, "reportingFrequencyDescription": "Monthly", "parent": { "id": 2, "description": "Victoria" }, "parentDescription": "Victoria", "timestamp": moment("2019-08-09T16:48:14.567").toDate(), "managedOrganizations": [] },

        ];

        const organizationService = new OrganizationService();
        spyOn(organizationService, "myorganizations").and.returnValue(Promise.resolve(dto));

        const sut = new OrganizationCreate(organizationService, undefined, undefined);

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
     
        const sut = new OrganizationCreate(organizationService, undefined, undefined);

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
        
        const sut = new OrganizationCreate(organizationService, undefined, undefined);
        sut.selectOrganization(dto[0]);

        await sut.search();

        expect(sut.selectedOrganization).not.toBeDefined();
        expect(sut.isSearching).toBe(false);
        expect(sut.nodatafound).toBe(true);
    });

    it("onOrganizationCreateFailed reset creating flag", () => {
        const sut = new OrganizationCreate(undefined, undefined, undefined);

        sut.isCreatingOrganization = true;

        sut.onOrganizationCreateFailed({ $values: ["error"] });

        expect(sut.isCreatingOrganization).toBe(false);
    });
});
