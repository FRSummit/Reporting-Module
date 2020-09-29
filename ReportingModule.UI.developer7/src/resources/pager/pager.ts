import { bindable, computedFrom, containerless, bindingMode } from "aurelia-framework";
import { PagingData } from "models/PagingData";

@containerless
export class Pager {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) pagingdata: PagingData;
    @bindable loadpage: (pageNumber: number) => Promise<any>;

    @computedFrom('pagingData')
    get pages(){
        return Math.floor(this.pagingdata.totalRecords / this.pagingdata.pageSize) + (this.pagingdata.totalRecords % this.pagingdata.pageSize > 0 ? 1 : 0);
    }

    get displaypages(){
        let first = this.pagingdata.page - 5 < 1 ? 1 : this.pagingdata.page - 5;
        const last = first + 9 > this.pages ? this.pages : first + 9;
        first = last - 9 < first && last - 9 > 0 ? last - 9 : first;
        const ps = [];
        let curr = first;
        do {
            ps.push(curr);
            curr = curr + 1;
        } while (curr <= last)
        return ps;
    }

    async load(pageNumber: number) {
        if(this.loadpage) {
            await this.loadpage(pageNumber);
        }
    }
}