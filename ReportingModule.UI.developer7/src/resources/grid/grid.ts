import { SearchResult } from "models/SearchResult";
import { PagedSearchTerms } from "models/PagedSearchTerms";

export class Grid<T, U> {
    isSearching = false;
    items: U[] = [];
    searchResult: SearchResult<T>;
    nodatafound = false;
    constructor(
        public searchTerms: PagedSearchTerms,
        public searchFunc: (p: PagedSearchTerms) => Promise<SearchResult<T>>,
        public mapFunc: (t: T) => U){}

    search = async (loadPage?: number) => {
        this.isSearching = true;
        this.searchTerms.page = loadPage || this.searchTerms.page;
        this.searchResult = await this.searchFunc(this.searchTerms);
        this.nodatafound = this.searchResult.items.length == 0;
        this.items.splice(0, this.items.length);
        this.searchResult.items.forEach(o => this.items.push(this.mapFunc(o)));
        this.isSearching = false;
    }
}