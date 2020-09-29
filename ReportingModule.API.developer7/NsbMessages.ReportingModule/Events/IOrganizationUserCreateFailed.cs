using NServiceBus;

namespace ReportingModule.Events
{
    public interface IOrganizationUserCreateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}