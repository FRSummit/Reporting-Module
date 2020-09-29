using System;
using System.Threading.Tasks;
using System.Web.Http;
using log4net;
using NsbWeb.Core;
using NsbWeb.ReportingModule.Common.ActionFilters;
using NsbWeb.ReportingModule.Common.Extensions;
using NServiceBus;
using ReportingModule.Commands;

namespace NsbWeb.ReportingModule.Controller
{
    public class PingPongController : ApiController
    {
        private const string V1 = "reporting/v1/ping/";
        private readonly ILog _log = LogManager.GetLogger(typeof(PingPongController));
        private readonly Func<IEndpointInstance> _endpointInstance;
        public PingPongController(Func<IEndpointInstance> endpointInstance)
        {
            _endpointInstance = endpointInstance;
        }

        [Route(V1)]
        [HttpPost]
        [SignalR]
        public async Task<IHttpActionResult> Ping([FromBody]string message)
        {
            try
            {
                var cmd = new PingCommand(message);
                await _endpointInstance().SendWithSignalRMetaData(cmd, Request);
                return this.Accepted();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return InternalServerError();
            }
        }


    }
}