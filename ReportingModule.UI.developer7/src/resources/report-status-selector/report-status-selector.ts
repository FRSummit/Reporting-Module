import { containerless, bindable, bindingMode } from "aurelia-framework";
import { ReportingTerm } from "models/ReportingTerm";
import { ReportStatus } from "models/ReportStatus";

@containerless
export class ReportStatusSelectorCustomElement{
    statusOptions = [
        { id: ReportStatus.Draft, name: "Plan Not Submitted"},
        { id: ReportStatus.PlanPromoted, name: "Plan Submitted, Report Not Submitted"},
        { id: ReportStatus.Submitted, name: "Plan Submitted, Report Submitted"}
    ];

    @bindable({ defaultBindingMode: bindingMode.twoWay }) selectedStatus: ReportStatus;
}