import { bindable, bindingMode, containerless } from "aurelia-framework";
import { MemberReportData } from "models/MemberReportData";

@containerless
export class ReportManpowerEdit {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) associateMemberData: MemberReportData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) associateMemberGeneratedData: MemberReportData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) preliminaryMemberData: MemberReportData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) preliminaryMemberGeneratedData: MemberReportData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) supporterMemberData: MemberReportData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) supporterMemberGeneratedData: MemberReportData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memberMemberData: MemberReportData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memberMemberGeneratedData: MemberReportData;    
}