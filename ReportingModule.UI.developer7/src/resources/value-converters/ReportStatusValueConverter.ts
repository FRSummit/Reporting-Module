import { ReportStatus } from "models/ReportStatus";

export class ReportStatusValueConverter {
    statusNames = [
        { id: ReportStatus.Draft, name: "Plan"},
        { id: ReportStatus.PlanPromoted, name: "Report"},
        { id: ReportStatus.Submitted, name: "Report"} //Old Value: Submitted
    ];

    toView(value: ReportStatus) {
        return this.statusNames.find(o => o.id === value).name;
    }
}
