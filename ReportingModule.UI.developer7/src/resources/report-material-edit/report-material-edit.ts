import { bindable, bindingMode, containerless } from "aurelia-framework";
import { MaterialData } from "models/MaterialData";

@containerless
export class ReportMaterialEdit {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bookSaleMaterialData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bookSaleMaterialGeneratedData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bookDistributionMaterialData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bookDistributionMaterialGeneratedData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) vhsSaleMaterialData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) vhsSaleMaterialGeneratedData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) vhsDistributionMaterialData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) vhsDistributionMaterialGeneratedData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) emailDistributionMaterialData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) emailDistributionMaterialGeneratedData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) ipdcLeafletDistributionMaterialData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) ipdcLeafletDistributionMaterialGeneratedData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherSaleMaterialData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherSaleMaterialGeneratedData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherDistributionMaterialData: MaterialData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherDistributionMaterialGeneratedData: MaterialData;
}