using System;
using FluentAssertions;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using ReportingModule.Core.Domains;
using ReportingModule.SystemTests.Common;
using ReportingModule.SystemTests.Common.TestData;
using ReportingModule.SystemTests.Nsb7.Configuration;
using StructureMap;

namespace ReportingModule.SystemTests.Nsb7
{
	[TestFixture]
    [Category("Integration")]
    public abstract class AggregateDalTest<T, TIdentifier> where T : class, IAggregate<TIdentifier>
    {
        protected abstract IContainer ExecutionContainer { get; }

        protected virtual T CreateAggregate()
        {
            return DataProvider.Get<T>();
        }

        [Test]
        public void CanInsertAndRetrieveAggregate()
        {
            TestInsertAndRetrieve();
        }

        protected internal Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> Options = o => o.SqlDateComparison().IgnoringCyclicReferences();

        protected void TestInsertAndRetrieve(Func<T> creator = null)
        {
            var aggregate = Endpoint.ActOnSqlSession(ExecutionContainer,
                session =>
                {
                    var item = creator != null
                        ? creator()
                        : CreateAggregate();

                    session.Save(item);
                    return item;
                });

            Endpoint.AssertOnSqlSessionThat(ExecutionContainer,
                s =>
                {
                    var retrievedAggregate = s.Get<T>(aggregate.Id);
                    retrievedAggregate.Should().BeEquivalentTo(aggregate, Options);
                });
        }
    }
}
