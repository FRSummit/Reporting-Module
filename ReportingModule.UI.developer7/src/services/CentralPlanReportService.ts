import env from "../environment";
import { fetchPostWithAccessToken, fetchWithAccessToken, fetchFileWithAccessToken } from "./fetch";
import { OrganizationReference } from "models/OrganizationReference";
import { ReportingTerm } from "models/ReportingTerm";
import { PlanData } from "../models/PlanData";
import { ReportData } from "models/ReportData";
import { ExcelReportType } from "models/ExcelReportType";
import { CentralPlanViewModelDto } from "models/CentralPlanViewModelDto";
import { CentralReportViewModelDto } from "models/CentralReportViewModelDto";
import { ReportingFrequency } from "models/ReportingFrequency";
import { ReportLastPeriodUpdateData } from "models/ReportLastPeriodUpdateData";

export class CentralPlanReportService {
    centralPlanReportServiceUrl = `${env.apiBaseUrl}/reporting/v1/central`;
    getPlan(planId: number): Promise<CentralPlanViewModelDto> {
        return fetchWithAccessToken(`${this.centralPlanReportServiceUrl}/plan/${planId}`);
    }
    updatePlan(organizationId: number, planId: number, planData: PlanData): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/plan/update?organizationId=${organizationId}&planId=${planId}`, JSON.stringify(planData));
    }
    createPlan(organizationReference: OrganizationReference, year: number, reportingTerm: ReportingTerm): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/plan/create?year=${year}&reportingTerm=${reportingTerm}`, JSON.stringify(organizationReference));
    }
    createPlan2(organizationReference: OrganizationReference, year: number, reportingTerm: ReportingTerm, reportingFrequency: ReportingFrequency): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/plan/create2?year=${year}&reportingTerm=${reportingTerm}&reportingFrequency=${reportingFrequency}`,
            JSON.stringify(organizationReference));
    }
    copy(copyFrom: number, organization: OrganizationReference, year: number, reportingTerm: ReportingTerm, reportingFrequency: ReportingFrequency): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/plan/copy?year=${year}&reportingTerm=${reportingTerm}&reportingFrequency=${reportingFrequency}&copyFromReportId=${copyFrom}`,
            JSON.stringify(organization));
    }
    submitPlan(organizationId: number, planId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/plan/submit?planId=${planId}&organizationId=${organizationId}`);
    }
    getReport(reportId: number): Promise<CentralReportViewModelDto> {
        return fetchWithAccessToken(`${this.centralPlanReportServiceUrl}/report/${reportId}`);
    }
    updateReport(organizationId: number, reportId: number, reportData: ReportData): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/report/update/id?organizationId=${organizationId}&reportId=${reportId}`, JSON.stringify(reportData));
    }
    updateReportLastPeriod(organizationId: number, reportId: number, reportLastPeriodUpdateData: ReportLastPeriodUpdateData): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/report/updateLastPeriod/id?organizationId=${organizationId}&reportId=${reportId}`,
        JSON.stringify(reportLastPeriodUpdateData));
    }
    submitReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/report/submit?reportId=${reportId}&organizationId=${organizationId}`);
    }
    unsubmitReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/report/unsubmit?reportId=${reportId}&organizationId=${organizationId}`);
    }
    downloadReport(reportId: number, excelReportType: ExcelReportType): Promise<Blob> {
        return fetchFileWithAccessToken(`${this.centralPlanReportServiceUrl}/download/report/${reportId}?excelReportType=${excelReportType}`);
    }
    resetReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/report/reset/id?organizationId=${organizationId}&reportId=${reportId}`);
    }
    recalculateReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/report/recalculate/id?organizationId=${organizationId}&reportId=${reportId}`);
    }
    delete(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.centralPlanReportServiceUrl}/report/delete?reportId=${reportId}&organizationId=${organizationId}`);
    }
}
