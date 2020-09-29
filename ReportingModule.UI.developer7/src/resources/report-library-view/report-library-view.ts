import { bindable, bindingMode, containerless } from "aurelia-framework";
import { LibraryStockData } from "models/LibraryStockData";

@containerless
export class ReportLibraryView {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bookLibraryStockData: LibraryStockData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bookLibraryStockGeneratedData: LibraryStockData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) vhsLibraryStockData: LibraryStockData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) vhsLibraryStockGeneratedData: LibraryStockData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherLibraryStockData: LibraryStockData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherLibraryStockGeneratedData: LibraryStockData;
}