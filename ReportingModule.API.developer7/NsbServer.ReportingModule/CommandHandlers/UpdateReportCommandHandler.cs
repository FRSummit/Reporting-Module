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
    //Not in use
    public class UpdateReportCommandHandler : IHandleMessages<UpdateReportCommand>
    {
        private readonly ISession _session;

        public UpdateReportCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(UpdateReportCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<UpdateReportCommand, string>()
                .Bind(msg =>
                    {
                        var organization = _session.Get<Organization>(message.Organization.Id);

                        var report = _session.Get<Report>(message.ReportId);
                        if (report.ReportStatus >= ReportStatus.Draft)
                        {
                            report.Update(message.Description,
                                message.Organization,
                                new ReportingPeriod(organization.ReportingFrequency, message.ReportingTerm, message.Year));
                            ;
                            _session.Save(report);
                            return Result<Report, string[]>.Succeeded(report);
                        }
                        return Result<Report, string[]>.Failed(new[] { "Ïnvalid report status" });
                    }
                )
                .Handle(report => HandleSuccess(username,
                        report, context), HandleFailure);
        }

        private Task HandleSuccess(string username, Report report, IMessageHandlerContext context)
        {
            var data = report.SerializeMessage();

            switch (report.Organization.OrganizationType)
            {
                case OrganizationType.Central:
                    return context.Publish<ICentralReportUpdated>(e =>
                    {
                        e.Username = username;
                        e.Organization = report.Organization;
                        e.CentralReport = report;
                        e.SerializedData = data;
                    });
                case OrganizationType.State:
                    return context.Publish<IStateReportUpdated>(e =>
                    {
                        e.Username = username;
                        e.Organization = report.Organization;
                        e.StateReport = report;
                        e.SerializedData = data;
                    });
                case OrganizationType.Zone:
                    return context.Publish<IZoneReportUpdated>(e =>
                    {
                        e.Username = username;
                        e.Organization = report.Organization;
                        e.ZoneReport = report;
                        e.SerializedData = data;
                    });
                default:
                    return context.Publish<IUnitReportUpdated>(e =>
                    {
                        e.Username = username;
                        e.Organization = report.Organization;
                        e.UnitReport = report;
                        e.SerializedData = data;
                    });
            }
        }

        private Task HandleFailure(string[] errors)
        {
            return Task.CompletedTask;
        }
    }
}