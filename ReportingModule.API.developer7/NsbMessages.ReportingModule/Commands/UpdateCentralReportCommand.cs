﻿using System;
using NServiceBus;
using ReportingModule.ValueObjects;

namespace ReportingModule.Commands
{
    public class UpdateCentralReportCommand : ICommand
    {
        public UpdateCentralReportCommand(int reportId,
            ReportUpdateData reportUpdateData)
        {

            ReportId = reportId;
            ReportUpdateData = reportUpdateData ?? throw new ArgumentNullException(nameof(reportUpdateData));
        }

        public int ReportId { get; private set; }
        public ReportUpdateData ReportUpdateData { get; private set; }
    }
}