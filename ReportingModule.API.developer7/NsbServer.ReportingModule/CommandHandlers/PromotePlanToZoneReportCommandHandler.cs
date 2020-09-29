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
    public class PromotePlanToZoneReportCommandHandler : IHandleMessages<PromotePlanToZoneReportCommand>
    {
        private readonly IZoneReportService _zoneReportService;
        private readonly ISession _session;
        public PromotePlanToZoneReportCommandHandler(IZoneReportService zoneReportService, ISession session)
        {
            _zoneReportService = zoneReportService;
            _session = session;
        }

        public Task Handle(PromotePlanToZoneReportCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<PromotePlanToZoneReportCommand, string>()
                .Bind(msg =>
                {
                    var plan = _session.Query<ZoneReport>().Single(o => o.Id == msg.PlanId);
                    if (plan.ReportStatus >= ReportStatus.PlanPromoted)
                        return Result<ZoneReport, string[]>.Succeeded(plan);
                    if (plan.ReportStatus == ReportStatus.Draft)
                    {
                        var promotedPlan = _zoneReportService.PromotePlanToZoneReport(msg.PlanId);
                        return Result<ZoneReport, string[]>.Succeeded(promotedPlan);
                    }

                    return Result<ZoneReport, string[]>.Failed(new[] { "Invalid plan status" });
                })
                .Handle(zoneReport => HandleSuccess(username,
                        zoneReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, ZoneReport zoneReport, IMessageHandlerContext context)
        {
            var data = zoneReport.SerializeMessage();

            return context.Publish<IZonePlanPromoted>(e =>
            {
                e.Username = username;
                e.Organization = zoneReport.Organization;
                e.ZoneReport = zoneReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IZonePlanPromoteFailed>(e =>
            {
                e.Errors = errors;
            });
        }
    }
}