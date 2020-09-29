import { ReportingFrequency } from "models/ReportingFrequency";
export class ReportingFrequencyValueConverter {
    toView(value: ReportingFrequency) {
        return ReportingFrequency[value];
    }
}
