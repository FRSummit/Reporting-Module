using System;
using FluentAssertions;
using FluentAssertions.Equivalency;
using ReportingModule.Core;

namespace ReportingModule.SystemTests.Common
{
	public static class UsingFluent
	{		
		public static EquivalencyAssertionOptions<T> ExcludingEntityReferenceSearchTerms<T>(this EquivalencyAssertionOptions<T> config)
		{
			return config.Using<EntityReference>(EntityReferenceComparer).WhenTypeIs<EntityReference>();
		}

		private static void EntityReferenceComparer(IAssertionContext<EntityReference> ctx)
		{
			var retrieved = ctx.Subject;
			var expected = ctx.Expectation;
			retrieved.Id.Should().Be(expected.Id);
			retrieved.Description.Should().Be(expected.Description);
		}

		public static EquivalencyAssertionOptions<T> SqlDateComparison<T>(this EquivalencyAssertionOptions<T> config)
		{
			return config.Using<DateTime>(DateTimeSqlPrecisionComparer).WhenTypeIs<DateTime>();
		}

		private static void DateTimeSqlPrecisionComparer(IAssertionContext<DateTime> ctx)
		{
			var retrieved = ctx.Subject;
			var expected = ctx.Expectation;
			retrieved.Should().BeCloseTo(expected, 1000);
		}
	}
}