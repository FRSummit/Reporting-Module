using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace NsbWeb.ReportingModule.Common.ActionResults
{
    public class ExcelResult : IHttpActionResult
    {
        private byte[] _bytes;
        private string _filename;
        public ExcelResult(byte[] bytes,string filename)
        {
            _bytes = bytes ?? throw new ArgumentNullException(nameof(bytes));
            _filename = filename;
        }
        public System.Threading.Tasks.Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(_bytes)
            };
            response.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment")
                {
                    FileName = _filename
                };
            response.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            return System.Threading.Tasks.Task.FromResult(response);
        }
    }
}
