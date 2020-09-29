import { bindable, bindingMode } from "aurelia-framework";
import { SocialWelfarePlanData } from "models/SocialWelfarePlanData";

export class PlanSocialwelfareEdit {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) qardeHasanaSocialWelfarePlanData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) qardeHasanaSocialWelfarePlanGeneratedData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) patientVisitSocialWelfarePlanData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) patientVisitSocialWelfarePlanGeneratedData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) socialVisitSocialWelfarePlanData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) socialVisitSocialWelfarePlanGeneratedData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) transportSocialWelfarePlanData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) transportSocialWelfarePlanGeneratedData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) shiftingSocialWelfarePlanData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) shiftingSocialWelfarePlanGeneratedData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) shoppingSocialWelfarePlanData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) shoppingSocialWelfarePlanGeneratedData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) foodDistributionSocialWelfarePlanData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) foodDistributionSocialWelfarePlanGeneratedData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) cleanUpAustraliaSocialWelfarePlanData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) cleanUpAustraliaSocialWelfarePlanGeneratedData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherSocialWelfarePlanData: SocialWelfarePlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherSocialWelfarePlanGeneratedData: SocialWelfarePlanData;

}