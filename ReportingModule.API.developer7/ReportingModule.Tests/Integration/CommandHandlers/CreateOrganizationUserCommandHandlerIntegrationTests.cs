using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using ReportingModule.CommandHandlers;
using ReportingModule.Commands;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7;
using ReportingModule.SystemTests.Nsb7.Configuration;
using ReportingModule.Tests.Builders;

namespace ReportingModule.Tests.Integration.CommandHandlers
{
    [TestFixture(Category = "Integration")]
    public class CreateOrganizationUserCommandHandlerIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
            Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer, s =>
            {
                DomainDatabase.ClearAllReportingModuleTables(s);
            });
        }

        [Test]
        public async Task Handle_SavesRecord()
        {
            var username = DataProvider.Get<string>();
            var role = DataProvider.Get<string>();
            var now = DateTimeDbTestExtensions.SetUtcNowToRandomDate();


            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var org = new OrganizationBuilder().BuildAndPersist(s);
                    return new
                    {
                        username,
                        Cmd = new CreateOrganizationUserCommand(username, role, org)
                    };
                });


            await Endpoint.Act<CreateOrganizationUserCommandHandler>(
                AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) =>
                {
                    ctx.SetUsernameOnHeader(testParams.username);
                    return h.Handle(testParams.Cmd, ctx);
                });

        Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizationUser = s.Query<OrganizationUser>().Single();
                    organizationUser.Should().NotBeNull();
                    organizationUser.Username.Should().Be(testParams.Cmd.Username);
                    organizationUser.Role.Should().Be(testParams.Cmd.Role);
                    organizationUser.Organization.Should().Be(testParams.Cmd.Organization);
                    organizationUser.Timestamp.Should().Be(now);
                    organizationUser.IsDeleted.Should().Be(false);

                });
        }

        [Test]
        public async Task Handle_RaisesException_WhenInvalidOrganization()
        {
            var username = DataProvider.Get<string>();
            var role = DataProvider.Get<string>();
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();


            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var org = new OrganizationBuilder().Build();//not persisted
                    return new
                    {
                        Cmd = new CreateOrganizationUserCommand(username, role, org)
                    };
                });


            await Endpoint.ActRaisesException<CreateOrganizationUserCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) => h.Handle(testParams.Cmd, ctx));

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizationUser = s.Query<OrganizationUser>().SingleOrDefault();
                    organizationUser.Should().BeNull();
                });
        }

        [Test]
        public async Task Handle_RaisesException_WhenOrganizationUserExists()
        {
            var username = DataProvider.Get<string>();
            var role = DataProvider.Get<string>();
            DateTimeDbTestExtensions.SetUtcNowToRandomDate();


            var testParams = Endpoint.ArrangeOnSqlSession(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var org = new OrganizationBuilder().BuildAndPersist(s);
                    new TestObjectBuilder<OrganizationUser>()
                        .SetArgument(o=>o.Username , username)
                        .SetArgument(o=>o.Role, role)
                        .SetArgument(o=>o.Organization, org)
                        .BuildAndPersist(s);
                    return new
                    {
                        Cmd = new CreateOrganizationUserCommand(username, role, org)
                    };
                });

            await Endpoint.ActRaisesException<CreateOrganizationUserCommandHandler>(AssemblySetupFixture.EndpointTestContainer,
                (h, ctx) => h.Handle(testParams.Cmd, ctx));

            Endpoint.AssertOnSqlSessionThat(AssemblySetupFixture.EndpointTestContainer,
                s =>
                {
                    var organizationUser = s.Query<OrganizationUser>().Single();
                    organizationUser.Should().NotBeNull();
                });
        }

    }
}