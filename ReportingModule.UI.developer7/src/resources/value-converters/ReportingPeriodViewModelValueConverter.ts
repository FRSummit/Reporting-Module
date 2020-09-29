import * as moment from "moment";
import { ReportingPeriodViewModel } from "models/ReportingPeriodViewModel";
import { ReportingTermValueConverter } from "./ReportingTermValueConverter";

export class ReportingPeriodViewModelValueConverter {
    toView(reportingPeriod: ReportingPeriodViewModel) {
        const start = moment(reportingPeriod.startDate);
        const end = moment(reportingPeriod.endDate);
        return `${start.format("MMM")} ${start.format("YYYY")} to ${end.format("MMM")} ${end.format("YYYY")}${reportingPeriod.isActive ? ' (Active)' : ''}`;
    }
}