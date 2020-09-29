using System;
using ReportingModule.Core.Domains;
using ReportingModule.ValueObjects;
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace ReportingModule.Entities
{
    public class ReportEventLog : IAggregate<int>
    {
        protected ReportEventLog()
        { }

        public ReportEventLog(string messageType, string message, int? organizationId, int? reportId,  string createdByUsername, DateTime timestamp, ReportEventLogVisibility visibility = ReportEventLogVisibility.All)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
            if (string.IsNullOrWhiteSpace(messageType))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(messageType));
            OrganizationId = organizationId;
            ReportId = reportId;
            MessageType = messageType;
            Message = message;
            CreatedByUsername = createdByUsername;
            Timestamp = timestamp;
            Visibility = visibility;
        }

        public int Id { get; private set; }
        public int? OrganizationId { get; private set; }
        public int? ReportId { get; private set; }
        public string MessageType { get; private set; }
        public string Message { get; private set; }
        public string CreatedByUsername { get; private set; }
        public ReportEventLogVisibility Visibility { get; private set; }
        public DateTime Timestamp { get; private set; }
    }
}
