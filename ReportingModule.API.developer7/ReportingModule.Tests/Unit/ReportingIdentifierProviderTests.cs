using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using ReportingModule.Entities;
using ReportingModule.Services.Impl;

namespace ReportingModule.Tests.Unit
{
    [TestFixture(Category = "Unit")]
    public class ReportingIdentifierProviderTests
    {
        [Test]
        public void AllIdentifierTypes_HaveAPrefix()
        {
            var missingPrefixes = Enum.GetValues(typeof(IdentifierType))
                .Cast<IdentifierType>()
                .Where(o => !ReportingIdentifierProvider.Prefixes.ContainsKey(o))
                .ToArray();

            missingPrefixes.Should().BeEmpty();
        }
    }
}