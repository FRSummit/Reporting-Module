using NServiceBus;
using ReportingModule.ValueObjects;

namespace ReportingModule.Events
{
    public interface IOrganizationUpdated : IEvent
    {
        string Username { get; set; }
        OrganizationReference Organization { get; set; }
        string SerializedData { get; set; }
    }
}