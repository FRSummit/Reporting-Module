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
    public class CreateCentralPlanCommandHandler : IHandleMessages<CreateCentralPlanCommand>
    {
        private readonly ICentralReportFactory _centralReportFactory;
        private readonly ISession _session;
        public CreateCentralPlanCommandHandler(ICentralReportFactory centralReportFactory, ISession session)
        {
            _centralReportFactory = centralReportFactory;
            _session = session;
        }

        public Task Handle(CreateCentralPlanCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization and ReportingTerm whether created already for this term

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<CreateCentralPlanCommand, string>()
                .Bind(Validate)
                .Map(msg => _centralReportFactory.CreateNewCentralPlan(msg.Description, msg.Organization,
                    msg.ReportingTerm, msg.Year, msg.ReportingFrequency))
                .Handle(centralReport => HandleSuccess(username, centralReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, CentralReport centralReport, IMessageHandlerContext context)
        {
            var data = centralReport.SerializeMessage();

            return context.Publish<ICentralPlanCreated>(e =>
            {
                e.Username = username;
                e.Organization = centralReport.Organization;
                e.CentralReport = centralReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<ICentralPlanCreateFailed>(e =>
            {
                e.Errors = errors;
            });
        }

        private Result<CreateCentralPlanCommand, string[]> Validate(CreateCentralPlanCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<CreateCentralPlanCommand, string[]>.Failed(enumerable.ToArray())
                : Result<CreateCentralPlanCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(CreateCentralPlanCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Report>().FirstOrDefault(o => o.Organization.OrganizationType == OrganizationType.Central &&
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