import { containerless, bindable, bindingMode } from "aurelia-framework";
import { FinanceData } from "models/FinanceData";

@containerless
export class ReportFinanceEdit {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) baitulMalFinanceData: FinanceData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) baitulMalFinanceGeneratedData: FinanceData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) aDayMasjidProjectFinanceData: FinanceData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) aDayMasjidProjectFinanceGeneratedData: FinanceData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) masjidTableBankFinanceData: FinanceData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) masjidTableBankFinanceGeneratedData: FinanceData;
}