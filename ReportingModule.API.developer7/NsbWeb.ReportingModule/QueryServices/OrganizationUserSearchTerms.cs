using ReportingModule.ViewModels.Search;

namespace NsbWeb.ReportingModule.QueryServices
{
    public class OrganizationUserSearchTerms : GridSearchTerms
    {
        public string QuickSearch { get; set; }
        public OrganizationUserOrderBy OrderBy { get; set; }

    }

    public enum OrganizationUserOrderBy
    {
        Organization = 1,
        UserName = 2
    }
}