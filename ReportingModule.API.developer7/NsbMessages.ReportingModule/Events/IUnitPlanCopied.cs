﻿using NServiceBus;
using ReportingModule.Core;
using ReportingModule.ValueObjects;

namespace ReportingModule.Events
{
    public interface IUnitPlanCopied : IEvent
    {
        string Username { get; set; }
        EntityReference UnitReport { get; set; }
        OrganizationReference Organization { get; set; }
        string SerializedData { get; set; }
        
    }
}