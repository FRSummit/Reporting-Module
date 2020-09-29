﻿using NServiceBus;
using ReportingModule.Core;
using ReportingModule.ValueObjects;

namespace ReportingModule.Events
{
    public interface IReportSubmitted : IEvent
    {
        string Username { get; set; }
        EntityReference Report { get; set; }
        OrganizationReference Organization { get; set; }
        string SerializedData { get; set; }
        
    }
}