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
    public class CreateStatePlanCommandHandler : IHandleMessages<CreateStatePlanCommand>
    {
        private readonly IStateReportFactory _stateReportFactory;
        private readonly ISession _session;
        public CreateStatePlanCommandHandler(IStateReportFactory stateReportFactory, ISession session)
        {
            _stateReportFactory = stateReportFactory;
            _session = session;
        }

        public Task Handle(CreateStatePlanCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization and ReportingTerm whether created already for this term

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<CreateStatePlanCommand, string>()
                .Bind(Validate)
                .Map(msg => _stateReportFactory.CreateNewStatePlan(msg.Description, msg.Organization,
                    msg.ReportingTerm, msg.Year, message.ReportingFrequency))
                .Handle(stateReport => HandleSuccess(username, stateReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, StateReport stateReport, IMessageHandlerContext context)
        {
            var data = stateReport.SerializeMessage();

            return context.Publish<IStatePlanCreated>(e =>
            {
                e.Username = username;
                e.Organization = stateReport.Organization;
                e.StateReport = stateReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IStatePlanCreateFailed>(e =>
            {
                e.Errors = errors;
            });
        }

        private Result<CreateStatePlanCommand, string[]> Validate(CreateStatePlanCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<CreateStatePlanCommand, string[]>.Failed(enumerable.ToArray())
                : Result<CreateStatePlanCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(CreateStatePlanCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Report>().FirstOrDefault(o => o.Organization.OrganizationType == OrganizationType.State &&
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