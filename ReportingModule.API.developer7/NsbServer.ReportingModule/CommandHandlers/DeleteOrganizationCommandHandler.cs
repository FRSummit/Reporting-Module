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
using ReportingModule.Utility;

namespace ReportingModule.CommandHandlers
{
    public class DeleteOrganizationCommandHandler : IHandleMessages<DeleteOrganizationCommand>
    {
        private readonly ISession _session;

        public DeleteOrganizationCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(DeleteOrganizationCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization and ReportingTerm whether created already for this term

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<DeleteOrganizationCommand, string>()
                .Bind(Validate)
                .Map(msg =>
                {
                    var org = _session.Get<Organization>(message.OrganizationId);
                    org.MarkAsDelete();
                    _session.Save(org);

                    return org;

                })
                .Handle(org => HandleSuccess(username, org, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, Organization org, IMessageHandlerContext context)
        {
            var data = org.SerializeMessage();

            return context.Publish<IOrganizationDeleted>(e =>
            {
                e.Username = username;
                e.Organization = org;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IOrganizationDeleteFailed>(e => { e.Errors = errors; });
        }

        private Result<DeleteOrganizationCommand, string[]> Validate(DeleteOrganizationCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<DeleteOrganizationCommand, string[]>.Failed(enumerable.ToArray())
                : Result<DeleteOrganizationCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(DeleteOrganizationCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Organization>().FirstOrDefault(o => o.Id == message.OrganizationId);
            if (existing == null)
                errors.Add($"Unable to delete organization. Organization does not exist");

            var existingReport = _session.Query<Report>()
                .FirstOrDefault(o => o.Organization.Id == message.OrganizationId);

            if (existingReport != null)
                errors.Add($"Unable to delete organization. Existing reports found that belong to this organization");

            return errors;
        }


    }
}