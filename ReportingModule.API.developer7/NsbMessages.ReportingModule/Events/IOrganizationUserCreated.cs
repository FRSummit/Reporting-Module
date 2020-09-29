using NServiceBus;
using ReportingModule.Core;

namespace ReportingModule.Events
{
    public interface IOrganizationUserCreated : IEvent
    {
        string Username { get; set; }
        EntityReference OrganizationUser{ get; set; }
        string SerializedData { get; set; }
    }
}