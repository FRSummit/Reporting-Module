import { Money } from "models/Money";
import { Currency } from "models/Currency";

export class MoneyValueConverter {
    toView(value: Money) {
        if(!value) return;
        //return `${Currency[value.currency]} ${value.amount}`;
        return "$ "+ `${value.amount}`;
    }
}