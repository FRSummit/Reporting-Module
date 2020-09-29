using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.Entities;

namespace ReportingModule.CommandHandlers
{
    public class UpdateOrganizationUserCommandHandler : IHandleMessages<UpdateOrganizationUserCommand>
    {
        private readonly ISession _session;
        public UpdateOrganizationUserCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(UpdateOrganizationUserCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items

            var existingOrganizationUser = _session
                .Query<OrganizationUser>()
                .Single(o => o.Username == message.Username && o.Role == message.ExistingRole &&
                                     o.Organization.Id == message.Organization.Id);
            var organization = _session.Query<Organization>()
                .Single(o => o.Id == message.Organization.Id);

            if (existingOrganizationUser != null && organization != null)
            {
                existingOrganizationUser.Update(message.NewRole);
                _session.Save(existingOrganizationUser);
            }

            return Task.CompletedTask;
        }

    }
}