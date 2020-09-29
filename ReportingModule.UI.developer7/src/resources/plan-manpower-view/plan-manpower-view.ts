import { bindable, bindingMode, containerless } from "aurelia-framework";
import { MemberPlanData } from "models/MemberPlanData";

@containerless
export class PlanManpowerView {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) associateMemberPlanData: MemberPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) associateMemberPlanGeneratedData: MemberPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) preliminaryMemberPlanData: MemberPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) preliminaryMemberPlanGeneratedData: MemberPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) supporterMemberPlanData: MemberPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) supporterMemberPlanGeneratedData: MemberPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memberMemberPlanData: MemberPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memberMemberPlanGeneratedData: MemberPlanData;
}