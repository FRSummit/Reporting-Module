namespace ReportingModule.ViewModels.Search
{
    public class GridSearchTerms
    {
        public const int DefaultPageSize = 10;
        
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = DefaultPageSize;
        public PagingData PagingData => new PagingData(Page, PageSize, 0);
    }
}