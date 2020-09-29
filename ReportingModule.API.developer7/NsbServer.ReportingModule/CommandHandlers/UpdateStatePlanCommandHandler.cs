using System.Threading.Tasks;
using NHibernate;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.Core;
using ReportingModule.Core.Nsb7;
using ReportingModule.Entities;
using ReportingModule.Events;
using ReportingModule.Utility;
using ReportingModule.ValueObjects;

namespace ReportingModule.CommandHandlers
{
    public class UpdateStatePlanCommandHandler : IHandleMessages<UpdateStatePlanCommand>
    {
        private readonly ISession _session;

        public UpdateStatePlanCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(UpdateStatePlanCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<UpdateStatePlanCommand, string>()
                .Bind(msg =>
                    {
                        var stateReport = _session.Get<StateReport>(msg.ReportId);
                        if (stateReport!=null && stateReport.Organization.OrganizationType == OrganizationType.State && stateReport.ReportStatus >= ReportStatus.Draft)
                        {
                            stateReport.UpdatePlan(msg.PlanData);
                            _session.Save(stateReport);
                            return Result<StateReport, string[]>.Succeeded( stateReport);
                        }

                        return Result<StateReport, string[]>.Failed(new[] {"Invalid plan"});
                    }
                )
                .Handle(stateReport => HandleSuccess(username,
                        stateReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, StateReport stateReport, IMessageHandlerContext context)
        {
            var data = stateReport.SerializeMessage();

            return context.Publish<IStatePlanUpdated>(e =>
            {
                e.Username = username;
                e.Organization = stateReport.Organization;
                e.StateReport = stateReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IStatePlanUpdateFailed>(e =>
            {
                e.Errors = errors;
            });
        }
    }
}