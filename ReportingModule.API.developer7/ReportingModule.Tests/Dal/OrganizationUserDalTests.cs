using NUnit.Framework;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Nsb7;
using StructureMap;

namespace ReportingModule.Tests.Dal
{
    [TestFixture(Category = "Integration")]
    public class OrganizationUserDalTests : AggregateDalTest<OrganizationUser, int>
    {
        protected override IContainer ExecutionContainer => AssemblySetupFixture.EndpointTestContainer;
    }
}