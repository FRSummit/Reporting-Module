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
    public class UpdateZoneReportCommandHandler : IHandleMessages<UpdateZoneReportCommand>
    {
        private readonly ISession _session;

        public UpdateZoneReportCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(UpdateZoneReportCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<UpdateZoneReportCommand, string>()
                .Bind(msg =>
                    {
                        var zoneReport = _session.Get<ZoneReport>(msg.ReportId);
                        if (zoneReport.ReportStatus >= ReportStatus.PlanPromoted)
                        {
                            zoneReport.Update(msg.ReportUpdateData);
                            _session.Save(zoneReport);
                            return Result<ZoneReport, string[]>.Succeeded(zoneReport);
                        }
                        return Result<ZoneReport, string[]>.Failed(new[] { "Ïnvalid report status" });
                    }
                )
                .Handle(zoneReport => HandleSuccess(username,
                        zoneReport, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, ZoneReport zoneReport, IMessageHandlerContext context)
        {
            var data = zoneReport.SerializeMessage();

            return context.Publish<IZoneReportUpdated>(e =>
            {
                e.Username = username;
                e.Organization = zoneReport.Organization;
                e.ZoneReport = zoneReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IZoneReportUpdateFailed>(e =>
            {
                e.Errors = errors;
            });
        }
    }
    
}