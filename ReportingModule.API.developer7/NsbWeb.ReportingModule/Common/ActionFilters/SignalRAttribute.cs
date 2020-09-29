using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ReportingModule.Core.Metadata;

namespace NsbWeb.ReportingModule.Common.ActionFilters
{
    public class SignalRAttribute : ActionFilterAttribute
    {
        private string _signalrCorrelationId;

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Headers.Contains(MetaDataConstants.SignalRConnectionId)) return;

            var connectionId = actionContext.Request.Headers.GetValues(MetaDataConstants.SignalRConnectionId).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(connectionId)) return;

            _signalrCorrelationId = Guid.NewGuid().ToString();
            actionContext.Request.Properties.Add(MetaDataConstants.SignalRCorrelationId, _signalrCorrelationId);

            Trace.TraceInformation($"{MetaDataConstants.SignalRCorrelationId}: {_signalrCorrelationId}.");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (_signalrCorrelationId == null || actionExecutedContext.Response == null) return;

            actionExecutedContext.Response.Headers.Add(MetaDataConstants.SignalRCorrelationId, _signalrCorrelationId);
            actionExecutedContext.Response.Content = new ObjectContent<string>(_signalrCorrelationId,
                new JsonMediaTypeFormatter());
        }
    }
}
