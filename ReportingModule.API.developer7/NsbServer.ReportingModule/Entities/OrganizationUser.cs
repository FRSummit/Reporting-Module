using System;
using System.Diagnostics.CodeAnalysis;
using ReportingModule.Core;
using ReportingModule.Core.Domains;
using ReportingModule.Utility;

namespace ReportingModule.Entities
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class OrganizationUser : IAggregate<int>
    {
        protected OrganizationUser()
        {
            
        }

        public OrganizationUser(string username, string role, EntityReference organization)
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(role));
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(username));
            Username = username;
            Role = role;
            Organization = organization ?? throw new ArgumentNullException(nameof(organization));
            Timestamp = ZaphodTime.UtcNow;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
        public EntityReference Organization { get; private set; }
        public string Role { get; private set; }
        public DateTime Timestamp { get; private set; }
        public bool IsDeleted { get; private set; }

        public void MarkAsDelete()
        {
            IsDeleted = true;
            Timestamp = ZaphodTime.UtcNow;
        }

        

        public void Update(
            string role
            )
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(role));
            Role = role;
            Timestamp = ZaphodTime.UtcNow;
        }
    }
}