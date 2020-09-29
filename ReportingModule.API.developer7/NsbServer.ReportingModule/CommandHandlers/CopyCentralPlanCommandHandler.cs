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
    public class CopyCentralPlanCommandHandler : IHandleMessages<CopyCentralPlanCommand>
    {
        private readonly ICentralReportFactory _centralReportFactory;
        private readonly ISession _session;
        public CopyCentralPlanCommandHandler(ICentralReportFactory centralReportFactory, ISession session)
        {
            _centralReportFactory = centralReportFactory;
            _session = session;
        }

        public Task Handle(CopyCentralPlanCommand message, IMessageHandlerContext context)
        {
            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<CopyCentralPlanCommand, string>()
                .Bind(Validate)
                .Map(msg => _centralReportFactory.CopyCentralPlan(msg.Description, msg.CopyFromReportId, msg.Organization,
                    msg.ReportingTerm, msg.Year))
                .Handle(centralReport => HandleSuccess(username, centralReport, context), errors =>  HandleFailure(errors, context));
        }

        private Task HandleSuccess(string username, CentralReport centralReport, IMessageHandlerContext context)
        {
            var data = centralReport.SerializeMessage();

            return context.Publish<ICentralPlanCopied>(e =>
            {
                e.Username = username;
                e.Organization = centralReport.Organization;
                e.CentralReport = centralReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<ICentralPlanCopyFailed>(e =>
            {
                e.Errors = errors;
            });
        }

        private Result<CopyCentralPlanCommand, string[]> Validate(CopyCentralPlanCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<CopyCentralPlanCommand, string[]>.Failed(enumerable.ToArray())
                : Result<CopyCentralPlanCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(CopyCentralPlanCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Report>().FirstOrDefault(o => o.Organization.OrganizationType == OrganizationType.Central &&
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