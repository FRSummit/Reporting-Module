using ReportingModule.ValueObjects;
using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices
{
    public class OrganizationSearchTerms : GridSearchTerms
    {
        public string QuickSearch { get; set; }
        public OrganizationType? OrganizationType { get; set; }

    }
}