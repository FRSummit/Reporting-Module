using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace NsbWeb.Core
{
    public class TextFileActionResult : IHttpActionResult
    {
        public TextFileActionResult()
        {
            
        }
        public TextFileActionResult(string fileName, string fileContent)
        {
            FileName = fileName;
            FileContent = fileContent;
        }

        public string FileName { get; }
        public string FileContent { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage {Content = new StringContent(FileContent)};
            response.Content.Headers.ContentDisposition
                = new ContentDispositionHeaderValue("attachment") { FileName = FileName };
            response.Content.Headers.ContentType
                = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength = FileContent.Length;

            return Task.FromResult(response);
        }
    }
}