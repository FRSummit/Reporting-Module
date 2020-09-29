import { bindable, bindingMode, containerless } from "aurelia-framework";
import { LibraryStockData } from "models/LibraryStockData";

type props = {
    increased: number,
    decreased: number
};

@containerless
export class LibraryThisPeriod {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) libraryStockData: LibraryStockData;
    initialData: props;

    getProps(dto: LibraryStockData) {
        const propsData: props = {
            increased: dto.increased,
            decreased: dto.decreased
        };
        return propsData;
    }

    libraryStockDataChanged(newValue: LibraryStockData, oldValue: LibraryStockData) {
        this.initialData = this.getProps(newValue);
    }

    get isDirty() {
        const latestData: props = this.getProps(this.libraryStockData);
        return JSON.stringify(this.initialData) !== JSON.stringify(latestData) && this.libraryStockData.thisPeriod != this.newThisPeriod;
    }
    
    get newThisPeriod() {
        const newValue = this.libraryStockData.lastPeriod + this.libraryStockData.increased - this.libraryStockData.decreased;
        return newValue < 0 ? 0 : newValue;
    }
}