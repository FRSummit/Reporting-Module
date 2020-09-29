using System;
using ReportingModule.Core;
using ICommand = NServiceBus.ICommand;

namespace ReportingModule.Commands
{
    public class UpdateOrganizationUserCommand : ICommand
    {
        public UpdateOrganizationUserCommand(string username,
            string existingRole,
            EntityReference organization,
            string newRole)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(username));
            if (string.IsNullOrWhiteSpace(existingRole))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(existingRole));
            if (string.IsNullOrWhiteSpace(newRole))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(newRole));
            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            Username = username;
            ExistingRole = existingRole;
            NewRole = newRole;
        }

        public string Username { get; private set; }
        public string ExistingRole { get; private set; }
        public string NewRole { get; private set; }
        public EntityReference Organization { get; private set; }

    }
}