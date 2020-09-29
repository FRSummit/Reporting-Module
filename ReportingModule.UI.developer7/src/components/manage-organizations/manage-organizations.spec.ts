import { ManageOrganizations } from "./manage-organizations";
import { OrganizationService } from "services/OrganizationService";
import { SearchResult } from "models/SearchResult";
import { OrganizationViewModelDto } from "models/OrganizationViewModelDto";
import * as moment from "moment";

describe("Manage Organizations tests", () => {
    it("search calls expected service", async () => {       
        const dto: SearchResult<OrganizationViewModelDto> = {
          "items":[
            {"id":1,"organizationType":5,"organizationTypeDescription":"Central","description":"Central","reportingFrequency":12,"reportingFrequencyDescription":"Anual","parent":{"id":0,"description":"Root"},"parentDescription":"","timestamp": moment("2019-08-09T16:48:14.567").toDate(),"managedOrganizations":[]},
            {"id":2,"organizationType":3,"organizationTypeDescription":"State","description":"Victoria","reportingFrequency":3,"reportingFrequencyDescription":"Quarterly","parent":{"id":1,"description":"Central"},"parentDescription":"Central","timestamp": moment("2019-08-09T16:48:14.567").toDate(),"managedOrganizations":[]},
            {"id":3,"organizationType":1,"organizationTypeDescription":"Unit","description":"Footscray Unit, President: Mohammad Mostadir, State: Victoria.","reportingFrequency":1,"reportingFrequencyDescription":"Monthly","parent":{"id":2,"description":"Victoria"},"parentDescription":"Victoria","timestamp": moment("2019-08-09T16:48:14.567").toDate(),"managedOrganizations":[]},
            {"id":4,"organizationType":1,"organizationTypeDescription":"Unit","description":"Sunshine Unit, President: Mohammad Mostadir, State: Victoria.","reportingFrequency":1,"reportingFrequencyDescription":"Monthly","parent":{"id":2,"description":"Victoria"},"parentDescription":"Victoria","timestamp":moment("2019-08-09T16:48:14.567").toDate(),"managedOrganizations":[]},
            {"id":5,"organizationType":1,"organizationTypeDescription":"Unit","description":"Truganina North Unit, President: Mohammad Mostadir, State: Victoria.","reportingFrequency":1,"reportingFrequencyDescription":"Monthly","parent":{"id":2,"description":"Victoria"},"parentDescription":"Victoria","timestamp":moment("2019-08-09T16:48:14.567").toDate(),"managedOrganizations":[]},
            {"id":6,"organizationType":3,"organizationTypeDescription":"State","description":"NSW","reportingFrequency":3,"reportingFrequencyDescription":"Quarterly","parent":{"id":1,"description":"Central"},"timestamp":moment("2019-08-09T16:48:14.567").toDate(),"parentDescription":"Central","managedOrganizations":[]},
            {"id":7,"organizationType":2,"organizationTypeDescription":"Zone","description":"NSW Zone One","reportingFrequency":1,"reportingFrequencyDescription":"Monthly","parent":{"id":6,"description":"NSW"},"timestamp":moment("2019-08-09T16:48:14.567").toDate(),"parentDescription":"NSW","managedOrganizations":[]},
            {"id":8,"organizationType":1,"organizationTypeDescription":"Unit","description":"Lakemba Unit, President: Mohammad Mostadir, State: Victoria.","reportingFrequency":1,"reportingFrequencyDescription":"Monthly","parent":{"id":7,"description":"NSW Zone One"},"parentDescription":"NSW Zone One","timestamp":moment("2019-08-09T16:48:14.567").toDate(),"managedOrganizations":[]}],
            "pagingData":{"page":1,"pageSize":10,"totalRecords":8}
        };
        const organizationService = new OrganizationService();
        spyOn(organizationService, "search").and.returnValue(Promise.resolve(dto));
        const sut = new ManageOrganizations(organizationService, undefined, undefined);
        
        await sut.grid.search();

        expect(sut.organizationService.search).toHaveBeenCalled();
    })
});
