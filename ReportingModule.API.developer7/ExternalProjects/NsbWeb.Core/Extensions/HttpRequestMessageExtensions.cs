using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NsbWeb.Core.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static async Task<HttpContent[]> GetFileContents(this HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await request.Content.ReadAsMultipartAsync(provider);

            return provider.Contents.ToArray();
        }
    }
}