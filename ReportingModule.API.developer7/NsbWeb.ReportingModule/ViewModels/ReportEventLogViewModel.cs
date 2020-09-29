using System;
using System.Diagnostics.CodeAnalysis;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class ReportEventLogViewModel
    {
        protected ReportEventLogViewModel()
        {
        }
        protected ReportEventLogViewModel(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
        public int? OrganizationId { get; private set; }
        public int? ReportId { get; private set; }
        public string MessageType { get; private set; }
        public string Message { get; private set; }
        public string CreatedByUsername { get; private set; }
        public ReportEventLogVisibility Visibility { get; private set; }
        public DateTime Timestamp { get; private set; }
        
    }
}