using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ReportingModule.Core;
using ReportingModule.ValueObjects;

namespace NsbWeb.ReportingModule.ViewModels
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class OrganizationViewModel
    {
        protected OrganizationViewModel()
        {
            _managedOrganizations = new List<OrganizationReference>();
        }
        protected OrganizationViewModel(int id)
        {
            Id = id;
            _managedOrganizations = new List<OrganizationReference>();
        }
        public int Id { get; private set; }
        public OrganizationType OrganizationType { get; private set; }
        public string OrganizationTypeDescription => GetOrganizationTypeDescription();
        public string Description { get; private set; }
        public string Details { get; private set; }
        public ReportingFrequency ReportingFrequency { get; private set; }
        public string ReportingFrequencyDescription => GetReportingFrequencyDescription();
        public EntityReference Parent { get; private set; }
        public string ParentDescription => GetParentDescription();
        public DateTime Timestamp { get; private set; }
        public IEnumerable<OrganizationReference> ManagedOrganizations => _managedOrganizations;
        private readonly ICollection<OrganizationReference> _managedOrganizations;
        public void AddOrganizationReference(OrganizationReference organizationReference)
        {
            if (organizationReference == null) throw new ArgumentNullException(nameof(organizationReference));
            _managedOrganizations.Add(organizationReference);
        }

        public static implicit operator OrganizationReference(OrganizationViewModel organization)
        {
            return new OrganizationReference(organization.Id, organization.OrganizationType, organization.Description, organization.Details, organization.ReportingFrequency);
        }

        private string GetReportingFrequencyDescription()
        {
            return ReportingFrequency.ToString();
        }
        private string GetOrganizationTypeDescription()
        {
            return OrganizationType.ToString();
        }

        private static EntityReference Root = new EntityReference(0, "Root");

        private string GetParentDescription()
        {
            if (Parent.Description == Root.Description)
                return "";
            return Parent.Description;
        }

    }
}