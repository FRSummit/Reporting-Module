using System.Collections;
using NUnit.Framework;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.Services
{
    public class CreatePlanFixtureData
    {
        public static IEnumerable FixtureParams
        {
            get
            {
                yield return new TestFixtureData(ReportingFrequency.Quarterly, ReportingTerm.One);
                //yield return new TestFixtureData(ReportingFrequency.Quarterly, ReportingTerm.Two);
                //yield return new TestFixtureData(ReportingFrequency.Quarterly, ReportingTerm.Three);
                yield return new TestFixtureData(ReportingFrequency.Quarterly, ReportingTerm.Four);
            }
        }
    }
}