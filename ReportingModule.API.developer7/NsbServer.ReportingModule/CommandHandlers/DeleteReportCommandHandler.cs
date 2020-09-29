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
    public class DeleteReportCommandHandler : IHandleMessages<DeleteReportCommand>
    {
        private readonly ISession _session;

        public DeleteReportCommandHandler(ISession session)
        {
            _session = session;
        }

        

        public Task Handle(DeleteReportCommand message, IMessageHandlerContext context)
        {
            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<DeleteReportCommand, string>()
                .Bind(msg =>
                {
                    var report = _session.Query<Report>().Single(o => o.Id == msg.ReportId);
                    if (report!=null)
                    {
                        report.MarkAsDelete();
                        _session.Save(report);
                        return Result<Report, string[]>.Succeeded(report);
                    }

                    return Result<Report, string[]>.Failed(new[] { "Invalid report" });
                })
                .Handle(report => HandleSuccess(username, report, context), e => HandleFailure(e, context));
        }

        private Task HandleSuccess(string username, Report report, IMessageHandlerContext context)
        {
            var data = report.SerializeMessage();

            return context.Publish<IReportDeleted>(e =>
            {
                e.Username = username;
                e.Organization = report.Organization;
                e.Report = report;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IReportDeleteFailed>(e =>
            {
                e.Errors = errors;
            });
        }
    }
}