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
    public class CreateOrganizationCommandHandler : IHandleMessages<CreateOrganizationCommand>
    {
        private readonly ISession _session;
        public CreateOrganizationCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(CreateOrganizationCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization and ReportingTerm whether created already for this term

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<CreateOrganizationCommand, string>()
                .Bind(Validate)
                .Map(msg =>
                {
                    var org = new Organization(message.Description, message.Details, message.OrganizationType, message.ReportingFrequency, message.Parent);
                    _session.Save(org);
                    return org;

                })
                .Handle(org => HandleSuccess(username, org, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, Organization org, IMessageHandlerContext context)
        {
            var data = org.SerializeMessage();

            return context.Publish<IOrganizationCreated>(e =>
            {
                e.Username = username;
                e.Organization = org;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IOrganizationCreateFailed>(e => { e.Errors = errors; });
        }

        private Result<CreateOrganizationCommand, string[]> Validate(CreateOrganizationCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<CreateOrganizationCommand, string[]>.Failed(enumerable.ToArray())
                : Result<CreateOrganizationCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(CreateOrganizationCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Organization>().FirstOrDefault(o => o.OrganizationType == message.OrganizationType &&
                                                         o.Description == message.Description
                                                         && o.Parent == message.Parent);
            if (existing != null)
                errors.Add($"Unable to create organization. Organization exist {existing.Description}");
            return errors;
        }


    }
}