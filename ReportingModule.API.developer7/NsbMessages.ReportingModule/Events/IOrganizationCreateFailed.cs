using NServiceBus;

namespace ReportingModule.Events
{
    public interface IOrganizationCreateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}