using NServiceBus;

namespace ReportingModule.Commands
{
    public class DeleteOrganizationUserCommand : ICommand
    {
        public DeleteOrganizationUserCommand(int organizationUserId)
        {
            OrganizationUserId = organizationUserId;
        }

        public int OrganizationUserId { get; private set; }
    }
}