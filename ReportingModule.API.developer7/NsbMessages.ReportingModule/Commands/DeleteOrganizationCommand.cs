using NServiceBus;

namespace ReportingModule.Commands
{
    public class DeleteOrganizationCommand : ICommand
    {
        public DeleteOrganizationCommand(int organizationId)
        {
            OrganizationId = organizationId;
        }

        public int OrganizationId { get; private set; }
    }
}