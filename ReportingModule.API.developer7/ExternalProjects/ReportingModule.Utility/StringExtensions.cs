using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReportingModule.Utility
{
	public static class StringExtensions
	{
		public static string GetWithSpacesByCamelCasing(this String str)
		{
			return Regex.Replace(
				str,
				"([A-Z])",
				" $1",
				RegexOptions.Compiled).Trim();
		}

		public static bool IsNumeric(this string s)
		{
			return new Regex("^[0-9]+$").IsMatch(s);
		}

		public static bool IsAlphaNumeric(this string s)
		{
			return new Regex("^[0-9a-zA-Z]+$").IsMatch(s);
		}

		public static bool IsNumber(this string s)
		{
			double temp;
			return Double.TryParse(s, out temp);
		}

		public static string[] GetWildcardSearch(this string s)
		{
			char[] separators = new []{' ', '\t'};
			return s.GetWildcardSearch(separators);
		}

		public static string[] GetWildcardSearch(this string s, char[] separators)
		{
			if (s == null) throw new ArgumentNullException("s");
			s = s.Trim();
			if (String.IsNullOrEmpty(s))
				return new [] {String.Empty};
			
			string[] searchTerms = s.Split(separators);
			return searchTerms.Select(x => x + "*").ToArray();
		}

        private const string TrimmedValidEmailRegexString =
            @"((([a-z]|\d|[!#\$%&\'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&\'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))";

        private static readonly Regex TrimmedValidEmailRegex = new Regex($"^{TrimmedValidEmailRegexString}$", RegexOptions.IgnoreCase);
        private static readonly Regex UnTrimmedValidEmailRegex = new Regex($"^\\s*{TrimmedValidEmailRegexString}\\s*$", RegexOptions.IgnoreCase);

        public static bool IsValidEmail(this string address, bool trimmed=true)
		{
            if (string.IsNullOrWhiteSpace(address))
                return false;

		    return trimmed ? TrimmedValidEmailRegex.IsMatch(address) : UnTrimmedValidEmailRegex.IsMatch(address);
		}

		public static int? TryParseInt(this string s)
		{
			if (s == null) return null;

			int tempInt;
			bool parsedSuccessfully = Int32.TryParse(s, out tempInt);

			return parsedSuccessfully
						? tempInt
						: (int?)null;
		}

		public static bool IsEmptyOrWhitespace(this string s)
		{
			return string.IsNullOrWhiteSpace(s) && (s != null);
		}

		public static string NullIfEmpty(this string s)
		{
			return string.IsNullOrWhiteSpace(s)
			       	? null
			       	: s;
		}

        public static string NullIfEmptyTrim(this string s)
        {
            return string.IsNullOrWhiteSpace(s)
                    ? null
                    : s.Trim();
        }

        public static bool ParseBoolFalseIfNotTrue(this string s)
        {
            var b = false;
            return bool.TryParse(s, out b) && b;
        }
	}

	public static class EnumerationOfStringExtensions
	{
		public static string GenerateSearchTerm(this IEnumerable<string> terms)
		{
			var validTerms = terms
				.Where(x => !string.IsNullOrWhiteSpace(x))
				.Select(x => x.Trim());
			return string.Join(" ", validTerms);
		}
	}
}