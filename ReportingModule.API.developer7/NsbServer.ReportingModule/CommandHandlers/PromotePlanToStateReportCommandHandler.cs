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
    public class PromotePlanToStateReportCommandHandler : IHandleMessages<PromotePlanToStateReportCommand>
    {
        private readonly IStateReportService _stateReportService;
        private readonly ISession _session;
        public PromotePlanToStateReportCommandHandler(IStateReportService stateReportService, ISession session)
        {
            _stateReportService = stateReportService;
            _session = session;
        }

        public Task Handle(PromotePlanToStateReportCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<PromotePlanToStateReportCommand, string>()
                .Bind(msg =>
                {
                    var plan = _session.Query<StateReport>().Single(o => o.Id == msg.PlanId);
                    if (plan.ReportStatus >= ReportStatus.PlanPromoted)
                        return Result<StateReport, string[]>.Succeeded(plan);
                    if (plan.ReportStatus == ReportStatus.Draft)
                    {
                        var promotedPlan = _stateReportService.PromotePlanToStateReport(msg.PlanId);
                        return Result<StateReport, string[]>.Succeeded(promotedPlan);
                    }

                    return Result<StateReport, string[]>.Failed(new[] { "Invalid plan status" });
                })
                .Handle(stateReport => HandleSuccess(username,
                        stateReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, StateReport stateReport, IMessageHandlerContext context)
        {
            var data = stateReport.SerializeMessage();

            return context.Publish<IStatePlanPromoted>(e =>
            {
                e.Username = username;
                e.Organization = stateReport.Organization;
                e.StateReport = stateReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IStatePlanPromoteFailed>(e =>
            {
                e.Errors = errors;
            });
        }
    }
}