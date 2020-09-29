using System;
using FluentAssertions;
using ReportingModule.Core;

namespace ReportingModule.SystemTests.Common
{
    public static class ResultTestingExtensions
    {
        public static void ShouldBeSuccess<T>(this Result<T, string[]> result)
        {
            if (result.IsFailure)
            {
                Console.Write(string.Join(Environment.NewLine, result.Failure));
            }
            
            result.IsSuccess.Should().BeTrue();
        }
    }
}