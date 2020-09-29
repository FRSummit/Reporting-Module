using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace NsbWeb.ReportingModule.Common
{
    public class AcceptedResult : IHttpActionResult
    {
        private HttpStatusCode statusCode = HttpStatusCode.Accepted;

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(statusCode));
        }
    }
}
