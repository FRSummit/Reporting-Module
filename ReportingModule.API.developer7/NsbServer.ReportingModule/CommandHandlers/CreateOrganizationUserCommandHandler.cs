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
    public class CreateOrganizationUserCommandHandler : IHandleMessages<CreateOrganizationUserCommand>
    {
        private readonly ISession _session;
        public CreateOrganizationUserCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(CreateOrganizationUserCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization and ReportingTerm whether created already for this term

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<CreateOrganizationUserCommand, string>()
                .Bind(Validate)
                .Map(msg =>
                {
                    var newOrganizationUser = new OrganizationUser(message.Username, message.Role, message.Organization);
                    _session.Save(newOrganizationUser);
                    
                    return newOrganizationUser;

                })
                .Handle(orgUser => HandleSuccess(username, orgUser, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, OrganizationUser orgUser, IMessageHandlerContext context)
        {
            var data = orgUser.SerializeMessage();

            return context.Publish<IOrganizationUserCreated>(e =>
            {
                e.Username = username;
                e.OrganizationUser = new EntityReference(orgUser.Id, orgUser.Username);
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IOrganizationUserCreateFailed>(e => { e.Errors = errors; });
        }

        private Result<CreateOrganizationUserCommand, string[]> Validate(CreateOrganizationUserCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<CreateOrganizationUserCommand, string[]>.Failed(enumerable.ToArray())
                : Result<CreateOrganizationUserCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(CreateOrganizationUserCommand message)
        {
            var errors = new List<string>();

            var existingOrganizationUser = _session
                .Query<OrganizationUser>()
                .SingleOrDefault(o => o.Username == message.Username && o.Role == message.Role &&
                                      o.Organization.Id == message.Organization.Id);
            if (existingOrganizationUser != null)
                errors.Add($"Unable to create user. User already exist {existingOrganizationUser.Username}");

            var existingOrganization = _session.Query<Organization>()
                .FirstOrDefault(o => o.Id == message.Organization.Id);
            if (existingOrganization == null)
                errors.Add($"Unable to create user. Organization not found");

            return errors;
        }


    }
}