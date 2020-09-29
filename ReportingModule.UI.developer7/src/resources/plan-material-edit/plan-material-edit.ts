import { bindable, bindingMode, containerless } from "aurelia-framework";
import { MaterialPlanData } from "models/MaterialPlanData";

@containerless
export class PlanMaterialEdit {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bookSaleMaterialPlanData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bookSaleMaterialPlanGeneratedData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bookDistributionMaterialPlanData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bookDistributionMaterialPlanGeneratedData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) vhsSaleMaterialPlanData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) vhsSaleMaterialPlanGeneratedData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) vhsDistributionMaterialPlanData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) vhsDistributionMaterialPlanGeneratedData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) emailDistributionMaterialPlanData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) emailDistributionMaterialPlanGeneratedData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) ipdcLeafletDistributionMaterialPlanData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) ipdcLeafletDistributionMaterialPlanGeneratedData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherSaleMaterialPlanData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherSaleMaterialPlanGeneratedData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherDistributionMaterialPlanData: MaterialPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherDistributionMaterialPlanGeneratedData: MaterialPlanData;
}