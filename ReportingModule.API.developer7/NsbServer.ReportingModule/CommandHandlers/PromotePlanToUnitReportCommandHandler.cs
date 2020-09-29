using NHibernate;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.Events;
using ReportingModule.Services;
using System.Linq;
using System.Threading.Tasks;
using ReportingModule.Core;
using ReportingModule.Core.Nsb7;
using ReportingModule.Entities;
using ReportingModule.Utility;
using ReportingModule.ValueObjects;

namespace ReportingModule.CommandHandlers
{
    public class PromotePlanToUnitReportCommandHandler : IHandleMessages<PromotePlanToUnitReportCommand>
    {
        private readonly IUnitReportService _unitReportService;
        private readonly ISession _session;
        public PromotePlanToUnitReportCommandHandler(IUnitReportService unitReportService, ISession session)
        {
            _unitReportService = unitReportService;
            _session = session;
        }

        public Task Handle(PromotePlanToUnitReportCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<PromotePlanToUnitReportCommand, string>()
                .Bind(msg =>
                {
                    var plan = _session.Query<UnitReport>().Single(o => o.Id == msg.PlanId);
                    if (plan.ReportStatus >= ReportStatus.PlanPromoted)
                        return Result<UnitReport, string[]>.Succeeded(plan);
                    if (plan.ReportStatus == ReportStatus.Draft)
                    {
                        var promotedPlan = _unitReportService.PromotePlanToUnitReport(msg.PlanId);
                        return Result<UnitReport, string[]>.Succeeded(promotedPlan);
                    }

                    return Result<UnitReport, string[]>.Failed(new[] { "Invalid plan status" });
                })
                .Handle(unitReport => HandleSuccess(username,
                        unitReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, UnitReport unitReport, IMessageHandlerContext context)
        {
            var data = unitReport.SerializeMessage();

            return context.Publish<IUnitPlanPromoted>(e =>
            {
                e.Username = username;
                e.Organization = unitReport.Organization;
                e.UnitReport = unitReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IUnitPlanPromoteFailed>(e =>
            {
                e.Errors = errors;
            });
        }
    }
}