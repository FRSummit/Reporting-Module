import { bindable, bindingMode } from "aurelia-framework";
import { SocialWelfareData } from "models/SocialWelfareData";

export class ReportSocialwelfareEdit {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) qardeHasanaSocialWelfareData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) qardeHasanaSocialWelfareGeneratedData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) patientVisitSocialWelfareData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) patientVisitSocialWelfareGeneratedData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) socialVisitSocialWelfareData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) socialVisitSocialWelfareGeneratedData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) transportSocialWelfareData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) transportSocialWelfareGeneratedData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) shiftingSocialWelfareData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) shiftingSocialWelfareGeneratedData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) shoppingSocialWelfareData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) shoppingSocialWelfareGeneratedData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) foodDistributionSocialWelfareData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) foodDistributionSocialWelfareGeneratedData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) cleanUpAustraliaSocialWelfareData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) cleanUpAustraliaSocialWelfareGeneratedData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherSocialWelfareData: SocialWelfareData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherSocialWelfareGeneratedData: SocialWelfareData;


}