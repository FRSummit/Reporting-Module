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
    public class PromotePlanToCentralReportCommandHandler : IHandleMessages<PromotePlanToCentralReportCommand>
    {
        private readonly ICentralReportService _centralReportService;
        private readonly ISession _session;
        public PromotePlanToCentralReportCommandHandler(ICentralReportService centralReportService, ISession session)
        {
            _centralReportService = centralReportService;
            _session = session;
        }

        public Task Handle(PromotePlanToCentralReportCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<PromotePlanToCentralReportCommand, string>()
                .Bind(msg =>
                {
                    var plan = _session.Query<CentralReport>().Single(o => o.Id == msg.PlanId);
                    if (plan.ReportStatus >= ReportStatus.PlanPromoted)
                        return Result<CentralReport, string[]>.Succeeded(plan);
                    if (plan.ReportStatus == ReportStatus.Draft)
                    {
                        var promotedPlan = _centralReportService.PromotePlanToCentralReport(msg.PlanId);
                        return Result<CentralReport, string[]>.Succeeded(promotedPlan);
                    }

                    return Result<CentralReport, string[]>.Failed(new[] { "Invalid plan status" });
                })
                .Handle(centralReport => HandleSuccess(username, centralReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, CentralReport centralReport, IMessageHandlerContext context)
        {
            var data = centralReport.SerializeMessage();

            return context.Publish<ICentralPlanPromoted>(e =>
            {
                e.Username = username;
                e.Organization = centralReport.Organization;
                e.CentralReport = centralReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<ICentralPlanPromoteFailed>(e =>
            {
                e.Errors = errors;
            });
        }
    }
}