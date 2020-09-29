import env from "../environment";
import { fetchPostWithAccessToken } from "./fetch";

export class AdminService {
    pingServiceUrl = `${env.apiBaseUrl}/reporting/v1/ping`;

    ping(message: string): Promise<void> {
        return fetchPostWithAccessToken(this.pingServiceUrl, message);
    }
}