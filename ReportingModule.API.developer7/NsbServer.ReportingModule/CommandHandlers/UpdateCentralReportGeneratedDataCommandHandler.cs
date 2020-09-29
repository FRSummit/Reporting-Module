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
    public class UpdateCentralReportGeneratedDataCommandHandler : IHandleMessages<UpdateCentralReportGeneratedDataCommand>
    {
        private readonly ISession _session;
        private readonly ICentralReportService _centralReportService;
        public UpdateCentralReportGeneratedDataCommandHandler(ISession session, ICentralReportService centralReportService)
        {
            _session = session;
            _centralReportService = centralReportService;
        }

        public Task Handle(UpdateCentralReportGeneratedDataCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<UpdateCentralReportGeneratedDataCommand, string>()
                .Bind(msg =>
                    {
                        var centralReport = _session.Get<CentralReport>(msg.ReportId);
                        if (centralReport.ReportStatus >= ReportStatus.Draft)
                        {
                            var generatedData = _centralReportService.GetGeneratedData(centralReport.Organization.Id, centralReport.ReportingPeriod);
                            centralReport.UpdateGeneratedData(generatedData);
                            if (message.OverrideReportData)
                            {
                                centralReport.UpdatePlan(generatedData);
                                centralReport.Update(generatedData);
                            }

                            _session.Save(centralReport);
                            return Result<CentralReport, string[]>.Succeeded(centralReport);
                        }
                        return Result<CentralReport, string[]>.Failed(new[] { "Ïnvalid report status" });
                    }
                )
                .Handle(centralReport => HandleSuccess(username,
                        centralReport, context), e => HandleFailure(e, context));
        }


        private Task HandleSuccess(string username, CentralReport centralReport, IMessageHandlerContext context)
        {
            var data = centralReport.SerializeMessage();

            return context.Publish<ICentralReportUpdated>(e =>
            {
                e.Username = username;
                e.Organization = centralReport.Organization;
                e.CentralReport = centralReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<ICentralReportUpdateFailed>(e =>
            {
                e.Errors = errors;
            });
        }
    }
}