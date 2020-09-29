namespace ReportingModule.ValueObjects
{
    public class ReportLastPeriodUpdateData
    {
        public ReportLastPeriodUpdateData(MemberReportData memberMemberReportData = null,
            MemberReportData associateMemberReportData = null,
            MemberReportData preliminaryMemberReportData = null,
            MemberReportData supporterMemberReportData = null,

            FinanceReportData baitulMalFinanceReportData = null,
            FinanceReportData aDayMasjidProjectFinanceReportData = null,
            FinanceReportData masjidTableBankFinanceReportData = null,

            LibraryStockReportData bookLibraryStockReportData = null,
            LibraryStockReportData vhsLibraryStockReportData = null,
            LibraryStockReportData otherLibraryStockReportData = null
            )
        {
            AssociateMemberReportData = associateMemberReportData ?? MemberData.Default();
            PreliminaryMemberReportData = preliminaryMemberReportData ?? MemberData.Default();
            SupporterMemberReportData = supporterMemberReportData ?? MemberData.Default();
            MemberMemberReportData = memberMemberReportData ?? MemberData.Default();

            BaitulMalFinanceReportData = baitulMalFinanceReportData ?? FinanceData.Default();
            ADayMasjidProjectFinanceReportData = aDayMasjidProjectFinanceReportData ?? FinanceData.Default();
            MasjidTableBankFinanceReportData = masjidTableBankFinanceReportData ?? FinanceData.Default();

            BookLibraryStockReportData = bookLibraryStockReportData ?? LibraryStockData.Default();
            VhsLibraryStockReportData = vhsLibraryStockReportData ?? LibraryStockData.Default();
            OtherLibraryStockReportData = otherLibraryStockReportData ?? LibraryStockData.Default();
        }
        public MemberReportData AssociateMemberReportData { get; private set; }
        public MemberReportData PreliminaryMemberReportData { get; private set; }
        public MemberReportData SupporterMemberReportData { get; private set; }
        public MemberReportData MemberMemberReportData { get; private set; }

        public FinanceReportData BaitulMalFinanceReportData { get; private set; }
        public FinanceReportData ADayMasjidProjectFinanceReportData { get; private set; }
        public FinanceReportData MasjidTableBankFinanceReportData { get; private set; }

        public LibraryStockReportData BookLibraryStockReportData { get; private set; }
        public LibraryStockReportData VhsLibraryStockReportData { get; private set; }
        public LibraryStockReportData OtherLibraryStockReportData { get; private set; }

    }
}