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
    public class UpdateOrganizationCommandHandler : IHandleMessages<UpdateOrganizationCommand>
    {
        private readonly ISession _session;

        public UpdateOrganizationCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(UpdateOrganizationCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization and ReportingTerm whether created already for this term

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<UpdateOrganizationCommand, string>()
                .Bind(Validate)
                .Map(msg =>
                {
                    var org = _session.Get<Organization>(msg.OrganizationId);
                    if (org.Description != msg.Description)
                        org.SetDescription(msg.Description);
                    if (org.Details != msg.Details)
                        org.SetDetails(msg.Details);
                    if (org.ReportingFrequency != msg.ReportingFrequency)
                        org.SetReportingFrequency(msg.ReportingFrequency);
                    if (org.OrganizationType != msg.OrganizationType)
                        org.SetOrganizationType(msg.OrganizationType);
                    if (org.Parent != msg.Parent)
                        org.SetParent(msg.Parent);
                    _session.Save(org);
                    return org;

                })
                .Handle(org => HandleSuccess(username, org, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, Organization org, IMessageHandlerContext context)
        {
            var data = org.SerializeMessage();

            return context.Publish<IOrganizationUpdated>(e =>
            {
                e.Username = username;
                e.Organization = org;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IOrganizationUpdateFailed>(e => { e.Errors = errors; });
        }

        private Result<UpdateOrganizationCommand, string[]> Validate(UpdateOrganizationCommand message)
        {
            var validationErrors = ValidateInternal(message);
            var enumerable = validationErrors as string[] ?? validationErrors.ToArray();
            return enumerable.Any()
                ? Result<UpdateOrganizationCommand, string[]>.Failed(enumerable.ToArray())
                : Result<UpdateOrganizationCommand, string[]>.Succeeded(message);
        }

        protected internal IEnumerable<string> ValidateInternal(UpdateOrganizationCommand message)
        {
            var errors = new List<string>();

            var existing = _session
                .Query<Organization>().FirstOrDefault(o => o.Id == message.OrganizationId);
            if (existing == null)
                errors.Add($"Unable to create organization. Organization do not exist {message.Description}");

            if (message.Parent.Id == message.OrganizationId)
                errors.Add($"unable to add same organization as Parent organization");

            return errors;
        }


    }
}