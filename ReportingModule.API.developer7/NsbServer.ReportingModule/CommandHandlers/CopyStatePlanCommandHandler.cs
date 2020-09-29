using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.Core;
using ReportingModule.Core.Nsb7;
using ReportingModule.Entities;
using ReportingModule.Events;
using ReportingModule.Services;
using ReportingModule.Utility;
using ReportingModule.ValueObjects;

namespace ReportingModule.CommandHandlers
{
    public class CopyStatePlanCommandHandler : IHandleMessages<CopyStatePlanCommand>
    {
        private readonly IStateReportFactory _stateReportFactory;
        private readonly ISession _session;
        public CopyStatePlanCommandHandler(IStateReportFactory stateReportFactory, ISession session)
        {
            _stateReportFactory = stateReportFactory;
            _session = session;
        }

        public Task Handle(CopyStatePlanCommand message, IMessageHandlerContext context)
        {
            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<CopyStatePlanCommand, string>()
                .Bind(Validate)
                .Map(msg => _stateReportFactory.CopyStatePlan(msg.Description, msg.CopyFromReportId, msg.Organization,
                    msg.ReportingTerm, msg.Year))
                .Handle(stateReport => HandleSuccess(username, stateReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, StateReport stateReport, IMessageHandlerContext context)
        {
            var data = stateReport.SerializeMessage();

            return context.Publish<IStatePlanCopied>(e =>
            {
                e.Username = username;
                e.Organization = stateReport.Organization;
                e.StateReport = stateReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IStatePlanCopyFailed>(e =>
            {
                e.Errors = errors;
            });
        }

        private Result<CopyStatePlanCommand, string[]> Validate(CopyStatePlanCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<CopyStatePlanCommand, string[]>.Failed(enumerable.ToArray())
                : Result<CopyStatePlanCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(CopyStatePlanCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Report>().FirstOrDefault(o => o.Organization.OrganizationType == OrganizationType.State &&
                                                     o.Organization.Id == message.Organization.Id &&
                                                     o.ReportingPeriod.ReportingFrequency == message.ReportingFrequency &&
                                                     o.ReportingPeriod.ReportingTerm == message.ReportingTerm &&
                                                     o.ReportingPeriod.Year == message.Year);
            if (existing != null)
                errors.Add($"Unable to copy plan. Plan exist {existing.Description}");

            var copyFrom = _session.Query<Report>().FirstOrDefault(o => o.Id == message.CopyFromReportId);
            if (copyFrom == null)
                errors.Add($"Unable to copy plan. Invalid Plan Id {message.CopyFromReportId}");
            if (copyFrom != null && copyFrom.Organization.Id != message.Organization.Id)
                errors.Add($"Unable to copy plan. Invalid organization {message.Organization.Description}");

            return errors;
        }

    }
}