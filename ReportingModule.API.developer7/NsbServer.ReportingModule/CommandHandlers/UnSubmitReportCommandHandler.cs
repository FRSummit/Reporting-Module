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
using ReportingModule.ValueObjects;

namespace ReportingModule.CommandHandlers
{
    public class UnSubmitReportCommandHandler : IHandleMessages<UnSubmitReportCommand>
    {
        private readonly ISession _session;
        public UnSubmitReportCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(UnSubmitReportCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<UnSubmitReportCommand, string>()
                .Bind(msg =>
                {
                    var report = _session.Query<Report>().Single(o => o.Id == msg.ReportId);
                    if (report.ReportStatus == ReportStatus.Draft)
                        return Result<Report, string[]>.Succeeded(report);
                    if (report.ReportStatus == ReportStatus.Submitted)
                    {
                        report.MarkStatusAsPlanPromoted();
                        _session.Save(report);
                        return Result<Report, string[]>.Succeeded(report);
                    }
                    if (report.ReportStatus == ReportStatus.PlanPromoted)
                    {
                        report.MarkStatusAsDraft();
                        _session.Save(report);
                        return Result<Report, string[]>.Succeeded(report);
                    }

                    return Result<Report, string[]>.Failed(new[] { "Invalid report status" });
                })
                .Handle(report => HandleSuccess(username, report, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, Report unitReport, IMessageHandlerContext context)
        {
            var data = unitReport.SerializeMessage();

            return context.Publish<IReportUnSubmitted>(e =>
            {
                e.Username = username;
                e.Organization = unitReport.Organization;
                e.Report = unitReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IReportUnSubmitFailed>(e =>
            {
                e.Errors = errors;
            });
        }
    }
}