using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace NsbWeb.Core
{
    //https://stackoverflow.com/questions/21533022/web-api-2-download-file-using-async-taskihttpactionresult

    public class FileActionResult : IHttpActionResult
    {
        public FileActionResult()
        {
            
        }
        public FileActionResult(string fileName, byte[] fileContent, int fileLength)
        {
            FileName = fileName;
            FileContent = fileContent;
            FileLength = fileLength;
        }

        public string FileName { get; }
        public byte[] FileContent { get; }
        public int FileLength { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage {Content = new ByteArrayContent(FileContent)};
            response.Content.Headers.ContentDisposition
                = new ContentDispositionHeaderValue("attachment") { FileName = FileName };
            response.Content.Headers.ContentType
                = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength = FileLength;

            return Task.FromResult(response);
        }
    }
}
