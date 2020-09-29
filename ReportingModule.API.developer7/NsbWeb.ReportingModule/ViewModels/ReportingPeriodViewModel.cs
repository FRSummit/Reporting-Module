using System;
using Newtonsoft.Json;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels
{
    public class ReportingPeriodViewModel
    {
        [JsonIgnore]
        public ReportingPeriod ReportingPeriodData { get; set; }
        public OrganizationReference OrganizationReference { get; set; }
        public int Year => ReportingPeriodData.Year;
        public ReportingFrequency ReportingFrequency => ReportingPeriodData.ReportingFrequency;
        public ReportingTerm ReportingTerm => ReportingPeriodData.ReportingTerm;
        public DateTime StartDate => ReportingPeriodData.StartDate;
        public DateTime EndDate => ReportingPeriodData.EndDate;
        public bool IsActive { get; set; }
    }
}