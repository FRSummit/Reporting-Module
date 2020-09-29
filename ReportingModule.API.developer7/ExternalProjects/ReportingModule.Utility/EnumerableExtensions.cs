using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportingModule.Utility
{
	public static class EnumerableExtensions
	{
		public static bool EqualListContents<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
		{
			return list1.Count() == list2.Count() &&
			       !list1.Except(list2).Any() &&
			       !list2.Except(list1).Any();
		}

		public static TResult MaxOrDefault<T, TResult>(this IEnumerable<T> list, Func<T, TResult> selector)
		{
			return !list.Any() ? default(TResult) : list.Max(selector);
		}

		public static T MaxOrDefault<T>(this IEnumerable<T> list)
		{
			return list.MaxOrDefault(o => o);
		}

		public static TResult MinOrDefault<T, TResult>(this IEnumerable<T> list, Func<T, TResult> selector)
		{
			return !list.Any() ? default(TResult) : list.Min(selector);
		}

		public static T MinOrDefault<T>(this IEnumerable<T> list)
		{
			return list.MinOrDefault(o => o);
		}

		public static bool EqualsDictionary<TKey, TValue>(this IDictionary<TKey, TValue> d1, IDictionary<TKey, TValue> d2)
		{
			return d1.Count == d2.Count && !d1.Except(d2).Any();
		}

        /// <summary>
        /// Wraps this object instance into an IEnumerable&lt;T&gt;
        /// consisting of a single item.
        /// </summary>
        /// <typeparam name="T"> Type of the object. </typeparam>
        /// <param name="item"> The instance that will be wrapped. </param>
        /// <returns> An IEnumerable&lt;T&gt; consisting of a single item. </returns>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
	}
}