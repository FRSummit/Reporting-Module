import env from "../environment";
import { fetchPostWithAccessToken, fetchWithAccessToken, fetchFileWithAccessToken } from "./fetch";
import { OrganizationReference } from "models/OrganizationReference";
import { ReportingTerm } from "models/ReportingTerm";
import { PlanData } from "../models/PlanData";
import { StatePlanViewModelDto } from "../models/StatePlanViewModelDto";
import { StateReportViewModelDto } from "../models/StateReportViewModelDto";
import { ReportData } from "models/ReportData";
import { ExcelReportType } from "models/ExcelReportType";
import { ReportingFrequency } from "models/ReportingFrequency";
import { ReportLastPeriodUpdateData } from "models/ReportLastPeriodUpdateData";


export class StatePlanReportService {
    statePlanReportServiceUrl = `${env.apiBaseUrl}/reporting/v1/state`;

    getPlan(planId: number): Promise<StatePlanViewModelDto> {
        return fetchWithAccessToken(`${this.statePlanReportServiceUrl}/plan/${planId}`);
    }

    updatePlan(organizationId: number, planId: number, planData: PlanData): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/plan/update?organizationId=${organizationId}&planId=${planId}`,
            JSON.stringify(planData));
    }

    createPlan(organizationReference: OrganizationReference, year: number, reportingTerm: ReportingTerm): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/plan/create?year=${year}&reportingTerm=${reportingTerm}`,
            JSON.stringify(organizationReference));
    }

    createPlan2(organizationReference: OrganizationReference, year: number, reportingTerm: ReportingTerm, reportingFrequency: ReportingFrequency): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/plan/create2?year=${year}&reportingTerm=${reportingTerm}&reportingFrequency=${reportingFrequency}`,
            JSON.stringify(organizationReference));
    }

    copy(copyFrom: number, organization: OrganizationReference, year: number, reportingTerm: ReportingTerm, reportingFrequency: ReportingFrequency): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/plan/copy?year=${year}&reportingTerm=${reportingTerm}&reportingFrequency=${reportingFrequency}&copyFromReportId=${copyFrom}`,
            JSON.stringify(organization));
    }

    submitPlan(organizationId: number, planId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/plan/submit?planId=${planId}&organizationId=${organizationId}`);
    }

    getReport(reportId: number): Promise<StateReportViewModelDto> {
        return fetchWithAccessToken(`${this.statePlanReportServiceUrl}/report/${reportId}`);
    }

    updateReport(organizationId: number, reportId: number, reportData: ReportData): Promise<void> {
          return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/report/update/id?organizationId=${organizationId}&reportId=${reportId}`,
          JSON.stringify(reportData));
    }

    updateReportLastPeriod(organizationId: number, reportId: number, reportLastPeriodUpdateData: ReportLastPeriodUpdateData): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/report/updateLastPeriod/id?organizationId=${organizationId}&reportId=${reportId}`,
        JSON.stringify(reportLastPeriodUpdateData));
    }

    submitReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/report/submit?reportId=${reportId}&organizationId=${organizationId}`);
    }
    
    unsubmitReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/report/unsubmit?reportId=${reportId}&organizationId=${organizationId}`);
    }
    
    downloadReport(reportId: number, excelReportType: ExcelReportType): Promise<Blob> {
        return fetchFileWithAccessToken(`${this.statePlanReportServiceUrl}/download/report/${reportId}?excelReportType=${excelReportType}`);
    }

    resetReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/report/reset/id?organizationId=${organizationId}&reportId=${reportId}`);
    }

    recalculateReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/report/recalculate/id?organizationId=${organizationId}&reportId=${reportId}`);
    }

    delete(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.statePlanReportServiceUrl}/report/delete?reportId=${reportId}&organizationId=${organizationId}`);
    }
}
