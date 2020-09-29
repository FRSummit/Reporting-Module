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
    public class UpdateCentralPlanCommandHandler : IHandleMessages<UpdateCentralPlanCommand>
    {
        private readonly ISession _session;

        public UpdateCentralPlanCommandHandler(ISession session)
        {
            _session = session;
        }


        public Task Handle(UpdateCentralPlanCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<UpdateCentralPlanCommand, string>()
                .Bind(msg =>
                    {
                        var centralReport = _session.Get<CentralReport>(msg.ReportId);
                        if (centralReport!=null && centralReport.Organization.OrganizationType == OrganizationType.Central && centralReport.ReportStatus >= ReportStatus.Draft)
                        {
                            centralReport.UpdatePlan(msg.PlanData);
                            _session.Save(centralReport);
                            return Result<CentralReport, string[]>.Succeeded( centralReport);
                        }

                        return Result<CentralReport, string[]>.Failed(new[] {"Invalid plan"});
                    }
                )
                .Handle(centralReport => HandleSuccess(username,
                        centralReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, CentralReport centralReport, IMessageHandlerContext context)
        {
            var data = centralReport.SerializeMessage();

            return context.Publish<ICentralPlanUpdated>(e =>
            {
                e.Username = username;
                e.Organization = centralReport.Organization;
                e.CentralReport = centralReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<ICentralPlanUpdateFailed>(e =>
            {
                e.Errors = errors;
            });
        }
    }
}