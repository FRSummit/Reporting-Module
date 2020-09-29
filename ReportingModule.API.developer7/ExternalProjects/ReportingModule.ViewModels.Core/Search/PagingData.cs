using System;
using Newtonsoft.Json;

namespace ReportingModule.ViewModels.Search
{
    public class PagingData
    {
        public static PagingData Default => new PagingData(1, 10, 0);

        public static PagingData MakeForResultCount(PagingData queryPagingData, int resultCount)
        {
            if (queryPagingData == null) throw new ArgumentNullException(nameof(queryPagingData));
            if (resultCount < 0)
            {
                throw new ArgumentException("Result count must not be less than zero", nameof(resultCount));
            }

            if (resultCount > queryPagingData.Skip) return new PagingData(queryPagingData.Page, queryPagingData.PageSize, resultCount);

            var maxPage = resultCount <= queryPagingData.PageSize
                ? 1
                : resultCount / queryPagingData.PageSize + 1;

            return new PagingData(maxPage, queryPagingData.PageSize, resultCount);
        }

        public PagingData(int page, int pageSize, int totalRecords)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than zero", nameof(page));
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than zero", nameof(pageSize));
            }

            Page = page;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }

        public int Page { get; protected set; }
        public int PageSize { get; protected set; }
        public int TotalRecords { get; protected set; }

        [JsonIgnore]
        public int Skip => (Page - 1) * PageSize;

        [JsonIgnore]
        public int Take => PageSize;
    }
}