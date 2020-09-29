import { bindable, bindingMode, containerless } from "aurelia-framework";
import { ReportingPeriodViewModel } from "models/ReportingPeriodViewModel";

@containerless
export class ReportingPeriodSelectorCustomElement {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) reportingPeriods: ReportingPeriodViewModel[];
    @bindable({ defaultBindingMode: bindingMode.twoWay }) selectedReportingPeriod: ReportingPeriodViewModel;

    reportingPeriodsChanged(newReportingPeriods: ReportingPeriodViewModel[]) {
        this.selectedReportingPeriod = undefined;
        if((newReportingPeriods || []).length === 0) return;
        const activePeriods = newReportingPeriods.filter(o => o.isActive).sort(this.sortReportingPeriodViewModel);
        if(activePeriods.length === 0) return;
        this.selectedReportingPeriod = activePeriods[0];
    }

    get sortedReportingPeriods () {
        return this.reportingPeriods.sort(this.sortReportingPeriodViewModel);
    }

    private sortReportingPeriodViewModel(a: ReportingPeriodViewModel, b: ReportingPeriodViewModel): number {
        if (a.year < b.year)
            return -1;
        if (a.year > b.year)
            return 1;
        if (a.reportingFrequency < b.reportingFrequency)
            return -1;
        if (a.reportingFrequency > b.reportingFrequency)
            return 1;
        if (a.reportingTerm < b.reportingTerm)
            return -1;
        if (a.reportingTerm > b.reportingTerm)
            return 1;
        return 0;
    }
}