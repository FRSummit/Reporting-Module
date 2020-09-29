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
    public class CopyZonePlanCommandHandler : IHandleMessages<CopyZonePlanCommand>
    {
        private readonly IZoneReportFactory _zoneReportFactory;
        private readonly ISession _session;
        public CopyZonePlanCommandHandler(IZoneReportFactory zoneReportFactory, ISession session)
        {
            _zoneReportFactory = zoneReportFactory;
            _session = session;
        }

        public Task Handle(CopyZonePlanCommand message, IMessageHandlerContext context)
        {
            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<CopyZonePlanCommand, string>()
                .Bind(Validate)
                .Map(msg => _zoneReportFactory.CopyZonePlan(msg.Description, msg.CopyFromReportId, msg.Organization,
                    msg.ReportingTerm, msg.Year))
                .Handle(zoneReport => HandleSuccess(username, zoneReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, ZoneReport zoneReport, IMessageHandlerContext context)
        {
            var data = zoneReport.SerializeMessage();

            return context.Publish<IZonePlanCopied>(e =>
            {
                e.Username = username;
                e.Organization = zoneReport.Organization;
                e.ZoneReport = zoneReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IZonePlanCopyFailed>(e =>
            {
                e.Errors = errors;
            });
        }

        private Result<CopyZonePlanCommand, string[]> Validate(CopyZonePlanCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<CopyZonePlanCommand, string[]>.Failed(enumerable.ToArray())
                : Result<CopyZonePlanCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(CopyZonePlanCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Report>().FirstOrDefault(o => o.Organization.OrganizationType == OrganizationType.Zone &&
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