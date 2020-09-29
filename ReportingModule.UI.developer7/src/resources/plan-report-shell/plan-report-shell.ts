import { containerless, autoinject, bindable, bindingMode } from "aurelia-framework";
import { AppRouter } from "aurelia-router";
import { OrganizationType } from "models/OrganizationType";
import { ReportStatus } from "models/ReportStatus";
import { AuthService } from "auth-service";

@containerless
@autoinject
export class PlanReportShell {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) organizationType: OrganizationType;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) itemId: number;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) reportStatus: ReportStatus;

    constructor(public appRouter: AppRouter, public auth: AuthService) {}

    isActive(routehref: string) {
        const route = this.appRouter.routes.find(r => r.href === routehref);
        const result= route
            ? route.navModel.isActive
            : false;
        return result;
    }

    get canEditLastPeriod() {
        return this.auth.isSystemAdmin;
    }

    get canCopy() {
        return this.auth.isSystemAdmin || this.reportStatus === ReportStatus.Submitted;
    }
}