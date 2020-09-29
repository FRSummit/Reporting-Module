import { Pager } from "./pager";
import { PagingData } from "models/PagingData";

describe("pager tests", () => {
    describe("when 10 pages", () => {
        it("page 1", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(1, 10, 100);
    
            expect(sut.pages).toBe(10);
            expect(sut.displaypages).toEqual(Array.from({length: 10}, (v,i) => 1+i));
        });
    
        it("page 6", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(6, 10, 100);
    
            expect(sut.pages).toBe(10);
            expect(sut.displaypages).toEqual(Array.from({length: 10}, (v,i) => 1+i));
        });
        it("page 10", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(10, 10, 100);
    
            expect(sut.pages).toBe(10);
            expect(sut.displaypages).toEqual(Array.from({length: 10}, (v,i) => 1+i));
        });    
    });

    describe("when 6 pages", () => {
        it("page 1", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(1, 10, 56);
    
            expect(sut.pages).toBe(6);
            expect(sut.displaypages).toEqual(Array.from({length: 6}, (v,i) => 1+i));
        });

        it("page 3", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(3, 10, 56);
    
            expect(sut.pages).toBe(6);
            expect(sut.displaypages).toEqual(Array.from({length: 6}, (v,i) => 1+i));
        });

        it("page 6", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(6, 10, 56);
    
            expect(sut.pages).toBe(6);
            expect(sut.displaypages).toEqual(Array.from({length: 6}, (v,i) => 1+i));
        });
    });

    describe("when 1 pages", () => {
        it("page 1", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(1, 10, 10);
    
            expect(sut.pages).toBe(1);
            expect(sut.displaypages).toEqual(Array.from({length: 1}, (v,i) => 1+i));
        });
    });

    describe("when 12 pages", () => {
        it("page 1", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(1, 10, 116);
    
            expect(sut.pages).toBe(12);
            expect(sut.displaypages).toEqual(Array.from({length: 10}, (v,i) => 1+i));
        });

        it("page 5", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(5, 10, 116);
    
            expect(sut.pages).toBe(12);
            expect(sut.displaypages).toEqual(Array.from({length: 10}, (v,i) => 1+i));
        });

        it("page 7", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(7, 10, 116);
    
            expect(sut.pages).toBe(12);
            expect(sut.displaypages).toEqual([2,3,4,5,6,7,8,9,10,11]);
        });

        it("page 8", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(8, 10, 116);
    
            expect(sut.pages).toBe(12);
            expect(sut.displaypages).toEqual([3,4,5,6,7,8,9,10,11, 12]);
        });

        it("page 9", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(9, 10, 116);
    
            expect(sut.pages).toBe(12);
            expect(sut.displaypages).toEqual([3,4,5,6,7,8,9,10,11, 12]);
        });

        it("page 12", () => {
            const sut = new Pager();
            sut.pagingdata = new PagingData(12, 10, 116);
    
            expect(sut.pages).toBe(12);
            expect(sut.displaypages).toEqual([3,4,5,6,7,8,9,10,11, 12]);
        });
    });
});