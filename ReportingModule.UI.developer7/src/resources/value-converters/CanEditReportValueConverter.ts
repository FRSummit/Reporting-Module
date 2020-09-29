import { autoinject } from "aurelia-framework";
import { ReportStatus } from "models/ReportStatus";
import { AuthService } from "auth-service";
@autoinject
export class CanEditReportValueConverter {
    constructor(public authService: AuthService) { }
    toView(reportStatus: ReportStatus) {
        return (this.authService.isSystemAdmin && reportStatus === ReportStatus.Submitted) ||
            reportStatus === ReportStatus.PlanPromoted;
    }
}
