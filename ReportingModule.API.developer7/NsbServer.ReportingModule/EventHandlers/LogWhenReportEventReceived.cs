using System.Threading.Tasks;
using NHibernate;
using NServiceBus;
using ReportingModule.Entities;
using ReportingModule.Events;
using ReportingModule.Utility;

namespace ReportingModule.EventHandlers
{
    public class LogWhenReportEventReceived : IHandleMessages<IUnitPlanCreated>,
        IHandleMessages<IUnitPlanCopied>,
        IHandleMessages<IUnitPlanUpdated>,
        IHandleMessages<IUnitPlanPromoted>,
        IHandleMessages<IUnitReportUpdated>,
        IHandleMessages<IReportSubmitted>,
        IHandleMessages<IReportUnSubmitted>,
        IHandleMessages<IStatePlanCreated>,
        IHandleMessages<IStatePlanCopied>,
        IHandleMessages<IStatePlanUpdated>,
        IHandleMessages<IStatePlanPromoted>,
        IHandleMessages<IStateReportUpdated>,
        IHandleMessages<ICentralPlanCreated>,
        IHandleMessages<ICentralPlanCopied>,
        IHandleMessages<ICentralPlanUpdated>,
        IHandleMessages<ICentralPlanPromoted>,
        IHandleMessages<ICentralReportUpdated>,
        IHandleMessages<IZonePlanCreated>,
        IHandleMessages<IZonePlanCopied>,
        IHandleMessages<IZonePlanUpdated>,
        IHandleMessages<IZonePlanPromoted>,
        IHandleMessages<IZoneReportUpdated>
    {
        private readonly ISession _session;

        public LogWhenReportEventReceived(ISession session)
        {
            _session = session;
        }

        private void Save(ReportEventLog log)
        {
            _session.Save(log);
        }
        public Task Handle(IReportSubmitted message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.Report.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IReportUnSubmitted message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.Report.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }

        public Task Handle(IUnitPlanCreated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.UnitReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IUnitPlanCopied message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.UnitReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IUnitPlanUpdated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.UnitReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IUnitPlanPromoted message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.UnitReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IUnitReportUpdated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.UnitReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }

        public Task Handle(IZonePlanCreated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.ZoneReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IZonePlanCopied message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.ZoneReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IZonePlanUpdated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.ZoneReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IZonePlanPromoted message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.ZoneReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IZoneReportUpdated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.ZoneReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }

        public Task Handle(IStatePlanCreated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.StateReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IStatePlanCopied message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.StateReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IStatePlanUpdated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.StateReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IStatePlanPromoted message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.StateReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(IStateReportUpdated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.StateReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }

        public Task Handle(ICentralPlanCreated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.CentralReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(ICentralPlanCopied message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.CentralReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(ICentralPlanUpdated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.CentralReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(ICentralPlanPromoted message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.CentralReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
        public Task Handle(ICentralReportUpdated message, IMessageHandlerContext context)
        {
            Save(new ReportEventLog(message.GetType().ToString(),
                message.SerializeMessage(),
                message.Organization.Id,
                message.CentralReport.Id,
                message.Username,
                ZaphodTime.UtcNow));
            return Task.CompletedTask;
        }
    }
}
