import { containerless, bindable, bindingMode } from "aurelia-framework";

@containerless
export class InputNumberCustomElement {
    @bindable({ defaultBindingMode: bindingMode.twoWay }) inputNumber: number;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) generated: number;

    get hasGenerated() {
        if (this.generated === null || this.generated === undefined) return false;
        return true;
    }
}