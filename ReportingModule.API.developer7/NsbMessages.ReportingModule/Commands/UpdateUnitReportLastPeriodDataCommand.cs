using System;
using NServiceBus;
using ReportingModule.ValueObjects;

namespace ReportingModule.Commands
{
    public class UpdateUnitReportLastPeriodDataCommand : ICommand
    {
        public UpdateUnitReportLastPeriodDataCommand(int reportId,
            ReportLastPeriodUpdateData lastPeriodUpdateData)
        {
            
            ReportId = reportId;
            LastPeriodUpdateData = lastPeriodUpdateData ?? throw new ArgumentNullException(nameof(lastPeriodUpdateData));
        }

        public int ReportId { get; private set; }
        public ReportLastPeriodUpdateData LastPeriodUpdateData { get; private set; }
    }
}