using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using ReportingModule.Common;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Unit
{
    [TestFixture(Category = "Unit")]
    public class CalculatorTests
    {
        [TestCaseSource(typeof(CalculatorTestDataClass), "MeeetingProgramDataTestCases")]
        public void Calculates_MeetingProgramData_AsExpected(IEnumerable<MeetingProgramData> unitDatas, IEnumerable<MeetingProgramData> zoneDatas, IEnumerable<MeetingProgramData> stateDatas, IEnumerable<MeetingProgramData> centralDatas, MeetingProgramData expected)
        {
            var result = Calculator.GetCalculatedMeetingProgramData(unitDatas, zoneDatas, stateDatas, centralDatas);
            result.Should().BeEquivalentTo(expected);
        }
    }

    public class CalculatorTestDataClass
    {
        public static IEnumerable MeeetingProgramDataTestCases
        {
            get
            {
                yield return new TestCaseData(null, null, null, null, MeetingProgramData.Default());
                yield return new TestCaseData(null, new MeetingProgramData[0], new MeetingProgramData[0], new MeetingProgramData[0], MeetingProgramData.Default());
                yield return new TestCaseData(null, null, new MeetingProgramData[0], new MeetingProgramData[0], MeetingProgramData.Default());
                yield return new TestCaseData(new MeetingProgramData[0], new MeetingProgramData[0], new MeetingProgramData[0], new MeetingProgramData[0], MeetingProgramData.Default());
                yield return new TestCaseData(new MeetingProgramData[0], 
                    new MeetingProgramData[0],
                    new[]
                    {
                        new MeetingProgramData(1, null, 1, 1, null),
                        new MeetingProgramData(1, null, 1, 1, null),
                    },
                    new[]
                    {
                        new MeetingProgramData(1, null, 1, 1, null),
                        new MeetingProgramData(1, null, 1, 1, null),
                    },
                    new MeetingProgramData(4, null, 4, 1, null)
                );
                yield return new TestCaseData(new MeetingProgramData[0],
                    new[]
                    {
                        new MeetingProgramData(1, null, 1, 1, null),
                        new MeetingProgramData(1, null, 1, 1, null),
                    },
                    new[]
                    {
                        new MeetingProgramData(1, null, 1, 1, null),
                        new MeetingProgramData(1, null, 1, 1, null),
                    },
                    null,
                    new MeetingProgramData(4, null, 4, 1, null)
                );
                yield return new TestCaseData(new[]
                    {
                        new MeetingProgramData(1, null, 1, 1, null),
                        new MeetingProgramData(1, null, 1, 1, null),
                    },
                    new[]
                    {
                        new MeetingProgramData(1, null, 1, 1, null),
                        new MeetingProgramData(1, null, 1, 1, null),
                    },
                    new[]
                    {
                        new MeetingProgramData(1, null, 1, 1, null),
                        new MeetingProgramData(1, null, 1, 1, null),
                    },
                    new[]
                    {
                        new MeetingProgramData(1, null, 1, 1, null),
                        new MeetingProgramData(1, null, 1, 1, null),
                    },
                    new MeetingProgramData(8, null, 8, 1, null)
                );
            }
        }
    }
}