using NServiceBus;

namespace ReportingModule.Events
{
    public interface IOrganizationUpdateFailed : IEvent
    {
        string[] Errors { get; set; }
    }
}