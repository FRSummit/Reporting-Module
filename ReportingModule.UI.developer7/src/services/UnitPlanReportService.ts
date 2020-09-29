import env from "../environment";
import { fetchWithAccessToken, fetchPostWithAccessToken, fetchFileWithAccessToken } from "./fetch";
import { UnitPlanViewModelDto } from "models/UnitPlanViewModelDto";
import { PlanData } from "models/PlanData";
import { ReportingTerm } from "models/ReportingTerm";
import { OrganizationReference } from "models/OrganizationReference";
import { UnitReportViewModelDto } from "models/UnitReportViewModelDto";
import { ReportUpdateData } from "models/ReportUpdateData";
import { ExcelReportType } from "models/ExcelReportType";
import { ReportingFrequency } from "models/ReportingFrequency";
import { ReportLastPeriodUpdateData } from "models/ReportLastPeriodUpdateData";

export class UnitPlanReportService {
    unitPlanReportServiceUrl = `${env.apiBaseUrl}/reporting/v1/unit`;
    
    createPlan(organizationReference: OrganizationReference, year: number, reportingTerm: ReportingTerm): Promise<void> {
        console.log('----------Create_Plan----------');
        console.log(organizationReference);
        console.log(year);
        console.log(reportingTerm);
        console.log(fetchPostWithAccessToken);
        console.log('----------Create_Plan----------');
        return fetchPostWithAccessToken(`${this.unitPlanReportServiceUrl}/plan/create?year=${year}&reportingTerm=${reportingTerm}`,
            JSON.stringify(organizationReference));
    }

    createPlan2(organizationReference: OrganizationReference, year: number, reportingTerm: ReportingTerm, reportingFrequency: ReportingFrequency): Promise<void> {
        console.log('----------Create_Plan_2----------');
        console.log(organizationReference);
        console.log(JSON.stringify(organizationReference));
        console.log(year);
        console.log(reportingTerm);
        console.log(reportingFrequency);
        console.log(fetchPostWithAccessToken);
        console.log('----------Create_Plan_2----------');
        return fetchPostWithAccessToken(`${this.unitPlanReportServiceUrl}/plan/create2?year=${year}&reportingTerm=${reportingTerm}&reportingFrequency=${reportingFrequency}`,
            JSON.stringify(organizationReference));
    }

    copy(copyFrom: number, organization: OrganizationReference, year: number, reportingTerm: ReportingTerm, reportingFrequency: ReportingFrequency): Promise<void> {
        console.log('----------copy----------');
        console.log(copyFrom);
        console.log(organization);
        console.log(year);
        console.log(reportingTerm);
        console.log(reportingFrequency);
        console.log(fetchPostWithAccessToken);
        console.log('----------copy----------');
        return fetchPostWithAccessToken(`${this.unitPlanReportServiceUrl}/plan/copy?year=${year}&reportingTerm=${reportingTerm}&reportingFrequency=${reportingFrequency}&copyFromReportId=${copyFrom}`,
            JSON.stringify(organization));
    }

    getPlan(planId: number): Promise<UnitPlanViewModelDto> {
        console.log('----------getPlan----------');
        console.log(planId);
        console.log(fetchWithAccessToken);
        console.log('----------getPlan----------');
        return fetchWithAccessToken(`${this.unitPlanReportServiceUrl}/plan/${planId}`);
    }

    updatePlan(organizationId: number, planId: number, planData: PlanData): Promise<void> {
        console.log('----------updatePlan----------');
        console.log(organizationId);
        console.log(planId);
        console.log(planData);
        console.log(fetchPostWithAccessToken);
        console.log('----------updatePlan----------');
        return fetchPostWithAccessToken(`${this.unitPlanReportServiceUrl}/plan/update?organizationId=${organizationId}&planId=${planId}`,
            JSON.stringify(planData));
    }

    submitPlan(organizationId: number, planId: number): Promise<void> {
        console.log('----------submitPlan----------');
        console.log(organizationId);
        console.log(planId);
        console.log(fetchPostWithAccessToken);
        console.log('----------submitPlan----------');
        return fetchPostWithAccessToken(`${this.unitPlanReportServiceUrl}/plan/submit?planId=${planId}&organizationId=${organizationId}`);
    }

    getReport(reportId: number): Promise<UnitReportViewModelDto> {
        console.log('----------getReport----------');
        console.log(reportId);
        console.log(fetchWithAccessToken);
        console.log('----------getReport----------');
        return fetchWithAccessToken(`${this.unitPlanReportServiceUrl}/report/${reportId}`);
    }

    updateReport(organizationId: number, reportId: number, reportData: ReportUpdateData): Promise<void> {
        console.log('----------updateReport----------');
        console.log(organizationId);
        console.log(reportId);
        console.log(reportData);
        console.log(fetchPostWithAccessToken);
        console.log('----------updateReport----------');
         return fetchPostWithAccessToken(`${this.unitPlanReportServiceUrl}/report/update?organizationId=${organizationId}&reportId=${reportId}`,
         JSON.stringify(reportData));
    }

    updateReportLastPeriod(organizationId: number, reportId: number, reportLastPeriodUpdateData: ReportLastPeriodUpdateData): Promise<void> {
        console.log('----------updateReportLastPeriod----------');
        console.log(organizationId);
        console.log(reportId);
        console.log(reportLastPeriodUpdateData);
        console.log(fetchPostWithAccessToken);
        console.log('----------updateReportLastPeriod----------');
        return fetchPostWithAccessToken(`${this.unitPlanReportServiceUrl}/report/updateLastPeriod?organizationId=${organizationId}&reportId=${reportId}`,
        JSON.stringify(reportLastPeriodUpdateData));
   }

    submitReport(organizationId: number, reportId: number): Promise<void> {
        console.log('----------submitReport----------');
        console.log(organizationId);
        console.log(reportId);
        console.log(fetchPostWithAccessToken);
        console.log('----------submitReport----------');
        return fetchPostWithAccessToken(`${this.unitPlanReportServiceUrl}/report/submit?reportId=${reportId}&organizationId=${organizationId}`);
    }

    unsubmitReport(organizationId: number, reportId: number): Promise<void> {
        console.log('----------unsubmitReport----------');
        console.log(organizationId);
        console.log(reportId);
        console.log(fetchPostWithAccessToken);
        console.log('----------unsubmitReport----------');
        return fetchPostWithAccessToken(`${this.unitPlanReportServiceUrl}/report/unsubmit?reportId=${reportId}&organizationId=${organizationId}`);
    }

    downloadReport(reportId: number, excelReportType: ExcelReportType): Promise<Blob> {
        console.log('----------downloadReport----------');
        console.log(reportId);
        console.log(excelReportType);
        console.log(fetchFileWithAccessToken);
        console.log('----------downloadReport----------');
        return fetchFileWithAccessToken(`${this.unitPlanReportServiceUrl}/download/report/${reportId}?excelReportType=${excelReportType}`);
    }

    delete(organizationId: number, reportId: number): Promise<void> {
        console.log('----------delete----------');
        console.log(organizationId);
        console.log(reportId);
        console.log(fetchPostWithAccessToken);
        console.log('----------delete----------');
        return fetchPostWithAccessToken(`${this.unitPlanReportServiceUrl}/report/delete?reportId=${reportId}&organizationId=${organizationId}`);
    }
}
