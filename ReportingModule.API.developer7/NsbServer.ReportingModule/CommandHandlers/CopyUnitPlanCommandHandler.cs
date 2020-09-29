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
    public class CopyUnitPlanCommandHandler : IHandleMessages<CopyUnitPlanCommand>
    {
        private readonly IUnitReportFactory _unitReportFactory;
        private readonly ISession _session;
        public CopyUnitPlanCommandHandler(IUnitReportFactory unitReportFactory, ISession session)
        {
            _unitReportFactory = unitReportFactory;
            _session = session;
        }

        public Task Handle(CopyUnitPlanCommand message, IMessageHandlerContext context)
        {
            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<CopyUnitPlanCommand, string>()
                .Bind(Validate)
                .Map(msg => _unitReportFactory.CopyUnitPlan(msg.Description, msg.CopyFromReportId, msg.Organization,
                    msg.ReportingTerm, msg.Year))
                .Handle(unitReport => HandleSuccess(username, unitReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, UnitReport unitReport, IMessageHandlerContext context)
        {
            var data = unitReport.SerializeMessage();

            return context.Publish<IUnitPlanCopied>(e =>
            {
                e.Username = username;
                e.Organization = unitReport.Organization;
                e.UnitReport = unitReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IUnitPlanCopyFailed>(e =>
            {
                e.Errors = errors;
            });
        }

        private Result<CopyUnitPlanCommand, string[]> Validate(CopyUnitPlanCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<CopyUnitPlanCommand, string[]>.Failed(enumerable.ToArray())
                : Result<CopyUnitPlanCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(CopyUnitPlanCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Report>().FirstOrDefault(o => o.Organization.OrganizationType == OrganizationType.Unit &&
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