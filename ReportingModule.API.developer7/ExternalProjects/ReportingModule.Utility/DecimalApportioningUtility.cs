using System;
using System.Linq;

namespace ReportingModule.Utility
{
	public static class DecimalApportioningUtility
	{		
		public static decimal[] Apportion(this decimal amount, int numberOfPortions, int numberOfDecimals)
		{
			if (numberOfPortions < 1) throw new ArgumentException("Must divide into at least one portion!", "numberOfPortions");

			var currencyFactor = (decimal)Math.Pow(10, numberOfDecimals);

			int remainder;

			var roundedPortion = Math.DivRem((int)(currencyFactor * amount), numberOfPortions, out remainder);

			return new int[numberOfPortions]
				.Select((x, index) => (roundedPortion + ((index < remainder) ? 1 : 0)) / currencyFactor)
				.ToArray();
		}
	}
}
