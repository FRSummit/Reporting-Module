using System;
using System.Diagnostics.CodeAnalysis;
using ReportingModule.Core;

namespace NsbWeb.ReportingModule.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class OrganizationUserViewModel : IOrganizationFilter
    {
        protected OrganizationUserViewModel()
        {
        }
        protected OrganizationUserViewModel(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Role { get; private set; }
        public EntityReference Organization { get; private set; }
        public DateTime Timestamp { get; private set; }
    }
}