import { ReportStatus } from "models/ReportStatus";

export class ReportPlanStatusValueConverter {
    statusNames = [
        { id: ReportStatus.Draft, name: "Plan Not Submitted"},
        { id: ReportStatus.PlanPromoted, name: "Plan Submitted, Report Not Submitted"},
        { id: ReportStatus.Submitted, name: "Plan Submitted, Report Submitted"}
    ];

    toView(value: ReportStatus) {
        return this.statusNames.find(o => o.id === value).name;
    }
}
