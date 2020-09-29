import { inject } from "aurelia-framework";

@inject(Element)
export class DecimalOnlyCustomAttribute {
    constructor(public element: Element) {}

    attached() {
        this.element.addEventListener("keydown", this.onKeyDown, false);
    }

    detached() {
        this.element.removeEventListener("keydown", this.onKeyDown);
    }

    static decimalRegex = new RegExp(/[0-9]|Backspace|Delete|Home|End|ArrowLeft|ArrowRight|Tab|\./);

    onKeyDown = (e: KeyboardEvent) => {
        //console.log([e.key, DecimalOnlyCustomAttribute.decimalRegex.test(e.key), e]);
        if(e.cancelable && !DecimalOnlyCustomAttribute.decimalRegex.test(e.key)){
           e.preventDefault();
        }
    }
}