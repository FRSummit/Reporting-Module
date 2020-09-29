import { ReportingTerm } from "models/ReportingTerm";

export class ReportingTermValueConverter {
    toView(value: ReportingTerm) {
        return ReportingTerm[value];
    }
}