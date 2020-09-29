import { autoinject } from "aurelia-framework";
import { ReportStatus } from "models/ReportStatus";
import { AuthService } from "auth-service";
@autoinject
export class CanViewReportValueConverter {
    constructor(public authService: AuthService) { }
    toView(reportStatus: ReportStatus) {
        return reportStatus > ReportStatus.Draft;
    }
}
