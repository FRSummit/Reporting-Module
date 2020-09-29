using FluentAssertions;
using NsbWeb.ReportingModule.QueryServices.Impl;
using NsbWeb.ReportingModule.ViewModels;
using NUnit.Framework;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.Tests.Builders;
using ReportingModule.ValueObjects;
using ReportingModule.ViewModels.Search;

namespace ReportingModule.Tests.Unit
{
    [TestFixture(Category = "Unit")]
    public class ExcelReportFactoryTests
    {
        [TestCase(OrganizationType.Unit, ReportingFrequency.Monthly)]
        [TestCase(OrganizationType.State, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.Zone, ReportingFrequency.Quarterly)]
        public void GetRecent_Returns_Result_AsExpected(OrganizationType organizationType, ReportingFrequency reportingFrequency)
        {
            var org1 = new TestObjectBuilder<OrganizationReference>()
                .SetArgument(o => o.OrganizationType, organizationType)
                .Build();

            var org2 = new TestObjectBuilder<OrganizationReference>()
                .SetArgument(o => o.OrganizationType, organizationType)
                .Build();

            
            var excelReportData1 = new ExcelReportDataBuilder().Build();
            excelReportData1.Organization = org1;
            excelReportData1.ReportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, ReportingTerm.One, 2019);
            var excelReportData2 = new ExcelReportDataBuilder().Build();
            excelReportData2.Organization = org1;
            excelReportData2.ReportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, ReportingTerm.Four, 2019);

            var excelReportData3 = new ExcelReportDataBuilder().Build();
            excelReportData3.Organization = org1;
            excelReportData3.ReportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, ReportingTerm.Three, 2019);

            var excelReportData4 = new ExcelReportDataBuilder().Build();
            excelReportData4.Organization = org2;
            excelReportData4.ReportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, ReportingTerm.One, 2019);

            var excelReportData5 = new ExcelReportDataBuilder().Build();
            excelReportData5.Organization = org2;
            excelReportData5.ReportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, ReportingTerm.Three, 2019);

            var excelReportData6 = new ExcelReportDataBuilder().Build();
            excelReportData6.Organization = org2;
            excelReportData6.ReportingPeriod = new ReportingPeriod(ReportingFrequency.Monthly, ReportingTerm.Two, 2019);

            var excelReportDatas = new[] {
                excelReportData1,
                excelReportData2,
                excelReportData3,
                excelReportData4,
                excelReportData5,
                excelReportData6
            };

            var data = new SearchResult<ExcelReportData>(excelReportDatas, new PagingData(1, 100, 1000));
            var recentExcelReportDatas = ExcelReportFactory.GetRecentExcelReportDatas(data.Items, organizationType);
            var expected = new[] { excelReportData2, excelReportData5 };
            // ReSharper disable once CoVariantArrayConversion
            recentExcelReportDatas.Should().BeEquivalentTo(expected);
        }

        [TestCase(OrganizationType.Unit, ReportingFrequency.Monthly)]
        [TestCase(OrganizationType.State, ReportingFrequency.Quarterly)]
        [TestCase(OrganizationType.Zone, ReportingFrequency.Quarterly)]
        public void GetRecent_Returns_Result_AsExpected_WhenEmptyArray(OrganizationType organizationType, ReportingFrequency reportingFrequency)
        {
            var data = new SearchResult<ExcelReportData>(new ExcelReportData[0], new PagingData(1, 100, 1000));
            var recentExcelReportDatas = ExcelReportFactory.GetRecentExcelReportDatas(data.Items, organizationType);
            var expected = new ExcelReportData[0];
            // ReSharper disable once CoVariantArrayConversion
            recentExcelReportDatas.Should().BeEquivalentTo(expected);
        }
    }
}