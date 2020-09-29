import * as moment from "moment";
import { ReportingPeriod } from "models/ReportingPeriod";

export class ReportingPeriodValueConverter {
    toView(reportingPeriod: ReportingPeriod) {
        const start = moment(reportingPeriod.startDate);
        const end = moment(reportingPeriod.endDate);
        return `Reporting Period: ${start.format("MMMM")}, ${start.format("YYYY")} - ${end.format("MMMM")}, ${end.format("YYYY")}`;
    }
}