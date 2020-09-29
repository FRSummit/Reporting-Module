import { MemberReportData } from "./MemberReportData";
import { FinanceReportData } from "./FinanceReportData";
import { LibraryStockReportData } from "./LibraryStockReportData";
export class ReportLastPeriodUpdateData {
    constructor(public memberMemberReportData: MemberReportData, 
        public associateMemberReportData: MemberReportData, 
        public preliminaryMemberReportData: MemberReportData, 
        public supporterMemberReportData: MemberReportData, 
        public baitulMalFinanceReportData: FinanceReportData, 
        public aDayMasjidProjectFinanceReportData: FinanceReportData, 
        public masjidTableBankFinanceReportData: FinanceReportData, 
        public bookLibraryStockReportData: LibraryStockReportData, 
        public vhsLibraryStockReportData: LibraryStockReportData, 
        public otherLibraryStockReportData: LibraryStockReportData) 
    { }
}
