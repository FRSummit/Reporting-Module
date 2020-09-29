using System;
using ReportingModule.Core;
using ICommand = NServiceBus.ICommand;

namespace ReportingModule.Commands
{
    public class CreateOrganizationUserCommand : ICommand
    {
        public CreateOrganizationUserCommand(string username,
            string role,
            EntityReference organization)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(username));
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(role));
            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            Username = username;
            Role = role;
        }

        public string Username { get; private set; }
        public string Role { get; private set; }
        public EntityReference Organization { get; private set; }

    }
}