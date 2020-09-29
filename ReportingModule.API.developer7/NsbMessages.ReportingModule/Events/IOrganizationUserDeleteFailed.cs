using NServiceBus;

namespace ReportingModule.Events
{
    public interface IOrganizationUserDeleteFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}