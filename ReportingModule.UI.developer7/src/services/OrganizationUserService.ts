import env from "../environment";
import { OrganizationUserSearchTerms } from "models/OrganizationUserSearchTerms";
import { OrganizationUserViewModelDto } from "models/OrganizationUserViewModelDto";
import { OrganizationRoleType } from "models/OrganizationRoleType";
import { EntityReference } from "models/EntityReference";
import { SearchResult } from "models/SearchResult";
import { fetchPostWithAccessToken, fetchWithAccessToken, fetchFileWithAccessToken } from "./fetch";


export class OrganizationUserService {
    organizationUserServiceUrl = `${env.apiBaseUrl}/reporting/v1/organization/user`;

    search = (organizationUserSearchTerms: OrganizationUserSearchTerms): Promise<SearchResult<OrganizationUserViewModelDto>> => {  
        return fetchWithAccessToken(`${this.organizationUserServiceUrl}/search?${organizationUserSearchTerms.toQry()}`);
    }

    create(username: string, organizationRoleType: OrganizationRoleType, organization: EntityReference): Promise<void> {
        return fetchPostWithAccessToken(`${this.organizationUserServiceUrl}/create?username=${username}&organizationRoleType=${organizationRoleType}`,
            JSON.stringify(organization));
    }

    delete(organizationUserId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.organizationUserServiceUrl}/delete?organizationUserId=${organizationUserId}`);
    }
}
