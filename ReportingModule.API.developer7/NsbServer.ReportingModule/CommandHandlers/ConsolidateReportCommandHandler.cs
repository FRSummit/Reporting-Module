using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.Core;
using ReportingModule.Core.Nsb7;
using ReportingModule.Events;
using ReportingModule.Services;
using ReportingModule.ValueObjects;

namespace ReportingModule.CommandHandlers
{
    public class ConsolidateReportCommandHandler : IHandleMessages<ConsolidateReportCommand>
    {
        private readonly IConsolidatedReportService _consolidatedReportService;

        public ConsolidateReportCommandHandler(IConsolidatedReportService consolidatedReportService)
        {
            _consolidatedReportService = consolidatedReportService;
        }

        public Task Handle(ConsolidateReportCommand message, IMessageHandlerContext context)
        {
            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<ConsolidateReportCommand, string>()
                .Bind(o => Validate(o))
                .Map(msg => _consolidatedReportService.GetConsolidatedReportData(message.ReportIds))
                .Handle(reportData => HandleSuccess(username, message.ReportIds, reportData, context), errors => HandleFailure(errors, context));
        }

        private Task HandleSuccess(string username, int[] reportIds, ReportData reportData, IMessageHandlerContext context)
        {
            
            return context.Publish<IConsolidateReportSucceeded>(e =>
            {
                e.Username = username;
                e.ReportIds = reportIds;
                e.ReportData = reportData;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IConsolidateReportFailed>(e =>
            {
                e.Errors = errors;
            });
        }

        private Result<ConsolidateReportCommand, string[]> Validate(ConsolidateReportCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<ConsolidateReportCommand, string[]>.Failed(enumerable.ToArray())
                : Result<ConsolidateReportCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(ConsolidateReportCommand message)
        {
            var errors = new List<string>();
            
            if (!message.ReportIds.Any())
                errors.Add($"Unable to consolidate. Invalid ReportIds");
            if (message.ReportIds.Length == 1)
                errors.Add("Nothing to consolidate. Only one report found");

            return errors;
        }

    }
}