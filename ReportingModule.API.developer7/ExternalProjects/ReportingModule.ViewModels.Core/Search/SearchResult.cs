using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportingModule.ViewModels.Search
{
    public class SearchResult<T>
    {
        public SearchResult(IEnumerable<T> items, PagingData pagingData)
        {
            Items = items?.ToArray() ?? throw new ArgumentNullException(nameof(items));
            PagingData = pagingData ?? throw new ArgumentNullException(nameof(pagingData));
        }

        public static SearchResult<T> Build(
            IEnumerable<T> items,
            PagingData pagingData)
        {
            if (pagingData == null) throw new ArgumentNullException(nameof(pagingData));
            var itemsValue = items?.ToArray() ?? throw new ArgumentNullException(nameof(items));

            return new SearchResult<T>
            {
                Items = itemsValue,
                PagingData = pagingData
            };
        }

        protected SearchResult()
        { }

        public T[] Items { get; protected set; }
        public PagingData PagingData { get; protected set; }
    }
}