using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NServiceBus;
using ReportingModule.Commands;
using ReportingModule.Entities;
using ReportingModule.Events;

namespace ReportingModule.EventHandlers
{
    public class UpdateReportWhenOrganizationUpdated : IHandleMessages<IOrganizationUpdated>
      
    {
        private readonly ISession _session;

        public UpdateReportWhenOrganizationUpdated(ISession session)
        {
            _session = session;
        }

        public Task Handle(IOrganizationUpdated message, IMessageHandlerContext context)
        {
            var tasks = new List<Task>();
            _session.Query<Report>()
                .Where(o => o.Organization.Id == message.Organization.Id).ToList()
                .ForEach(r =>
                {

                    var cmd = new UpdateReportCommand(r.Id, r.Description, message.Organization, r.ReportingPeriod.Year,
                        r.ReportingPeriod.ReportingTerm);
                    tasks.Add(context.Send(cmd));

                });
            return Task.WhenAll(tasks);
        }
    }
}