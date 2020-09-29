import { autoinject } from "aurelia-framework";
import { DialogController } from "aurelia-dialog";
import { YesNo } from "./YesNo";

@autoinject
export class YesNoDialog {
    vm: YesNo;
    constructor(public controller: DialogController) {
    }

    activate(vm: YesNo) {
        this.vm = vm;
    }
}