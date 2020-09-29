using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportingModule.Core
{
	public static class ResultExtensions
		// Gotta make a move to a town that's right for me,...
		// Won't you take me to, Funkytown!
	{
		public static Result<TSuccess2, TFailure2> Either<TSuccess, TFailure, TSuccess2, TFailure2>(
			this Result<TSuccess, TFailure> x,
			Func<Result<TSuccess, TFailure>, Result<TSuccess2, TFailure2>> onSuccess,
			Func<Result<TSuccess, TFailure>, Result<TSuccess2, TFailure2>> onFailure)
		{
			return x.IsSuccess ? onSuccess(x) : onFailure(x);
		}

        // Whatever x is, make it a success.
        public static Result<TSuccess, TFailure[]> ToResult<TSuccess, TFailure>(this TSuccess success)
        {
            return Result<TSuccess, TFailure[]>.Succeeded(success);
        }

        // Whatever x is, make it a failure.
        // The trick is that failure is an array type, can it can be made an empty array failure.
        public static Result<TSuccess, TFailure[]> ToFailure<TSuccess, TFailure>(
			this Result<TSuccess, TFailure[]> x)
		{
			return x.Either(
				a => Result<TSuccess, TFailure[]>.Failed(new TFailure[0]),
				b => b
				);
		}

		// Put accumulator and next together.
		// If they are both successes, then put them together as a success.
		// If either/both are failures, then put them together as a failure.
		// Because success and failure is an array, they can be put together
		public static Result<TSuccess[], TFailure[]> Merge<TSuccess, TFailure>(
			this Result<TSuccess[], TFailure[]> accumulator,
			Result<TSuccess, TFailure[]> next)
		{
			if (accumulator.IsSuccess && next.IsSuccess)
			{
				return Result<TSuccess[], TFailure[]>
					.Succeeded(accumulator.Success.Concat(new List<TSuccess>() {next.Success})
						.ToArray());
			}
			return Result<TSuccess[], TFailure[]>
				.Failed(accumulator.ToFailure().Failure.Concat(next.ToFailure().Failure).ToArray());
		}

        // Aggregate an array of results together.
        // If any of the results fail, return combined failures
        // Will only return success if all results succeed
	    public static Result<TSuccess[], TFailure[]> Aggregate<TSuccess, TFailure>(
	        this IEnumerable<Result<TSuccess, TFailure[]>> accumulator)
	    {
	        var emptySuccess = Result<TSuccess[], TFailure[]>.Succeeded(new TSuccess[0]);
	        return accumulator.Aggregate(emptySuccess, (acc, o) => acc.Merge(o));
	    }

        public static Result<TSuccess[], TFailure[]> Aggregate<TSuccess, TFailure>(
			this Result<TSuccess[], TFailure[]> accumulator,
			Func<TSuccess, Result<TSuccess, TFailure[]>> func)
		{
			if (accumulator.IsSuccess)
			{
				var emptySuccess = Result<TSuccess[], TFailure[]>.Succeeded(new TSuccess[0]);
				return accumulator
					.Success
					.Select(func)
					.Aggregate(emptySuccess, (acc, next) => acc.Merge(next));
			}

			return Result<TSuccess[], TFailure[]>.Failed(accumulator.Failure);
		}

		// Map: functional map
		// if x is a a success call f, otherwise pass it through as a failure
		public static Result<TSuccessNew, TFailure> Map<TSuccess, TFailure, TSuccessNew>(
			this Result<TSuccess, TFailure> x,
			Func<TSuccess, TSuccessNew> f)
		{
			return x.IsSuccess
				? Result<TSuccessNew, TFailure>.Succeeded(f(x.Success))
				: Result<TSuccessNew, TFailure>.Failed(x.Failure);
		}

		// MapMany: functional map on arrays
		// if x is a a success call f, otherwise pass it through as a failure
		public static Result<TSuccessNew[], TFailure> MapMany<TSuccess, TFailure, TSuccessNew>(
			this Result<TSuccess[], TFailure> x,
			Func<TSuccess, TSuccessNew> f)
		{
			return x.IsSuccess
				? Result<TSuccessNew[], TFailure>.Succeeded(x.Success.Select(f).ToArray())
				: Result<TSuccessNew[], TFailure>.Failed(x.Failure);
		}

		// Bind: functinal bind
		// Monadize it!
		public static Result<TSuccessNew, TFailure> Bind<TSuccess, TFailure, TSuccessNew>(
			this Result<TSuccess, TFailure> x,
			Func<TSuccess, Result<TSuccessNew, TFailure>> f)
		{
			return x.IsSuccess
				? f(x.Success)
				: Result<TSuccessNew, TFailure>.Failed(x.Failure);
		}

	    // BindMany: functional bind on arrays
	    // If x is a failure, pass it through
        // If x is a success, apply f to x. If any failures, fail, if all successes pass back success results.
	    public static Result<TSuccessNew[], TFailure[]> BindMany<TSuccess, TFailure, TSuccessNew>(
	        this Result<TSuccess[], TFailure[]> x,
	        Func<TSuccess, Result<TSuccessNew,TFailure[]>> f)
	    {
	        return x.IsSuccess
	            ? x.Success.Select(f).Aggregate()
	            : Result<TSuccessNew[], TFailure[]>.Failed(x.Failure);
	    }

        // This is the >> compose operator in 
        // https://fsharpforfunandprofit.com/posts/recipe-part2/
        public static Result<TSuccessNew, TFailure> Compose<TSuccess, TFailure, TSuccessNew>
			(this Result<TSuccess, TFailure> x,
				Func<Result<TSuccess, TFailure>, Result<TSuccessNew, TFailure>> f)
		{
			return x.IsSuccess
				? f(x)
				: Result<TSuccessNew, TFailure>.Failed(x.Failure);
		}

        public static Func<TSuccess, Result<TSuccessNew, TFailure>> Switch<TSuccess, TSuccessNew, TFailure>(this Func<TSuccess, TSuccessNew> f)
        {
            return x => Result<TSuccessNew, TFailure>.Succeeded(f(x));
        }

        public static Result<TSuccess,TFailure> Tee<TSuccess, TFailure>(this Result<TSuccess,TFailure> x, Action<TSuccess> f)
		{
			if (x.IsSuccess)
			{
				f(x.Success);
			}

			return x;
		}

	    public static Result<TSuccess[], TFailure> TeeMany<TSuccess, TFailure>(this Result<TSuccess[], TFailure> x, Action<TSuccess> f)
	    {
	        if (x.IsSuccess)
	        {
	            x.Success.ToList().ForEach(f);
	        }

	        return x;
	    }

        public static Result<TFinalSuccess, TFailure[]> Apply<TSuccess, TAnotherSuccess, TFinalSuccess, TFailure>(this
			Result<TSuccess, TFailure[]> aResult, Result<TAnotherSuccess, TFailure[]> anotherResult, Func<TSuccess, TAnotherSuccess, TFinalSuccess> f)
		{
			if (aResult.IsSuccess && anotherResult.IsSuccess)
				return Result<TFinalSuccess, TFailure[]>.Succeeded(f(aResult.Success, anotherResult.Success));

			if (aResult.IsFailure && anotherResult.IsSuccess)
				return Result<TFinalSuccess, TFailure[]>.Failed(aResult.Failure);

			if(aResult.IsSuccess && anotherResult.IsFailure)
				return Result<TFinalSuccess, TFailure[]>.Failed(anotherResult.Failure);

			return Result<TFinalSuccess, TFailure[]>.Failed(aResult.Failure.Concat(anotherResult.Failure).ToArray());
		}

		// LINQify - http://tomasp.net/blog/idioms-in-linq.aspx/
		// LINQ map
		public static Result<TSuccessNew, TFailure> Select<TSuccess, TFailure, TSuccessNew>(
			this Result<TSuccess, TFailure> o,
			Func<TSuccess, TSuccessNew> f)
		{
			return o.Map(f);
		}

		// LINQ bind
		public static Result<TSuccess3, TFailure> SelectMany<TSuccess1, TSuccess2, TFailure, TSuccess3>(
			this Result<TSuccess1, TFailure> o,
			Func<TSuccess1, Result<TSuccess2, TFailure>> f,
			Func<TSuccess1, TSuccess2, TSuccess3> mapper)
		{
			return o.Bind(oValue => f(oValue).Map(fValue => mapper(oValue, fValue)));

		}

        /// <summary>
        /// If both result1 and result2 are success, applies combinator to success results.
        /// Otherwise returns combined failures
        /// </summary>
        public static Result<TSuccess3, TFailure[]> Combine<TSuccess, TSuccess2, TSuccess3, TFailure>(
            this Result<TSuccess, TFailure[]> result1,
            Result<TSuccess2, TFailure[]> result2,
            Func<TSuccess, TSuccess2, TSuccess3> combinator)
        {
            if (result1.IsSuccess && result2.IsSuccess)
                return Result<TSuccess3, TFailure[]>.Succeeded(combinator(result1.Success, result2.Success));

            return Result<TSuccess3, TFailure[]>.Failed(
                result1.ToFailure().Failure.Concat(result2.ToFailure().Failure)
                    .ToArray());
        }

        /// <summary>
        /// If result1 is a success, execute func2.
        /// If result of func2 is success, applies combinator to success results.
        /// Otherwise returns either failure of result1 or failure of result 2
        /// </summary>
        public static Result<TSuccess3, TFailure> LazyCombine<TSuccess, TSuccess2, TSuccess3, TFailure>(
            this Result<TSuccess, TFailure> result1,
            Func<Result<TSuccess2, TFailure>> func2,
            Func<TSuccess, TSuccess2, TSuccess3> combinator)
        {
            if (result1.IsFailure)
                return Result<TSuccess3, TFailure>.Failed(result1.Failure);

            var result2 = func2();

            if (result2.IsSuccess)
                return Result<TSuccess3, TFailure>.Succeeded(combinator(result1.Success, result2.Success));

            return Result<TSuccess3, TFailure>.Failed(result2.Failure);
        }

        /// <summary>
        /// If result1 is a success, pipe into pipeFunc and join results if second function is successful
        /// </summary>
        public static Result<TSuccess3, TFailure> Join<TSuccess, TSuccess2, TSuccess3, TFailure>(
            this Result<TSuccess, TFailure> result1,
            Func<TSuccess, Result<TSuccess2, TFailure>> pipeFunc,
            Func<TSuccess, TSuccess2, TSuccess3> combinator)
        {
            if (result1.IsFailure)
                return Result<TSuccess3, TFailure>.Failed(result1.Failure);

            var result2 = pipeFunc(result1.Success);

            return result2.IsSuccess
                ? Result<TSuccess3, TFailure>.Succeeded(combinator(result1.Success, result2.Success))
                : Result<TSuccess3, TFailure>.Failed(result2.Failure);
        }
	}
}