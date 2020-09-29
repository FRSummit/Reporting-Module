import { containerless, bindable, bindingMode } from "aurelia-framework";
import { ReportingFrequency } from "models/ReportingFrequency";
import { ReportingTerm } from "models/ReportingTerm";

type selectableReportingTerm = {
    id: ReportingTerm,
    description: string
};

@containerless
export class ReportingTermSelectorCustomElement {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) reportingFrequency: ReportingFrequency; 
    @bindable({ defaultBindingMode: bindingMode.twoWay }) selectedReportingTerm: ReportingTerm;
    get reportingTerms(): selectableReportingTerm[] {
        const terms = this.getReportingTerms();
        const arr: selectableReportingTerm[] = [];
        
        terms && terms.forEach(t => {
            arr.push({
                id: t,
                description: ReportingTerm[t]
            });
        });
        return arr;
    }

    getReportingTerms() {
        switch(this.reportingFrequency){
            case ReportingFrequency.Yearly : return [ReportingTerm.Q1];
            case ReportingFrequency.HalfYearly: return [
                ReportingTerm.Q1,
                ReportingTerm.Q2
            ];
            case ReportingFrequency.EveryFourMonth: return [
                ReportingTerm.Q1,
                ReportingTerm.Q2,
                ReportingTerm.Q3
            ];            
            case ReportingFrequency.Quarterly : return [
                ReportingTerm.Q1,
                ReportingTerm.Q2,
                ReportingTerm.Q3,
                ReportingTerm.Q4
            ];
            case ReportingFrequency.EveryTwoMonth: return [
                ReportingTerm.Q1,
                ReportingTerm.Q2,
                ReportingTerm.Q3,
                ReportingTerm.Q4,
                ReportingTerm.Q5,
                ReportingTerm.Q6
            ];
            case ReportingFrequency.Monthly: return [
                ReportingTerm.Q1,
                ReportingTerm.Q2,
                ReportingTerm.Q3,
                ReportingTerm.Q4,
                ReportingTerm.Q5,
                ReportingTerm.Q6,
                ReportingTerm.Q7,
                ReportingTerm.Q8,
                ReportingTerm.Q9,
                ReportingTerm.Q10,
                ReportingTerm.Q11,
                ReportingTerm.Q12
            ];
        }
    }
}