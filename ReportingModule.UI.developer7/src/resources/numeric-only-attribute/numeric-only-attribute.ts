import { inject } from "aurelia-framework";

@inject(Element)
export class NumericOnlyCustomAttribute {
    constructor(public element: Element) {}

    attached() {
        this.element.addEventListener("keydown", this.onKeyDown, false);
    }

    detached() {
        this.element.removeEventListener("keydown", this.onKeyDown);
    }

    static numericRegex = new RegExp(/[0-9]|Backspace|Delete|Home|End|ArrowLeft|ArrowRight|Tab/);

    onKeyDown = (e: KeyboardEvent) => {
        //console.log([e.key, NumericOnlyCustomAttribute.numericRegex.test(e.key), e]);
        if(e.cancelable && !NumericOnlyCustomAttribute.numericRegex.test(e.key)){
           e.preventDefault();
        }
    }
}
