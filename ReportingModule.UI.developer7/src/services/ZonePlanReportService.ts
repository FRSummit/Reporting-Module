import env from "../environment";
import { fetchPostWithAccessToken, fetchWithAccessToken, fetchFileWithAccessToken } from "./fetch";
import { OrganizationReference } from "models/OrganizationReference";
import { ReportingTerm } from "models/ReportingTerm";
import { PlanData } from "../models/PlanData";
import { ReportData } from "models/ReportData";
import { ExcelReportType } from "models/ExcelReportType";
import { ZonePlanViewModelDto } from "models/ZonePlanViewModelDto";
import { ZoneReportViewModelDto } from "models/ZoneReportViewModelDto";
import { ReportingFrequency } from "models/ReportingFrequency";
import { ReportLastPeriodUpdateData } from "models/ReportLastPeriodUpdateData";

export class ZonePlanReportService {
    zonePlanReportServiceUrl = `${env.apiBaseUrl}/reporting/v1/zone`;
    getPlan(planId: number): Promise<ZonePlanViewModelDto> {
        return fetchWithAccessToken(`${this.zonePlanReportServiceUrl}/plan/${planId}`);
    }
    updatePlan(organizationId: number, planId: number, planData: PlanData): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/plan/update?organizationId=${organizationId}&planId=${planId}`, JSON.stringify(planData));
    }
    createPlan(organizationReference: OrganizationReference, year: number, reportingTerm: ReportingTerm): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/plan/create?year=${year}&reportingTerm=${reportingTerm}`, JSON.stringify(organizationReference));
    }
    createPlan2(organizationReference: OrganizationReference, year: number, reportingTerm: ReportingTerm, reportingFrequency: ReportingFrequency): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/plan/create2?year=${year}&reportingTerm=${reportingTerm}&reportingFrequency=${reportingFrequency}`,
            JSON.stringify(organizationReference));
    }
    copy(copyFrom: number, organization: OrganizationReference, year: number, reportingTerm: ReportingTerm, reportingFrequency: ReportingFrequency): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/plan/copy?year=${year}&reportingTerm=${reportingTerm}&reportingFrequency=${reportingFrequency}&copyFromReportId=${copyFrom}`,
            JSON.stringify(organization));
    }
    submitPlan(organizationId: number, planId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/plan/submit?planId=${planId}&organizationId=${organizationId}`);
    }
    getReport(reportId: number): Promise<ZoneReportViewModelDto> {
        return fetchWithAccessToken(`${this.zonePlanReportServiceUrl}/report/${reportId}`);
    }
    updateReport(organizationId: number, reportId: number, reportData: ReportData): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/report/update/id?organizationId=${organizationId}&reportId=${reportId}`, JSON.stringify(reportData));
    }
    updateReportLastPeriod(organizationId: number, reportId: number, reportLastPeriodUpdateData: ReportLastPeriodUpdateData): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/report/updateLastPeriod/id?organizationId=${organizationId}&reportId=${reportId}`,
        JSON.stringify(reportLastPeriodUpdateData));
    }
    submitReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/report/submit?reportId=${reportId}&organizationId=${organizationId}`);
    }
    unsubmitReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/report/unsubmit?reportId=${reportId}&organizationId=${organizationId}`);
    }
    downloadReport(reportId: number, excelReportType: ExcelReportType): Promise<Blob> {
        return fetchFileWithAccessToken(`${this.zonePlanReportServiceUrl}/download/report/${reportId}?excelReportType=${excelReportType}`);
    }
    resetReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/report/reset/id?organizationId=${organizationId}&reportId=${reportId}`);
    }
    recalculateReport(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/report/recalculate/id?organizationId=${organizationId}&reportId=${reportId}`);
    }
    delete(organizationId: number, reportId: number): Promise<void> {
        return fetchPostWithAccessToken(`${this.zonePlanReportServiceUrl}/report/delete?reportId=${reportId}&organizationId=${organizationId}`);
    }
}
