using System;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices
{
    public class ReportEventLogSearchTerms : GridSearchTerms
    {
        public string QuickSearch { get; set; }
        public DateTime? TimestampFrom { get; set; }
        public DateTime? TimestampTo { get; set; }

    }
}