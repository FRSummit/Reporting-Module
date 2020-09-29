using System;
using ReportingModule.ValueObjects;
using ICommand = NServiceBus.ICommand;

namespace ReportingModule.Commands
{
    public class UpdateUnitReportCommand : ICommand
    {
        public UpdateUnitReportCommand(int reportId,
            ReportUpdateData reportUpdateData)
        {
            
            ReportId = reportId;
            ReportUpdateData = reportUpdateData ?? throw new ArgumentNullException(nameof(reportUpdateData));
        }

        public int ReportId { get; private set; }
        public ReportUpdateData ReportUpdateData { get; private set; }
    }
}