using System;
using System.Collections.Generic;
using System.Linq;
using ReportingModule.Core.Exceptions;
using ReportingModule.Utility;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

namespace ReportingModule.Core
{
    public class Money : IEquatable<Money>
    {
        public static int MaxDecimals = 2;

        protected Money()
        {
        }


        public Money(decimal amount, Currency? currency = Currency.AUD)
        {
            if (currency == null)
                throw new ArgumentNullException(nameof(currency));

            if (amount != decimal.Round(amount, MaxDecimals))
                throw new ArgumentException(String.Format("Money can only have {0} decimal places", MaxDecimals), nameof(amount));

            if (currency != null && (int)currency.Value == 0)
                currency = Currency.AUD;
            //throw new ArgumentException("Unitialized currency is not allowed", nameof(currency));

            Amount = amount;
            Currency = currency.Value;
        }

        public static Money Default() => new Money(0);
        public static Money Zero() => new Money(0);


        public virtual decimal Amount { get; private set; }
        public virtual Currency Currency { get; private set; }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Amount == Amount && Equals(other.Currency, Currency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Money)) return false;
            return Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            return new Object[] { Amount, Currency }.GenerateHashCode();
        }

        public static bool operator ==(Money left, Money right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !Equals(left, right);
        }

        public static Money operator +(Money left, Money right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            if (left.Currency != right.Currency)
                throw new ArgumentException("Money must be of the same currency.", nameof(right));
            return new Money(left.Amount + right.Amount, left.Currency);
        }

        public static Money operator -(Money left, Money right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            if (left.Currency != right.Currency)
                throw new ArgumentException("Money must be of the same currency.", nameof(right));
            return new Money(left.Amount - right.Amount, left.Currency);
        }

        public static Money operator *(Money a, int multiplier)
        {
            if (a == null) return null;
            return new Money(a.Amount * multiplier, a.Currency);
        }

        public static bool operator >(Money left, Money right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            if (left.Currency != right.Currency)
                throw new ArgumentException("Money must be of the same currency.", nameof(right));
            return left.Amount > right.Amount;
        }

        public static bool operator <(Money left, Money right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            if (left.Currency != right.Currency)
                throw new ArgumentException("Money must be of the same currency.", nameof(right));
            return left.Amount < right.Amount;
        }

        public static bool operator >=(Money left, Money right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            if (left.Currency != right.Currency)
                throw new ArgumentException("Money must be of the same currency.", nameof(right));
            return left.Amount >= right.Amount;
        }

        public static bool operator <=(Money left, Money right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            if (left.Currency != right.Currency)
                throw new ArgumentException("Money must be of the same currency.", nameof(right));
            return left.Amount <= right.Amount;
        }

        public virtual Money DivideByAndRound(decimal divisor, MidpointRounding rounding = MidpointRounding.AwayFromZero)
        {
            return new Money(decimal.Round(Amount / divisor, MaxDecimals, rounding), Currency);
        }

        public override string ToString()
        {
            return String.Format("{0} {1:N2}", Currency, Amount);
        }
    }

    public static class MoneyExtensions
    {
        public static IEnumerable<Money> Sum(this IEnumerable<Money> moneyToSum)
        {
            if (moneyToSum == null) throw new ArgumentNullException(nameof(moneyToSum));


            return moneyToSum.Where(x => x != null)
                .GroupBy(o => o.Currency)
                .Select(o => new Money(o.Sum(x => x.Amount), o.Key));
        }

        public static IEnumerable<Money> SumMoney(this IEnumerable<IEnumerable<Money>> moneyToSum)
        {
            if (moneyToSum == null) throw new ArgumentNullException(nameof(moneyToSum));
            IEnumerable<Money> allMoney = moneyToSum.SelectMany(_ => _);
            return allMoney.Sum();
        }

        public static bool AreSameCurrency(this IEnumerable<Money> moneyToSum)
        {
            return moneyToSum.Select(x => x.Currency).Distinct().Count() <= 1;
        }

        public static Money SingleCurrencyMax(this IEnumerable<IEnumerable<Money>> moneyToSum)
        {
            if (!moneyToSum.AreSameCurrency())
                throw new MultipleCurrenciesException();
            return moneyToSum.Select(x => x.Sum()).Select(x => x.SingleOrDefault()).SingleCurrencyMax();
        }

        public static Money SingleCurrencySum(this IEnumerable<Money> moneyToSum)
        {
            if (!moneyToSum.AreSameCurrency())
                throw new MultipleCurrenciesException();
            if (!moneyToSum.Any())
                throw new ArgumentException("Must have money, to sum money");
            return moneyToSum.Sum().Single();
        }

        public static bool AreSameCurrency(this IEnumerable<IEnumerable<Money>> moneysToSum)
        {
            return moneysToSum.SelectMany(_ => _).AreSameCurrency();
        }

        public static Money SingleCurrencyMax(this IEnumerable<Money> moneyToSum)
        {
            if (moneyToSum == null) throw new ArgumentNullException(nameof(moneyToSum));
            if (!moneyToSum.Any())
                return null;
            if (moneyToSum.Select(x => x.Currency).Distinct().Count() > 1)
                throw new MultipleCurrenciesException();
            var currency = moneyToSum.First().Currency;
            return new Money(moneyToSum.Max(x => x.Amount), currency);
        }

        public static IEnumerable<Money> Minus(this IEnumerable<Money> moneyA, IEnumerable<Money> moneyB)
        {
            if (moneyA == null) throw new ArgumentNullException(nameof(moneyA));
            if (moneyB == null) throw new ArgumentNullException(nameof(moneyB));

            var a = moneyA.Where(x => x != null).ToArray();
            var b = moneyB.Where(x => x != null).ToArray();

            return a.Select(x => x.Currency).Union(b.Select(x => x.Currency))
                .Select(c => new Money(
                                 a.Where(x => x.Currency == c).Sum(x => x.Amount) -
                                 b.Where(x => x.Currency == c).Sum(x => x.Amount),
                                 c));
        }

        public static IEnumerable<Money> Add(this IEnumerable<Money> moneyA, IEnumerable<Money> moneyB)
        {
            if (moneyA == null) throw new ArgumentNullException(nameof(moneyA));
            if (moneyB == null) throw new ArgumentNullException(nameof(moneyB));

            var a = moneyA.Where(x => x != null).ToArray();
            var b = moneyB.Where(x => x != null).ToArray();

            return a.Select(x => x.Currency).Union(b.Select(x => x.Currency))
                .Select(c => new Money(
                                a.Where(x => x.Currency == c).Sum(x => x.Amount) +
                                b.Where(x => x.Currency == c).Sum(x => x.Amount),
                                c));
        }


        public static Money[] Apportion(this Money money, int numberOfPortions)
        {
            if (money == null) throw new ArgumentNullException(nameof(money));
            if (numberOfPortions < 1) throw new ArgumentException("Must divide into at least one portion!", nameof(numberOfPortions));

            var portions = money.Amount.Apportion(numberOfPortions, Money.MaxDecimals);

            return new int[numberOfPortions]
                .Select((x, index) => new Money(portions[index], money.Currency))
                .ToArray();
        }

        public static IEnumerable<Money> MultiplyBy(this IEnumerable<Money> amount, int multiplier)
        {
            if (amount == null) throw new ArgumentNullException(nameof(amount));
            return amount.Select(x => x * multiplier);
        }

        public static Money MultiplyBy(this Money a, decimal multiplier, MidpointRounding roundingPolicy)
        {
            if (a == null) return null;
            var amount = Math.Round(a.Amount * multiplier, Money.MaxDecimals, roundingPolicy);
            return new Money(amount, a.Currency);
        }

        public static IEnumerable<Money> MultiplyBy(this IEnumerable<Money> amount, decimal multiplier, MidpointRounding roundingPolicy)
        {
            if (amount == null) throw new ArgumentNullException(nameof(amount));
            return amount.Select(x => x.MultiplyBy(multiplier, roundingPolicy));
        }


        public static MultiCurrencyMoney Sum(this IEnumerable<MultiCurrencyMoney> moneyToSum)
        {
            if (moneyToSum == null) throw new ArgumentNullException(nameof(moneyToSum));
            return new MultiCurrencyMoney(moneyToSum.SelectMany(o => o.Amount).Sum().ToArray());
        }
    }

    public class MultiCurrencyMoney : IEquatable<MultiCurrencyMoney>
    {

        public MultiCurrencyMoney(params Money[] amount)
        {
            Amount = amount?.Sum().ToArray() ?? throw new ArgumentNullException(nameof(amount));
        }

        public Money[] Amount { get; private set; }

        public bool Equals(MultiCurrencyMoney other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Amount.EqualListContents(Amount);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(MultiCurrencyMoney)) return false;
            return Equals((MultiCurrencyMoney)obj);
        }

        public override int GetHashCode()
        {
            return Amount.OrderBy(x => x.Currency).Cast<object>().ToArray().GenerateHashCode();
        }

        public static bool operator ==(MultiCurrencyMoney left, MultiCurrencyMoney right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MultiCurrencyMoney left, MultiCurrencyMoney right)
        {
            return !Equals(left, right);
        }

        public static MultiCurrencyMoney operator +(MultiCurrencyMoney amount1, MultiCurrencyMoney amount2)
        {
            return new MultiCurrencyMoney(amount1.Amount.Add(amount2.Amount).ToArray());
        }

        public static MultiCurrencyMoney operator -(MultiCurrencyMoney amount1, MultiCurrencyMoney amount2)
        {
            var money1Amounts = amount1.Amount;
            var money2Amounts = amount2.Amount;
            var allCurrencies = money1Amounts.Select(x => x.Currency).Union(money2Amounts.Select(y => y.Currency)).Distinct()
                .ToArray();

            money1Amounts = allCurrencies
                .Select(x => money1Amounts.SingleOrDefault(y => y.Currency == x) ?? new Money(0, x)).ToArray();
            money2Amounts = allCurrencies
                .Select(x => money2Amounts.SingleOrDefault(y => y.Currency == x) ?? new Money(0, x)).ToArray();
            var amountsOut = allCurrencies
                .Select(c => money1Amounts.Single(x => x.Currency == c) - money2Amounts.Single(y => y.Currency == c))
                .ToArray();
            return new MultiCurrencyMoney(amountsOut);
        }
    }

    public static class MoneyDisplayExtensions
    {
        public static string Format(this Money m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            return String.Format("{0} {1:N}", m.Currency, m.Amount);
        }
    }


}