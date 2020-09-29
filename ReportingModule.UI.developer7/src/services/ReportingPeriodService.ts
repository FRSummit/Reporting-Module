import { ReportingPeriodViewModel } from "models/ReportingPeriodViewModel";
import { fetchWithAccessToken } from "./fetch";
import env from "../environment";

export class ReportingPeriodService {
    reportingPeriodServiceUrl = `${env.apiBaseUrl}/reporting/v1/reportingperiod`;

    getReportingPeriodsToCreatePlan = (organizationId: number): Promise<ReportingPeriodViewModel[]> => {
        return fetchWithAccessToken(`${this.reportingPeriodServiceUrl}/oforganization?organizationId=${organizationId}`);
    }

    getNextReportingPeriod = (reportId: number): Promise<ReportingPeriodViewModel> => {
        return fetchWithAccessToken(`${this.reportingPeriodServiceUrl}/next?reportId=${reportId}`);
    }
}