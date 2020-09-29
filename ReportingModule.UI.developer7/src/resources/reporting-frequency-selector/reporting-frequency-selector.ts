import { containerless, bindable, bindingMode } from "aurelia-framework";
import { ReportingFrequency } from "models/ReportingFrequency";

@containerless
export class ReportingFrequencySelectorCustomElement{
    reportingFrequencyOptions = [
        { id: ReportingFrequency.Monthly, description: "Monthly"},
        { id: ReportingFrequency.EveryTwoMonth, description: "EveryTwoMonth"},
        { id: ReportingFrequency.Quarterly, description: "Quarterly"},
        { id: ReportingFrequency.EveryFourMonth, description: "EveryFourMonth"},
        { id: ReportingFrequency.HalfYearly, description: "HalfYearly"},
        { id: ReportingFrequency.Yearly, description: "Yearly"}
    ];

    @bindable({ defaultBindingMode: bindingMode.twoWay }) excludeChooseOption: boolean;

    @bindable({ defaultBindingMode: bindingMode.twoWay }) selectedFrequency: ReportingFrequency;
}
