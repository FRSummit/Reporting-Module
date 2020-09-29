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
    public class DeleteOrganizationUserCommandHandler : IHandleMessages<DeleteOrganizationUserCommand>
    {
        private readonly ISession _session;

        public DeleteOrganizationUserCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(DeleteOrganizationUserCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization and ReportingTerm whether created already for this term

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<DeleteOrganizationUserCommand, string>()
                .Bind(Validate)
                .Map(msg =>
                {
                    var organizationUser = _session.Get<OrganizationUser>(message.OrganizationUserId);
                    organizationUser.MarkAsDelete();
                    _session.Save(organizationUser);

                    return organizationUser;

                })
                .Handle(org => HandleSuccess(username, org, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, OrganizationUser organizationUser, IMessageHandlerContext context)
        {
            var data = organizationUser.SerializeMessage();

            return context.Publish<IOrganizationUserDeleted>(e =>
            {
                e.Username = username;
                e.OrganizationUser = new EntityReference(organizationUser.Id, organizationUser.Username);
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IOrganizationUserDeleteFailed>(e => { e.Errors = errors; });
        }

        private Result<DeleteOrganizationUserCommand, string[]> Validate(DeleteOrganizationUserCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<DeleteOrganizationUserCommand, string[]>.Failed(enumerable.ToArray())
                : Result<DeleteOrganizationUserCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(DeleteOrganizationUserCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<OrganizationUser>().FirstOrDefault(o => o.Id == message.OrganizationUserId);
            if (existing == null)
                errors.Add($"Unable to delete organization user. Organization user does not exist");

            return errors;
        }
    }
}