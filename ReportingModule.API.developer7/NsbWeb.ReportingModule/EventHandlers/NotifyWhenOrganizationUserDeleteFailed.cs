﻿using System.Threading.Tasks;
using NsbWeb.Core;
using NsbWeb.ReportingModule.SignalR;
using NServiceBus;
using ReportingModule.Events;

namespace NsbWeb.ReportingModule.EventHandlers
{
    public class NotifyWhenOrganizationUserDeleteFailed
        : IHandleMessages<IOrganizationUserDeleteFailed>
    {
        public Task Handle(IOrganizationUserDeleteFailed message, IMessageHandlerContext context)
        {
            var client = context.GetSignalRClientFromMessageContext<ReportingModuleHub>();
            client?.OrganizationUserDeleteFailed(message.Errors);
            return Task.CompletedTask;
        }
    }
}