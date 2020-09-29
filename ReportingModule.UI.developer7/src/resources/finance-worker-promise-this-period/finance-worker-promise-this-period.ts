import { bindable, bindingMode, containerless } from "aurelia-framework";
import { Money } from "models/Money";
import { FinanceData } from "models/FinanceData";
import { Currency } from "models/Currency";

type props = {
    workerPromiseIncreaseTarget: number,
    workerPromiseIncreased: number,
    workerPromiseDecreased: number
};

@containerless
export class FinanceWorkerPromiseThisPeriod {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) financeData: FinanceData;
    initialData: props;

    getProps(dto: FinanceData) {
        const propsData: props = {
            workerPromiseIncreaseTarget: dto.workerPromiseIncreaseTarget.amount,
            workerPromiseIncreased: dto.workerPromiseIncreased.amount,
            workerPromiseDecreased: dto.workerPromiseDecreased.amount
        };
        return propsData;
    }
    financeDataChanged(newValue: FinanceData, oldValue: FinanceData) {
        this.initialData = this.getProps(newValue);
    }

    get isDirty() {
        const latestData: props = this.getProps(this.financeData);
        return JSON.stringify(this.initialData) !== JSON.stringify(latestData) && this.financeData.workerPromiseThisPeriod.amount != this.newThisPeriod.amount;
    }
    
    zeroThisPeriod = new Money(0, Currency.AUD);
    
    get newThisPeriod() {
        const newValue = this.financeData.workerPromiseLastPeriod.amount + this.financeData.workerPromiseIncreased.amount - this.financeData.workerPromiseDecreased.amount;
        return newValue < 0 ? this.zeroThisPeriod : new Money(newValue, Currency.AUD);
    }
}