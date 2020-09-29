import { DecimalValueConverter } from "./DecimalValueConverter";

describe("DecimalValueConverter tests", () => {
    it("1.2 is valid", () => {
        const sut = new DecimalValueConverter();
        
        const result = sut.fromView("1.2");

        expect(result).toBe(1.2);
    });

    it("1. is invalid", () => {
        const sut = new DecimalValueConverter();
        
        const result = sut.fromView("1.");

        expect(result).toBe(1);
    });
});