import { bindable, bindingMode, containerless } from "aurelia-framework";
import { Money } from "models/Money";
import { Currency } from "models/Currency";

@containerless
export class MoneySelectorCustomElement {
    currencyOptions = Object.keys(Currency)
                        .filter(c => typeof Currency[c] === "number")
                        .map(c => {
                            return { 
                                id: Currency[c],
                                description: c
                            };
                        })
                        .sort((a, b) => {
                            if(a.description < b.description) return -1;
                            if(a.description > b.description)return 1;
                            return 0;
                        });

    @bindable({ defaultBindingMode: bindingMode.twoWay }) money: Money;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) generated: Money;
}