import { containerless, bindable, bindingMode } from "aurelia-framework";
import { FinancePlanData } from "models/FinancePlanData";

@containerless
export class PlanFinanceEdit {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) baitulMalFinancePlanData: FinancePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) baitulMalFinancePlanGeneratedData: FinancePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) aDayMasjidProjectFinancePlanData: FinancePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) aDayMasjidProjectFinancePlanGeneratedData: FinancePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) masjidTableBankFinancePlanData: FinancePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) masjidTableBankFinancePlanGeneratedData: FinancePlanData;
}