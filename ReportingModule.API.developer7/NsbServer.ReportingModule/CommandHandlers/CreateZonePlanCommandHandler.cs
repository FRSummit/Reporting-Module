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
    public class CreateZonePlanCommandHandler : IHandleMessages<CreateZonePlanCommand>
    {
        private readonly IZoneReportFactory _zoneReportFactory;
        private readonly ISession _session;
        public CreateZonePlanCommandHandler(IZoneReportFactory zoneReportFactory, ISession session)
        {
            _zoneReportFactory = zoneReportFactory;
            _session = session;
        }

        public Task Handle(CreateZonePlanCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization and ReportingTerm whether created already for this term

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<CreateZonePlanCommand, string>()
                .Bind(Validate)
                .Map(msg => _zoneReportFactory.CreateNewZonePlan(msg.Description, msg.Organization,
                    msg.ReportingTerm, msg.Year, msg.ReportingFrequency))
                .Handle(zoneReport => HandleSuccess(username, zoneReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, ZoneReport zoneReport, IMessageHandlerContext context)
        {
            var data = zoneReport.SerializeMessage();

            return context.Publish<IZonePlanCreated>(e =>
            {
                e.Username = username;
                e.Organization = zoneReport.Organization;
                e.ZoneReport = zoneReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IZonePlanCreateFailed>(e =>
            {
                e.Errors = errors;
            });
        }

        private Result<CreateZonePlanCommand, string[]> Validate(CreateZonePlanCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<CreateZonePlanCommand, string[]>.Failed(enumerable.ToArray())
                : Result<CreateZonePlanCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(CreateZonePlanCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Report>().FirstOrDefault(o => o.Organization.OrganizationType == OrganizationType.Zone &&
                                                         o.Organization.Id == message.Organization.Id &&
                                                         o.ReportingPeriod.ReportingFrequency == message.ReportingFrequency &&
                                                         o.ReportingPeriod.ReportingTerm == message.ReportingTerm &&
                                                          o.ReportingPeriod.Year == message.Year);
            if (existing != null)
                errors.Add($"Unable to create plan. Plan exist {existing.Description}");
            return errors;
        }
    }
}