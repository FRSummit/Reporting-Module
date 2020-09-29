import { PlansAndReports } from "./plans-and-reports";
import { AllReportService } from "services/AllReportsService";
import { SearchResult } from "models/SearchResult";
import { ReportViewModelDto } from "models/ReportViewModelDto";
import * as moment from "moment";
import { UnitPlanReportService } from "services/UnitPlanReportService";
import { ZonePlanReportService } from "services/ZonePlanReportService";
import { StatePlanReportService } from "services/StatePlanReportService";
import { CentralPlanReportService } from "services/CentralPlanReportService";
import { ReportGridItem } from "./ReportGridItem";
import { OrganizationReference } from "models/OrganizationReference";
import { OrganizationType } from "models/OrganizationType";
import { ReportingFrequency } from "models/ReportingFrequency";
import { getMockLocalStorage } from "../../../test/MockLocalStorage";
import { BrowserStorage } from "../../utils/browserStorage";


describe("plans and reports tests", () => {

    let mockLocalStorage: Storage = null;
    let browserStorage: BrowserStorage = null;

    beforeEach(() => {
        mockLocalStorage = getMockLocalStorage();
        browserStorage = new BrowserStorage(null, {
            storage: mockLocalStorage
        });
    });


    it("search calls expected service", async () => {
        const dto: SearchResult<ReportViewModelDto> = {
            "items": [
                {
                    "id": 1, "description": "10001-VIC-TGN-JAN19",
                    "organization": { "id": 5, "organizationType": 1, "description": "Truganina North Unit", "reportingFrequency": 1 },
                    "reportingPeriod": { "startDate": moment("2019-01-01T00:00:00").toDate(), "endDate": moment("2019-01-31T23:59:59").toDate(), "reportingFrequency": 1, "reportingTerm": 1, "year": 2019 },
                    "reportStatus": 3, "reportStatusDescription": "Submitted", "reOpenedReportStatus": 0, "reOpenedReportStatusDescription": "None", "timestamp": moment("2019-07-20T03:18:50.827").toDate()
                },
                {
                    "id": 2, "description": "10001-VIC-TGN-FEBN19",
                    "organization": { "id": 5, "organizationType": 1, "description": "Truganina North Unit", "reportingFrequency": 1 },
                    "reportingPeriod": { "startDate": moment("2019-02-01T00:00:00").toDate(), "endDate": moment("2019-02-28T23:59:59").toDate(), "reportingFrequency": 1, "reportingTerm": 2, "year": 2019 },
                    "reportStatus": 3, "reportStatusDescription": "Submitted", "reOpenedReportStatus": 0, "reOpenedReportStatusDescription": "None", "timestamp": moment("2019-07-20T03:18:50.827").toDate()
                }],
            "pagingData": { "page": 1, "pageSize": 10, "totalRecords": 2 }
        };
        const allReportService = new AllReportService();
        spyOn(allReportService, "search").and.returnValue(Promise.resolve(dto));
        const sut = new PlansAndReports(allReportService, undefined, undefined, undefined, undefined, undefined, undefined, browserStorage);

        await sut.grid.search();

        expect(sut.allReportService.search).toHaveBeenCalled();
    });

    it("unit plan delete calls expected service", async () => {
        const allReportService = new AllReportService();
        const unitPlanReportService = new UnitPlanReportService();
        const zonePlanReportService = new ZonePlanReportService();
        const statePlanReportService = new StatePlanReportService();
        const centralPlanReportService = new CentralPlanReportService();

        spyOn(unitPlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(zonePlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(statePlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(centralPlanReportService, "delete").and.returnValue(Promise.resolve());

        const itemToDelete = new ReportGridItem(12, "", new OrganizationReference(1, OrganizationType.Unit, "test", ReportingFrequency.Monthly), undefined, undefined, undefined, undefined, undefined, undefined, false, true);
        const sut = new PlansAndReports(allReportService, unitPlanReportService, zonePlanReportService, statePlanReportService, centralPlanReportService, undefined, undefined, browserStorage);

        await sut.delete(itemToDelete);

        expect(unitPlanReportService.delete).toHaveBeenCalledWith(1, 12);
        expect(itemToDelete.isDeleting).toBe(true);
    });

    it("zone plan delete calls expected service", async () => {
        const allReportService = new AllReportService();
        const unitPlanReportService = new UnitPlanReportService();
        const zonePlanReportService = new ZonePlanReportService();
        const statePlanReportService = new StatePlanReportService();
        const centralPlanReportService = new CentralPlanReportService();

        spyOn(unitPlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(zonePlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(statePlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(centralPlanReportService, "delete").and.returnValue(Promise.resolve());

        const itemToDelete = new ReportGridItem(22, "", new OrganizationReference(2, OrganizationType.Zone, "test", ReportingFrequency.Monthly), undefined, undefined, undefined, undefined, undefined, undefined, false, true);
        const sut = new PlansAndReports(allReportService, unitPlanReportService, zonePlanReportService, statePlanReportService, centralPlanReportService, undefined, undefined, browserStorage);

        await sut.delete(itemToDelete);

        expect(zonePlanReportService.delete).toHaveBeenCalledWith(2, 22);
        expect(itemToDelete.isDeleting).toBe(true);
    });

    it("state plan delete calls expected service", async () => {
        const allReportService = new AllReportService();
        const unitPlanReportService = new UnitPlanReportService();
        const zonePlanReportService = new ZonePlanReportService();
        const statePlanReportService = new StatePlanReportService();
        const centralPlanReportService = new CentralPlanReportService();

        spyOn(unitPlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(zonePlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(statePlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(centralPlanReportService, "delete").and.returnValue(Promise.resolve());

        const itemToDelete = new ReportGridItem(32, "", new OrganizationReference(3, OrganizationType.State, "test", ReportingFrequency.Monthly), undefined, undefined, undefined, undefined, undefined, undefined, false, true);
        const sut = new PlansAndReports(allReportService, unitPlanReportService, zonePlanReportService, statePlanReportService, centralPlanReportService, undefined, undefined, browserStorage);

        await sut.delete(itemToDelete);

        expect(statePlanReportService.delete).toHaveBeenCalledWith(3, 32);
        expect(itemToDelete.isDeleting).toBe(true);
    });

    it("central plan delete calls expected service", async () => {
        const allReportService = new AllReportService();
        const unitPlanReportService = new UnitPlanReportService();
        const zonePlanReportService = new ZonePlanReportService();
        const statePlanReportService = new StatePlanReportService();
        const centralPlanReportService = new CentralPlanReportService();

        spyOn(unitPlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(zonePlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(statePlanReportService, "delete").and.returnValue(Promise.resolve());
        spyOn(centralPlanReportService, "delete").and.returnValue(Promise.resolve());

        const itemToDelete = new ReportGridItem(42, "", new OrganizationReference(4, OrganizationType.Central, "test", ReportingFrequency.Monthly), undefined, undefined, undefined, undefined, undefined, undefined, false, true);
        const sut = new PlansAndReports(allReportService, unitPlanReportService, zonePlanReportService, statePlanReportService, centralPlanReportService, undefined, undefined, browserStorage);

        await sut.delete(itemToDelete);

        expect(centralPlanReportService.delete).toHaveBeenCalledWith(4, 42);
        expect(itemToDelete.isDeleting).toBe(true);
    });
});
