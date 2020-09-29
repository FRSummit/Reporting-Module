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
    public class CreateUnitPlanCommandHandler : IHandleMessages<CreateUnitPlanCommand>
    {
        private readonly IUnitReportFactory _unitReportFactory;
        private readonly ISession _session;
        public CreateUnitPlanCommandHandler(IUnitReportFactory unitReportFactory, ISession session)
        {
            _unitReportFactory = unitReportFactory;
            _session = session;
        }

        public Task Handle(CreateUnitPlanCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization and ReportingTerm whether created already for this term

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<CreateUnitPlanCommand, string>()
                .Bind(Validate)
                .Map(msg => _unitReportFactory.CreateNewUnitPlan(msg.Description, msg.Organization,
                    msg.ReportingTerm, msg.Year, msg.ReportingFrequency))
                .Handle(unitReport => HandleSuccess(username, unitReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, UnitReport unitReport, IMessageHandlerContext context)
        {
            var data = unitReport.SerializeMessage();

            return context.Publish<IUnitPlanCreated>(e =>
            {
                e.Username = username;
                e.Organization = unitReport.Organization;
                e.UnitReport = unitReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IUnitPlanCreateFailed>(e =>
            {
                e.Errors = errors;
            });
        }

        private Result<CreateUnitPlanCommand, string[]> Validate(CreateUnitPlanCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<CreateUnitPlanCommand, string[]>.Failed(enumerable.ToArray())
                : Result<CreateUnitPlanCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(CreateUnitPlanCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Report>().FirstOrDefault(o => o.Organization.OrganizationType == OrganizationType.Unit &&
                                                         o.Organization.Id == message.Organization.Id &&
                                                         o.ReportingPeriod.ReportingTerm == message.ReportingTerm &&
                                                         o.ReportingPeriod.Year == message.Year);
            if (existing != null)
                errors.Add($"Unable to create plan. Plan exist {existing.Description}");
            return errors;
        }

    }
}