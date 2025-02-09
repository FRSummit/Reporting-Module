﻿using System.Threading.Tasks;
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
    public class UpdateCentralReportLastPeriodDataCommandHandler : IHandleMessages<UpdateCentralReportLastPeriodDataCommand>
    {
        private readonly ISession _session;

        public UpdateCentralReportLastPeriodDataCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(UpdateCentralReportLastPeriodDataCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<UpdateCentralReportLastPeriodDataCommand, string>()
                .Bind(msg =>
                    {
                        var centralReport = _session.Get<CentralReport>(msg.ReportId);
                        if (centralReport.ReportStatus >= ReportStatus.Draft)
                        {

                            centralReport.Update(message.LastPeriodUpdateData);
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
            return context.Publish<ICentralReportUpdateFailed>(e => { e.Errors = errors; });
        }
    }
}