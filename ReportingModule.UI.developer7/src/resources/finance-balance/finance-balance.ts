import { bindable, bindingMode, containerless } from "aurelia-framework";
import { Money } from "models/Money";
import { FinanceData } from "models/FinanceData";
import { Currency } from "models/Currency";

type props = {
    collection: number,
    expense: number,
    nisabPaidToCentral: number
};

@containerless
export class FinanceBalance {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) financeData: FinanceData;
    initialData: props;

    getProps(dto: FinanceData) {
        const propsData: props = {
            collection: dto.collection.amount,
            expense: dto.expense.amount,
            nisabPaidToCentral: dto.nisabPaidToCentral.amount
        };
        return propsData;
    }
    
    financeDataChanged(newValue: FinanceData, oldValue: FinanceData) {
        this.initialData = this.getProps(newValue);
    }

    get isDirty() {
        const latestData: props = this.getProps(this.financeData);
        return JSON.stringify(this.initialData) !== JSON.stringify(latestData) && this.financeData.balance.amount != this.newBalance.amount;
    }
    
    zeroBalance = new Money(0, Currency.AUD);
    
    get newBalance() {
        const newValue = this.financeData.lastPeriod.amount + this.financeData.collection.amount - this.financeData.expense.amount - this.financeData.nisabPaidToCentral.amount;
        return new Money(newValue, Currency.AUD);
    }
}