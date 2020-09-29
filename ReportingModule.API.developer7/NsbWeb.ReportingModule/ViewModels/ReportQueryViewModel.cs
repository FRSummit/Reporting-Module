using System.Diagnostics.CodeAnalysis;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class ReportQueryViewModel
    {
        public int Id { get; set; }
        public OrganizationReference Organization { get; set; }
    }
}