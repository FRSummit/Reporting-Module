using NServiceBus;

namespace ReportingModule.Events
{
    public interface IOrganizationDeleteFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}