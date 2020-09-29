﻿using NServiceBus;
using ReportingModule.Core;
using ReportingModule.ValueObjects;

namespace ReportingModule.Events
{
    public interface IStatePlanCopied : IEvent
    {
        string Username { get; set; }
        EntityReference StateReport { get; set; }
        OrganizationReference Organization { get; set; }
        string SerializedData { get; set; }
        
    }
}