import { ReportingTermSelectorCustomElement } from "./reporting-term-selector";
import { ReportingFrequency } from "models/ReportingFrequency";
import { ReportingTerm } from "models/ReportingTerm";

describe("ReportingTermSelector tests", () => {
     it("Yearly Frequency", () => {
        const sut = new ReportingTermSelectorCustomElement();
        sut.reportingFrequency = ReportingFrequency.Yearly;

        expect(sut.getReportingTerms()).toEqual([ReportingTerm.Q1]);
     });

     it("HalfYearly Frequency", () => {
        const sut = new ReportingTermSelectorCustomElement();
        sut.reportingFrequency = ReportingFrequency.HalfYearly;

        expect(sut.getReportingTerms()).toEqual([ReportingTerm.Q1, ReportingTerm.Q2]);
     });

     it("EveryFourMonth Frequency", () => {
        const sut = new ReportingTermSelectorCustomElement();
        sut.reportingFrequency = ReportingFrequency.EveryFourMonth;

        expect(sut.getReportingTerms()).toEqual([ReportingTerm.Q1, ReportingTerm.Q2, ReportingTerm.Q3]);
     });

     it("Quarterly Frequency", () => {
        const sut = new ReportingTermSelectorCustomElement();
        sut.reportingFrequency = ReportingFrequency.Quarterly;

        expect(sut.getReportingTerms()).toEqual([ReportingTerm.Q1, ReportingTerm.Q2, ReportingTerm.Q3, ReportingTerm.Q4]);
     });

     it("EveryTwoMonth Frequency", () => {
        const sut = new ReportingTermSelectorCustomElement();
        sut.reportingFrequency = ReportingFrequency.EveryTwoMonth;

        expect(sut.getReportingTerms()).toEqual([ReportingTerm.Q1, ReportingTerm.Q2, ReportingTerm.Q3, ReportingTerm.Q4, ReportingTerm.Q5, ReportingTerm.Q6]);
     });

     it("Monthly Frequency", () => {
        const sut = new ReportingTermSelectorCustomElement();
        sut.reportingFrequency = ReportingFrequency.Monthly;

        expect(sut.getReportingTerms()).toEqual([ReportingTerm.Q1, ReportingTerm.Q2, ReportingTerm.Q3, ReportingTerm.Q4, ReportingTerm.Q5, ReportingTerm.Q6,
            ReportingTerm.Q7, ReportingTerm.Q8, ReportingTerm.Q9, ReportingTerm.Q10, ReportingTerm.Q11, ReportingTerm.Q12]);
     });

});