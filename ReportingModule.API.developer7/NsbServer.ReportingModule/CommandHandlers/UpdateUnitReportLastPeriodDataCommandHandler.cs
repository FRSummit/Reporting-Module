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
    public class UpdateUnitReportLastPeriodDataCommandHandler : IHandleMessages<UpdateUnitReportLastPeriodDataCommand>
    {
        private readonly ISession _session;

        public UpdateUnitReportLastPeriodDataCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(UpdateUnitReportLastPeriodDataCommand message, IMessageHandlerContext context)
        {
            //Todo SK validate message description for uniqueness, detail for valid reporting items
            //validate Organization, Template and ReportingTerm

            var username = message.GetUsernameFromMetadata(context);

            return message.ToResult<UpdateUnitReportLastPeriodDataCommand, string>()
                .Bind(msg =>
                {
                    var unitReport = _session.Get<UnitReport>(msg.ReportId);
                    if (unitReport.ReportStatus >= ReportStatus.Draft)
                    {

                        unitReport.Update(message.LastPeriodUpdateData);
                        _session.Save(unitReport);
                        return Result<UnitReport, string[]>.Succeeded(unitReport);
                    }

                    return Result<UnitReport, string[]>.Failed(new[] { "Ïnvalid report status" });
                }
                )
                .Handle(unitReport => HandleSuccess(username,
                        unitReport, context), e => HandleFailure(e, context));
        }


        private Task HandleSuccess(string username, UnitReport unitReport, IMessageHandlerContext context)
        {
            var data = unitReport.SerializeMessage();

            return context.Publish<IUnitReportUpdated>(e =>
            {
                e.Username = username;
                e.Organization = unitReport.Organization;
                e.UnitReport = unitReport;
                e.SerializedData = data;
            });
        }

        private Task HandleFailure(string[] errors, IMessageHandlerContext context)
        {
            return context.Publish<IUnitReportUpdateFailed>(e => { e.Errors = errors; });
        }
    }
}