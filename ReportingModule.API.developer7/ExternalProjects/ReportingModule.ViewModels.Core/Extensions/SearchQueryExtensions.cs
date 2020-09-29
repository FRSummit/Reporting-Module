using System;
using System.Collections.Generic;
using System.Linq;
using ReportingModule.ViewModels.Search;

namespace ReportingModule.ViewModels.Extensions
{
	public static class SearchQueryExtensions
	{
		private const int DefaultPageSize = 25;

	    public static SearchResult<TBase> FetchSimpleSearchResult<TBase>(
	        this IQueryable<TBase> baseQuery,
	        PagingData pagingData,
	        bool fetchTotalCount = true)
	    {
	        return baseQuery.FetchSearchResult(_ => _,
	            _ => _,
	            pagingData,
	            fetchTotalCount);
	    }

	    public static SearchResult<T> FetchSearchResult<TBase, TMap, T>(
	        this IQueryable<TBase> baseQuery,
	        Func<IQueryable<TBase>, IQueryable<TMap>> map,
	        Func<IEnumerable<TMap>, IEnumerable<T>> transform,
	        PagingData pagingData,
	        bool fetchTotalCount = true)
	    {
	        if (map == null) throw new ArgumentNullException(nameof(map));
	        if (transform == null) throw new ArgumentNullException(nameof(transform));

	        var totalResults = fetchTotalCount ? baseQuery.Count() : (int?) null;
	        var queryPagingData = pagingData ?? new PagingData(1, DefaultPageSize, 0);
	        var resultPagingData = fetchTotalCount
	            ? PagingData.MakeForResultCount(queryPagingData,
	                totalResults.Value)
	            : queryPagingData;

	        var items = baseQuery
	            .Map(map)
	            .FetchPage(resultPagingData)
	            .Transform(transform);

	        return new SearchResult<T>(items, resultPagingData);
	    }

	    private static IQueryable<T> Map<TBase, T>(this IQueryable<TBase> baseQuery,
												   Func<IQueryable<TBase>, IQueryable<T>> map)
		{
			return map(baseQuery);
		}

		public static T[] FetchPage<T>(this IQueryable<T> query, PagingData pagingData)
		{
			return query.Skip(pagingData.Skip).Take(pagingData.Take).ToArray();
		}

		private static IEnumerable<T> Transform<TMap, T>(this IEnumerable<TMap> mappedResult,
														 Func<IEnumerable<TMap>, IEnumerable<T>> transform)
		{
			return transform(mappedResult);
		}


	    public static IQueryable<T> TokeniseQuickSearch<T>(this IQueryable<T> query,
	        string quickSearch, Func<IQueryable<T>, string, IQueryable<T>> queryFunc)
	    {
	        return string.IsNullOrWhiteSpace(quickSearch)
	            ? query
	            : quickSearch.Split().Aggregate(query, queryFunc);
	    }
    }
}
