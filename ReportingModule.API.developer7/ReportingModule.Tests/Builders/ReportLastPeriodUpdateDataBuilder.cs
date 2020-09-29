using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Builders
{
    public class ReportLastPeriodUpdateDataBuilder
    {
        private MemberReportData _associateMemberReportData = new TestObjectBuilder<MemberReportData>().Build();

        public ReportLastPeriodUpdateDataBuilder SetAssociateMemberReportData(MemberReportData associateMemberReportData)
        {
            _associateMemberReportData = associateMemberReportData;
            return this;
        }

        private MemberReportData _preliminaryMemberReportData = new TestObjectBuilder<MemberReportData>().Build();

        public ReportLastPeriodUpdateDataBuilder SetPreliminaryMemberReportData(MemberReportData preliminaryMemberReportData)
        {
            _preliminaryMemberReportData = preliminaryMemberReportData;
            return this;
        }

        private MemberReportData _supporterMemberReportData = new TestObjectBuilder<MemberReportData>().Build();
        public ReportLastPeriodUpdateDataBuilder SetSupporterMemberReportData(MemberReportData supporterMemberReportData)
        {
            _supporterMemberReportData = supporterMemberReportData;
            return this;
        }


        private MemberReportData _memberMemberReportData = new TestObjectBuilder<MemberReportData>().Build();

        public ReportLastPeriodUpdateDataBuilder SetMemberMemberReportData(MemberReportData memberMemberReportData)
        {
            _memberMemberReportData = memberMemberReportData;
            return this;
        }


        private FinanceReportData _baitulMalFinanceReportData = new FinanceDataBuilder().Build();
        public ReportLastPeriodUpdateDataBuilder SetBaitulMalFinanceReportData(FinanceReportData baitulMalFinanceReportData)
        {
            _baitulMalFinanceReportData = baitulMalFinanceReportData;
            return this;
        }

        private FinanceReportData _aDayMasjidProjectFinanceReportData = new FinanceDataBuilder().Build();
        public ReportLastPeriodUpdateDataBuilder SetADayMasjidProjectFinanceReportData(FinanceReportData aDayMasjidProjectFinanceReportData)
        {
            _aDayMasjidProjectFinanceReportData = aDayMasjidProjectFinanceReportData;
            return this;
        }

        private FinanceReportData _masjidTableBankFinanceReportData = new FinanceDataBuilder().Build();
        public ReportLastPeriodUpdateDataBuilder SetMasjidTableBankFinanceReportData(FinanceReportData masjidTableBankFinanceReportData)
        {
            _masjidTableBankFinanceReportData = masjidTableBankFinanceReportData;
            return this;
        }

        private LibraryStockReportData _bookLibraryStockReportData = new TestObjectBuilder<LibraryStockReportData>().Build();
        public ReportLastPeriodUpdateDataBuilder SetBookLibraryStockReportData(LibraryStockReportData bookLibraryStockReportData)
        {
            _bookLibraryStockReportData = bookLibraryStockReportData;
            return this;
        }

        private LibraryStockReportData _otherLibraryStockReportData = new TestObjectBuilder<LibraryStockReportData>().Build();
        public ReportLastPeriodUpdateDataBuilder SetOtherLibraryStockReportData(LibraryStockReportData otherLibraryStockReportData)
        {
            _otherLibraryStockReportData = otherLibraryStockReportData;
            return this;
        }


        private LibraryStockReportData _vhsLibraryStockReportData = new TestObjectBuilder<LibraryStockReportData>().Build();
        public ReportLastPeriodUpdateDataBuilder SetVhsLibraryStockReportData(LibraryStockReportData vhsLibraryStockReportData)
        {
            _vhsLibraryStockReportData = vhsLibraryStockReportData;
            return this;
        }


        public ReportLastPeriodUpdateData Build()
        {
            var reportData = new TestObjectBuilder<ReportLastPeriodUpdateData>()
                .SetArgument(o => o.AssociateMemberReportData, _associateMemberReportData)
                .SetArgument(o => o.PreliminaryMemberReportData, _preliminaryMemberReportData)
                .SetArgument(o => o.SupporterMemberReportData, _supporterMemberReportData)
                .SetArgument(o => o.MemberMemberReportData, _memberMemberReportData)
              
                .SetArgument(o => o.BaitulMalFinanceReportData, _baitulMalFinanceReportData)
                .SetArgument(o => o.ADayMasjidProjectFinanceReportData, _aDayMasjidProjectFinanceReportData)
                .SetArgument(o => o.BaitulMalFinanceReportData, _baitulMalFinanceReportData)
                .SetArgument(o => o.ADayMasjidProjectFinanceReportData, _aDayMasjidProjectFinanceReportData)
                .SetArgument(o => o.MasjidTableBankFinanceReportData, _masjidTableBankFinanceReportData)
                
                .SetArgument(o => o.BookLibraryStockReportData, _bookLibraryStockReportData)
                .SetArgument(o => o.OtherLibraryStockReportData, _otherLibraryStockReportData)
                .SetArgument(o => o.VhsLibraryStockReportData, _vhsLibraryStockReportData)
                .Build();
            return reportData;
        }
    }
}