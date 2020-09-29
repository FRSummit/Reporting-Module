import { bindable, bindingMode, computedFrom, containerless } from "aurelia-framework";
import $ from "jquery";
import { MemberData } from "models/MemberData";

type props = {
    lastPeriod: number,
    increased: number,
    decreased: number
};

@containerless
export class MemberDataThisPeriod {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memberData: MemberData;
    initialData: props;
    stalePeriod: HTMLElement;

    attached() {
        ($(this.stalePeriod) as any).tooltip({
            title: "updated on save"
        });
    }

    getProps(dto: MemberData) {
        const propsData: props = {
            lastPeriod: dto.lastPeriod,
            increased: dto.increased,
            decreased: dto.decreased
        };
        return propsData;
    }
    memberDataChanged(newValue: MemberData, oldValue: MemberData) {
        this.initialData = this.getProps(newValue);
    }

    get isDirty() {
        const latestData: props = this.getProps(this.memberData);
        return JSON.stringify(this.initialData) !== JSON.stringify(latestData) && this.memberData.thisPeriod != this.newThisPeriod;
    }

    get newThisPeriod() {
        const newValue = this.memberData.lastPeriod + this.memberData.increased - this.memberData.decreased;
        return newValue < 0 ? 0 : newValue;
    }
}