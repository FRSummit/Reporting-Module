using NServiceBus;
using ReportingModule.Core;

namespace ReportingModule.Events
{
    public interface IOrganizationUserDeleted : IEvent
    {
        string Username { get; set; }
        EntityReference OrganizationUser { get; set; }
        string SerializedData { get; set; }
    }
}